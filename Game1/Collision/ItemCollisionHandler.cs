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
            if (item is StarItem)
            {
                HandleStar(item, itemColFrom);
            }
            else if (item is GreenMushroomItem)
            {
                HandleGreenMushroom(item, itemColFrom);
            }
            else if (item is RedMushroomItem)
            {
                HandleRedMushroom(item, itemColFrom);
            }
        }


        private void HandleStar(IItem item, String itemColFrom)
        {
            StarItem star = item as StarItem;
            if (itemColFrom.Equals("left"))
            {
                star.movingRight = false;
            }
            else if (itemColFrom.Equals("right"))
            {
                star.movingRight = true;
            }
        }

        private void HandleGreenMushroom(IItem item, String itemColFrom)
        {
            GreenMushroomItem greenMushroom = item as GreenMushroomItem;
            if (itemColFrom.Equals("left"))
            {
                greenMushroom.movingRight = false;
            }
            else if (itemColFrom.Equals("right"))
            {
                greenMushroom.movingRight = true;
            }
        }

        private void HandleRedMushroom(IItem item, String itemColFrom)
        {
            RedMushroomItem redMushroom = item as RedMushroomItem;
            if (itemColFrom.Equals("left"))
            {
                redMushroom.movingRight = false;
            }
            else if (itemColFrom.Equals("right"))
            {
                redMushroom.movingRight = true;
            }
        }


    }
}