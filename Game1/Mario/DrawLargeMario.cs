using Microsoft.Xna.Framework;

namespace Game
{
    class DrawLargeMario
    {
        private LargeMario toDraw;
        private Rectangle sourceReturn;
        private MarioPositionDic marioPosition = new MarioPositionDic();
        private Game myGame;

        public DrawLargeMario(Game game, LargeMario lMar)
        {
            myGame = game;
            toDraw = lMar;
        }

        public Rectangle giveSource()
        {
            int width = 17;
            int height = 33;

            if (myGame.marioState.flagpole)
            {
                sourceReturn = new Rectangle((int)marioPosition.PositionArr[70].X, (int)marioPosition.PositionArr[70].Y, width, height);
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
                            sourceReturn = new Rectangle((int)marioPosition.PositionArr[18].X, (int)marioPosition.PositionArr[18].Y, width, height);
                        }
                    }
                    else
                    {
                        if (!toDraw.MarState.crouch)
                        {
                            if (!toDraw.MarState.jump)
                            {
                                sourceReturn = new Rectangle((int)marioPosition.PositionArr[13].X, (int)marioPosition.PositionArr[13].Y, width, height);
                            }
                            else
                            {

                                sourceReturn = new Rectangle((int)marioPosition.PositionArr[18].X, (int)marioPosition.PositionArr[18].Y, width, height);
                            }
                        }
                        else
                        {
                            sourceReturn = new Rectangle((int)marioPosition.PositionArr[19].X, (int)marioPosition.PositionArr[19].Y, width, height);
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
                            sourceReturn = new Rectangle((int)marioPosition.PositionArr[25].X, (int)marioPosition.PositionArr[25].Y, width, height);
                        }
                    }
                    else
                    {
                        if (!toDraw.MarState.crouch)
                        {
                            if (!toDraw.MarState.jump)
                            {
                                sourceReturn = new Rectangle((int)marioPosition.PositionArr[20].X, (int)marioPosition.PositionArr[20].Y, width, height);
                            }
                            else
                            {
                                sourceReturn = new Rectangle((int)marioPosition.PositionArr[25].X, (int)marioPosition.PositionArr[25].Y, width, height);
                            }
                        }
                        else
                        {
                            sourceReturn = new Rectangle((int)marioPosition.PositionArr[26].X, (int)marioPosition.PositionArr[26].Y, width, height);
                        }
                    }
                }
            }
            
            return sourceReturn;
        }
    }
}
