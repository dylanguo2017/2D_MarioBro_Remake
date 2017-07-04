using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game
{
    public class LargeStarMario : IMario
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
        private DrawLargeStarMario drawMar;
        public int duration;
        private Rectangle destinationRectangle;
        private int animMod;
        private bool altColor;
        public bool AltColor
        {
            get
            {
                return altColor;
            }
        }


        public LargeStarMario(MarioStateClass mainState, Texture2D spriteSheet)
        {
            marioState = mainState;
            texture = spriteSheet;

            leftFacingCurrentFrame = 63;
            rightFacingCurrentFrame = 56;
            marioState.star = true;
            marioState.curStat = MarioStateClass.marioStatus.large;
            duration = 10;
            altColor = false;
            animMod = 0;
            drawMar = new DrawLargeStarMario(this);
        }

        public MarioStateClass.marioStatus currentStatus()
        {
            return marioState.curStat;
        }

        public void Update()
        {
            animMod++;
            if (animMod % 20 == 0)
            {
                if (marioState.move && marioState.facingLeft)
                {
                    if (leftFacingCurrentFrame == 63)
                    {
                        leftFacingCurrentFrame = 22;
                    }
                    else
                    {
                        leftFacingCurrentFrame = 63;
                    }
                }
                else if (marioState.move && !marioState.facingLeft)
                {
                    if (rightFacingCurrentFrame == 57)
                    {
                        rightFacingCurrentFrame = 14;
                    }  
                    else
                    {
                        rightFacingCurrentFrame = 57;
                    }
                }
                altColor = !altColor;
            }
            marioState.marioPhys.Update();

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            
            if (!marioState.facingLeft && marioState.move && marioState.XCoor - marioState.offset > 400)
            {
                marioState.offset = marioState.XCoor - 400;
            }
            Rectangle sourceRectangle = drawMar.giveSource();
            destinationRectangle = new Rectangle(marioState.XCoor - marioState.offset, marioState.YCoor - 16, sourceRectangle.Width, sourceRectangle.Height);
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
