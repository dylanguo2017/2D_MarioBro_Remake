using System;

namespace Game
{
    class ItemCollisionHandler 
    {
        private Game myGame;

        public ItemCollisionHandler(Game game)
        {
            myGame = game;
        }

        public void HandleCollision(IItem item, String itemColFrom)
        {
            if (itemColFrom.Equals("left"))
            {
                //item.right = false;
            }
            else if (itemColFrom.Equals("right"))
            {
                //item.right = true;
            }
        }

    }
}