using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace BookExamples
{
	/// <summary>
	/// Summary description for example5.
	/// </summary>
	public class example5 : System.Web.UI.Page
	{
    protected System.Web.UI.WebControls.DropDownList theDropDown;
    protected System.Web.UI.WebControls.ListBox theListBox;
  
		private void Page_Load(object sender, System.EventArgs e)
		{
      if (!IsPostBack)
      {
        // Bind the ListBox
        theListBox.DataSource = Session["customerTable"];
        theListBox.DataTextField = "FullName";
        theListBox.DataValueField = "CustomerID";
        theListBox.DataTextFormatString = "Name: {0}";

        // Bind the DropDown Control
        theDropDown.DataSource = Session["productTable"];
        theDropDown.DataTextField = "Description";
        theDropDown.DataValueField = "ProductID";

        // Make the Bind happen on all the controls
        DataBind();
      }
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
      this.Load += new System.EventHandler(this.Page_Load);

    }
		#endregion
	}
}
