using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace action_game.sources.model.character
{
    public struct Vector
    {
        public Vector(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y + z * z);
        }

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.x + b.x, a.y + b.y, a.z + b.z);
        }
        
        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.x - b.x, a.y - b.y, a.z - b.z);
        }

        public static Vector operator *(Vector a, float f)
        {
            return new Vector(a.x * f, a.y * f, a.z * f);
        }

        public static Vector operator /(Vector a, float f)
        {
            return new Vector(a.x / f, a.y / f, a.z / f);
        }

        public override String ToString()
        {
            return String.Format("{0},{1},{2}", x, y, z);
        }

        public float x;
        public float y;
        public float z;
    }

    public delegate void MovableEvent(IMovable movable);

    public interface IMovable
    {
        Vector SetPosition(float x, float y, float z);
        Vector CurrentPosition { get; }

        Vector SetVelocity(float x, float y, float z);
        Vector CurrentVelocity { get; }

        Vector SetRotation(float x, float y, float z);
        Vector CurrentRotation { get; }

        float Gravity { get; }

        void updateVelocity(float deltaTime);

        event MovableEvent OnMove;
        event MovableEvent OnChangeVelocity;
    }
}
