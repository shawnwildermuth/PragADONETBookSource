Imports System
Imports System.Windows.Forms


Namespace BookExamples
    _
  ' <summary>
  ' Base class for holding common code to be shared among the examples 
  ' in the chapters.
  ' </summary>
  Public Class BaseChapter

    Protected ReadOnly Property form() As MainForm
      Get
        Return Form.ActiveForm 
      End Get
    End Property

    ' Named Console so we can mimic a Console App

    Protected ReadOnly Property Console() As MainForm
      Get
        Return Form.ActiveForm 
      End Get
    End Property
  End Class 'BaseChapter 
End Namespace 'BookExamples