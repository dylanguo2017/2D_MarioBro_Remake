using System;

namespace Game
{
    public class MarioStateClass
    {
        public Boolean facingLeft;
        public Boolean crouch;
        public Boolean jump;
        public Boolean move;
        public Boolean up;
        public Boolean down;
        public Boolean left;
        public Boolean right;
        public enum marioStatus { large, fire, small, dead};
        public marioStatus curStat;
        public bool star;
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

        public MarioStateClass(Boolean fLeft, Boolean jmp, Boolean crch, Boolean mv)
        {
            facingLeft = fLeft;
            crouch = crch;
            jump = jmp;
            move = mv;
            xCoor = 300;
            yCoor = 300;
            left = true;
            right = true;
            up = true;
            down = true;
            curStat = marioStatus.small;
            star = false;
        }

        public void moveR()
        {
            if (right && !(curStat.Equals(marioStatus.dead)))
            {

                if (facingLeft && move && !jump)
                {
                    move = false;
                }
                else if (!facingLeft && !move && !jump)
                {
                    if (curStat.Equals(marioStatus.small) || !crouch)
                    {
                        move = true;
                        crouch = false;
                        xCoor++;
                    }
                }
                else if (jump)
                {
                    move = false;
                    xCoor++;
                    facingLeft = false;
                }
                else
                {
                    facingLeft = false;
                }
            }

        }

        public void moveL()
        {
            if (left && !(curStat.Equals(marioStatus.dead)))
            {

                if (!facingLeft && move && !jump)
                {
                    move = false;
                }
                else if (facingLeft && !move && !jump)
                {
                    if (curStat.Equals(marioStatus.small) || !crouch)
                    {
                        move = true;
                        crouch = false;
                        xCoor--;
                    }

                }
                else if (jump)
                {
                    move = false;
                    facingLeft = true;
                    xCoor--;
                }
                else
                {
                    facingLeft = true;
                }
            }
        }

        public void moveDown()
        {
            if (down && !(curStat.Equals(marioStatus.dead)))
            {

                if (jump)
                {
                    if (yCoor < 300)
                    {
                        yCoor++;
                    }
                    else
                    {
                        jump = false;
                    }
                }
                else
                {
                    crouch = true;
                    move = false;
                }
            }
        }

        public void moveUp()
        {
            if (up && !(curStat.Equals(marioStatus.dead)))
            {

                if (crouch)
                {
                    crouch = false;
                }
                else
                {
                    jump = true;
                    yCoor--;
                }
            }
        }
    }
}
