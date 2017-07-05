using Microsoft.Xna.Framework;

namespace Game
{
    public interface ICollisionDetector
    {
        void Update();
        void CollidesFrom(Rectangle objectRec);
    }
}
