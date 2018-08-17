using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace atom_skeleton {
	static class Program {

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			Form1 myForm1 = new Form1();
			myForm1.Text = "Atom Skeleton";

			Panel1 myPanel1 = new Panel1();
			myForm1.Controls.Add(myPanel1);
			myForm1.ShowDialog();
		}
	}
}
