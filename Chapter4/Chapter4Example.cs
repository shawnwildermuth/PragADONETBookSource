using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace BookExamples
{
    /// <summary>
    /// Summary description for Chapter4Example.
    /// </summary>
    public class Chapter4Example : System.Windows.Forms.Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
        private System.Windows.Forms.ComboBox cbCustomers;
        private System.Windows.Forms.ListView theView;
        private System.Windows.Forms.ColumnHeader InvoiceNumber;
        private System.Windows.Forms.ColumnHeader InvoiceDate;
        private System.Windows.Forms.ColumnHeader PO;
        private System.Windows.Forms.ColumnHeader FOB;
        private System.Windows.Forms.ColumnHeader Terms;
        private CustomerList customerList;

        public Chapter4Example()
        {
            // Required for Windows Form Designer support
            InitializeComponent();

            // Our Query
            string query = 
                "SELECT Customer.CustomerID, FirstName, LastName, HomePhone, " +
                "       Address, City, State, Zip, DOB, " +
                "       InvoiceNumber, InvoiceDate, FOB, PO, Terms " +
                "  FROM Customer " +
                "    JOIN Invoice on Customer.CustomerID = Invoice.CustomerID " +
                "  ORDER BY Customer.CustomerID, Invoice.InvoiceID ";

            // Attach to the database and execute the query
            try
            {
                SqlConnection conn = 
                    new SqlConnection("Server=localhost;Database=ADONET;Integrated Security=true;");
                conn.Open();

                // Make a new commmand for our query
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;

                // Get the DataReader
                SqlDataReader rdr = 
                    cmd.ExecuteReader(CommandBehavior.KeyInfo | 
                    CommandBehavior.CloseConnection);

                // Use the DataReader to construct our object model
                customerList = new CustomerList(rdr);

                // Clean up the DataReader, we are done with it
                rdr.Close();

                // Fill the combobox
                cbCustomers.Items.AddRange(customerList.ToArray());

                // Set the selected to the first item
                cbCustomers.SelectedIndex = 0;
            }
            catch (SqlException ex)
            {
                string err = "";
                foreach (SqlError error in ex.Errors)
                {
                    err += error.Message + "\n";
                }
                MessageBox.Show(err, ex.Message);
            }

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
            this.theView = new System.Windows.Forms.ListView();
            this.InvoiceNumber = new System.Windows.Forms.ColumnHeader();
            this.InvoiceDate = new System.Windows.Forms.ColumnHeader();
            this.PO = new System.Windows.Forms.ColumnHeader();
            this.FOB = new System.Windows.Forms.ColumnHeader();
            this.Terms = new System.Windows.Forms.ColumnHeader();
            this.cbCustomers = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // theView
            // 
            this.theView.CheckBoxes = true;
            this.theView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                                                                                      this.InvoiceNumber,
                                                                                      this.InvoiceDate,
                                                                                      this.PO,
                                                                                      this.FOB,
                                                                                      this.Terms});
            this.theView.FullRowSelect = true;
            this.theView.GridLines = true;
            this.theView.Location = new System.Drawing.Point(8, 32);
            this.theView.Name = "theView";
            this.theView.Size = new System.Drawing.Size(544, 416);
            this.theView.TabIndex = 0;
            this.theView.View = System.Windows.Forms.View.Details;
            // 
            // cbCustomers
            // 
            this.cbCustomers.Location = new System.Drawing.Point(8, 8);
            this.cbCustomers.Name = "cbCustomers";
            this.cbCustomers.Size = new System.Drawing.Size(544, 21);
            this.cbCustomers.TabIndex = 1;
            this.cbCustomers.SelectedIndexChanged += new System.EventHandler(this.cbCustomers_SelectedIndexChanged);
            // 
            // Chapter4Example
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(560, 454);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.cbCustomers,
                                                                          this.theView});
            this.Name = "Chapter4Example";
            this.Text = "Chapter4Example";
            this.ResumeLayout(false);

        }
		#endregion

        private void cbCustomers_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            theView.Items.Clear();

            Customer cust = (Customer) cbCustomers.SelectedItem;
      
            foreach (Invoice inv in cust.Invoices)
            {
                theView.Items.Add(new ListViewItem(inv.ToStringArray()));
            }
        }
        
        private static void Main()
        {
            Application.Run(new Chapter4Example());
        }

    }
}
