using Microsoft.Xna.Framework;
using static Game.Utility;

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
                        sourceReturn = new Rectangle((int)marioPosition.PositionArr[toDraw.RightFrame].X, (int)marioPosition.PositionArr[toDraw.RightFrame].Y, width, height);
                    }
                    else
                    {
                        if (toDraw.AltColor)
                        {
                            sourceReturn = new Rectangle((int)marioPosition.PositionArr[eighteen].X, (int)marioPosition.PositionArr[eighteen].Y, width, height);
                        }
                        else
                        {
                            sourceReturn = new Rectangle((int)marioPosition.PositionArr[sixty].X, (int)marioPosition.PositionArr[sixty].Y, width, height);
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
                                sourceReturn = new Rectangle((int)marioPosition.PositionArr[thirteen].X, (int)marioPosition.PositionArr[thirteen].Y, width, height);
                            }
                            else
                            {
                                sourceReturn = new Rectangle((int)marioPosition.PositionArr[fiftyFive].X, (int)marioPosition.PositionArr[fiftyFive].Y, width, height);
                            }
                        }
                        else
                        {
                            if (toDraw.AltColor)
                            {
                                sourceReturn = new Rectangle((int)marioPosition.PositionArr[eighteen].X, (int)marioPosition.PositionArr[eighteen].Y, width, height);
                            }
                            else
                            {
                                sourceReturn = new Rectangle((int)marioPosition.PositionArr[sixty].X, (int)marioPosition.PositionArr[sixty].Y, width, height);
                            }
                        }
                    }
                    else
                    {
                        if (toDraw.AltColor)
                        {
                            sourceReturn = new Rectangle((int)marioPosition.PositionArr[nineteen].X, (int)marioPosition.PositionArr[nineteen].Y, width, height);
                        }
                        else
                        {
                            sourceReturn = new Rectangle((int)marioPosition.PositionArr[sixtyOne].X, (int)marioPosition.PositionArr[sixtyOne].Y, width, height);
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
                        sourceReturn = new Rectangle((int)marioPosition.PositionArr[toDraw.LeftFrame].X, (int)marioPosition.PositionArr[toDraw.LeftFrame].Y, width, height);
                    }
                    else
                    {
                        if (toDraw.AltColor)
                        {
                            sourceReturn = new Rectangle((int)marioPosition.PositionArr[twentyFive].X, (int)marioPosition.PositionArr[twentyFive].Y, width, height);
                        }
                        else
                        {
                            sourceReturn = new Rectangle((int)marioPosition.PositionArr[sixtySeven].X, (int)marioPosition.PositionArr[sixtySeven].Y, width, height);
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
                                sourceReturn = new Rectangle((int)marioPosition.PositionArr[twenty].X, (int)marioPosition.PositionArr[twenty].Y, width, height);
                            }
                            else
                            {
                                sourceReturn = new Rectangle((int)marioPosition.PositionArr[sixtyTwo].X, (int)marioPosition.PositionArr[sixtyTwo].Y, width, height);
                            }
                        }
                        else
                        {
                            if (toDraw.AltColor)
                            {
                                sourceReturn = new Rectangle((int)marioPosition.PositionArr[twentyFive].X, (int)marioPosition.PositionArr[twentyFive].Y, width, height);
                            }
                            else
                            {
                                sourceReturn = new Rectangle((int)marioPosition.PositionArr[sixtySeven].X, (int)marioPosition.PositionArr[sixtySeven].Y, width, height);
                            }
                        }
                    }
                    else
                    {
                        if (toDraw.AltColor)
                        {
                            sourceReturn = new Rectangle((int)marioPosition.PositionArr[twentySix].X, (int)marioPosition.PositionArr[twentySix].Y, width, height);
                        }
                        else
                        {
                            sourceReturn = new Rectangle((int)marioPosition.PositionArr[sixtyEight].X, (int)marioPosition.PositionArr[sixtyEight].Y, width, height);
                        }
                    }
                }
            }
            return sourceReturn;
        }
    }
}
