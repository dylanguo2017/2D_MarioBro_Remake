using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game
{
    public class LargeStarMario : IMario
    {
        private MarioStateClass marioState;

        MarioPositionDic marioPosition = new MarioPositionDic();

        private Texture2D texture;

        private int rightFacingCurrentFrame;
        private int leftFacingCurrentFrame;
        public int duration;
        private Rectangle destinationRectangle;

        public LargeStarMario(MarioStateClass mainState, Texture2D spriteSheet)
        {
            marioState = mainState;
            texture = spriteSheet;

            leftFacingCurrentFrame = 63;
            rightFacingCurrentFrame = 56;
            marioState.star = true;
            marioState.curStat = MarioStateClass.marioStatus.large;
            duration = 10;
        }

        public MarioStateClass.marioStatus currentStatus()
        {
            return marioState.curStat;
        }

        public void Update()
        {

            if (marioState.move && marioState.facingLeft)
            {
                leftFacingCurrentFrame++;
                if (leftFacingCurrentFrame == 65)
                    leftFacingCurrentFrame = 63;
            }
            else if (marioState.move && !marioState.facingLeft)
            {
                rightFacingCurrentFrame++;
                if (rightFacingCurrentFrame == 58)
                    rightFacingCurrentFrame = 56;
            }
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
                        //RIGHT FACING MOVE
                        sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[rightFacingCurrentFrame].X, (int)this.marioPosition.PositionArr[rightFacingCurrentFrame].Y, width, height);
                        destinationRectangle = new Rectangle(marioState.XCoor, marioState.YCoor - 16, width, height);
                    }
                    else
                    {
                        //RIGHT FACING JUMP + MOVE :Same as right jump
                        sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[60].X, (int)this.marioPosition.PositionArr[60].Y, width, height);
                        destinationRectangle = new Rectangle(marioState.XCoor, marioState.YCoor - 16, width, height);
                    }
                }
                else
                {
                    if (!marioState.crouch)
                    {
                        if (!marioState.jump)
                        {
                            //RIGHT FACING IDLE
                            sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[55].X, (int)this.marioPosition.PositionArr[55].Y, width, height);
                            destinationRectangle = new Rectangle(marioState.XCoor, marioState.YCoor - 16, width, height);
                        }
                        else
                        {
                            //RIGHT FACING JUMP
                            sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[60].X, (int)this.marioPosition.PositionArr[60].Y, width, height);
                            destinationRectangle = new Rectangle(marioState.XCoor, marioState.YCoor - 16, width, height);
                        }
                    }
                    else
                    {
                        //RIGHT FACING CROUCH   
                        sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[61].X, (int)this.marioPosition.PositionArr[61].Y, width, height);
                        destinationRectangle = new Rectangle(marioState.XCoor, marioState.YCoor - 16, width, height);
                    }
                }
            }
            else
            {
                //Left facing sprite

                if (marioState.move)
                {
                    if (!marioState.jump)
                    {
                        //LEFT FACING MOVE                       
                        sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[leftFacingCurrentFrame].X, (int)this.marioPosition.PositionArr[leftFacingCurrentFrame].Y, width, height);
                    }
                    else
                    {
                        //LEFT FACING JUMP + MOVE
                        sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[67].X, (int)this.marioPosition.PositionArr[67].Y, width, height);
                    }
                    destinationRectangle = new Rectangle(marioState.XCoor, marioState.YCoor - 16, width, height);
                }
                else
                {
                    if (!marioState.crouch)
                    {
                        if (!marioState.jump)
                        {
                            //LEFT FACING IDLE
                            sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[62].X, (int)this.marioPosition.PositionArr[62].Y, width, height);
                            destinationRectangle = new Rectangle(marioState.XCoor, marioState.YCoor - 16, width, height);
                        }
                        else
                        {
                            //LEFT FACING JUMP
                            sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[67].X, (int)this.marioPosition.PositionArr[67].Y, width, height);
                            destinationRectangle = new Rectangle(marioState.XCoor, marioState.YCoor - 16, width, height);
                        }
                    }
                    else
                    {
                        //LEFT FACING CROUCH                        
                        sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[68].X, (int)this.marioPosition.PositionArr[68].Y, width, height);
                        destinationRectangle = new Rectangle(marioState.XCoor, marioState.YCoor - 16, width, height);
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
