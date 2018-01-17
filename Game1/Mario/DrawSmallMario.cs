using Microsoft.Xna.Framework;
using static Game.Utility;

namespace Game
{
    class DrawSmallMario
    {
        private SmallMario toDraw;
        private Rectangle sourceReturn;
        private MarioPositionDic marioPosition = new MarioPositionDic();
        private Game myGame;

        public DrawSmallMario(Game game, SmallMario sMar)
        {
            myGame = game;
            toDraw = sMar;
        }

        public Rectangle giveSource()
        {
            int width = 17;
            int height = 17;

            if (myGame.marioState.flagpole)
            {
                sourceReturn = new Rectangle((int)marioPosition.PositionArr[sixtyNine].X, (int)marioPosition.PositionArr[sixtyNine].Y, width, height);
            }
            else
            {
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
                            sourceReturn = new Rectangle((int)marioPosition.PositionArr[five].X, (int)marioPosition.PositionArr[five].Y, width, height);
                        }
                    }
                    else
                    {

                        if (!toDraw.MarState.jump)
                        {
                            sourceReturn = new Rectangle((int)marioPosition.PositionArr[zero].X, (int)marioPosition.PositionArr[zero].Y, width, height);
                        }
                        else
                        {
                            sourceReturn = new Rectangle((int)marioPosition.PositionArr[five].X, (int)marioPosition.PositionArr[five].Y, width, height);
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
                            sourceReturn = new Rectangle((int)marioPosition.PositionArr[eleven].X, (int)marioPosition.PositionArr[eleven].Y, width, height);

                        }
                    }
                    else
                    {
                        if (!toDraw.MarState.jump)
                        {
                            sourceReturn = new Rectangle((int)marioPosition.PositionArr[six].X, (int)marioPosition.PositionArr[six].Y, width, height);

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
