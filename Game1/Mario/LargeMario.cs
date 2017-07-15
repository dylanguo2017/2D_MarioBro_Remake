using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game
{
    public class LargeMario : IMario
    {
        private MarioStateClass marioState;
        public MarioStateClass MarState
        {
            get
            {
                return marioState;
            }
        }
        private Texture2D texture;

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
        private DrawLargeMario drawMar;
        private Rectangle destinationRectangle;
        private int invCtr;
        private int animMod;


        public LargeMario(MarioStateClass mainState, Texture2D spriteSheet)
        {
            marioState = mainState;
            texture = spriteSheet;
            rightFacingCurrentFrame = 14;
            leftFacingCurrentFrame = 21;
            marioState.curStat = MarioStateClass.marioStatus.large;
            marioState.star = false;
            invCtr = 0;
            animMod = 0;
            drawMar = new DrawLargeMario(this);
        }

        public MarioStateClass.marioStatus currentStatus()
        {
            return marioState.curStat;
        }

        public void Update()
        {
            animMod++;
            if (marioState.inv && invCtr == 0)
            {
                invCtr = 10;
            }

            marioState.marioPhys.Update();
            if (animMod % 20 == 0)
            {
                if (invCtr > 0)
                {
                    invCtr--;
                    if (invCtr == 0)
                    {
                        marioState.inv = false;
                    }
                }
                if (marioState.move && marioState.facingLeft)
                {
                    leftFacingCurrentFrame++;
                    if (leftFacingCurrentFrame == 23)
                        leftFacingCurrentFrame = 21;
                }
                else if (marioState.move && !marioState.facingLeft)
                {
                    rightFacingCurrentFrame++;

                    if (rightFacingCurrentFrame == 16)
                        rightFacingCurrentFrame = 14;

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

            destinationRectangle = new Rectangle(marioState.XCoor - marioState.offset, marioState.YCoor - 16, sourceRectangle.Width, sourceRectangle.Height);
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
