using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace WindowsFormsApp1
{
    static class Program
    {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		/// [DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		// [DllImport("libSystem.dylib")]
		//private static extern int MessageBox(IntPtr hWnd, string lpText, string lpCaption, uint uType);

		[STAThread]

		static void Main()//string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new othelloFrm());
		}
	}
}