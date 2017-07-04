using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game
{
    public class FireMario : IMario
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
        private DrawFireMario drawMar;
        private Rectangle destinationRectangle;
        private int animMod;

        public FireMario(MarioStateClass mainState, Texture2D spriteSheet)
        {
            marioState = mainState;
            texture = spriteSheet;
            leftFacingCurrentFrame = 36;
            rightFacingCurrentFrame = 28;
            marioState.curStat = MarioStateClass.marioStatus.fire;
            marioState.star = false;
            animMod = 0;
            drawMar = new DrawFireMario(this);
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
                    leftFacingCurrentFrame++;
                    if (leftFacingCurrentFrame == 38)
                        leftFacingCurrentFrame = 36;
                }
                else if (marioState.move && !marioState.facingLeft)
                {
                    rightFacingCurrentFrame++;
                    if (rightFacingCurrentFrame == 30)
                        rightFacingCurrentFrame = 28;
                }
            }
            marioState.marioPhys.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = drawMar.giveSource();

            if (!marioState.facingLeft && marioState.move && marioState.XCoor - marioState.offset > 400)
            {
                marioState.offset = marioState.XCoor - 400;
            }
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