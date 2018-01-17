using static Game.Utility;

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
            if (item is Star)
            {
                HandleStar(item);
            }
            else if (item is GreenMushroom)
            {
                HandleGreenMushroom(item);
            }
            else if (item is RedMushroom)
            {
                HandleRedMushroom(item);
            }
        }

        private void HandleStar(IItem item)
        {
            Star star = item as Star;

            if (hColFrom.Equals(sides.left))
            {
                star.movingR = false;
            }
            else if (hColFrom.Equals(sides.right))
            {
                star.movingR = true;
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
            GreenMushroom greenMushroom = item as GreenMushroom;
            if (hColFrom.Equals(sides.left))
            {
                greenMushroom.movingR = false;
            }
            else if (hColFrom.Equals(sides.right))
            {
                greenMushroom.movingR = true;
            }
            if (vColFrom.Equals(sides.top))
            {
                greenMushroom.gmPhysics.DontFall();
            }

        }

        private void HandleRedMushroom(IItem item)
        {
            RedMushroom redMushroom = item as RedMushroom;
            if (hColFrom.Equals(sides.left))
            {
                redMushroom.movingR = false;
            }
            else if (hColFrom.Equals(sides.right))
            {
                redMushroom.movingR = true;
            }
            if (vColFrom.Equals(sides.top))
            {
                redMushroom.rmPhysics.DontFall();
            }

        }


    }
}