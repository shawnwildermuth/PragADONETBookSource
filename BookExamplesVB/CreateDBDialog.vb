Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Reflection
Imports System.IO


Namespace BookExamples
    _
  ' <summary>
  ' Summary description for CreateDBDialog.
  ' </summary>
  Public Class CreateDBDialog
    Inherits System.Windows.Forms.Form
    Private label2 As System.Windows.Forms.Label
    Private label3 As System.Windows.Forms.Label
    Private WithEvents IntSecCheck As System.Windows.Forms.CheckBox
    Private userID As System.Windows.Forms.TextBox
    Private password As System.Windows.Forms.TextBox
    Private btnOk As System.Windows.Forms.Button
    Private btnCancel As System.Windows.Forms.Button
    Private label4 As System.Windows.Forms.Label
    Private WithEvents server As System.Windows.Forms.TextBox
    ' <summary>
    ' Required designer variable.
    ' </summary>
    Private components As System.ComponentModel.Container = Nothing


    Public Sub New()
      '
      ' Required for Windows Form Designer support
      '
      InitializeComponent()
    End Sub 'New

    '
    ' TODO: Add any constructor code after InitializeComponent call
    '

    ' <summary>
    ' Clean up any resources being used.
    ' </summary>
    Protected Overloads Sub Dispose(ByVal disposing As Boolean)
      If disposing Then
        If Not (components Is Nothing) Then
          components.Dispose()
        End If
      End If
      MyBase.Dispose(disposing)
    End Sub 'Dispose


    '
    'ToDo: Error processing original source shown below
    '
    '
    '-----^--- Pre-processor directives not translated
    ' <summary>
    '
    'ToDo: Error processing original source shown below
    '
    '
    '--^--- Unexpected pre-processor directive
    ' Required method for Designer support - do not modify
    ' the contents of this method with the code editor.
    ' </summary>
    Private Sub InitializeComponent()
      Me.btnOk = New System.Windows.Forms.Button()
      Me.IntSecCheck = New System.Windows.Forms.CheckBox()
      Me.label2 = New System.Windows.Forms.Label()
      Me.userID = New System.Windows.Forms.TextBox()
      Me.label3 = New System.Windows.Forms.Label()
      Me.password = New System.Windows.Forms.TextBox()
      Me.btnCancel = New System.Windows.Forms.Button()
      Me.label4 = New System.Windows.Forms.Label()
      Me.server = New System.Windows.Forms.TextBox()
      MyBase.SuspendLayout()
      ' 
      ' btnOk
      ' 
      Me.btnOk.Location = New System.Drawing.Point(208, 104)
      Me.btnOk.Name = "btnOk"
      Me.btnOk.TabIndex = 6
      Me.btnOk.Text = "&OK"
      ' 
      ' IntSecCheck
      ' 
      Me.IntSecCheck.Checked = True
      Me.IntSecCheck.CheckState = System.Windows.Forms.CheckState.Checked
      Me.IntSecCheck.Location = New System.Drawing.Point(104, 80)
      Me.IntSecCheck.Name = "IntSecCheck"
      Me.IntSecCheck.Size = New System.Drawing.Size(160, 16)
      Me.IntSecCheck.TabIndex = 4
      Me.IntSecCheck.Text = "Use Integrated Security?"
      ' 
      ' label2
      ' 
      Me.label2.Location = New System.Drawing.Point(8, 32)
      Me.label2.Name = "label2"
      Me.label2.Size = New System.Drawing.Size(96, 16)
      Me.label2.TabIndex = 9
      Me.label2.Text = "User ID:"
      ' 
      ' userID
      ' 
      Me.userID.Enabled = False
      Me.userID.Location = New System.Drawing.Point(104, 32)
      Me.userID.Name = "userID"
      Me.userID.Size = New System.Drawing.Size(176, 20)
      Me.userID.TabIndex = 2
      Me.userID.Text = ""
      ' 
      ' label3
      ' 
      Me.label3.Location = New System.Drawing.Point(8, 56)
      Me.label3.Name = "label3"
      Me.label3.Size = New System.Drawing.Size(96, 16)
      Me.label3.TabIndex = 10
      Me.label3.Text = "Password:"
      ' 
      ' password
      ' 
      Me.password.Enabled = False
      Me.password.Location = New System.Drawing.Point(104, 56)
      Me.password.Name = "password"
      Me.password.PasswordChar = "*"c
      Me.password.Size = New System.Drawing.Size(176, 20)
      Me.password.TabIndex = 3
      Me.password.Text = ""
      ' 
      ' btnCancel
      ' 
      Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.btnCancel.Location = New System.Drawing.Point(128, 104)
      Me.btnCancel.Name = "btnCancel"
      Me.btnCancel.TabIndex = 5
      Me.btnCancel.Text = "&Cancel"
      ' 
      ' label4
      ' 
      Me.label4.Location = New System.Drawing.Point(8, 8)
      Me.label4.Name = "label4"
      Me.label4.Size = New System.Drawing.Size(96, 16)
      Me.label4.TabIndex = 7
      Me.label4.Text = "Server:"
      ' 
      ' server
      ' 
      Me.server.Location = New System.Drawing.Point(104, 8)
      Me.server.Name = "server"
      Me.server.Size = New System.Drawing.Size(176, 20)
      Me.server.TabIndex = 0
      Me.server.Text = "localhost"
      ' 
      ' CreateDBDialog
      ' 
      MyBase.AcceptButton = Me.btnOk
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      MyBase.CancelButton = Me.btnCancel
      Me.ClientSize = New System.Drawing.Size(286, 129)
      Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.label4, Me.server, Me.btnCancel, Me.label3, Me.password, Me.label2, Me.userID, Me.IntSecCheck, Me.btnOk})
      MyBase.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      MyBase.MaximizeBox = False
      Me.MaximumSize = New System.Drawing.Size(296, 160)
      MyBase.MinimizeBox = False
      Me.MinimumSize = New System.Drawing.Size(296, 160)
      MyBase.Name = "CreateDBDialog"
      MyBase.ShowInTaskbar = False
      MyBase.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
      MyBase.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
      MyBase.Text = "Create Database"
      MyBase.ResumeLayout(False)
    End Sub 'InitializeComponent

    '
    'ToDo: Error processing original source shown below
    '
    '
    '-----^--- Pre-processor directives not translated
    Private Sub CreateDBDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load '
      'ToDo: Error processing original source shown below
      '
      '
      '--^--- Unexpected pre-processor directive
    End Sub 'CreateDBDialog_Load



    Private Sub IntSecCheck_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles IntSecCheck.CheckedChanged
      userID.Enabled = Not IntSecCheck.Checked
      password.Enabled = Not IntSecCheck.Checked
    End Sub 'IntSecCheck_CheckedChanged


    Private Sub btnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Click
      Cursor.Current = Cursors.WaitCursor
      Try
        Dim connString As String = "server=" + server.Text + ";" + "database=master;"

        If IntSecCheck.Checked Then
          connString += "Integrated Security=true;"
        Else
          connString += "User ID=" + userID.Text + ";Password=" + password.Text + ";"
        End If
        ' Create and Open the Connection
        Dim conn As New SqlConnection(connString)
        conn.Open()

        ' Get the Document from the Assembly
        Dim [assembly] As [Assembly] = [assembly].GetExecutingAssembly()
        Dim stream As Stream = [assembly].GetManifestResourceStream("BookExamples.ADONET.sql")
        Dim rdr As New StreamReader(stream)
        Dim sql As String = rdr.ReadToEnd()
        Dim stream2 As Stream = [assembly].GetManifestResourceStream("BookExamples.ADONET2.sql")
        Dim rdr2 As New StreamReader(stream)
        Dim sql2 As String = rdr.ReadToEnd()

        ' Execute the embedded SQL Doc
        Dim cmd As New SqlCommand(sql, conn)
        cmd.ExecuteNonQuery()
        cmd.CommandText = sql2;
        cmd.ExecuteNonQuery();

        ' Close
        conn.Close()

        ' Show the success
        MessageBox.Show("Database Created", "Pragmatic ADO.NET")

      Catch ex As SqlException
        MessageBox.Show([String].Format("Sql Error: {0}", ex.Message), "Pragmatic ADO.NET")
        Cursor.Current = Cursors.Arrow
        Return
      End Try

      MyBase.Close()
    End Sub 'btnOk_Click


    Private Sub textBox1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles server.TextChanged
    End Sub 'textBox1_TextChanged
  End Class 'CreateDBDialog 
End Namespace 'BookExamples