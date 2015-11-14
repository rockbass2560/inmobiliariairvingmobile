using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Ionic.Zip;
using System.Windows.Forms;
using System.Configuration;

namespace ProcessData
{
    public class WordManager
    {
        private List<WordInfo> wordList;
        private String invitacionUri;
        private WordDateInfo wordDateInfo;
        private RichTextBox richText;

        private static readonly string FORMAT_DATE = ConfigurationManager.AppSettings["formatLetter"];
        private static readonly string FORMAT_HOUR_INITIAL = ConfigurationManager.AppSettings["formatHourInitial"];
        private static readonly string FORMAT_HOUR_FINAL = ConfigurationManager.AppSettings["formatHourFinal"];

        public WordManager(List<WordInfo> wl, String uri, WordDateInfo info)
        {
            wordList = wl;
            invitacionUri = uri;
            wordDateInfo = info;
        }

        private Dictionary<String, MemoryStream> ProcessTemplate()
        {
            MemoryStream plantillaStream = new MemoryStream();
            Dictionary<String, MemoryStream> listStream = new Dictionary<String, MemoryStream>();

            //Extraemos la plantilla
                //Se modifican las fechas una sola vez en la plantilla
            using (richText = new RichTextBox())
            {
                richText.LoadFile(invitacionUri);
                SearchAndReaplaceRTF("[[Fecha Invitacion]]", wordDateInfo.FechaInvitacion.ToString(FORMAT_DATE));
                SearchAndReaplaceRTF("[[Fecha Mediacion]]", wordDateInfo.FechaMediacion.ToString(FORMAT_DATE));
                SearchAndReaplaceRTF("[[Hora Mediacion]]", String.Format("{0} a {1}", wordDateInfo.HoraInicio.ToString(FORMAT_HOUR_INITIAL),
                        wordDateInfo.HoraFinal.ToString(FORMAT_HOUR_FINAL)));

                richText.SaveFile(plantillaStream, RichTextBoxStreamType.RichText);
            }

            foreach (WordInfo info in wordList)
            {
                MemoryStream memoryFile = new MemoryStream();

                using (richText = new RichTextBox())
                {
                    plantillaStream.Position = 0;
                    richText.LoadFile(plantillaStream, RichTextBoxStreamType.RichText);
                    SearchAndReaplaceRTF("[[NOMBRE]]", info.Nombre);
                    SearchAndReaplaceRTF("[[DIRECCION]]", info.DireccionCompleta);
                    SearchAndReaplaceRTF("[[CREDITO]]", info.Credito.ToString());

                    richText.SaveFile(memoryFile, RichTextBoxStreamType.RichText);
                }

                listStream.Add(info.Nombre, memoryFile);
            }

            return listStream;
        }

        private void SearchAndReaplaceRTF(string placeHolder, string newValue)
        {
            richText.Select(richText.Find(placeHolder), placeHolder.Length);
            richText.SelectedText = newValue;
        }

        public byte[] CreateResponse()
        {
            //Creamos la lista de stream a usar
            Dictionary<String,MemoryStream> listSream = ProcessTemplate();

            //Ahora creamos el archivo zip a partir del stream
            ZipFile zipFile = new ZipFile();
            foreach (KeyValuePair<String,MemoryStream> obj in listSream)
	        {
                ZipEntry entry = zipFile.AddEntry(obj.Key+".rtf", obj.Value.ToArray());                
	        }

            MemoryStream memoryStream = new MemoryStream();
            zipFile.Save(memoryStream);

            return memoryStream.ToArray();
        }
    }
}
