using System;

namespace Game
{
    public interface ICollisionResponse
    {
        void HandleCollision(IMario mario, IObject gameObject, String marioCollidesFromHorizontalSide, String marioCollidesFromVerticalSide);
    }
}
