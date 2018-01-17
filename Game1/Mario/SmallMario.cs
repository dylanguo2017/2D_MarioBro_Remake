using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Game.Utility;

namespace Game
{
    public class SmallMario : IMario
    {
        private Game myGame;
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
        public bool visible { get; set; }

        public SmallMario(Game game)
        {
            myGame = game;
            marioState = myGame.marioState;
            texture = myGame.marioSprites;

            rightFacingCurrentFrame = 1;
            leftFacingCurrentFrame = 7;
            marioState.curStat = MarioStateClass.marioStatus.small;
            marioState.star = false;
            invCtr = 0;
            animMod = 0;
            drawMar = new DrawSmallMario(myGame, this);
            myGame.marioState.bat = false;

            visible = true;
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
            if (marioState.inv && invCtr == zero)
            {
                invCtr = 10;
            }

            if(animMod % twenty == zero)
            {
                if (invCtr > zero)
                {
                    invCtr--;
                    if (invCtr == zero)
                    {
                        marioState.inv = false;
                    }
                }
                if (marioState.move && marioState.facingLeft && !marioState.jump)
                {
                    leftFacingCurrentFrame++;
                    if (leftFacingCurrentFrame == nine)
                    {
                        leftFacingCurrentFrame = 7;
                    }
                }
                else if (marioState.move && !marioState.facingLeft && !marioState.jump)
                {
                    rightFacingCurrentFrame++;
                    if (rightFacingCurrentFrame == three)
                    {
                        rightFacingCurrentFrame = 1;
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (visible)
            {

                if (!marioState.facingLeft && marioState.move && marioState.XCoor - marioState.offset > fourHundred)
                {
                    marioState.offset = marioState.XCoor - fourHundred;
                }

                Rectangle sourceRectangle = drawMar.giveSource();
                destinationRectangle = new Rectangle(marioState.XCoor - marioState.offset, marioState.YCoor, sourceRectangle.Width, sourceRectangle.Height);
                if (invCtr % two == one)
                {
                    return;
                }
                spriteBatch.Begin();
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
                spriteBatch.End();
            }
    }

        public Rectangle DestinationRectangle()
        {
            return destinationRectangle;
        }
    }
}
