using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class HourMinute : System.Web.UI.UserControl
{
    public string HoraInicial
    {
        get { return txtHoraInicio.Text; }
        set { txtHoraInicio.Text = value; }
    }
    public string MinutoFinal
    {
        get { return txtMinutoInicio.Text; }
        set { txtMinutoInicio.Text = value; }
    }
    public int IndexAMPM
    {
        get { return ddlAMPM.SelectedIndex; }
        set { ddlAMPM.SelectedIndex = value; }
    }
}
