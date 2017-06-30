using System;

namespace Game
{
    public class Physics
    {
        private Boolean falling;
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
        public int yVel = 5;
        public int yAcc = 1;
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
        }

        public void DontFall()
        {
            falling = false;
        }
        
        public void Update()
        {
            if (falling)
            {
                yCoor = yCoor + 1;
                //yVel += yAcc;
            }
            System.Diagnostics.Debug.WriteLine("Ycoor" + yCoor);
            System.Diagnostics.Debug.WriteLine("stat" + falling);
            falling = true;
        }
    }
}
