using System;
using System.Windows.Forms;

namespace BookExamples
{
	/// <summary>
	/// Base class for holding common code to be shared among the examples 
	/// in the chapters.
	/// </summary>
	public class BaseChapter
	{
    protected MainForm form 
    {
      get 
      {
        return Form.ActiveForm as MainForm;
      }
    }

    // Named Console so we can mimic a Console App
    protected MainForm Console
    {
      get 
      {
        return Form.ActiveForm as MainForm;
      }
    }
  
  }
}
