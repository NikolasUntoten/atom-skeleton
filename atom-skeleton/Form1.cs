using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace atom_skeleton {
	public partial class Form1 : Form {

		BackgroundWorker bgWorker;

		public Form1() {
			InitializeComponent();

			bgWorker = new BackgroundWorker();
			bgWorker.DoWork += new DoWorkEventHandler(RunThread);
		}

		void RunThread(object sender, DoWorkEventArgs e) {

		}
	}
}
