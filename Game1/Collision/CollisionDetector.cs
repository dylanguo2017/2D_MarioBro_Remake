using Microsoft.Xna.Framework;
using static Game.Utility;

namespace Game.Collision
{
    public class CollisionDetector
    {
        public sides hColFrom;
        public sides vColFrom;

        public CollisionDetector()
        {
            hColFrom = sides.none;
            vColFrom = sides.none;
        }

        public void CollidesFrom(Rectangle rec1, Rectangle rec2)
        {
            hColFrom = sides.none;
            vColFrom = sides.none;

            if ((rec1.Top <= rec2.Top && rec1.Bottom >= rec2.Top + two) || (rec1.Top > rec2.Top && rec2.Bottom >= rec1.Top - two))
            {
                if (rec1.Right > rec2.Right)
                {
                    hColFrom = sides.right;
                }
                else if (rec1.Left < rec2.Left)
                {
                    hColFrom = sides.left;
                }
            }

            if ((rec1.Left <= rec2.Left && rec1.Right >= rec2.Left + two) || (rec1.Left > rec2.Left && rec2.Right >= rec1.Left - two))
            {
                if (rec1.Bottom > rec2.Bottom)
                {
                    vColFrom = sides.bottom;
                }
                else if (rec1.Top < rec2.Top)
                {
                    vColFrom = sides.top;
                }
            }

        }
    }
}
