using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace atom_skeleton {
	class Panel1 : Panel {

		private Atom2D[] atoms;

		public Panel1() {
			atoms = new Atom2D[20];

			Random rand = new Random();
			for (int i = 0; i < atoms.Length; i++) {
				atoms[i] = new Atom2D(
					(float)rand.NextDouble(), (float)rand.NextDouble(),
					.1f, .1f, (float)rand.NextDouble());
			}
		}

		protected override void OnPaint(PaintEventArgs e) {
			base.OnPaint(e);

			foreach (Atom2D atom in atoms) {
				atom.updatePosition(atoms);
			}
			foreach (Atom2D atom in atoms) {
				atom.updateForces(atoms);
			}

			Graphics g = e.Graphics;
			Pen myPen = new Pen(Color.Red);

			//g.DrawRectangle(myPen, new Rectangle(0, 0, 90, 90));

			foreach (Atom2D atom in atoms) {
				int x = (int) (atom.position.X * 100);
				int y = (int) (atom.position.Y * 100);
				g.DrawEllipse(myPen, x, y, 5, 5);
			}

			myPen.Dispose();
			g.Dispose();
		}
	}
}
