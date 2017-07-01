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
                item.right = false;
            }
            else if (itemCollidesFrom.Equals("right"))
            {
                item.right = true;
            }
        }

    }
}