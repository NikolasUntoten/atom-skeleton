using System;
using System.Numerics;

namespace atom_skeleton {
	class Atom2D {
		public const float MINIMUM_FORCE = 0.001f;
		public const float SET_DISTANCE = 0.1f;
		public const float K = 1f;

		private Atom2D[] Connected;

		public Vector2 Position;
		public Vector2 Velocity;
		public float Rotation;

		public Atom2D(Vector2 initPosition, Vector2 initVelocity, float initRotation) {
			Setup(initPosition, initVelocity, initRotation);
		}

		public Atom2D() {
			Setup(new Vector2(), new Vector2(), 0);
		}

		public Atom2D(float posX, float posY, float velX, float velY, float rotation) {
			Setup(new Vector2(posX, posY),
				new Vector2(velX, velY),
				rotation);
		}

		private void Setup(Vector2 initPosition, Vector2 initVelocity, float initRotation) {
			Position = initPosition;
			Velocity = initVelocity;
			Rotation = initRotation;
			Connected = new Atom2D[0];
		}

		public void ConnectAtom(Atom2D atom) {
			Atom2D[] tempArr = new Atom2D[Connected.Length + 1];
			for (int i = 0; i < Connected.Length; i++) {
				tempArr[i] = Connected[i];
			}
			tempArr[Connected.Length] = atom;
			Connected = tempArr;
		}

		public void Push(float force, float direction) {
			Velocity.X += force * (float) Math.Sin(direction);
			Velocity.Y += force * (float) Math.Cos(direction);
		}

		public void UpdatePosition(Atom2D[] atoms) {
			Position.X += Velocity.X * 0.001f;
			Position.Y += Velocity.Y * 0.001f;
			Push(-Velocity.Length()*0.01f, (float) Math.Atan2(Velocity.X, Velocity.Y));
		}

		public void UpdateForces() {
			foreach (Atom2D atom in Connected) {
				float xDist = atom.Position.X - Position.X;
				float yDist = atom.Position.Y - Position.Y;
				float direction = (float)Math.Atan2(xDist, yDist);

				float distance = Vector2.Distance(Position, atom.Position);
				distance = Math.Abs(distance);
				float power = K * (SET_DISTANCE - distance);
				
				if (Math.Abs(power) >= MINIMUM_FORCE) {
					atom.Push(power, direction);
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
