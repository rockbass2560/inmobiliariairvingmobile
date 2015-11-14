using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

/// <summary>
/// Descripción breve de Extensions
/// </summary>
public static class Extensions
{
    public static void AddClass(this HtmlControl control,string clase)
    {
        if (control.Attributes["class"] == null)
        {
            control.Attributes.Add("class", clase);
        }
        else
        {
            string claseCSS = control.Attributes["class"];
            claseCSS += " ui-disabled";
            control.Attributes["class"] = claseCSS;
        }
    }

    public static void BindCombo<T>(this DropDownList combo, List<T> lista)
    {
        combo.DataSource = lista;
        combo.DataTextField = "Descripcion";
        combo.DataValueField = "ID";
        combo.DataBind();
        combo.SelectedIndex = 0;
    }
    public static void SetValue(this DropDownList combo, object value)
    {
        combo.ClearSelection();
        combo.Items.FindByValue(value.ToString()).Selected = true;
    }
}
