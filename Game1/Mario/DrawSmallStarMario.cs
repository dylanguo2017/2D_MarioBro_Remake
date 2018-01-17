using Microsoft.Xna.Framework;
using static Game.Utility;

namespace Game
{
    class DrawSmallStarMario
    {
        private SmallStarMario toDraw;
        private Rectangle sourceReturn;
        private MarioPositionDic marioPosition = new MarioPositionDic();

        public DrawSmallStarMario(SmallStarMario ssMar)
        {
            toDraw = ssMar;
        }

        public Rectangle giveSource()
        {
            int width = 17;
            int height = 17;

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
                            sourceReturn = new Rectangle((int)marioPosition.PositionArr[fourtyEight].X, (int)marioPosition.PositionArr[fourtyEight].Y, width, height);
                        }
                        else
                        {
                            sourceReturn = new Rectangle((int)marioPosition.PositionArr[five].X, (int)marioPosition.PositionArr[five].Y, width, height);
                        }
                    }
                }
                else
                {

                    if (!toDraw.MarState.jump)
                    {
                        if (toDraw.AltColor)
                        {
                            sourceReturn = new Rectangle((int)marioPosition.PositionArr[fourtyThree].X, (int)marioPosition.PositionArr[fourtyThree].Y, width, height);
                        }
                        else
                        {
                            sourceReturn = new Rectangle((int)marioPosition.PositionArr[zero].X, (int)marioPosition.PositionArr[zero].Y, width, height);
                        }
                    }
                    else
                    {
                        if (toDraw.AltColor)
                        {
                            sourceReturn = new Rectangle((int)marioPosition.PositionArr[fourtyEight].X, (int)marioPosition.PositionArr[fourtyEight].Y, width, height);
                        }
                        else
                        {
                            sourceReturn = new Rectangle((int)marioPosition.PositionArr[five].X, (int)marioPosition.PositionArr[five].Y, width, height);
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
                            sourceReturn = new Rectangle((int)marioPosition.PositionArr[fiftyFour].X, (int)marioPosition.PositionArr[fiftyFour].Y, width, height);
                        }
                        else
                        {
                            sourceReturn = new Rectangle((int)marioPosition.PositionArr[eleven].X, (int)marioPosition.PositionArr[eleven].Y, width, height);
                        }
                    }
                }
                else
                {
                    if (!toDraw.MarState.jump)
                    {
                        if (toDraw.AltColor)
                        {
                            sourceReturn = new Rectangle((int)marioPosition.PositionArr[fourtyNine].X, (int)marioPosition.PositionArr[fourtyNine].Y, width, height);
                        }
                        else
                        {
                            sourceReturn = new Rectangle((int)marioPosition.PositionArr[six].X, (int)marioPosition.PositionArr[six].Y, width, height);
                        }
                    }
                    else
                    {
                        if (toDraw.AltColor)
                        {
                            sourceReturn = new Rectangle((int)marioPosition.PositionArr[fiftyFour].X, (int)marioPosition.PositionArr[fiftyFour].Y, width, height);
                        }
                        else
                        {
                            sourceReturn = new Rectangle((int)marioPosition.PositionArr[eleven].X, (int)marioPosition.PositionArr[eleven].Y, width, height);
                        }
                    }
                }

            }
            return sourceReturn;
        }
    }
}
