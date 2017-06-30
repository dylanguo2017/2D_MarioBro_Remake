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
        public Boolean inv;
        public Physics marioPhys;
        public int offset = 0;

        public int XCoor
        {
            get
            {
                return marioPhys.XCoor;
            }
            set
            {
                marioPhys.XCoor = value;
            }
        }
        public int YCoor
        {
            get
            {
                return marioPhys.YCoor;
            }
            set
            {
                marioPhys.YCoor = value;
            }
        }

        public MarioStateClass(Boolean fLeft, Boolean jmp, Boolean crch, Boolean mv)
        {
            facingLeft = fLeft;
            crouch = crch;
            jump = jmp;
            move = mv;
            marioPhys = new Physics(48, 432);
            left = true;
            right = true;
            up = true;
            down = true;
            curStat = marioStatus.small;
            star = false;
            inv = false;
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
                        marioPhys.XCoor++;
                    }
                }
                else if (jump)
                {
                    move = true;
                    marioPhys.XCoor++;
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
                        marioPhys.XCoor--;
                    }

                }
                else if (jump)
                {
                    move = true;
                    facingLeft = true;
                    marioPhys.XCoor--;
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
                    if (marioPhys.YCoor < 432)
                    {
                        marioPhys.YCoor++;
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
                    marioPhys.yVel = -1;
                }
            }
        }
    }
}
