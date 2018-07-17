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
using System.Data.SqlClient;


namespace BookExamples
{
	/// <summary>
	/// Summary description for example1.
	/// </summary>
	public class example1 : System.Web.UI.Page
	{
    protected System.Web.UI.WebControls.Label Label1;
    protected System.Web.UI.WebControls.TextBox theTextBox;
    protected DataTable productTable;

		private void Page_Load(object sender, System.EventArgs e)
		{
      // Get the ProductTable from  the Session State
      // so we can bind to it.
      productTable = Session["productTable"] as DataTable;

      // Force the Binding to occur
      // on the Data Binding that we created in the
      // ASP.NET Page
      // Or you could call DataBind() on the page to force all controls to 
      // data bind.
      theTextBox.DataBind();

      
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
