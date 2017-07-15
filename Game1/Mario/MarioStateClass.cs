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
        public int jmpCtr = 0;
        public bool wPress = false;

        public bool flagpole = false;

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

        public void MoveR()
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
                        marioPhys.xVel = 1;
                    }
                }
                else if (jump)
                {
                    move = true;
                    marioPhys.xVel = 1;
                    facingLeft = false;
                }
                else
                {
                    facingLeft = false;
                }
            }

        }

        public void MoveL()
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
                        if (marioPhys.XCoor > offset)
                        {
                            marioPhys.xVel = -1;
                        }
                    }

                }
                else if (jump)
                {
                    move = true;
                    facingLeft = true;
                    if (marioPhys.XCoor > offset)
                    {
                        marioPhys.xVel = -1;
                    }
                }
                else
                {
                    facingLeft = true;
                }
            }
        }

        public void MoveDown()
        {
            if (!curStat.Equals(marioStatus.dead) && !curStat.Equals(marioStatus.small))
            {
                if (!jump)
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
                else if (jmpCtr > 0 && !wPress)
                {
                    jmpCtr--;
                    marioPhys.falling = true;
                    jump = true;
                    marioPhys.yVel = -4;
                }
            }
        }
    }
}
