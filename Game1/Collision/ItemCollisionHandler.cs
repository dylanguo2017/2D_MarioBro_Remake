using static Game.Game;
using System;

namespace Game
{
    class ItemCollisionHandler 
    {
        private Game myGame;
        public sides hColFrom { get; set; }
        public sides vColFrom { get; set; }

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

            if (hColFrom.Equals(sides.left))
            {
                star.movingRight = false;
            }
            else if (hColFrom.Equals(sides.right))
            {
                star.movingRight = true;
            }

            if (vColFrom.Equals(sides.top))
            {
                star.movingUp = true;
            }
            else if (vColFrom.Equals(sides.bottom))
            {
                star.movingUp = false;
            }
        }

        private void HandleGreenMushroom(IItem item)
        {
            GreenMushroomItem greenMushroom = item as GreenMushroomItem;
            if (hColFrom.Equals(sides.left))
            {
                greenMushroom.movingRight = false;
            }
            else if (hColFrom.Equals(sides.right))
            {
                greenMushroom.movingRight = true;
            }

        }

        private void HandleRedMushroom(IItem item)
        {
            RedMushroomItem redMushroom = item as RedMushroomItem;
            if (hColFrom.Equals(sides.left))
            {
                redMushroom.movingRight = false;
            }
            else if (hColFrom.Equals(sides.right))
            {
                redMushroom.movingRight = true;
            }
            if (vColFrom.Equals(sides.top))
            {
                redMushroom.rmPhysics.DontFall();
            }

        }


    }
}