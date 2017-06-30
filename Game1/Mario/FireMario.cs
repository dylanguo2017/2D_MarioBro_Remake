using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game
{
    public class FireMario : IMario
    {
        private MarioStateClass marioState;

        MarioPositionDic marioPosition = new MarioPositionDic();

        private Texture2D texture;

        private int rightFacingCurrentFrame;
        private int leftFacingCurrentFrame;

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
            int width = 17;
            int height = 33;
            Rectangle sourceRectangle;

            if (!marioState.facingLeft)
            {

                if (marioState.move)
                {
                    if (!marioState.jump)
                    {
                        sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[rightFacingCurrentFrame].X, (int)this.marioPosition.PositionArr[rightFacingCurrentFrame].Y, width, height);
                    }
                    else
                    {
                        sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[33].X, (int)this.marioPosition.PositionArr[33].Y, width, height);
                    }
                }
                else
                {
                    if (!marioState.crouch)
                    {
                        if (!marioState.jump)
                        {
                            sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[27].X, (int)this.marioPosition.PositionArr[27].Y, width, height);
                        }
                        else
                        {
                            sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[33].X, (int)this.marioPosition.PositionArr[33].Y, width, height);
                        }
                    }
                    else
                    {
                        sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[34].X, (int)this.marioPosition.PositionArr[34].Y, width, height);
                    }
                }
            }
            else
            {

                if (marioState.move)
                {
                    if (!marioState.jump)
                    {
                        sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[leftFacingCurrentFrame].X, (int)this.marioPosition.PositionArr[leftFacingCurrentFrame].Y, width, height);
                    }
                    else
                    {
                        sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[41].X, (int)this.marioPosition.PositionArr[41].Y, width, height);
                    }
                }
                else
                {
                    if (!marioState.crouch)
                    {
                        if (!marioState.jump)
                        {
                            sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[35].X, (int)this.marioPosition.PositionArr[35].Y, width, height);
                        }
                        else
                        {
                            sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[41].X, (int)this.marioPosition.PositionArr[41].Y, width, height);
                        }
                    }
                    else
                    {
                        sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[42].X, (int)this.marioPosition.PositionArr[42].Y, width, height);
                    }
                }
            }

            if (!marioState.facingLeft && marioState.move && marioState.XCoor - marioState.offset > 400)
            {
                marioState.offset = marioState.XCoor - 400;
            }
            destinationRectangle = new Rectangle(marioState.XCoor - marioState.offset, marioState.YCoor - 16, width, height);

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
