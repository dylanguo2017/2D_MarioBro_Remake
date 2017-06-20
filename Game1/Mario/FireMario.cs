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

        public FireMario(MarioStateClass mainState, Texture2D spriteSheet)
        {
            marioState = mainState;
            texture = spriteSheet;

            leftFacingCurrentFrame = 36;
            rightFacingCurrentFrame = 28;
            marioState.curStat = MarioStateClass.marioStatus.fire;
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
                        sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[33].X, (int)this.marioPosition.PositionArr[33].Y, width, height);
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
                            sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[27].X, (int)this.marioPosition.PositionArr[27].Y, width, height);
                            destinationRectangle = new Rectangle(marioState.XCoor, marioState.YCoor - 16, width, height);
                        }
                        else
                        {
                            //RIGHT FACING JUMP
                            sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[33].X, (int)this.marioPosition.PositionArr[33].Y, width, height);
                            destinationRectangle = new Rectangle(marioState.XCoor, marioState.YCoor - 16, width, height);
                        }
                    }
                    else
                    {
                        //RIGHT FACING CROUCH   
                        sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[34].X, (int)this.marioPosition.PositionArr[34].Y, width, height);
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
                        sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[41].X, (int)this.marioPosition.PositionArr[41].Y, width, height);
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
                            sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[35].X, (int)this.marioPosition.PositionArr[35].Y, width, height);
                            destinationRectangle = new Rectangle(marioState.XCoor, marioState.YCoor - 16, width, height);
                        }
                        else
                        {
                            //LEFT FACING JUMP
                            sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[41].X, (int)this.marioPosition.PositionArr[41].Y, width, height);
                            destinationRectangle = new Rectangle(marioState.XCoor, marioState.YCoor - 16, width, height);
                        }
                    }
                    else
                    {
                        //LEFT FACING CROUCH                        
                        sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[42].X, (int)this.marioPosition.PositionArr[42].Y, width, height);
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
