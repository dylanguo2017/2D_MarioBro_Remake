using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game
{
    public class SmallStarMario : IMario
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
        private DrawSmallStarMario drawMar;
        private int duration;
        private Rectangle destinationRectangle;
        private bool altColor;
        public bool AltColor
        {
            get
            {
                return altColor;
            }
        }
        private int animMod;


        public SmallStarMario(MarioStateClass mainState, Texture2D spriteSheet)
        {
            marioState = mainState;
            texture = spriteSheet;

            rightFacingCurrentFrame = 44;
            leftFacingCurrentFrame = 50;
            marioState.star = true;
            marioState.curStat = MarioStateClass.marioStatus.small;
            duration = 10;
            altColor = false;
            animMod = 0;
            drawMar = new DrawSmallStarMario(this);
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
                if (marioState.move && marioState.facingLeft && !marioState.jump)
                {
                    leftFacingCurrentFrame++;
                    if (leftFacingCurrentFrame == 52)
                    {
                        leftFacingCurrentFrame = 50;
                    }
                }
                else if (marioState.move && !marioState.facingLeft && !marioState.jump)
                {
                    rightFacingCurrentFrame++;
                    if (rightFacingCurrentFrame == 46)
                    {
                        rightFacingCurrentFrame = 44;
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
            destinationRectangle = new Rectangle(marioState.XCoor - marioState.offset, marioState.YCoor, sourceRectangle.Width, sourceRectangle.Height);

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
