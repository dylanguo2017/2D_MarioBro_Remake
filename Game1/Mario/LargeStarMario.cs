﻿using Microsoft.Xna.Framework;
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
        private int animMod;
        private bool altColor;


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
                        if (altColor)
                        {
                            sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[18].X, (int)this.marioPosition.PositionArr[18].Y, width, height);
                        }
                        else
                        {
                            sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[60].X, (int)this.marioPosition.PositionArr[60].Y, width, height);
                        }
                    }
                }
                else
                {
                    if (!marioState.crouch)
                    {
                        if (!marioState.jump)
                        {
                            if (altColor)
                            {
                                sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[13].X, (int)this.marioPosition.PositionArr[13].Y, width, height);
                            }
                            else
                            {
                                sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[55].X, (int)this.marioPosition.PositionArr[55].Y, width, height);
                            }
                        }
                        else
                        {
                            if (altColor)
                            {
                                sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[18].X, (int)this.marioPosition.PositionArr[18].Y, width, height);
                            } 
                            else
                            {
                                sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[60].X, (int)this.marioPosition.PositionArr[60].Y, width, height);
                            }
                        }
                    }
                    else
                    {
                        if (altColor)
                        {
                            sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[19].X, (int)this.marioPosition.PositionArr[19].Y, width, height);
                        }
                        else
                        {
                            sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[61].X, (int)this.marioPosition.PositionArr[61].Y, width, height);
                        }
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
                        if (altColor)
                        {
                            sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[25].X, (int)this.marioPosition.PositionArr[25].Y, width, height);
                        }
                        else
                        {
                            sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[67].X, (int)this.marioPosition.PositionArr[67].Y, width, height);
                        }
                    }
                }
                else
                {
                    if (!marioState.crouch)
                    {
                        if (!marioState.jump)
                        {
                            if (altColor)
                            {
                                sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[20].X, (int)this.marioPosition.PositionArr[20].Y, width, height);
                            }
                            else
                            {
                                sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[62].X, (int)this.marioPosition.PositionArr[62].Y, width, height);
                            }
                        }
                        else
                        {
                            if (altColor)
                            {
                                sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[25].X, (int)this.marioPosition.PositionArr[25].Y, width, height);
                            }
                            else
                            {
                                sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[67].X, (int)this.marioPosition.PositionArr[67].Y, width, height);
                            }
                        }
                    }
                    else
                    {
                        if (altColor)
                        {
                            sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[26].X, (int)this.marioPosition.PositionArr[26].Y, width, height);
                        }
                        else
                        {
                            sourceRectangle = new Rectangle((int)this.marioPosition.PositionArr[68].X, (int)this.marioPosition.PositionArr[68].Y, width, height);
                        }
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
