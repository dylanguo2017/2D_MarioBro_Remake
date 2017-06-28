using System;

namespace Game
{
    public class Physics
    {
        private Boolean falling;
        private int fallTime;
        private int xCoor;
        public int XCoor
        {
            get
            {
                return xCoor;
            }
            set
            {
                xCoor = value;
            }
        }
        public int yCoor;
        public int YCoor
        {
            get
            {
                return yCoor;
            }
            set
            {
                yCoor = value;
            }
        }

        public Physics(int inX, int inY)
        {
            xCoor = inX;
            yCoor = inY;
            falling = false;
            fallTime = -1;
        }

        public void Falls()
        {
            falling = true;
            fallTime = 0;
        }
        
        public void Update()
        {
            if (falling)
            {
                yCoor = yCoor - fallTime * fallTime;
            }
        }
    }
}
