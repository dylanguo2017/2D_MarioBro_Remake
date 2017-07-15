using Microsoft.Xna.Framework;

namespace Game
{
    class DrawFireMario
    {
        private FireMario toDraw;
        private Rectangle sourceReturn;
        private MarioPositionDic marioPosition = new MarioPositionDic();
        private Game myGame;

        public DrawFireMario(Game game, FireMario fMar)
        {
            myGame = game;
            toDraw = fMar;
        }

        public Rectangle giveSource()
        {
            int width = 17;
            int height = 33;

            if (myGame.marioState.flagpole)
            {
                sourceReturn = new Rectangle((int)marioPosition.PositionArr[71].X, (int)marioPosition.PositionArr[71].Y, width, height);
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
                            sourceReturn = new Rectangle((int)marioPosition.PositionArr[33].X, (int)marioPosition.PositionArr[33].Y, width, height);
                        }
                    }
                    else
                    {
                        if (!toDraw.MarState.crouch)
                        {
                            if (!toDraw.MarState.jump)
                            {
                                sourceReturn = new Rectangle((int)marioPosition.PositionArr[27].X, (int)marioPosition.PositionArr[27].Y, width, height);
                            }
                            else
                            {
                                sourceReturn = new Rectangle((int)marioPosition.PositionArr[33].X, (int)marioPosition.PositionArr[33].Y, width, height);
                            }
                        }
                        else
                        {
                            sourceReturn = new Rectangle((int)marioPosition.PositionArr[34].X, (int)marioPosition.PositionArr[34].Y, width, height);
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
                            sourceReturn = new Rectangle((int)marioPosition.PositionArr[41].X, (int)marioPosition.PositionArr[41].Y, width, height);
                        }
                    }
                    else
                    {
                        if (!toDraw.MarState.crouch)
                        {
                            if (!toDraw.MarState.jump)
                            {
                                sourceReturn = new Rectangle((int)marioPosition.PositionArr[35].X, (int)marioPosition.PositionArr[35].Y, width, height);
                            }
                            else
                            {
                                sourceReturn = new Rectangle((int)marioPosition.PositionArr[41].X, (int)marioPosition.PositionArr[41].Y, width, height);
                            }
                        }
                        else
                        {
                            sourceReturn = new Rectangle((int)marioPosition.PositionArr[42].X, (int)marioPosition.PositionArr[42].Y, width, height);
                        }
                    }
                }
            }
            
            return sourceReturn;
        }
    }
}
