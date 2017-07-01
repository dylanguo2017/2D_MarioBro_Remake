using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{ 
    public class ProjectileBlockCollisionHandler : ICollisionResponseProjectile
    {
        private Game myGame;

        public ProjectileBlockCollisionHandler(Game game)
        {
            myGame = game;
        }

        public void HandleCollision(Fireball fBalls, IObject gameObject, String marioCollidesFromHorizontalSide, String marioCollidesFromVerticalSide)
        {
            ISprite block = gameObject as ISprite;
            if (marioCollidesFromVerticalSide.Equals("top"))
            {
                fBalls.Bounce();
            }
            else
            {
                fBalls.Delete();
            }
        }
    }
}
