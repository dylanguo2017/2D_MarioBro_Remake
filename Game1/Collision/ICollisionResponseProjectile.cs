using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    interface ICollisionResponseProjectile
    {
        void HandleCollision(Fireball fBalls, IObject gameObject, String marioCollidesFromHorizontalSide, String marioCollidesFromVerticalSide);
    }
}
