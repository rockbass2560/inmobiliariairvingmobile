using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlCasaWebControls
{
    [DefaultProperty("Campos")]
    [ToolboxData("<{0}:ComboColonia runat='server' Campos='ALL'></{0}:ComboColonia>")]
    public class ColoniaCombo : DropDownList
    {
        protected override object SaveViewState()
        {

            return base.SaveViewState();
        }

        [DefaultValue("ALL")]
        public string Campos
        {
            get
            {
                return ViewState["Campos"].ToString();
            }
            set
            {
                ViewState["Campos"] = value;
            }
        }

        protected override void RenderContents(HtmlTextWriter output)
        {
            output.Write(Text);
        }
    }
}
