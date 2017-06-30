using System;

namespace Game
{
    public class Physics
    {
        public Boolean falling;
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
        public double yCoor;
        public double yVel;
        public double yAcc = 0.02;
        public int YCoor
        {
            get
            {
                return (int)yCoor;
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
            yVel = 0;
        }

        public void DontFall()
        {
            falling = false;
            yVel = 0;
        }
        
        public void Update()
        {
            if (falling)
            {        
                yVel += yAcc;
            }
            yCoor = yCoor + yVel;
            falling = true;
        }
    }
}
