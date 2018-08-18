using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace atom_skeleton {
	class Panel1 : Panel {

		const int WIDTH = 100;
		const int HEIGHT = 100;

		private BackgroundWorker bgWorker;

		private Atom2D[] atoms;

		private Bitmap buffer;

		public Panel1() {

			InitializeAtoms();
			InitializeWorker();
			InitializeBuffer();
		}

		private void InitializeAtoms() {
			atoms = new Atom2D[20];

			Random rand = new Random();
			for (int i = 0; i < atoms.Length; i++) {
				atoms[i] = new Atom2D(
					(float)rand.NextDouble(), (float)rand.NextDouble(),
					0f, 0f, (float)rand.NextDouble());
			}
		}

		private void InitializeWorker() {
			bgWorker = new BackgroundWorker();
			bgWorker.DoWork += new DoWorkEventHandler(RunThread);

			bgWorker.RunWorkerAsync();
		}

		private void InitializeBuffer() {
			buffer = new Bitmap(WIDTH, HEIGHT);
		}

		protected override void OnPaint(PaintEventArgs e) {
			base.OnPaint(e);
			e.Graphics.DrawImage(buffer, new Point(0, 0));
		}

		private void DrawAtomsToBuffer() {
			InitializeBuffer();

			foreach (Atom2D atom in atoms) {
				int x = (int)(atom.position.X * 100);
				int y = (int)(atom.position.Y * 100);

				for (int i = 0; i < 10; i++) {
					for (int j = 0; j < 10; j++) {
						drawPixel(x+i-5, y+j-5);
					}
				}
			}
		}

		void drawPixel(int x, int y) {
			if (x < 0 || x >= WIDTH || y < 0 || y >= HEIGHT) return;
			buffer.SetPixel(x, y, Color.Red);
		}

		void RunThread(object sender, DoWorkEventArgs e) {
			while (true) {
				foreach (Atom2D atom in atoms) {
					atom.UpdatePosition(atoms);
				}
				foreach (Atom2D atom in atoms) {
					atom.UpdateForces(atoms);
				}

				DrawAtomsToBuffer();

				this.Invoke((MethodInvoker)delegate {
					Refresh();
				});

				Thread.Sleep(50);
			}
		}
	}
}
