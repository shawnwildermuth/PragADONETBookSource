using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Reflection;
using System.IO;

namespace BookExamples
{
	/// <summary>
	/// Summary description for CreateDBDialog.
	/// </summary>
	public class CreateDBDialog : System.Windows.Forms.Form
	{
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.CheckBox IntSecCheck;
    private System.Windows.Forms.TextBox userID;
    private System.Windows.Forms.TextBox password;
    private System.Windows.Forms.Button btnOk;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox server;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CreateDBDialog()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
      this.btnOk = new System.Windows.Forms.Button();
      this.IntSecCheck = new System.Windows.Forms.CheckBox();
      this.label2 = new System.Windows.Forms.Label();
      this.userID = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.password = new System.Windows.Forms.TextBox();
      this.btnCancel = new System.Windows.Forms.Button();
      this.label4 = new System.Windows.Forms.Label();
      this.server = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // btnOk
      // 
      this.btnOk.Location = new System.Drawing.Point(208, 104);
      this.btnOk.Name = "btnOk";
      this.btnOk.TabIndex = 6;
      this.btnOk.Text = "&OK";
      this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
      // 
      // IntSecCheck
      // 
      this.IntSecCheck.Checked = true;
      this.IntSecCheck.CheckState = System.Windows.Forms.CheckState.Checked;
      this.IntSecCheck.Location = new System.Drawing.Point(104, 80);
      this.IntSecCheck.Name = "IntSecCheck";
      this.IntSecCheck.Size = new System.Drawing.Size(160, 16);
      this.IntSecCheck.TabIndex = 4;
      this.IntSecCheck.Text = "Use Integrated Security?";
      this.IntSecCheck.CheckedChanged += new System.EventHandler(this.IntSecCheck_CheckedChanged);
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(8, 32);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(96, 16);
      this.label2.TabIndex = 9;
      this.label2.Text = "User ID:";
      // 
      // userID
      // 
      this.userID.Enabled = false;
      this.userID.Location = new System.Drawing.Point(104, 32);
      this.userID.Name = "userID";
      this.userID.Size = new System.Drawing.Size(176, 20);
      this.userID.TabIndex = 2;
      this.userID.Text = "";
      // 
      // label3
      // 
      this.label3.Location = new System.Drawing.Point(8, 56);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(96, 16);
      this.label3.TabIndex = 10;
      this.label3.Text = "Password:";
      // 
      // password
      // 
      this.password.Enabled = false;
      this.password.Location = new System.Drawing.Point(104, 56);
      this.password.Name = "password";
      this.password.PasswordChar = '*';
      this.password.Size = new System.Drawing.Size(176, 20);
      this.password.TabIndex = 3;
      this.password.Text = "";
      // 
      // btnCancel
      // 
      this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btnCancel.Location = new System.Drawing.Point(128, 104);
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.TabIndex = 5;
      this.btnCancel.Text = "&Cancel";
      // 
      // label4
      // 
      this.label4.Location = new System.Drawing.Point(8, 8);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(96, 16);
      this.label4.TabIndex = 7;
      this.label4.Text = "Server:";
      // 
      // server
      // 
      this.server.Location = new System.Drawing.Point(104, 8);
      this.server.Name = "server";
      this.server.Size = new System.Drawing.Size(176, 20);
      this.server.TabIndex = 0;
      this.server.Text = "localhost";
      this.server.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
      // 
      // CreateDBDialog
      // 
      this.AcceptButton = this.btnOk;
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.CancelButton = this.btnCancel;
      this.ClientSize = new System.Drawing.Size(286, 129);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.label4,
                                                                  this.server,
                                                                  this.btnCancel,
                                                                  this.label3,
                                                                  this.password,
                                                                  this.label2,
                                                                  this.userID,
                                                                  this.IntSecCheck,
                                                                  this.btnOk});
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MaximumSize = new System.Drawing.Size(296, 160);
      this.MinimizeBox = false;
      this.MinimumSize = new System.Drawing.Size(296, 160);
      this.Name = "CreateDBDialog";
      this.ShowInTaskbar = false;
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Create Database";
      this.Load += new System.EventHandler(this.CreateDBDialog_Load);
      this.ResumeLayout(false);

    }
		#endregion

    private void CreateDBDialog_Load(object sender, System.EventArgs e)
    {
    
    }

    private void IntSecCheck_CheckedChanged(object sender, System.EventArgs e)
    {
      userID.Enabled = !IntSecCheck.Checked;
      password.Enabled = !IntSecCheck.Checked;
    }

    private void btnOk_Click(object sender, System.EventArgs e)
    {
      Cursor.Current = Cursors.WaitCursor;
      try
      {
        string connString = "server=" + server.Text + ";" +
          "database=master;";

        if (IntSecCheck.Checked)
        {
          connString += "Integrated Security=true;";
        }
        else
        {
          connString += "User ID=" + userID.Text + ";Password=" + password.Text + ";";
        }
        // Create and Open the Connection
        SqlConnection conn = new SqlConnection(connString);
        conn.Open();

        // Get the Document from the Assembly
        Assembly assembly = Assembly.GetExecutingAssembly();
        Stream stream = assembly.GetManifestResourceStream("BookExamples.ADONET.sql");
        Stream stream2 = assembly.GetManifestResourceStream("BookExamples.ADONET2.sql");
        StreamReader rdr = new StreamReader(stream);
        string sql = rdr.ReadToEnd();
        StreamReader rdr2 = new StreamReader(stream2);
        string sql2 = rdr2.ReadToEnd();

        // Execute the embedded SQL Doc
        SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.ExecuteNonQuery();
        
        // Execute the second embedded SQL Doc
        cmd.CommandText = sql2;
        cmd.ExecuteNonQuery();

        // Close
        conn.Close();     

        // Show the success
        MessageBox.Show("Database Created", "Pragmatic ADO.NET");
        
      }
      catch (SqlException ex)
      {
        MessageBox.Show(String.Format("Sql Error: {0}", ex.Message), "Pragmatic ADO.NET");
        Cursor.Current = Cursors.Arrow;
        return;
      }
            
      this.Close();
    }

    private void textBox1_TextChanged(object sender, System.EventArgs e)
    {
    
    }
	}
}
