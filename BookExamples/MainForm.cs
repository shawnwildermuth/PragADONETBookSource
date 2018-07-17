using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;
using System.Reflection;
using System.IO;
using System.Data.SqlClient;

namespace BookExamples
{
  /// <summary>
  /// Summary description for Form1.
  /// </summary>
  public class MainForm : System.Windows.Forms.Form
  {
    #region Private Members
    private System.Windows.Forms.MainMenu mainMenu1;
    private System.Windows.Forms.MenuItem menuItem1;
    private System.Windows.Forms.MenuItem menuItem3;
    private System.Windows.Forms.MenuItem menuItem4;
    private System.Windows.Forms.MenuItem menuItem5;
    private System.Windows.Forms.MenuItem menuItem6;
    private System.Windows.Forms.MenuItem menuItem7;
    private System.Windows.Forms.MenuItem menuItem9;
    private System.Windows.Forms.MenuItem menuItem10;
    private System.Windows.Forms.MenuItem menuItem11;
    private System.Windows.Forms.MenuItem menuItem12;
    private System.Windows.Forms.TabControl theTabCtrl;
    private System.Windows.Forms.TabPage pageGrid;
    private System.Windows.Forms.TabPage pageOutput;
    private System.Windows.Forms.DataGrid theGrid;
    private Chapter1  ch1  = new Chapter1();
    private Chapter2  ch2  = new Chapter2();
    private Chapter3  ch3  = new Chapter3();
    private Chapter4  ch4  = new Chapter4();
    private Chapter5  ch5  = new Chapter5();
    private Chapter6  ch6  = new Chapter6();
    private Chapter7  ch7  = new Chapter7();
    private Chapter8  ch8  = new Chapter8();
    private Chapter9  ch9  = new Chapter9();
    private Chapter10 ch10 = new Chapter10();
    private Appendix appendix = new Appendix();
    private System.Windows.Forms.MenuItem menuCh5Ex1;
    private System.Windows.Forms.MenuItem menuItem8;
    private System.Windows.Forms.MenuItem menuCreateDB;
    private System.Windows.Forms.MenuItem menuExit;
    private System.Windows.Forms.MenuItem menuCh5Ex2;
    private System.Windows.Forms.MenuItem menuCh5Ex3;
    private System.Windows.Forms.MenuItem menuCh5Ex4;
    private System.Windows.Forms.MenuItem menuCh5Ex5;
    private System.Windows.Forms.MenuItem menuCh5Ex6;
    private System.Windows.Forms.MenuItem menuCh5Ex7;
    private System.Windows.Forms.MenuItem menuCh5Ex8;
    private System.Windows.Forms.MenuItem menuCh5Ex9;
    private System.Windows.Forms.MenuItem menuCh5Ex10;
    private System.Windows.Forms.MenuItem menuCh5Ex11;
    private System.Windows.Forms.MenuItem menuCh5Ex12;
    private System.Windows.Forms.MenuItem menuCh5Ex13;
    private System.Windows.Forms.MenuItem menuCh5Ex14;
    private System.Windows.Forms.MenuItem menuCh5Ex15;
    private System.Windows.Forms.MenuItem menuCh5Ex16;
    private System.Windows.Forms.TextBox textOutput;
    private System.Windows.Forms.MenuItem menuCh5Ex17;
    private System.Windows.Forms.MenuItem menuItem2;
    private System.Windows.Forms.MenuItem menuItem13;
    private System.Windows.Forms.MenuItem menuCh5Ex18;
    private System.Windows.Forms.MenuItem menuCh5Ex19;
    private System.Windows.Forms.MenuItem menuCh5Ex20;
    private System.Windows.Forms.MenuItem menuCh6Ex1;
    private System.Windows.Forms.MenuItem menuCh6Ex2;
    private System.Windows.Forms.MenuItem menuCh7Ex1;
    private System.Windows.Forms.MenuItem menuCh7Ex2;
    private System.Windows.Forms.MenuItem menuCh7Ex3;
    private System.Windows.Forms.MenuItem menuCh7Ex4;
    private System.Windows.Forms.MenuItem menuCh7Ex5;
    private System.Windows.Forms.MenuItem menuCh7Ex6;
    private System.Windows.Forms.MenuItem menuCh7Ex7;
    private System.Windows.Forms.MenuItem menuCh7Ex8;
    private System.Windows.Forms.MenuItem menuCh7Ex9;
    private System.Windows.Forms.MenuItem menuCh7Ex10;
    private System.Windows.Forms.MenuItem menuCh7Ex11;
    private System.Windows.Forms.MenuItem menuCh7Ex12;
    private System.Windows.Forms.MenuItem menuCh7Ex13;
    private System.Windows.Forms.MenuItem menuCh7Ex14;
    private System.Windows.Forms.MenuItem menuCh7Ex15;
    private System.Windows.Forms.MenuItem menuCh8Ex1;
    private System.Windows.Forms.MenuItem menuCh8Ex2;
    private System.Windows.Forms.MenuItem menuCh8Ex3;
    private System.Windows.Forms.MenuItem menuCh8Ex4;
    private System.Windows.Forms.MenuItem menuCh8Ex5;
    private System.Windows.Forms.MenuItem menuItem14;
    private System.Windows.Forms.MenuItem menuCh8Ex6;
    private System.Windows.Forms.MenuItem menuCh8Ex7;
    private System.Windows.Forms.MenuItem menuCh8Ex8;
    private System.Windows.Forms.MenuItem menuCh8Ex9;
    private System.Windows.Forms.MenuItem menuCh8Ex10;
    private System.Windows.Forms.MenuItem menuCh8Ex11;
    private System.Windows.Forms.MenuItem menuCh8Ex12;
    private System.Windows.Forms.MenuItem menuCh1Ex2;
    private System.Windows.Forms.MenuItem menuCh1Ex3;
    private System.Windows.Forms.MenuItem menuCh1Ex4;
    private System.Windows.Forms.MenuItem menuCh1Ex5;
    private System.Windows.Forms.MenuItem menuCh1Ex6;
    private System.Windows.Forms.MenuItem menuCh8Ex13;
    private System.Windows.Forms.MenuItem menuCh9Ex1;
    private System.Windows.Forms.MenuItem menuCh9Ex2;
    private System.Windows.Forms.MenuItem menuCh9Ex3;
    private System.Windows.Forms.MenuItem menuCh9Ex4;
    private System.Windows.Forms.MenuItem menuCh9Ex5;
    private System.Windows.Forms.MenuItem menuCh9Ex6;
    private System.Windows.Forms.MenuItem menuCh9Ex7;
    private System.Windows.Forms.MenuItem menuCh9Ex8;
    private System.Windows.Forms.MenuItem menuCh9Ex9;
    private System.Windows.Forms.MenuItem menuCh9Ex10;
    private System.Windows.Forms.MenuItem menuCh9Ex11;
    private System.Windows.Forms.MenuItem menuCh9Ex12;
    private System.Windows.Forms.MenuItem menuCh9Ex13;
    private System.Windows.Forms.MenuItem menuCh9Ex14;
    private System.Windows.Forms.MenuItem menuCh9Ex15;
    private System.Windows.Forms.MenuItem menuCh9Ex16;
    private System.Windows.Forms.MenuItem menuCh10;
    private System.Windows.Forms.MenuItem menuCh4ExDlg;
    private System.Windows.Forms.MenuItem menuCh5Ex21;
    private System.Windows.Forms.MenuItem menuCh4Ex11;
    private System.Windows.Forms.MenuItem menuCh5Ex22;
    private System.Windows.Forms.MenuItem menuCh5Ex23;
    private System.Windows.Forms.MenuItem menuCh5Ex24;
    private System.Windows.Forms.MenuItem menuCh5Ex25;
    private System.Windows.Forms.MenuItem menuInvoiceLister;
    private System.Windows.Forms.MenuItem menuCh6Ex3;
    private System.Windows.Forms.MenuItem menuCh6Ex4;
    private System.Windows.Forms.MenuItem menuCh6Ex5;
    private System.Windows.Forms.MenuItem menuCh7Ex16;
    private System.Windows.Forms.MenuItem menuCh7Ex17;
    private System.Windows.Forms.MenuItem menuCh1Ex7;
    private System.Windows.Forms.MenuItem menuCh1Ex8;
    private System.Windows.Forms.MenuItem menuCh2Ex1;
    private System.Windows.Forms.MenuItem menuCh2Ex2;
    private System.Windows.Forms.MenuItem menuCh2Ex3;
    private System.Windows.Forms.MenuItem menuCh2Ex5;
    private System.Windows.Forms.MenuItem menuCh2Ex9;
    private System.Windows.Forms.MenuItem menuCh2Ex10;
    private System.Windows.Forms.MenuItem menuCh2Ex11;
    private System.Windows.Forms.MenuItem menuCh2Ex12;
    private System.Windows.Forms.MenuItem menuCh3Ex1;
    private System.Windows.Forms.MenuItem menuCh3Ex2;
    private System.Windows.Forms.MenuItem menuCh3Ex3;
    private System.Windows.Forms.MenuItem menuCh3Ex4;
    private System.Windows.Forms.MenuItem menuCh3Ex5;
    private System.Windows.Forms.MenuItem menuCh3Ex6;
    private System.Windows.Forms.MenuItem menuCh3Ex7;
    private System.Windows.Forms.MenuItem menuCh3Ex9;
    private System.Windows.Forms.MenuItem menuCh3Ex10;
    private System.Windows.Forms.MenuItem menuCh3Ex11;
    private System.Windows.Forms.MenuItem menuCh3Ex12;
    private System.Windows.Forms.MenuItem menuCh3Ex13;
    private System.Windows.Forms.MenuItem menuCh3Ex15;
    private System.Windows.Forms.MenuItem menuCh3Ex16;
    private System.Windows.Forms.MenuItem menuCh3Ex17;
    private System.Windows.Forms.MenuItem menuCh3Ex18;
    private System.Windows.Forms.MenuItem menuCh3Ex19;
    private System.Windows.Forms.MenuItem menuCh4Ex1;
    private System.Windows.Forms.MenuItem menuCh4Ex2;
    private System.Windows.Forms.MenuItem menuCh4Ex3;
    private System.Windows.Forms.MenuItem menuCh4Ex4;
    private System.Windows.Forms.MenuItem menuCh4Ex5;
    private System.Windows.Forms.MenuItem menuCh4Ex6;
    private System.Windows.Forms.MenuItem menuCh4Ex10;
    private System.Windows.Forms.MenuItem menuCh4Ex12;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.Container components = null;
    #endregion

    public MainForm()
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
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main() 
    {
      Application.Run(new MainForm());
    }

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>

    private void MainForm_Load(object sender, System.EventArgs e)
    {
    }

    protected override void Dispose( bool disposing )
    {
      if( disposing )
      {
        if (components != null) 
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
      this.mainMenu1 = new System.Windows.Forms.MainMenu();
      this.menuItem1 = new System.Windows.Forms.MenuItem();
      this.menuCreateDB = new System.Windows.Forms.MenuItem();
      this.menuItem8 = new System.Windows.Forms.MenuItem();
      this.menuExit = new System.Windows.Forms.MenuItem();
      this.menuItem3 = new System.Windows.Forms.MenuItem();
      this.menuCh1Ex2 = new System.Windows.Forms.MenuItem();
      this.menuCh1Ex3 = new System.Windows.Forms.MenuItem();
      this.menuCh1Ex4 = new System.Windows.Forms.MenuItem();
      this.menuCh1Ex5 = new System.Windows.Forms.MenuItem();
      this.menuCh1Ex6 = new System.Windows.Forms.MenuItem();
      this.menuCh1Ex7 = new System.Windows.Forms.MenuItem();
      this.menuCh1Ex8 = new System.Windows.Forms.MenuItem();
      this.menuItem4 = new System.Windows.Forms.MenuItem();
      this.menuCh2Ex1 = new System.Windows.Forms.MenuItem();
      this.menuCh2Ex2 = new System.Windows.Forms.MenuItem();
      this.menuCh2Ex3 = new System.Windows.Forms.MenuItem();
      this.menuCh2Ex5 = new System.Windows.Forms.MenuItem();
      this.menuCh2Ex9 = new System.Windows.Forms.MenuItem();
      this.menuCh2Ex10 = new System.Windows.Forms.MenuItem();
      this.menuCh2Ex11 = new System.Windows.Forms.MenuItem();
      this.menuCh2Ex12 = new System.Windows.Forms.MenuItem();
      this.menuItem5 = new System.Windows.Forms.MenuItem();
      this.menuCh3Ex1 = new System.Windows.Forms.MenuItem();
      this.menuCh3Ex2 = new System.Windows.Forms.MenuItem();
      this.menuCh3Ex3 = new System.Windows.Forms.MenuItem();
      this.menuCh3Ex4 = new System.Windows.Forms.MenuItem();
      this.menuCh3Ex5 = new System.Windows.Forms.MenuItem();
      this.menuCh3Ex6 = new System.Windows.Forms.MenuItem();
      this.menuCh3Ex7 = new System.Windows.Forms.MenuItem();
      this.menuCh3Ex9 = new System.Windows.Forms.MenuItem();
      this.menuCh3Ex10 = new System.Windows.Forms.MenuItem();
      this.menuCh3Ex11 = new System.Windows.Forms.MenuItem();
      this.menuCh3Ex12 = new System.Windows.Forms.MenuItem();
      this.menuCh3Ex13 = new System.Windows.Forms.MenuItem();
      this.menuCh3Ex15 = new System.Windows.Forms.MenuItem();
      this.menuCh3Ex16 = new System.Windows.Forms.MenuItem();
      this.menuCh3Ex17 = new System.Windows.Forms.MenuItem();
      this.menuCh3Ex18 = new System.Windows.Forms.MenuItem();
      this.menuCh3Ex19 = new System.Windows.Forms.MenuItem();
      this.menuItem6 = new System.Windows.Forms.MenuItem();
      this.menuCh4Ex1 = new System.Windows.Forms.MenuItem();
      this.menuCh4Ex2 = new System.Windows.Forms.MenuItem();
      this.menuCh4Ex3 = new System.Windows.Forms.MenuItem();
      this.menuCh4ExDlg = new System.Windows.Forms.MenuItem();
      this.menuCh4Ex11 = new System.Windows.Forms.MenuItem();
      this.menuItem7 = new System.Windows.Forms.MenuItem();
      this.menuCh5Ex1 = new System.Windows.Forms.MenuItem();
      this.menuCh5Ex2 = new System.Windows.Forms.MenuItem();
      this.menuCh5Ex3 = new System.Windows.Forms.MenuItem();
      this.menuCh5Ex4 = new System.Windows.Forms.MenuItem();
      this.menuCh5Ex5 = new System.Windows.Forms.MenuItem();
      this.menuCh5Ex6 = new System.Windows.Forms.MenuItem();
      this.menuCh5Ex7 = new System.Windows.Forms.MenuItem();
      this.menuCh5Ex8 = new System.Windows.Forms.MenuItem();
      this.menuCh5Ex9 = new System.Windows.Forms.MenuItem();
      this.menuCh5Ex10 = new System.Windows.Forms.MenuItem();
      this.menuCh5Ex11 = new System.Windows.Forms.MenuItem();
      this.menuCh5Ex12 = new System.Windows.Forms.MenuItem();
      this.menuCh5Ex13 = new System.Windows.Forms.MenuItem();
      this.menuCh5Ex14 = new System.Windows.Forms.MenuItem();
      this.menuCh5Ex15 = new System.Windows.Forms.MenuItem();
      this.menuCh5Ex16 = new System.Windows.Forms.MenuItem();
      this.menuCh5Ex17 = new System.Windows.Forms.MenuItem();
      this.menuCh5Ex18 = new System.Windows.Forms.MenuItem();
      this.menuCh5Ex19 = new System.Windows.Forms.MenuItem();
      this.menuCh5Ex20 = new System.Windows.Forms.MenuItem();
      this.menuCh5Ex21 = new System.Windows.Forms.MenuItem();
      this.menuCh5Ex22 = new System.Windows.Forms.MenuItem();
      this.menuCh5Ex23 = new System.Windows.Forms.MenuItem();
      this.menuCh5Ex24 = new System.Windows.Forms.MenuItem();
      this.menuCh5Ex25 = new System.Windows.Forms.MenuItem();
      this.menuInvoiceLister = new System.Windows.Forms.MenuItem();
      this.menuItem9 = new System.Windows.Forms.MenuItem();
      this.menuCh6Ex1 = new System.Windows.Forms.MenuItem();
      this.menuCh6Ex2 = new System.Windows.Forms.MenuItem();
      this.menuCh6Ex3 = new System.Windows.Forms.MenuItem();
      this.menuCh6Ex4 = new System.Windows.Forms.MenuItem();
      this.menuCh6Ex5 = new System.Windows.Forms.MenuItem();
      this.menuItem10 = new System.Windows.Forms.MenuItem();
      this.menuCh7Ex1 = new System.Windows.Forms.MenuItem();
      this.menuCh7Ex2 = new System.Windows.Forms.MenuItem();
      this.menuCh7Ex3 = new System.Windows.Forms.MenuItem();
      this.menuCh7Ex4 = new System.Windows.Forms.MenuItem();
      this.menuCh7Ex5 = new System.Windows.Forms.MenuItem();
      this.menuCh7Ex6 = new System.Windows.Forms.MenuItem();
      this.menuCh7Ex7 = new System.Windows.Forms.MenuItem();
      this.menuCh7Ex8 = new System.Windows.Forms.MenuItem();
      this.menuCh7Ex9 = new System.Windows.Forms.MenuItem();
      this.menuCh7Ex10 = new System.Windows.Forms.MenuItem();
      this.menuCh7Ex11 = new System.Windows.Forms.MenuItem();
      this.menuCh7Ex12 = new System.Windows.Forms.MenuItem();
      this.menuCh7Ex13 = new System.Windows.Forms.MenuItem();
      this.menuCh7Ex14 = new System.Windows.Forms.MenuItem();
      this.menuCh7Ex15 = new System.Windows.Forms.MenuItem();
      this.menuCh7Ex16 = new System.Windows.Forms.MenuItem();
      this.menuCh7Ex17 = new System.Windows.Forms.MenuItem();
      this.menuItem11 = new System.Windows.Forms.MenuItem();
      this.menuCh8Ex1 = new System.Windows.Forms.MenuItem();
      this.menuCh8Ex2 = new System.Windows.Forms.MenuItem();
      this.menuCh8Ex3 = new System.Windows.Forms.MenuItem();
      this.menuCh8Ex4 = new System.Windows.Forms.MenuItem();
      this.menuCh8Ex5 = new System.Windows.Forms.MenuItem();
      this.menuCh8Ex6 = new System.Windows.Forms.MenuItem();
      this.menuCh8Ex7 = new System.Windows.Forms.MenuItem();
      this.menuCh8Ex8 = new System.Windows.Forms.MenuItem();
      this.menuCh8Ex9 = new System.Windows.Forms.MenuItem();
      this.menuCh8Ex10 = new System.Windows.Forms.MenuItem();
      this.menuCh8Ex11 = new System.Windows.Forms.MenuItem();
      this.menuCh8Ex12 = new System.Windows.Forms.MenuItem();
      this.menuCh8Ex13 = new System.Windows.Forms.MenuItem();
      this.menuItem2 = new System.Windows.Forms.MenuItem();
      this.menuCh9Ex1 = new System.Windows.Forms.MenuItem();
      this.menuCh9Ex2 = new System.Windows.Forms.MenuItem();
      this.menuCh9Ex3 = new System.Windows.Forms.MenuItem();
      this.menuCh9Ex4 = new System.Windows.Forms.MenuItem();
      this.menuCh9Ex5 = new System.Windows.Forms.MenuItem();
      this.menuCh9Ex6 = new System.Windows.Forms.MenuItem();
      this.menuCh9Ex7 = new System.Windows.Forms.MenuItem();
      this.menuCh9Ex8 = new System.Windows.Forms.MenuItem();
      this.menuCh9Ex9 = new System.Windows.Forms.MenuItem();
      this.menuCh9Ex10 = new System.Windows.Forms.MenuItem();
      this.menuCh9Ex11 = new System.Windows.Forms.MenuItem();
      this.menuCh9Ex12 = new System.Windows.Forms.MenuItem();
      this.menuCh9Ex13 = new System.Windows.Forms.MenuItem();
      this.menuCh9Ex14 = new System.Windows.Forms.MenuItem();
      this.menuCh9Ex15 = new System.Windows.Forms.MenuItem();
      this.menuCh9Ex16 = new System.Windows.Forms.MenuItem();
      this.menuItem13 = new System.Windows.Forms.MenuItem();
      this.menuCh10 = new System.Windows.Forms.MenuItem();
      this.menuItem14 = new System.Windows.Forms.MenuItem();
      this.menuItem12 = new System.Windows.Forms.MenuItem();
      this.theTabCtrl = new System.Windows.Forms.TabControl();
      this.pageOutput = new System.Windows.Forms.TabPage();
      this.textOutput = new System.Windows.Forms.TextBox();
      this.pageGrid = new System.Windows.Forms.TabPage();
      this.theGrid = new System.Windows.Forms.DataGrid();
      this.menuCh4Ex4 = new System.Windows.Forms.MenuItem();
      this.menuCh4Ex5 = new System.Windows.Forms.MenuItem();
      this.menuCh4Ex6 = new System.Windows.Forms.MenuItem();
      this.menuCh4Ex10 = new System.Windows.Forms.MenuItem();
      this.menuCh4Ex12 = new System.Windows.Forms.MenuItem();
      this.theTabCtrl.SuspendLayout();
      this.pageOutput.SuspendLayout();
      this.pageGrid.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.theGrid)).BeginInit();
      this.SuspendLayout();
      // 
      // mainMenu1
      // 
      this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                              this.menuItem1,
                                                                              this.menuItem3,
                                                                              this.menuItem4,
                                                                              this.menuItem5,
                                                                              this.menuItem6,
                                                                              this.menuItem7,
                                                                              this.menuItem9,
                                                                              this.menuItem10,
                                                                              this.menuItem11,
                                                                              this.menuItem2,
                                                                              this.menuItem13,
                                                                              this.menuItem14,
                                                                              this.menuItem12});
      // 
      // menuItem1
      // 
      this.menuItem1.Index = 0;
      this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                              this.menuCreateDB,
                                                                              this.menuItem8,
                                                                              this.menuExit});
      this.menuItem1.Text = "&File";
      // 
      // menuCreateDB
      // 
      this.menuCreateDB.Index = 0;
      this.menuCreateDB.Text = "&Create Database";
      this.menuCreateDB.Click += new System.EventHandler(this.menuCreateDB_Click);
      // 
      // menuItem8
      // 
      this.menuItem8.Index = 1;
      this.menuItem8.Text = "-";
      // 
      // menuExit
      // 
      this.menuExit.Index = 2;
      this.menuExit.Text = "E&xit";
      this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
      // 
      // menuItem3
      // 
      this.menuItem3.Index = 1;
      this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                              this.menuCh1Ex2,
                                                                              this.menuCh1Ex3,
                                                                              this.menuCh1Ex4,
                                                                              this.menuCh1Ex5,
                                                                              this.menuCh1Ex6,
                                                                              this.menuCh1Ex7,
                                                                              this.menuCh1Ex8});
      this.menuItem3.Text = "Ch &1";
      // 
      // menuCh1Ex2
      // 
      this.menuCh1Ex2.Index = 0;
      this.menuCh1Ex2.Text = "Listing 1.2";
      this.menuCh1Ex2.Click += new System.EventHandler(this.menuCh1Ex2_Click);
      // 
      // menuCh1Ex3
      // 
      this.menuCh1Ex3.Index = 1;
      this.menuCh1Ex3.Text = "Listing 1.3";
      this.menuCh1Ex3.Click += new System.EventHandler(this.menuCh1Ex3_Click);
      // 
      // menuCh1Ex4
      // 
      this.menuCh1Ex4.Index = 2;
      this.menuCh1Ex4.Text = "Listing 1.4";
      this.menuCh1Ex4.Click += new System.EventHandler(this.menuCh1Ex4_Click);
      // 
      // menuCh1Ex5
      // 
      this.menuCh1Ex5.Index = 3;
      this.menuCh1Ex5.Text = "Listing 1.5";
      this.menuCh1Ex5.Click += new System.EventHandler(this.menuCh1Ex5_Click);
      // 
      // menuCh1Ex6
      // 
      this.menuCh1Ex6.Index = 4;
      this.menuCh1Ex6.Text = "Listing 1.6";
      this.menuCh1Ex6.Click += new System.EventHandler(this.menuCh1Ex6_Click);
      // 
      // menuCh1Ex7
      // 
      this.menuCh1Ex7.Index = 5;
      this.menuCh1Ex7.Text = "Listing 1.7";
      this.menuCh1Ex7.Click += new System.EventHandler(this.menuCh1Ex7_Click);
      // 
      // menuCh1Ex8
      // 
      this.menuCh1Ex8.Index = 6;
      this.menuCh1Ex8.Text = "Listing 1.8";
      this.menuCh1Ex8.Click += new System.EventHandler(this.menuCh1Ex8_Click);
      // 
      // menuItem4
      // 
      this.menuItem4.Index = 2;
      this.menuItem4.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                              this.menuCh2Ex1,
                                                                              this.menuCh2Ex2,
                                                                              this.menuCh2Ex3,
                                                                              this.menuCh2Ex5,
                                                                              this.menuCh2Ex9,
                                                                              this.menuCh2Ex10,
                                                                              this.menuCh2Ex11,
                                                                              this.menuCh2Ex12});
      this.menuItem4.Text = "Ch &2";
      // 
      // menuCh2Ex1
      // 
      this.menuCh2Ex1.Index = 0;
      this.menuCh2Ex1.Text = "Listing 2.1";
      this.menuCh2Ex1.Click += new System.EventHandler(this.menuCh2Ex1_Click);
      // 
      // menuCh2Ex2
      // 
      this.menuCh2Ex2.Index = 1;
      this.menuCh2Ex2.Text = "Listing 2.2";
      this.menuCh2Ex2.Click += new System.EventHandler(this.menuCh2Ex2_Click);
      // 
      // menuCh2Ex3
      // 
      this.menuCh2Ex3.Index = 2;
      this.menuCh2Ex3.Text = "Listing 2.3";
      this.menuCh2Ex3.Click += new System.EventHandler(this.menuCh2Ex3_Click);
      // 
      // menuCh2Ex5
      // 
      this.menuCh2Ex5.Index = 3;
      this.menuCh2Ex5.Text = "Listing 2.5";
      this.menuCh2Ex5.Click += new System.EventHandler(this.menuCh2Ex5_Click);
      // 
      // menuCh2Ex9
      // 
      this.menuCh2Ex9.Index = 4;
      this.menuCh2Ex9.Text = "Listing 2.9";
      this.menuCh2Ex9.Click += new System.EventHandler(this.menuCh2Ex9_Click);
      // 
      // menuCh2Ex10
      // 
      this.menuCh2Ex10.Index = 5;
      this.menuCh2Ex10.Text = "Listing 2.10";
      this.menuCh2Ex10.Click += new System.EventHandler(this.menuCh2Ex10_Click);
      // 
      // menuCh2Ex11
      // 
      this.menuCh2Ex11.Index = 6;
      this.menuCh2Ex11.Text = "Listing 2.11";
      this.menuCh2Ex11.Click += new System.EventHandler(this.menuCh2Ex11_Click);
      // 
      // menuCh2Ex12
      // 
      this.menuCh2Ex12.Index = 7;
      this.menuCh2Ex12.Text = "Listing 2.12";
      this.menuCh2Ex12.Click += new System.EventHandler(this.menuCh2Ex12_Click);
      // 
      // menuItem5
      // 
      this.menuItem5.Index = 3;
      this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                              this.menuCh3Ex1,
                                                                              this.menuCh3Ex2,
                                                                              this.menuCh3Ex3,
                                                                              this.menuCh3Ex4,
                                                                              this.menuCh3Ex5,
                                                                              this.menuCh3Ex6,
                                                                              this.menuCh3Ex7,
                                                                              this.menuCh3Ex9,
                                                                              this.menuCh3Ex10,
                                                                              this.menuCh3Ex11,
                                                                              this.menuCh3Ex12,
                                                                              this.menuCh3Ex13,
                                                                              this.menuCh3Ex15,
                                                                              this.menuCh3Ex16,
                                                                              this.menuCh3Ex17,
                                                                              this.menuCh3Ex18,
                                                                              this.menuCh3Ex19});
      this.menuItem5.Text = "Ch &3";
      // 
      // menuCh3Ex1
      // 
      this.menuCh3Ex1.Index = 0;
      this.menuCh3Ex1.Text = "Listing 3.1";
      this.menuCh3Ex1.Click += new System.EventHandler(this.menuCh3Ex1_Click);
      // 
      // menuCh3Ex2
      // 
      this.menuCh3Ex2.Index = 1;
      this.menuCh3Ex2.Text = "Listing 3.2";
      this.menuCh3Ex2.Click += new System.EventHandler(this.menuCh3Ex2_Click);
      // 
      // menuCh3Ex3
      // 
      this.menuCh3Ex3.Index = 2;
      this.menuCh3Ex3.Text = "Listing 3.3";
      this.menuCh3Ex3.Click += new System.EventHandler(this.menuCh3Ex3_Click);
      // 
      // menuCh3Ex4
      // 
      this.menuCh3Ex4.Index = 3;
      this.menuCh3Ex4.Text = "Listing 3.4";
      this.menuCh3Ex4.Click += new System.EventHandler(this.menuCh3Ex4_Click);
      // 
      // menuCh3Ex5
      // 
      this.menuCh3Ex5.Index = 4;
      this.menuCh3Ex5.Text = "Listing 3.5";
      this.menuCh3Ex5.Click += new System.EventHandler(this.menuCh3Ex5_Click);
      // 
      // menuCh3Ex6
      // 
      this.menuCh3Ex6.Index = 5;
      this.menuCh3Ex6.Text = "Listing 3.6";
      this.menuCh3Ex6.Click += new System.EventHandler(this.menuCh3Ex6_Click);
      // 
      // menuCh3Ex7
      // 
      this.menuCh3Ex7.Index = 6;
      this.menuCh3Ex7.Text = "Listing 3.7";
      this.menuCh3Ex7.Click += new System.EventHandler(this.menuCh3Ex7_Click);
      // 
      // menuCh3Ex9
      // 
      this.menuCh3Ex9.Index = 7;
      this.menuCh3Ex9.Text = "Listing 3.9";
      this.menuCh3Ex9.Click += new System.EventHandler(this.menuCh3Ex9_Click);
      // 
      // menuCh3Ex10
      // 
      this.menuCh3Ex10.Index = 8;
      this.menuCh3Ex10.Text = "Listing 3.10";
      this.menuCh3Ex10.Click += new System.EventHandler(this.menuCh3Ex10_Click);
      // 
      // menuCh3Ex11
      // 
      this.menuCh3Ex11.Index = 9;
      this.menuCh3Ex11.Text = "Listing 3.11";
      this.menuCh3Ex11.Click += new System.EventHandler(this.menuCh3Ex11_Click);
      // 
      // menuCh3Ex12
      // 
      this.menuCh3Ex12.Index = 10;
      this.menuCh3Ex12.Text = "Listing 3.12";
      this.menuCh3Ex12.Click += new System.EventHandler(this.menuCh3Ex12_Click);
      // 
      // menuCh3Ex13
      // 
      this.menuCh3Ex13.Index = 11;
      this.menuCh3Ex13.Text = "Listing 3.13";
      this.menuCh3Ex13.Click += new System.EventHandler(this.menuCh3Ex13_Click);
      // 
      // menuCh3Ex15
      // 
      this.menuCh3Ex15.Index = 12;
      this.menuCh3Ex15.Text = "Listing 3.15";
      this.menuCh3Ex15.Click += new System.EventHandler(this.menuCh3Ex15_Click);
      // 
      // menuCh3Ex16
      // 
      this.menuCh3Ex16.Index = 13;
      this.menuCh3Ex16.Text = "Listing 3.16";
      this.menuCh3Ex16.Click += new System.EventHandler(this.menuCh3Ex16_Click);
      // 
      // menuCh3Ex17
      // 
      this.menuCh3Ex17.Index = 14;
      this.menuCh3Ex17.Text = "Listing 3.17";
      this.menuCh3Ex17.Click += new System.EventHandler(this.menuCh3Ex17_Click);
      // 
      // menuCh3Ex18
      // 
      this.menuCh3Ex18.Index = 15;
      this.menuCh3Ex18.Text = "Listing 3.18";
      this.menuCh3Ex18.Click += new System.EventHandler(this.menuCh3Ex18_Click);
      // 
      // menuCh3Ex19
      // 
      this.menuCh3Ex19.Index = 16;
      this.menuCh3Ex19.Text = "Listing 3.19";
      this.menuCh3Ex19.Click += new System.EventHandler(this.menuCh3Ex19_Click);
      // 
      // menuItem6
      // 
      this.menuItem6.Index = 4;
      this.menuItem6.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                              this.menuCh4Ex1,
                                                                              this.menuCh4Ex2,
                                                                              this.menuCh4Ex3,
                                                                              this.menuCh4Ex4,
                                                                              this.menuCh4Ex5,
                                                                              this.menuCh4Ex6,
                                                                              this.menuCh4Ex10,
                                                                              this.menuCh4Ex11,
                                                                              this.menuCh4Ex12,
                                                                              this.menuCh4ExDlg});
      this.menuItem6.Text = "Ch &4";
      // 
      // menuCh4Ex1
      // 
      this.menuCh4Ex1.Index = 0;
      this.menuCh4Ex1.Text = "Listing 4.1";
      this.menuCh4Ex1.Click += new System.EventHandler(this.menuCh4Ex1_Click);
      // 
      // menuCh4Ex2
      // 
      this.menuCh4Ex2.Index = 1;
      this.menuCh4Ex2.Text = "Listing 4.2";
      this.menuCh4Ex2.Click += new System.EventHandler(this.menuCh4Ex2_Click);
      // 
      // menuCh4Ex3
      // 
      this.menuCh4Ex3.Index = 2;
      this.menuCh4Ex3.Text = "Listing 4.3";
      this.menuCh4Ex3.Click += new System.EventHandler(this.menuCh4Ex3_Click);
      // 
      // menuCh4ExDlg
      // 
      this.menuCh4ExDlg.Index = 9;
      this.menuCh4ExDlg.Text = "Example Dialog";
      this.menuCh4ExDlg.Click += new System.EventHandler(this.menuCh4ExDlg_Click);
      // 
      // menuCh4Ex11
      // 
      this.menuCh4Ex11.Index = 7;
      this.menuCh4Ex11.Text = "Listing 4.11";
      this.menuCh4Ex11.Click += new System.EventHandler(this.menuCh4Ex11_Click);
      // 
      // menuItem7
      // 
      this.menuItem7.Index = 5;
      this.menuItem7.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                              this.menuCh5Ex1,
                                                                              this.menuCh5Ex2,
                                                                              this.menuCh5Ex3,
                                                                              this.menuCh5Ex4,
                                                                              this.menuCh5Ex5,
                                                                              this.menuCh5Ex6,
                                                                              this.menuCh5Ex7,
                                                                              this.menuCh5Ex8,
                                                                              this.menuCh5Ex9,
                                                                              this.menuCh5Ex10,
                                                                              this.menuCh5Ex11,
                                                                              this.menuCh5Ex12,
                                                                              this.menuCh5Ex13,
                                                                              this.menuCh5Ex14,
                                                                              this.menuCh5Ex15,
                                                                              this.menuCh5Ex16,
                                                                              this.menuCh5Ex17,
                                                                              this.menuCh5Ex18,
                                                                              this.menuCh5Ex19,
                                                                              this.menuCh5Ex20,
                                                                              this.menuCh5Ex21,
                                                                              this.menuCh5Ex22,
                                                                              this.menuCh5Ex23,
                                                                              this.menuCh5Ex24,
                                                                              this.menuCh5Ex25,
                                                                              this.menuInvoiceLister});
      this.menuItem7.Text = "Ch &5";
      // 
      // menuCh5Ex1
      // 
      this.menuCh5Ex1.Index = 0;
      this.menuCh5Ex1.Text = "Example 1";
      this.menuCh5Ex1.Click += new System.EventHandler(this.menuCh5Ex1_Click);
      // 
      // menuCh5Ex2
      // 
      this.menuCh5Ex2.Index = 1;
      this.menuCh5Ex2.Text = "Example 2";
      this.menuCh5Ex2.Click += new System.EventHandler(this.menuCh5Ex2_Click);
      // 
      // menuCh5Ex3
      // 
      this.menuCh5Ex3.Index = 2;
      this.menuCh5Ex3.Text = "Example 3";
      this.menuCh5Ex3.Click += new System.EventHandler(this.menuCh5Ex3_Click);
      // 
      // menuCh5Ex4
      // 
      this.menuCh5Ex4.Index = 3;
      this.menuCh5Ex4.Text = "Example 4";
      this.menuCh5Ex4.Click += new System.EventHandler(this.menuCh5Ex4_Click);
      // 
      // menuCh5Ex5
      // 
      this.menuCh5Ex5.Index = 4;
      this.menuCh5Ex5.Text = "Example 5";
      this.menuCh5Ex5.Click += new System.EventHandler(this.menuCh5Ex5_Click);
      // 
      // menuCh5Ex6
      // 
      this.menuCh5Ex6.Index = 5;
      this.menuCh5Ex6.Text = "Example 6";
      this.menuCh5Ex6.Click += new System.EventHandler(this.menuCh5Ex6_Click);
      // 
      // menuCh5Ex7
      // 
      this.menuCh5Ex7.Index = 6;
      this.menuCh5Ex7.Text = "Example 7";
      this.menuCh5Ex7.Click += new System.EventHandler(this.menuCh5Ex7_Click);
      // 
      // menuCh5Ex8
      // 
      this.menuCh5Ex8.Index = 7;
      this.menuCh5Ex8.Text = "Example 8";
      this.menuCh5Ex8.Click += new System.EventHandler(this.menuCh5Ex8_Click);
      // 
      // menuCh5Ex9
      // 
      this.menuCh5Ex9.Index = 8;
      this.menuCh5Ex9.Text = "Example 9";
      this.menuCh5Ex9.Click += new System.EventHandler(this.menuCh5Ex9_Click);
      // 
      // menuCh5Ex10
      // 
      this.menuCh5Ex10.Index = 9;
      this.menuCh5Ex10.Text = "Example 10";
      this.menuCh5Ex10.Click += new System.EventHandler(this.menuCh5Ex10_Click);
      // 
      // menuCh5Ex11
      // 
      this.menuCh5Ex11.Index = 10;
      this.menuCh5Ex11.Text = "Example 11";
      this.menuCh5Ex11.Click += new System.EventHandler(this.menuCh5Ex11_Click);
      // 
      // menuCh5Ex12
      // 
      this.menuCh5Ex12.Index = 11;
      this.menuCh5Ex12.Text = "Example 12";
      this.menuCh5Ex12.Click += new System.EventHandler(this.menuCh5Ex12_Click);
      // 
      // menuCh5Ex13
      // 
      this.menuCh5Ex13.Index = 12;
      this.menuCh5Ex13.Text = "Example 13";
      this.menuCh5Ex13.Click += new System.EventHandler(this.menuCh5Ex13_Click);
      // 
      // menuCh5Ex14
      // 
      this.menuCh5Ex14.Index = 13;
      this.menuCh5Ex14.Text = "Example 14";
      this.menuCh5Ex14.Click += new System.EventHandler(this.menuCh5Ex14_Click);
      // 
      // menuCh5Ex15
      // 
      this.menuCh5Ex15.Index = 14;
      this.menuCh5Ex15.Text = "Example 15";
      this.menuCh5Ex15.Click += new System.EventHandler(this.menuCh5Ex15_Click);
      // 
      // menuCh5Ex16
      // 
      this.menuCh5Ex16.Index = 15;
      this.menuCh5Ex16.Text = "Example 16";
      this.menuCh5Ex16.Click += new System.EventHandler(this.menuCh5Ex16_Click);
      // 
      // menuCh5Ex17
      // 
      this.menuCh5Ex17.Index = 16;
      this.menuCh5Ex17.Text = "Example 17";
      this.menuCh5Ex17.Click += new System.EventHandler(this.menuCh5Ex17_Click);
      // 
      // menuCh5Ex18
      // 
      this.menuCh5Ex18.Index = 17;
      this.menuCh5Ex18.Text = "Example 18";
      this.menuCh5Ex18.Click += new System.EventHandler(this.menuCh5Ex18_Click);
      // 
      // menuCh5Ex19
      // 
      this.menuCh5Ex19.Index = 18;
      this.menuCh5Ex19.Text = "Example 19";
      this.menuCh5Ex19.Click += new System.EventHandler(this.menuCh5Ex19_Click);
      // 
      // menuCh5Ex20
      // 
      this.menuCh5Ex20.Index = 19;
      this.menuCh5Ex20.Text = "Example 20";
      this.menuCh5Ex20.Click += new System.EventHandler(this.menuCh5Ex20_Click);
      // 
      // menuCh5Ex21
      // 
      this.menuCh5Ex21.Index = 20;
      this.menuCh5Ex21.Text = "Example 21";
      this.menuCh5Ex21.Click += new System.EventHandler(this.menuCh5Ex21_Click);
      // 
      // menuCh5Ex22
      // 
      this.menuCh5Ex22.Index = 21;
      this.menuCh5Ex22.Text = "Example 22";
      this.menuCh5Ex22.Click += new System.EventHandler(this.menuCh5Ex22_Click);
      // 
      // menuCh5Ex23
      // 
      this.menuCh5Ex23.Index = 22;
      this.menuCh5Ex23.Text = "Example 23";
      this.menuCh5Ex23.Click += new System.EventHandler(this.menuCh5Ex23_Click);
      // 
      // menuCh5Ex24
      // 
      this.menuCh5Ex24.Index = 23;
      this.menuCh5Ex24.Text = "Example 24";
      this.menuCh5Ex24.Click += new System.EventHandler(this.menuCh5Ex24_Click);
      // 
      // menuCh5Ex25
      // 
      this.menuCh5Ex25.Index = 24;
      this.menuCh5Ex25.Text = "Example 25";
      this.menuCh5Ex25.Click += new System.EventHandler(this.menuCh5Ex25_Click);
      // 
      // menuInvoiceLister
      // 
      this.menuInvoiceLister.Index = 25;
      this.menuInvoiceLister.Text = "Invoice Lister";
      this.menuInvoiceLister.Click += new System.EventHandler(this.menuInvoiceLister_Click);
      // 
      // menuItem9
      // 
      this.menuItem9.Index = 6;
      this.menuItem9.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                              this.menuCh6Ex1,
                                                                              this.menuCh6Ex2,
                                                                              this.menuCh6Ex3,
                                                                              this.menuCh6Ex4,
                                                                              this.menuCh6Ex5});
      this.menuItem9.Text = "Ch &6";
      // 
      // menuCh6Ex1
      // 
      this.menuCh6Ex1.Index = 0;
      this.menuCh6Ex1.Text = "Example 1";
      this.menuCh6Ex1.Click += new System.EventHandler(this.menuCh6Ex1_Click);
      // 
      // menuCh6Ex2
      // 
      this.menuCh6Ex2.Index = 1;
      this.menuCh6Ex2.Text = "Example 2";
      this.menuCh6Ex2.Click += new System.EventHandler(this.menuCh6Ex2_Click);
      // 
      // menuCh6Ex3
      // 
      this.menuCh6Ex3.Index = 2;
      this.menuCh6Ex3.Text = "Example 3";
      this.menuCh6Ex3.Click += new System.EventHandler(this.menuCh6Ex3_Click);
      // 
      // menuCh6Ex4
      // 
      this.menuCh6Ex4.Index = 3;
      this.menuCh6Ex4.Text = "Example 4";
      this.menuCh6Ex4.Click += new System.EventHandler(this.menuCh6Ex4_Click);
      // 
      // menuCh6Ex5
      // 
      this.menuCh6Ex5.Index = 4;
      this.menuCh6Ex5.Text = "Example 5";
      this.menuCh6Ex5.Click += new System.EventHandler(this.menuCh6Ex5_Click);
      // 
      // menuItem10
      // 
      this.menuItem10.Index = 7;
      this.menuItem10.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                               this.menuCh7Ex1,
                                                                               this.menuCh7Ex2,
                                                                               this.menuCh7Ex3,
                                                                               this.menuCh7Ex4,
                                                                               this.menuCh7Ex5,
                                                                               this.menuCh7Ex6,
                                                                               this.menuCh7Ex7,
                                                                               this.menuCh7Ex8,
                                                                               this.menuCh7Ex9,
                                                                               this.menuCh7Ex10,
                                                                               this.menuCh7Ex11,
                                                                               this.menuCh7Ex12,
                                                                               this.menuCh7Ex13,
                                                                               this.menuCh7Ex14,
                                                                               this.menuCh7Ex15,
                                                                               this.menuCh7Ex16,
                                                                               this.menuCh7Ex17});
      this.menuItem10.Text = "Ch &7";
      // 
      // menuCh7Ex1
      // 
      this.menuCh7Ex1.Index = 0;
      this.menuCh7Ex1.Text = "Example 1";
      this.menuCh7Ex1.Click += new System.EventHandler(this.menuCh7Ex1_Click);
      // 
      // menuCh7Ex2
      // 
      this.menuCh7Ex2.Index = 1;
      this.menuCh7Ex2.Text = "Example 2";
      this.menuCh7Ex2.Click += new System.EventHandler(this.menuCh7Ex2_Click);
      // 
      // menuCh7Ex3
      // 
      this.menuCh7Ex3.Index = 2;
      this.menuCh7Ex3.Text = "Example 3";
      this.menuCh7Ex3.Click += new System.EventHandler(this.menuCh7Ex3_Click);
      // 
      // menuCh7Ex4
      // 
      this.menuCh7Ex4.Index = 3;
      this.menuCh7Ex4.Text = "Example 4";
      this.menuCh7Ex4.Click += new System.EventHandler(this.menuCh7Ex4_Click);
      // 
      // menuCh7Ex5
      // 
      this.menuCh7Ex5.Index = 4;
      this.menuCh7Ex5.Text = "Example 5";
      this.menuCh7Ex5.Click += new System.EventHandler(this.menuCh7Ex5_Click);
      // 
      // menuCh7Ex6
      // 
      this.menuCh7Ex6.Index = 5;
      this.menuCh7Ex6.Text = "Example 6";
      this.menuCh7Ex6.Click += new System.EventHandler(this.menuCh7Ex6_Click);
      // 
      // menuCh7Ex7
      // 
      this.menuCh7Ex7.Index = 6;
      this.menuCh7Ex7.Text = "Example 7";
      this.menuCh7Ex7.Click += new System.EventHandler(this.menuCh7Ex7_Click);
      // 
      // menuCh7Ex8
      // 
      this.menuCh7Ex8.Index = 7;
      this.menuCh7Ex8.Text = "Example 8";
      this.menuCh7Ex8.Click += new System.EventHandler(this.menuCh7Ex8_Click);
      // 
      // menuCh7Ex9
      // 
      this.menuCh7Ex9.Index = 8;
      this.menuCh7Ex9.Text = "Example 9";
      this.menuCh7Ex9.Click += new System.EventHandler(this.menuCh7Ex9_Click);
      // 
      // menuCh7Ex10
      // 
      this.menuCh7Ex10.Index = 9;
      this.menuCh7Ex10.Text = "Example 10";
      this.menuCh7Ex10.Click += new System.EventHandler(this.menuCh7Ex10_Click);
      // 
      // menuCh7Ex11
      // 
      this.menuCh7Ex11.Index = 10;
      this.menuCh7Ex11.Text = "Example 11";
      this.menuCh7Ex11.Click += new System.EventHandler(this.menuCh7Ex11_Click);
      // 
      // menuCh7Ex12
      // 
      this.menuCh7Ex12.Index = 11;
      this.menuCh7Ex12.Text = "Example 12";
      this.menuCh7Ex12.Click += new System.EventHandler(this.menuCh7Ex12_Click);
      // 
      // menuCh7Ex13
      // 
      this.menuCh7Ex13.Index = 12;
      this.menuCh7Ex13.Text = "Example 13";
      this.menuCh7Ex13.Click += new System.EventHandler(this.menuCh7Ex13_Click);
      // 
      // menuCh7Ex14
      // 
      this.menuCh7Ex14.Index = 13;
      this.menuCh7Ex14.Text = "Example 14";
      this.menuCh7Ex14.Click += new System.EventHandler(this.menuCh7Ex14_Click);
      // 
      // menuCh7Ex15
      // 
      this.menuCh7Ex15.Index = 14;
      this.menuCh7Ex15.Text = "Example 15";
      this.menuCh7Ex15.Click += new System.EventHandler(this.menuCh7Ex15_Click);
      // 
      // menuCh7Ex16
      // 
      this.menuCh7Ex16.Index = 15;
      this.menuCh7Ex16.Text = "Example 16";
      this.menuCh7Ex16.Click += new System.EventHandler(this.menuCh7Ex16_Click);
      // 
      // menuCh7Ex17
      // 
      this.menuCh7Ex17.Index = 16;
      this.menuCh7Ex17.Text = "Example 17";
      this.menuCh7Ex17.Click += new System.EventHandler(this.menuCh7Ex17_Click);
      // 
      // menuItem11
      // 
      this.menuItem11.Index = 8;
      this.menuItem11.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                               this.menuCh8Ex1,
                                                                               this.menuCh8Ex2,
                                                                               this.menuCh8Ex3,
                                                                               this.menuCh8Ex4,
                                                                               this.menuCh8Ex5,
                                                                               this.menuCh8Ex6,
                                                                               this.menuCh8Ex7,
                                                                               this.menuCh8Ex8,
                                                                               this.menuCh8Ex9,
                                                                               this.menuCh8Ex10,
                                                                               this.menuCh8Ex11,
                                                                               this.menuCh8Ex12,
                                                                               this.menuCh8Ex13});
      this.menuItem11.Text = "Ch &8";
      // 
      // menuCh8Ex1
      // 
      this.menuCh8Ex1.Index = 0;
      this.menuCh8Ex1.Text = "Example 1";
      this.menuCh8Ex1.Click += new System.EventHandler(this.menuCh8Ex1_Click);
      // 
      // menuCh8Ex2
      // 
      this.menuCh8Ex2.Index = 1;
      this.menuCh8Ex2.Text = "Example 2";
      this.menuCh8Ex2.Click += new System.EventHandler(this.menuCh8Ex2_Click);
      // 
      // menuCh8Ex3
      // 
      this.menuCh8Ex3.Index = 2;
      this.menuCh8Ex3.Text = "Example 3";
      this.menuCh8Ex3.Click += new System.EventHandler(this.menuCh8Ex3_Click);
      // 
      // menuCh8Ex4
      // 
      this.menuCh8Ex4.Index = 3;
      this.menuCh8Ex4.Text = "Example 4";
      this.menuCh8Ex4.Click += new System.EventHandler(this.menuCh8Ex4_Click);
      // 
      // menuCh8Ex5
      // 
      this.menuCh8Ex5.Index = 4;
      this.menuCh8Ex5.Text = "Example 5";
      this.menuCh8Ex5.Click += new System.EventHandler(this.menuCh8Ex5_Click);
      // 
      // menuCh8Ex6
      // 
      this.menuCh8Ex6.Index = 5;
      this.menuCh8Ex6.Text = "Example 6";
      this.menuCh8Ex6.Click += new System.EventHandler(this.menuCh8Ex6_Click);
      // 
      // menuCh8Ex7
      // 
      this.menuCh8Ex7.Index = 6;
      this.menuCh8Ex7.Text = "Example 7";
      this.menuCh8Ex7.Click += new System.EventHandler(this.menuCh8Ex7_Click);
      // 
      // menuCh8Ex8
      // 
      this.menuCh8Ex8.Index = 7;
      this.menuCh8Ex8.Text = "Example 8";
      this.menuCh8Ex8.Click += new System.EventHandler(this.menuCh8Ex8_Click);
      // 
      // menuCh8Ex9
      // 
      this.menuCh8Ex9.Index = 8;
      this.menuCh8Ex9.Text = "Example 9";
      this.menuCh8Ex9.Click += new System.EventHandler(this.menuCh8Ex9_Click);
      // 
      // menuCh8Ex10
      // 
      this.menuCh8Ex10.Index = 9;
      this.menuCh8Ex10.Text = "Example 10";
      this.menuCh8Ex10.Click += new System.EventHandler(this.menuCh8Ex10_Click);
      // 
      // menuCh8Ex11
      // 
      this.menuCh8Ex11.Index = 10;
      this.menuCh8Ex11.Text = "Example 11";
      this.menuCh8Ex11.Click += new System.EventHandler(this.menuCh8Ex11_Click);
      // 
      // menuCh8Ex12
      // 
      this.menuCh8Ex12.Index = 11;
      this.menuCh8Ex12.Text = "Example 12";
      this.menuCh8Ex12.Click += new System.EventHandler(this.menuCh8Ex12_Click);
      // 
      // menuCh8Ex13
      // 
      this.menuCh8Ex13.Index = 12;
      this.menuCh8Ex13.Text = "Example 13";
      this.menuCh8Ex13.Click += new System.EventHandler(this.menuCh8Ex13_Click);
      // 
      // menuItem2
      // 
      this.menuItem2.Index = 9;
      this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                              this.menuCh9Ex1,
                                                                              this.menuCh9Ex2,
                                                                              this.menuCh9Ex3,
                                                                              this.menuCh9Ex4,
                                                                              this.menuCh9Ex5,
                                                                              this.menuCh9Ex6,
                                                                              this.menuCh9Ex7,
                                                                              this.menuCh9Ex8,
                                                                              this.menuCh9Ex9,
                                                                              this.menuCh9Ex10,
                                                                              this.menuCh9Ex11,
                                                                              this.menuCh9Ex12,
                                                                              this.menuCh9Ex13,
                                                                              this.menuCh9Ex14,
                                                                              this.menuCh9Ex15,
                                                                              this.menuCh9Ex16});
      this.menuItem2.Text = "Ch &9";
      // 
      // menuCh9Ex1
      // 
      this.menuCh9Ex1.Index = 0;
      this.menuCh9Ex1.Text = "Example 1";
      this.menuCh9Ex1.Click += new System.EventHandler(this.menuCh9Ex1_Click);
      // 
      // menuCh9Ex2
      // 
      this.menuCh9Ex2.Index = 1;
      this.menuCh9Ex2.Text = "Example 2";
      this.menuCh9Ex2.Click += new System.EventHandler(this.menuCh9Ex2_Click);
      // 
      // menuCh9Ex3
      // 
      this.menuCh9Ex3.Index = 2;
      this.menuCh9Ex3.Text = "Example 3";
      this.menuCh9Ex3.Click += new System.EventHandler(this.menuCh9Ex3_Click);
      // 
      // menuCh9Ex4
      // 
      this.menuCh9Ex4.Index = 3;
      this.menuCh9Ex4.Text = "Example 4";
      this.menuCh9Ex4.Click += new System.EventHandler(this.menuCh9Ex4_Click);
      // 
      // menuCh9Ex5
      // 
      this.menuCh9Ex5.Index = 4;
      this.menuCh9Ex5.Text = "Example 5";
      this.menuCh9Ex5.Click += new System.EventHandler(this.menuCh9Ex5_Click);
      // 
      // menuCh9Ex6
      // 
      this.menuCh9Ex6.Index = 5;
      this.menuCh9Ex6.Text = "Example 6";
      this.menuCh9Ex6.Click += new System.EventHandler(this.menuCh9Ex6_Click);
      // 
      // menuCh9Ex7
      // 
      this.menuCh9Ex7.Index = 6;
      this.menuCh9Ex7.Text = "Example 7";
      this.menuCh9Ex7.Click += new System.EventHandler(this.menuCh9Ex7_Click);
      // 
      // menuCh9Ex8
      // 
      this.menuCh9Ex8.Index = 7;
      this.menuCh9Ex8.Text = "Example 8";
      this.menuCh9Ex8.Click += new System.EventHandler(this.menuCh9Ex8_Click);
      // 
      // menuCh9Ex9
      // 
      this.menuCh9Ex9.Index = 8;
      this.menuCh9Ex9.Text = "Example 9";
      this.menuCh9Ex9.Click += new System.EventHandler(this.menuCh9Ex9_Click);
      // 
      // menuCh9Ex10
      // 
      this.menuCh9Ex10.Index = 9;
      this.menuCh9Ex10.Text = "Example 10";
      this.menuCh9Ex10.Click += new System.EventHandler(this.menuCh9Ex10_Click);
      // 
      // menuCh9Ex11
      // 
      this.menuCh9Ex11.Index = 10;
      this.menuCh9Ex11.Text = "Example 11";
      this.menuCh9Ex11.Click += new System.EventHandler(this.menuCh9Ex11_Click);
      // 
      // menuCh9Ex12
      // 
      this.menuCh9Ex12.Index = 11;
      this.menuCh9Ex12.Text = "Example 12";
      this.menuCh9Ex12.Click += new System.EventHandler(this.menuCh9Ex12_Click);
      // 
      // menuCh9Ex13
      // 
      this.menuCh9Ex13.Index = 12;
      this.menuCh9Ex13.Text = "Example 13";
      this.menuCh9Ex13.Click += new System.EventHandler(this.menuCh9Ex13_Click);
      // 
      // menuCh9Ex14
      // 
      this.menuCh9Ex14.Index = 13;
      this.menuCh9Ex14.Text = "Example 14";
      this.menuCh9Ex14.Click += new System.EventHandler(this.menuCh9Ex14_Click);
      // 
      // menuCh9Ex15
      // 
      this.menuCh9Ex15.Index = 14;
      this.menuCh9Ex15.Text = "Example 15";
      this.menuCh9Ex15.Click += new System.EventHandler(this.menuCh9Ex15_Click);
      // 
      // menuCh9Ex16
      // 
      this.menuCh9Ex16.Index = 15;
      this.menuCh9Ex16.Text = "Example 16";
      this.menuCh9Ex16.Click += new System.EventHandler(this.menuCh9Ex16_Click);
      // 
      // menuItem13
      // 
      this.menuItem13.Index = 10;
      this.menuItem13.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                               this.menuCh10});
      this.menuItem13.Text = "Ch 1&0";
      // 
      // menuCh10
      // 
      this.menuCh10.Index = 0;
      this.menuCh10.Text = "DataBinding Form";
      this.menuCh10.Click += new System.EventHandler(this.menuCh10_Click);
      // 
      // menuItem14
      // 
      this.menuItem14.Index = 11;
      this.menuItem14.Text = "C&h 11";
      // 
      // menuItem12
      // 
      this.menuItem12.Index = 12;
      this.menuItem12.Text = "&Appendix";
      // 
      // theTabCtrl
      // 
      this.theTabCtrl.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                             this.pageOutput,
                                                                             this.pageGrid});
      this.theTabCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.theTabCtrl.Name = "theTabCtrl";
      this.theTabCtrl.SelectedIndex = 0;
      this.theTabCtrl.Size = new System.Drawing.Size(664, 254);
      this.theTabCtrl.TabIndex = 0;
      // 
      // pageOutput
      // 
      this.pageOutput.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                             this.textOutput});
      this.pageOutput.Location = new System.Drawing.Point(4, 22);
      this.pageOutput.Name = "pageOutput";
      this.pageOutput.Size = new System.Drawing.Size(656, 228);
      this.pageOutput.TabIndex = 1;
      this.pageOutput.Text = "Output";
      // 
      // textOutput
      // 
      this.textOutput.AcceptsReturn = true;
      this.textOutput.Dock = System.Windows.Forms.DockStyle.Fill;
      this.textOutput.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.textOutput.Multiline = true;
      this.textOutput.Name = "textOutput";
      this.textOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.textOutput.Size = new System.Drawing.Size(656, 228);
      this.textOutput.TabIndex = 0;
      this.textOutput.Text = "";
      // 
      // pageGrid
      // 
      this.pageGrid.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                           this.theGrid});
      this.pageGrid.Location = new System.Drawing.Point(4, 22);
      this.pageGrid.Name = "pageGrid";
      this.pageGrid.Size = new System.Drawing.Size(656, 228);
      this.pageGrid.TabIndex = 0;
      this.pageGrid.Text = "DataGrid";
      // 
      // theGrid
      // 
      this.theGrid.DataMember = "";
      this.theGrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.theGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.theGrid.Name = "theGrid";
      this.theGrid.Size = new System.Drawing.Size(656, 228);
      this.theGrid.TabIndex = 0;
      // 
      // menuCh4Ex4
      // 
      this.menuCh4Ex4.Index = 3;
      this.menuCh4Ex4.Text = "Listing 4.4";
      this.menuCh4Ex4.Click += new System.EventHandler(this.menuCh4Ex4_Click);
      // 
      // menuCh4Ex5
      // 
      this.menuCh4Ex5.Index = 4;
      this.menuCh4Ex5.Text = "Listing 4.5";
      this.menuCh4Ex5.Click += new System.EventHandler(this.menuCh4Ex5_Click);
      // 
      // menuCh4Ex6
      // 
      this.menuCh4Ex6.Index = 5;
      this.menuCh4Ex6.Text = "Listing 4.6";
      this.menuCh4Ex6.Click += new System.EventHandler(this.menuCh4Ex6_Click);
      // 
      // menuCh4Ex10
      // 
      this.menuCh4Ex10.Index = 6;
      this.menuCh4Ex10.Text = "Listing 4.10";
      this.menuCh4Ex10.Click += new System.EventHandler(this.menuCh4Ex10_Click);
      // 
      // menuCh4Ex12
      // 
      this.menuCh4Ex12.Index = 8;
      this.menuCh4Ex12.Text = "Listing 4.12";
      this.menuCh4Ex12.Click += new System.EventHandler(this.menuCh4Ex12_Click);
      // 
      // MainForm
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(664, 254);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.theTabCtrl});
      this.Menu = this.mainMenu1;
      this.Name = "MainForm";
      this.Text = "Pragmatic ADO.NET Examples";
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.Load += new System.EventHandler(this.MainForm_Load);
      this.theTabCtrl.ResumeLayout(false);
      this.pageOutput.ResumeLayout(false);
      this.pageGrid.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.theGrid)).EndInit();
      this.ResumeLayout(false);

    }
		#endregion

    #region Grid and Output Helpers
    /// <summary>
    /// Mimics the System.Console class's output
    /// </summary>
    /// <param name="s">Format String</param>
    /// <param name="arg">Arguments</param>
    public void WriteLine(string s, params object[] arg)
    {
      StringBuilder bldr = new StringBuilder();
      bldr.AppendFormat(s, arg);
      WriteLine(bldr.ToString());
    }

    /// <summary>
    /// Mimics the System.Console class's output
    /// </summary>
    /// <param name="s">Text to write</param>
    public void WriteLine(string s)
    {
      Write(s + "\r\n");
    }

    /// <summary>
    /// Mimics the System.Console class's output
    /// </summary>
    /// <param name="s">Text to write</param>
    public void WriteLine(object o)
    {
      Write(o.ToString() + "\r\n");
    }

    /// <summary>
    /// Mimics the System.Console.Write function
    /// </summary>
    /// <param name="s">String to output</param>
    public void Write(string s)
    {
      textOutput.Text += s;
      theTabCtrl.SelectedTab = pageOutput;
    }

    /// <summary>
    /// Mimics the System.Console.Write function
    /// </summary>
    /// <param name="s">String to output</param>
    public void Write(object o)
    {
      textOutput.Text += o.ToString();
      theTabCtrl.SelectedTab = pageOutput;
    }

    /// <summary>
    /// Gives access to the grid without allowing 
    /// code to set the grid.
    /// </summary>
    public DataGrid TheGrid
    {
      get
      {
        theTabCtrl.SelectedTab = pageGrid;
        return theGrid;
      }
    }

    #endregion

    #region File Menu
    private void menuCreateDB_Click(object sender, System.EventArgs e)
    {
      CreateDBDialog dlg = new CreateDBDialog();
      dlg.ShowDialog(this);
    }

    public SqlConnection CreateConnection()
    {
      return new SqlConnection(
        "server=Mainsrv;" +
        "database=ADONET;" + 
        "Integrated Security=true;");
    }

    private void menuExit_Click(object sender, System.EventArgs e)
    {
      Application.Exit();
    }
    #endregion

    #region Chapter One Menu
    private void menuCh1Ex2_Click(object sender, System.EventArgs e)
    {
      ch1.Example2();    
    }

    private void menuCh1Ex3_Click(object sender, System.EventArgs e)
    {
      ch1.Example3();    
    }

    private void menuCh1Ex4_Click(object sender, System.EventArgs e)
    {
      ch1.Example4();    
    }

    private void menuCh1Ex5_Click(object sender, System.EventArgs e)
    {
      ch1.Example5();    
    }

    private void menuCh1Ex6_Click(object sender, System.EventArgs e)
    {
      ch1.Example6();    
    }

    private void menuCh1Ex7_Click(object sender, System.EventArgs e)
    {
      ch1.Example7();    
    }

    private void menuCh1Ex8_Click(object sender, System.EventArgs e)
    {
      ch1.Example8();    
    }
    #endregion

    #region Chapter Two Menu
    private void menuCh2Ex1_Click(object sender, System.EventArgs e)
    {
      ch2.Example1();
    }

    private void menuCh2Ex2_Click(object sender, System.EventArgs e)
    {
      ch2.Example2();
    }

    private void menuCh2Ex3_Click(object sender, System.EventArgs e)
    {
      ch2.Example3();
    }

    private void menuCh2Ex5_Click(object sender, System.EventArgs e)
    {
      ch2.Example5();
    }

    private void menuCh2Ex9_Click(object sender, System.EventArgs e)
    {
      ch2.Example9();
    }

    private void menuCh2Ex10_Click(object sender, System.EventArgs e)
    {
      ch2.Example10();
    }

    private void menuCh2Ex11_Click(object sender, System.EventArgs e)
    {
      ch2.Example11();
    }

    private void menuCh2Ex12_Click(object sender, System.EventArgs e)
    {
      ch2.Example12();
    }
    #endregion

    #region Chapter Three Menu
    private void menuCh3Ex1_Click(object sender, System.EventArgs e)
    {
      ch3.Example1();
    }

    private void menuCh3Ex2_Click(object sender, System.EventArgs e)
    {
      ch3.Example2();
    }

    private void menuCh3Ex3_Click(object sender, System.EventArgs e)
    {
      ch3.Example3();
    }

    private void menuCh3Ex4_Click(object sender, System.EventArgs e)
    {
      ch3.Example4();
    }

    private void menuCh3Ex5_Click(object sender, System.EventArgs e)
    {
      ch3.Example5();    
    }

    private void menuCh3Ex6_Click(object sender, System.EventArgs e)
    {
      ch3.Example6();    
    }

    private void menuCh3Ex7_Click(object sender, System.EventArgs e)
    {
      ch3.Example7();
    }

    private void menuCh3Ex9_Click(object sender, System.EventArgs e)
    {
      ch3.Example9();
    }

    private void menuCh3Ex10_Click(object sender, System.EventArgs e)
    {
      ch3.Example10();
    }

    private void menuCh3Ex11_Click(object sender, System.EventArgs e)
    {
      ch3.Example11();
    }

    private void menuCh3Ex12_Click(object sender, System.EventArgs e)
    {
      ch3.Example12();
    }

    private void menuCh3Ex13_Click(object sender, System.EventArgs e)
    {
      ch3.Example13();
    }

    private void menuCh3Ex15_Click(object sender, System.EventArgs e)
    {
      ch3.Example15();
    }

    private void menuCh3Ex16_Click(object sender, System.EventArgs e)
    {
      ch3.Example16();
    }

    private void menuCh3Ex17_Click(object sender, System.EventArgs e)
    {
      ch3.Example17();
    }

    private void menuCh3Ex18_Click(object sender, System.EventArgs e)
    {
      ch3.Example18();
    }

    private void menuCh3Ex19_Click(object sender, System.EventArgs e)
    {
      ch3.Example19();
    }
    #endregion

    #region Chapter Four Menu
    private void menuCh4Ex1_Click(object sender, System.EventArgs e)
    {
      ch4.Example1();
    }

    private void menuCh4Ex2_Click(object sender, System.EventArgs e)
    {
      ch4.Example2();
    }

    private void menuCh4Ex3_Click(object sender, System.EventArgs e)
    {
      ch4.Example3();
    }

    private void menuCh4Ex4_Click(object sender, System.EventArgs e)
    {
      ch4.Example4();
    }

    private void menuCh4Ex5_Click(object sender, System.EventArgs e)
    {
      ch4.Example5();
    }

    private void menuCh4Ex6_Click(object sender, System.EventArgs e)
    {
      ch4.Example6();
    }

    private void menuCh4Ex10_Click(object sender, System.EventArgs e)
    {
      ch4.Example10();
    }

    private void menuCh4Ex11_Click(object sender, System.EventArgs e)
    {
      ch4.Example11();
    }

    private void menuCh4Ex12_Click(object sender, System.EventArgs e)
    {
      ch4.Example12();
    }

    private void menuCh4ExDlg_Click(object sender, System.EventArgs e)
    {
      ch4.ExampleDialog();
    }

    private void menuInvoiceLister_Click(object sender, System.EventArgs e)
    {
      ch5.InvoiceLister();
    }
    #endregion

    #region Chapter Five Menu
    private void menuCh5Ex1_Click(object sender, System.EventArgs e)
    {
      ch5.Example1();
    }

    private void menuCh5Ex2_Click(object sender, System.EventArgs e)
    {
      ch5.Example2();
    }

    private void menuCh5Ex3_Click(object sender, System.EventArgs e)
    {
      ch5.Example3();
    }

    private void menuCh5Ex4_Click(object sender, System.EventArgs e)
    {
      ch5.Example4();
    }

    private void menuCh5Ex5_Click(object sender, System.EventArgs e)
    {
      ch5.Example5();
    }

    private void menuCh5Ex6_Click(object sender, System.EventArgs e)
    {
      ch5.Example6();
    }

    private void menuCh5Ex7_Click(object sender, System.EventArgs e)
    {
      ch5.Example7();
    }

    private void menuCh5Ex8_Click(object sender, System.EventArgs e)
    {
      ch5.Example8();
    }

    private void menuCh5Ex9_Click(object sender, System.EventArgs e)
    {
      ch5.Example9();
    }

    private void menuCh5Ex10_Click(object sender, System.EventArgs e)
    {
      ch5.Example10();
    }

    private void menuCh5Ex11_Click(object sender, System.EventArgs e)
    {
      ch5.Example11();
    }

    private void menuCh5Ex12_Click(object sender, System.EventArgs e)
    {
      ch5.Example12();
    }

    private void menuCh5Ex13_Click(object sender, System.EventArgs e)
    {
      ch5.Example13();
    }

    private void menuCh5Ex14_Click(object sender, System.EventArgs e)
    {
      ch5.Example14();
    }

    private void menuCh5Ex15_Click(object sender, System.EventArgs e)
    {
      ch5.Example15();
    }

    private void menuCh5Ex16_Click(object sender, System.EventArgs e)
    {
      ch5.Example16();
    }

    private void menuCh5Ex17_Click(object sender, System.EventArgs e)
    {
      ch5.Example17();
    }

    private void menuCh5Ex18_Click(object sender, System.EventArgs e)
    {
      ch5.Example18();
    }

    private void menuCh5Ex19_Click(object sender, System.EventArgs e)
    {
      ch5.Example19();
    }

    private void menuCh5Ex20_Click(object sender, System.EventArgs e)
    {
      ch5.Example20();
    }
    private void menuCh5Ex21_Click(object sender, System.EventArgs e)
    {
      ch5.Example21();
    }

    private void menuCh5Ex22_Click(object sender, System.EventArgs e)
    {
      ch5.Example22();
    }

    private void menuCh5Ex23_Click(object sender, System.EventArgs e)
    {
      ch5.Example23();
    }

    private void menuCh5Ex24_Click(object sender, System.EventArgs e)
    {
      ch5.Example24();
    }

    private void menuCh5Ex25_Click(object sender, System.EventArgs e)
    {
      ch5.Example25();
    }

    #endregion

    #region Chapter Six Menu
    private void menuCh6Ex1_Click(object sender, System.EventArgs e)
    {
      ch6.Example1();
    }

    private void menuCh6Ex2_Click(object sender, System.EventArgs e)
    {
      ch6.Example2();
    }
    private void menuCh6Ex3_Click(object sender, System.EventArgs e)
    {
      ch6.Example3();
    }

    private void menuCh6Ex4_Click(object sender, System.EventArgs e)
    {
      ch6.Example4();
    }

    private void menuCh6Ex5_Click(object sender, System.EventArgs e)
    {
      ch6.Example5();
    }

    #endregion

    #region Chapter Seven Menu
    private void menuCh7Ex1_Click(object sender, System.EventArgs e)
    {
      ch7.Example1();
    }

    private void menuCh7Ex2_Click(object sender, System.EventArgs e)
    {
      ch7.Example2();
    }

    private void menuCh7Ex3_Click(object sender, System.EventArgs e)
    {
      ch7.Example3();
    }

    private void menuCh7Ex4_Click(object sender, System.EventArgs e)
    {
      ch7.Example4();
    }

    private void menuCh7Ex5_Click(object sender, System.EventArgs e)
    {
      ch7.Example5();
    }

    private void menuCh7Ex6_Click(object sender, System.EventArgs e)
    {
      ch7.Example6();
    }

    private void menuCh7Ex7_Click(object sender, System.EventArgs e)
    {
      ch7.Example7();
    }

    private void menuCh7Ex8_Click(object sender, System.EventArgs e)
    {
      ch7.Example8();
    }

    private void menuCh7Ex9_Click(object sender, System.EventArgs e)
    {
      ch7.Example9();
    }

    private void menuCh7Ex10_Click(object sender, System.EventArgs e)
    {
      ch7.Example10();
    }

    private void menuCh7Ex11_Click(object sender, System.EventArgs e)
    {
      ch7.Example11();
    }

    private void menuCh7Ex12_Click(object sender, System.EventArgs e)
    {
      ch7.Example12();
    }

    private void menuCh7Ex13_Click(object sender, System.EventArgs e)
    {
      ch7.Example13();
    }

    private void menuCh7Ex14_Click(object sender, System.EventArgs e)
    {
      ch7.Example14();
    }

    private void menuCh7Ex15_Click(object sender, System.EventArgs e)
    {
      ch7.Example15();
    }
    private void menuCh7Ex16_Click(object sender, System.EventArgs e)
    {
      ch7.Example16();
    }

    private void menuCh7Ex17_Click(object sender, System.EventArgs e)
    {
      ch7.Example17();
    }
    #endregion

    #region Chapter Eight Menu
    private void menuCh8Ex1_Click(object sender, System.EventArgs e)
    {
      ch8.Example1();
    }

    private void menuCh8Ex2_Click(object sender, System.EventArgs e)
    {
      ch8.Example2();
    }

    private void menuCh8Ex3_Click(object sender, System.EventArgs e)
    {
      ch8.Example3();
    }

    private void menuCh8Ex4_Click(object sender, System.EventArgs e)
    {
      ch8.Example4();
    }

    private void menuCh8Ex5_Click(object sender, System.EventArgs e)
    {
      ch8.Example5();
    }

    private void menuCh8Ex6_Click(object sender, System.EventArgs e)
    {
      ch8.Example6();
    }

    private void menuCh8Ex7_Click(object sender, System.EventArgs e)
    {
      ch8.Example7();
    }

    private void menuCh8Ex8_Click(object sender, System.EventArgs e)
    {
      ch8.Example8();
    }

    private void menuCh8Ex9_Click(object sender, System.EventArgs e)
    {
      ch8.Example9();
    }

    private void menuCh8Ex10_Click(object sender, System.EventArgs e)
    {
      ch8.Example10();
    }

    private void menuCh8Ex11_Click(object sender, System.EventArgs e)
    {
      ch8.Example11();
    }

    private void menuCh8Ex12_Click(object sender, System.EventArgs e)
    {
      ch8.Example12();
    }
 
    private void menuCh8Ex13_Click(object sender, System.EventArgs e)
    {
      ch8.Example13();
    }
    #endregion

    #region Chapter Nine Menu
    private void menuCh9Ex1_Click(object sender, System.EventArgs e)
    {
      ch9.Example1();
    }

    private void menuCh9Ex2_Click(object sender, System.EventArgs e)
    {
      ch9.Example2();
    }

    private void menuCh9Ex3_Click(object sender, System.EventArgs e)
    {
      ch9.Example3();
    }

    private void menuCh9Ex4_Click(object sender, System.EventArgs e)
    {
      ch9.Example4();
    }

    private void menuCh9Ex5_Click(object sender, System.EventArgs e)
    {
      ch9.Example5();
    }

    private void menuCh9Ex6_Click(object sender, System.EventArgs e)
    {
      ch9.Example6();
    }

    private void menuCh9Ex7_Click(object sender, System.EventArgs e)
    {
      ch9.Example7();
    }

    private void menuCh9Ex8_Click(object sender, System.EventArgs e)
    {
      ch9.Example8();   
    }

    private void menuCh9Ex9_Click(object sender, System.EventArgs e)
    {
      ch9.Example9();
    }

    private void menuCh9Ex10_Click(object sender, System.EventArgs e)
    {
      ch9.Example10();
    }

    private void menuCh9Ex11_Click(object sender, System.EventArgs e)
    {
      ch9.Example11();
    }

    private void menuCh9Ex12_Click(object sender, System.EventArgs e)
    {
      ch9.Example12();
    }

    private void menuCh9Ex13_Click(object sender, System.EventArgs e)
    {
      ch9.Example13();
    }

    private void menuCh9Ex14_Click(object sender, System.EventArgs e)
    {
      ch9.Example14();
    }

    private void menuCh9Ex15_Click(object sender, System.EventArgs e)
    {
      ch9.Example15();
    }

    private void menuCh9Ex16_Click(object sender, System.EventArgs e)
    {
      ch9.Example16();
    }

    #endregion

    #region Chapter Ten Menu
    private void menuCh10_Click(object sender, System.EventArgs e)
    {
      DataBindingForm form = new DataBindingForm();
      form.ShowDialog(this);
    }

    #endregion



  }
}