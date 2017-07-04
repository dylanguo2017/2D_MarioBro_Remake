using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class DrawLargeStarMario
    {
        private LargeStarMario toDraw;
        private Rectangle sourceReturn;
        private MarioPositionDic marioPosition = new MarioPositionDic();

        public DrawLargeStarMario(LargeStarMario lsMar)
        {
            toDraw = lsMar;
        }

        public Rectangle giveSource()
        {
            int width = 17;
            int height = 33;

            if (!toDraw.MarState.facingLeft)
            {
                if (toDraw.MarState.move)
                {
                    if (!toDraw.MarState.jump)
                    {
                        sourceReturn = new Rectangle((int)this.marioPosition.PositionArr[toDraw.RightFrame].X, (int)this.marioPosition.PositionArr[toDraw.RightFrame].Y, width, height);
                    }
                    else
                    {
                        if (toDraw.AltColor)
                        {
                            sourceReturn = new Rectangle((int)this.marioPosition.PositionArr[18].X, (int)this.marioPosition.PositionArr[18].Y, width, height);
                        }
                        else
                        {
                            sourceReturn = new Rectangle((int)this.marioPosition.PositionArr[60].X, (int)this.marioPosition.PositionArr[60].Y, width, height);
                        }
                    }
                }
                else
                {
                    if (!toDraw.MarState.crouch)
                    {
                        if (!toDraw.MarState.jump)
                        {
                            if (toDraw.AltColor)
                            {
                                sourceReturn = new Rectangle((int)this.marioPosition.PositionArr[13].X, (int)this.marioPosition.PositionArr[13].Y, width, height);
                            }
                            else
                            {
                                sourceReturn = new Rectangle((int)this.marioPosition.PositionArr[55].X, (int)this.marioPosition.PositionArr[55].Y, width, height);
                            }
                        }
                        else
                        {
                            if (toDraw.AltColor)
                            {
                                sourceReturn = new Rectangle((int)this.marioPosition.PositionArr[18].X, (int)this.marioPosition.PositionArr[18].Y, width, height);
                            }
                            else
                            {
                                sourceReturn = new Rectangle((int)this.marioPosition.PositionArr[60].X, (int)this.marioPosition.PositionArr[60].Y, width, height);
                            }
                        }
                    }
                    else
                    {
                        if (toDraw.AltColor)
                        {
                            sourceReturn = new Rectangle((int)this.marioPosition.PositionArr[19].X, (int)this.marioPosition.PositionArr[19].Y, width, height);
                        }
                        else
                        {
                            sourceReturn = new Rectangle((int)this.marioPosition.PositionArr[61].X, (int)this.marioPosition.PositionArr[61].Y, width, height);
                        }
                    }
                }
            }
            else
            {
                if (toDraw.MarState.move)
                {
                    if (!toDraw.MarState.jump)
                    {
                        sourceReturn = new Rectangle((int)this.marioPosition.PositionArr[toDraw.LeftFrame].X, (int)this.marioPosition.PositionArr[toDraw.LeftFrame].Y, width, height);
                    }
                    else
                    {
                        if (toDraw.AltColor)
                        {
                            sourceReturn = new Rectangle((int)this.marioPosition.PositionArr[25].X, (int)this.marioPosition.PositionArr[25].Y, width, height);
                        }
                        else
                        {
                            sourceReturn = new Rectangle((int)this.marioPosition.PositionArr[67].X, (int)this.marioPosition.PositionArr[67].Y, width, height);
                        }
                    }
                }
                else
                {
                    if (!toDraw.MarState.crouch)
                    {
                        if (!toDraw.MarState.jump)
                        {
                            if (toDraw.AltColor)
                            {
                                sourceReturn = new Rectangle((int)this.marioPosition.PositionArr[20].X, (int)this.marioPosition.PositionArr[20].Y, width, height);
                            }
                            else
                            {
                                sourceReturn = new Rectangle((int)this.marioPosition.PositionArr[62].X, (int)this.marioPosition.PositionArr[62].Y, width, height);
                            }
                        }
                        else
                        {
                            if (toDraw.AltColor)
                            {
                                sourceReturn = new Rectangle((int)this.marioPosition.PositionArr[25].X, (int)this.marioPosition.PositionArr[25].Y, width, height);
                            }
                            else
                            {
                                sourceReturn = new Rectangle((int)this.marioPosition.PositionArr[67].X, (int)this.marioPosition.PositionArr[67].Y, width, height);
                            }
                        }
                    }
                    else
                    {
                        if (toDraw.AltColor)
                        {
                            sourceReturn = new Rectangle((int)this.marioPosition.PositionArr[26].X, (int)this.marioPosition.PositionArr[26].Y, width, height);
                        }
                        else
                        {
                            sourceReturn = new Rectangle((int)this.marioPosition.PositionArr[68].X, (int)this.marioPosition.PositionArr[68].Y, width, height);
                        }
                    }
                }
            }
            return sourceReturn;
        }
    }
}
