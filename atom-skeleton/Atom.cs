using System;
using System.Numerics;

namespace atom_skeleton {
	class Atom2D {
		public const float MINIMUM_FORCE = 0.001f;

		public Vector2 position;
		public Vector2 velocity;
		public float rotation;

		public Atom2D(Vector2 initPosition, Vector2 initVelocity, float initRotation) {
			setup(initPosition, initVelocity, initRotation);
		}

		public Atom2D() {
			setup(new Vector2(), new Vector2(), 0);
		}

		public Atom2D(float posX, float posY, float velX, float velY, float rotation) {
			setup(new Vector2(posX, posY),
				new Vector2(velX, velY),
				rotation);
		}

		private void setup(Vector2 initPosition, Vector2 initVelocity, float initRotation) {
			position = initPosition;
			velocity = initVelocity;
			rotation = initRotation;
		}

		public void push(float force, float direction) {
			velocity.X += force * (float) Math.Sin(direction);
			velocity.Y += force * (float) Math.Cos(direction);
		}

		public void updatePosition(Atom2D[] atoms) {
			position.X += velocity.X;
			position.Y += velocity.Y;
		}

		public void updateForces(Atom2D[] atoms) {
			foreach (Atom2D atom in atoms) {
				if (this != atom) {
					float xDist = atom.position.X - position.X;
					float yDist = atom.position.Y - position.Y;
					float direction = (float)Math.Atan2(yDist, xDist);
					float power = 1 / Vector2.DistanceSquared(atom.position, position);

					if (power >= MINIMUM_FORCE) {
						atom.push(power, direction);
					}
				}
			}
		}
	}

	class Atom3D {
		public Vector3 position;
		public Vector3 velocity;
		public Vector2 rotation;
	}
}
