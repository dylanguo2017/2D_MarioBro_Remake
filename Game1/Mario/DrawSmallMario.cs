using Microsoft.Xna.Framework;

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
                sourceReturn = new Rectangle((int)marioPosition.PositionArr[69].X, (int)marioPosition.PositionArr[69].Y, width, height);
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
                            sourceReturn = new Rectangle((int)marioPosition.PositionArr[5].X, (int)marioPosition.PositionArr[5].Y, width, height);
                        }
                    }
                    else
                    {

                        if (!toDraw.MarState.jump)
                        {
                            sourceReturn = new Rectangle((int)marioPosition.PositionArr[0].X, (int)marioPosition.PositionArr[0].Y, width, height);
                        }
                        else
                        {
                            sourceReturn = new Rectangle((int)marioPosition.PositionArr[5].X, (int)marioPosition.PositionArr[5].Y, width, height);
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
                            sourceReturn = new Rectangle((int)marioPosition.PositionArr[11].X, (int)marioPosition.PositionArr[11].Y, width, height);

                        }
                    }
                    else
                    {
                        if (!toDraw.MarState.jump)
                        {
                            sourceReturn = new Rectangle((int)marioPosition.PositionArr[6].X, (int)marioPosition.PositionArr[6].Y, width, height);

                        }
                        else
                        {
                            sourceReturn = new Rectangle((int)marioPosition.PositionArr[11].X, (int)marioPosition.PositionArr[11].Y, width, height);

                        }
                    }

                }
            }

            

            return sourceReturn;
        }
    }
}
