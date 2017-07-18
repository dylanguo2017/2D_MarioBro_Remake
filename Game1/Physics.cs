using System;

namespace Game
{
    public class Physics
    {
        public Boolean falling;
        private int xCoor;
        public int xVel;
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
        public double yAcc = 0.2;
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
            xVel = 0;
        }

        public void DontFall()
        {
            falling = false;
            yVel = 0;
        }
        public void Bounce()
        {
            yVel = -3;
        }
        public void Update()
        {
            if (falling)
            {        
                yVel += yAcc;
            }
            xCoor = xCoor + xVel;
            xVel = 0;
            yCoor = yCoor + yVel;
            falling = true;
        }
        public void Spawn(int x, int y)
        {
            xCoor = x;
            yCoor = y;
        }
    }
}
