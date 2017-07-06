using System;

namespace Game
{
    class ItemCollisionHandler 
    {
        private Game myGame;
        private String horizontalSide;
        private String verticalSide;

        public ItemCollisionHandler(Game game)
        {
            myGame = game;
        }

        public void HandleCollision(IItem item, String itemColFromHorizontalSide, String itemColFromVerticalSide)
        {
            horizontalSide = itemColFromHorizontalSide;
            verticalSide = itemColFromVerticalSide;

            if (item is StarItem)
            {
                HandleStar(item);
            }
            else if (item is GreenMushroomItem)
            {
                HandleGreenMushroom(item);
            }
            else if (item is RedMushroomItem)
            {
                HandleRedMushroom(item);
            }
        }


        private void HandleStar(IItem item)
        {
            StarItem star = item as StarItem;
            if (horizontalSide.Equals("left"))
            {
                star.movingRight = false;
            }
            else if (horizontalSide.Equals("right"))
            {
                star.movingRight = true;
            }

            if (verticalSide.Equals("top"))
            {
                // item moves up
            }
            else if (verticalSide.Equals("bottom"))
            {
                // item moves down
            }
        }

        private void HandleGreenMushroom(IItem item)
        {
            GreenMushroomItem greenMushroom = item as GreenMushroomItem;
            if (horizontalSide.Equals("left"))
            {
                greenMushroom.movingRight = false;
            }
            else if (horizontalSide.Equals("right"))
            {
                greenMushroom.movingRight = true;
            }

            if (verticalSide.Equals("top"))
            {
                // item moves up
            }
            else if (verticalSide.Equals("bottom"))
            {
                // item moves down
            }
        }

        private void HandleRedMushroom(IItem item)
        {
            RedMushroomItem redMushroom = item as RedMushroomItem;
            if (horizontalSide.Equals("left"))
            {
                redMushroom.movingRight = false;
            }
            else if (horizontalSide.Equals("right"))
            {
                redMushroom.movingRight = true;
            }

            if (verticalSide.Equals("top"))
            {
                // item moves up
            }
            else if (verticalSide.Equals("bottom"))
            {
                // item moves down
            }
        }


    }
}