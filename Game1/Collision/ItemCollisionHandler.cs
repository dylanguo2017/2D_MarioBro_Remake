using System;

namespace Game
{
    class ItemCollisionHandler /*: ICollisionResponse*/
    {
        private Game myGame;

        public ItemCollisionHandler(Game game)
        {
            myGame = game;
        }

        public void HandleCollision(ISprite item, String itemCollidesFrom)
        {
            if (itemCollidesFrom.Equals("left"))
            {
                // item bounces back to the right
            }
            else if (itemCollidesFrom.Equals("right"))
            {
                // item bounces back to the left
            }
        }

    }
}