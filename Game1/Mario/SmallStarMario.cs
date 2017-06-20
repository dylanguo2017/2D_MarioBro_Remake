using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game
{
    public class SmallStarMario : IMario
    {
        private MarioStateClass marioState;

        private Texture2D texture;

        MarioPositionDic marioPosition = new MarioPositionDic();

        private int rightFacingCurrentFrame;
        private int leftFacingCurrentFrame;
        private int duration;
        private Rectangle destinationRectangle;
        private bool altColor;
       

        public SmallStarMario(MarioStateClass mainState, Texture2D spriteSheet)
        {
            marioState = mainState;
            texture = spriteSheet;

            rightFacingCurrentFrame = 44;
            leftFacingCurrentFrame = 50;
            marioState.star = true;
            duration = 10;
            altColor = false;
        }
        public MarioStateClass.marioStatus currentStatus()
        {
            return marioState.curStat;
        }
        public void Update()
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

        public void Draw(SpriteBatch spriteBatch)
        {
            int width = 17;
            int height = 17;
            Rectangle sourceRectangle;

            if (!marioState.facingLeft)
            {
                if (marioState.move)
                {
                    if (!marioState.jump)
                    {
                        sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[rightFacingCurrentFrame].X, (int)this.marioPosition.PositionArr[rightFacingCurrentFrame].Y, width, height);
                        destinationRectangle = new Rectangle(marioState.XCoor, marioState.YCoor, width, height);
                    }
                    else
                    {
                        //RIGHT FACING JUMP + MOVE :Same as right jump
                        if (altColor)
                        {
                            sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[48].X, (int)this.marioPosition.PositionArr[48].Y, width, height);
                        }
                        else
                        {
                            sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[5].X, (int)this.marioPosition.PositionArr[5].Y, width, height);
                        }
                        destinationRectangle = new Rectangle(marioState.XCoor, marioState.YCoor, width, height);
                    }
                }
                else
                {

                    if (!marioState.jump)//right facing idle
                    {
                        if (altColor)
                        {
                            sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[43].X, (int)this.marioPosition.PositionArr[43].Y, width, height);
                        }
                        else
                        {
                            sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[0].X, (int)this.marioPosition.PositionArr[0].Y, width, height);
                        }
                        destinationRectangle = new Rectangle(marioState.XCoor, marioState.YCoor, width, height);
                    }
                    else// right jump
                    {
                        if (altColor)
                        {
                            sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[48].X, (int)this.marioPosition.PositionArr[48].Y, width, height);
                        }
                        else
                        {
                            sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[5].X, (int)this.marioPosition.PositionArr[5].Y, width, height);
                        }
                        destinationRectangle = new Rectangle(marioState.XCoor, marioState.YCoor, width, height);
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
                        destinationRectangle = new Rectangle(marioState.XCoor, marioState.YCoor, width, height);
                    }
                    else
                    {
                        //LEFT FACING JUMP + MOVE: Same as left jump 
                        if (altColor)
                        {
                            sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[54].X, (int)this.marioPosition.PositionArr[54].Y, width, height);
                        }
                        else
                        {
                            sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[11].X, (int)this.marioPosition.PositionArr[11].Y, width, height);
                        }
                        destinationRectangle = new Rectangle(marioState.XCoor, marioState.YCoor, width, height);
                    }
                }
                else
                {
                    if (!marioState.jump)//left facing idle
                    {
                        if (altColor)
                        {
                            sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[49].X, (int)this.marioPosition.PositionArr[49].Y, width, height);
                        }
                        else
                        {
                            sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[6].X, (int)this.marioPosition.PositionArr[6].Y, width, height);
                        }
                        destinationRectangle = new Rectangle(marioState.XCoor, marioState.YCoor, width, height);
                    }
                    else
                    {
                        if (altColor)
                        {
                            sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[54].X, (int)this.marioPosition.PositionArr[54].Y, width, height);
                        }
                        else
                        {
                            sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[11].X, (int)this.marioPosition.PositionArr[11].Y, width, height);
                        }
                        destinationRectangle = new Rectangle(marioState.XCoor, marioState.YCoor, width, height);
                    }
                }

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
