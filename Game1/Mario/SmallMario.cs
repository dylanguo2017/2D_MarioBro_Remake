using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game
{
    public class SmallMario : IMario
    {
        public MarioStateClass marioState;
        public MarioStateClass MarState
        {
            get
            {
                return marioState;
            }
        }
        public Texture2D texture;

        MarioPositionDic marioPosition = new MarioPositionDic();

        private int rightFacingCurrentFrame;
        public int RightFrame
        {
            get
            {
                return rightFacingCurrentFrame;
            }
        }
        private int leftFacingCurrentFrame;
        public int LeftFrame
        {
            get
            {
                return leftFacingCurrentFrame;
            }
        }
        private DrawSmallMario drawMar;
        private Rectangle destinationRectangle;
        private int invCtr;
        private int animMod;

        public SmallMario(MarioStateClass mainState, Texture2D spriteSheet)
        {
            marioState = mainState;
            texture = spriteSheet;

            rightFacingCurrentFrame = 1;
            leftFacingCurrentFrame = 7;
            marioState.curStat = MarioStateClass.marioStatus.small;
            marioState.star = false;
            invCtr = 0;
            animMod = 0;
            drawMar = new DrawSmallMario(this);
        }

        public MarioStateClass.marioStatus currentStatus()
        {
            return marioState.curStat;
        }

        public void Update()
        {
            animMod++;
            if (marioState.marioPhys.falling)
            {
                marioState.jump = true;
            }
            marioState.marioPhys.Update();
            if (marioState.inv && invCtr == 0)
            {
                invCtr = 10;
            }

            if(animMod % 20 == 0)
            {
                if (invCtr > 0)
                {
                    invCtr--;
                    if (invCtr == 0)
                    {
                        marioState.inv = false;
                    }
                }
                if (marioState.move && marioState.facingLeft && !marioState.jump)
                {
                    leftFacingCurrentFrame++;
                    if (leftFacingCurrentFrame == 9)
                    {
                        leftFacingCurrentFrame = 7;
                    }
                }
                else if (marioState.move && !marioState.facingLeft && !marioState.jump)
                {
                    rightFacingCurrentFrame++;
                    if (rightFacingCurrentFrame == 3)
                    {
                        rightFacingCurrentFrame = 1;
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!marioState.facingLeft && marioState.move && marioState.XCoor - marioState.offset > 400)
            {
                marioState.offset = marioState.XCoor - 400;
            }

            Rectangle sourceRectangle = drawMar.giveSource();
            destinationRectangle = new Rectangle(marioState.XCoor - marioState.offset, marioState.YCoor, sourceRectangle.Width, sourceRectangle.Height);
            if (invCtr % 2 == 1)
            {
                return;
            }
            spriteBatch.Begin();            
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
    }

        public Rectangle DestinationRectangle()
        {
            return destinationRectangle;
        }
    }
}
