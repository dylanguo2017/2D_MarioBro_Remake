using System;

namespace Game
{
    class ItemCollisionHandler 
    {
        private Game myGame;
        public Game.sides hColFrom { get; set; }
        public Game.sides vColFrom { get; set; }

        public ItemCollisionHandler(Game game)
        {
            myGame = game;
        }

        public void HandleCollision(IItem item)
        {
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

            if (hColFrom.Equals(Game.sides.left))
            {
                star.movingRight = false;
            }
            else if (hColFrom.Equals(Game.sides.right))
            {
                star.movingRight = true;
            }

            if (vColFrom.Equals(Game.sides.top))
            {
                star.movingUp = true;
            }
            else if (vColFrom.Equals(Game.sides.bottom))
            {
                star.movingUp = false;
            }
        }

        private void HandleGreenMushroom(IItem item)
        {
            GreenMushroomItem greenMushroom = item as GreenMushroomItem;
            if (hColFrom.Equals(Game.sides.left))
            {
                greenMushroom.movingRight = false;
            }
            else if (hColFrom.Equals(Game.sides.right))
            {
                greenMushroom.movingRight = true;
            }

        }

        private void HandleRedMushroom(IItem item)
        {
            RedMushroomItem redMushroom = item as RedMushroomItem;
            if (hColFrom.Equals(Game.sides.left))
            {
                redMushroom.movingRight = false;
            }
            else if (hColFrom.Equals(Game.sides.right))
            {
                redMushroom.movingRight = true;
            }

        }


    }
}