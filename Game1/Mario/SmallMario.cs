using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game
{
    public class SmallMario : IMario
    {
        public MarioStateClass marioState;

        public Texture2D texture;

        MarioPositionDic marioPosition = new MarioPositionDic();

        private int rightFacingCurrentFrame;
        private int leftFacingCurrentFrame;

        private Rectangle destinationRectangle;
        private int invCtr;
        private int animMod;
        

        public SmallMario(MarioStateClass mainState, Texture2D spriteSheet)
        {
            marioState = mainState;
            texture = spriteSheet;

            rightFacingCurrentFrame = 1;
            leftFacingCurrentFrame = 7;
            marioState.curStat = MarioStateClass.marioStatus.small;
            marioState.star = false;
            invCtr = 0;
            animMod = 0;
        }

        public MarioStateClass.marioStatus currentStatus()
        {
            return marioState.curStat;
        }

        public void Update()
        {
            animMod++;
            if (marioState.marioPhys.falling)
            {
                marioState.jump = true;
            }
            marioState.marioPhys.Update();
            if (marioState.inv && invCtr == 0)
            {
                invCtr = 10;
            }

            if(animMod % 20 == 0)
            {
                if (invCtr > 0)
                {
                    invCtr--;
                    if (invCtr == 0)
                    {
                        marioState.inv = false;
                    }
                }
                if (marioState.move && marioState.facingLeft && !marioState.jump)
                {
                    leftFacingCurrentFrame++;
                    if (leftFacingCurrentFrame == 9)
                    {
                        leftFacingCurrentFrame = 7;
                    }
                }
                else if (marioState.move && !marioState.facingLeft && !marioState.jump)
                {
                    rightFacingCurrentFrame++;
                    if (rightFacingCurrentFrame == 3)
                    {
                        rightFacingCurrentFrame = 1;
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            if (invCtr % 2 == 1)
            {
                return;
            }
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
                       
                    }
                    else
                    {
                        sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[5].X, (int)this.marioPosition.PositionArr[5].Y, width, height);
                    }
                }
                else
                {

                    if (!marioState.jump)
                    {
                        sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[0].X, (int)this.marioPosition.PositionArr[0].Y, width, height);
                    }
                    else
                    {
                        sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[5].X, (int)this.marioPosition.PositionArr[5].Y, width, height);
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
                        sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[11].X, (int)this.marioPosition.PositionArr[11].Y, width, height);
                        
                    }
                }
                else
                {
                    if (!marioState.jump)
                    {
                        sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[6].X, (int)this.marioPosition.PositionArr[6].Y, width, height);
                       
                    }
                    else
                    {
                        sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[11].X, (int)this.marioPosition.PositionArr[11].Y, width, height);
                      
                    }
                }

            }

             
            if (!marioState.facingLeft && marioState.move && marioState.XCoor - marioState.offset > 400)
            {
                marioState.offset = marioState.XCoor - 400;
            } 

            destinationRectangle = new Rectangle(marioState.XCoor - marioState.offset, marioState.YCoor, width, height);
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
