using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game
{
    public class LargeMario : IMario
    {
        private MarioStateClass marioState;

        private Texture2D texture;

        MarioPositionDic marioPosition = new MarioPositionDic();

        private int rightFacingCurrentFrame;
        private int leftFacingCurrentFrame;

        private Rectangle destinationRectangle;
        private int invCtr;


        public LargeMario(MarioStateClass mainState, Texture2D spriteSheet)
        {
            marioState = mainState;
            texture = spriteSheet;

            rightFacingCurrentFrame = 14;
            leftFacingCurrentFrame = 21;
            marioState.curStat = MarioStateClass.marioStatus.large;
            marioState.star = false;
            invCtr = 0;
        }

        public MarioStateClass.marioStatus currentStatus()
        {
            return marioState.curStat;
        }

        public void Update()
        {
            if (marioState.inv && invCtr == 0)
            {
                invCtr = 10;
            }
            if (invCtr > 0)
            {
                invCtr--;
                if (invCtr == 0)
                {
                    marioState.inv = false;
                }
                System.Diagnostics.Debug.WriteLine("TIME:" + invCtr);
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

        public void Draw(SpriteBatch spriteBatch)
        {
            if (invCtr % 2 == 1)
            {
                return;
            }
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
                        sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[18].X, (int)this.marioPosition.PositionArr[18].Y, width, height);
                    }
                }
                else
                {
                    if (!marioState.crouch)
                    {
                        if (!marioState.jump)
                        {
                            sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[13].X, (int)this.marioPosition.PositionArr[13].Y, width, height);
                        }
                        else
                        {

                            sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[18].X, (int)this.marioPosition.PositionArr[18].Y, width, height);
                        }
                    }
                    else
                    {

                        sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[19].X, (int)this.marioPosition.PositionArr[19].Y, width, height);
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
                        sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[25].X, (int)this.marioPosition.PositionArr[25].Y, width, height);
                    }
                }
                else
                {
                    if (!marioState.crouch)
                    {

                        if (!marioState.jump)
                        {
                            sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[20].X, (int)this.marioPosition.PositionArr[20].Y, width, height);
                        }
                        else
                        {
                            sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[25].X, (int)this.marioPosition.PositionArr[25].Y, width, height);
                        }
                    }
                    else
                    {
                        sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[26].X, (int)this.marioPosition.PositionArr[26].Y, width, height);
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
