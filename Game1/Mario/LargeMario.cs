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

        public LargeMario(MarioStateClass mainState, Texture2D spriteSheet)
        {
            marioState = mainState;
            texture = spriteSheet;

            rightFacingCurrentFrame = 14;
            leftFacingCurrentFrame = 21;
            marioState.curStat = MarioStateClass.marioStatus.large;
            marioState.star = false;
        }

        public MarioStateClass.marioStatus currentStatus()
        {
            return marioState.curStat;
        }

        public void Update()
        {
            //update is only for moving. this is a template logic, still needs fixing
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
            int width = 17;
            int height = 33;
            Rectangle sourceRectangle;

            //only put codes if there's an empty line below the comment
            if (!marioState.facingLeft)
            {
                //DO EVERYTHING FOR RIGHT FACING SPRITE IN THIS BLOCK. don't put codes below THIS comment
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
                        sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[18].X, (int)this.marioPosition.PositionArr[18].Y, width, height);
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
                            sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[13].X, (int)this.marioPosition.PositionArr[13].Y, width, height);
                        }
                        else
                        {
                            //RIGHT FACING JUMP                            

                            sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[18].X, (int)this.marioPosition.PositionArr[18].Y, width, height);
                        }
                        destinationRectangle = new Rectangle(marioState.XCoor, marioState.YCoor - 16, width, height);
                    }
                    else
                    {
                        //RIGHT FACING CROUCH                      

                        sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[19].X, (int)this.marioPosition.PositionArr[19].Y, width, height);
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
                        sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[25].X, (int)this.marioPosition.PositionArr[25].Y, width, height);
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
                            sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[20].X, (int)this.marioPosition.PositionArr[20].Y, width, height);
                        }
                        else
                        {
                            //LEFT FACING JUMP
                            sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[25].X, (int)this.marioPosition.PositionArr[25].Y, width, height);
                        }
                        destinationRectangle = new Rectangle(marioState.XCoor, marioState.YCoor - 16, width, height);
                    }
                    else
                    {
                        //LEFT FACING CROUCH                        
                        sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[26].X, (int)this.marioPosition.PositionArr[26].Y, width, height);
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
