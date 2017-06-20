using System;

namespace Game
{
    interface ICollisionResponse
    {
        void HandleCollison(IMario mario, IObject gameObject, String marioCollidesFromHorizontalSide, String marioCollidesFromVerticalSide);
    }
}
