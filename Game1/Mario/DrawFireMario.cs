using Microsoft.Xna.Framework;
using static Game.Utility;

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
                sourceReturn = new Rectangle((int)marioPosition.PositionArr[seventyOne].X, (int)marioPosition.PositionArr[seventyOne].Y, width, height);
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
                            sourceReturn = new Rectangle((int)marioPosition.PositionArr[thirtyThree].X, (int)marioPosition.PositionArr[thirtyThree].Y, width, height);
                        }
                    }
                    else
                    {
                        if (!toDraw.MarState.crouch)
                        {
                            if (!toDraw.MarState.jump)
                            {
                                sourceReturn = new Rectangle((int)marioPosition.PositionArr[twentySeven].X, (int)marioPosition.PositionArr[twentySeven].Y, width, height);
                            }
                            else
                            {
                                sourceReturn = new Rectangle((int)marioPosition.PositionArr[thirtyThree].X, (int)marioPosition.PositionArr[thirtyThree].Y, width, height);
                            }
                        }
                        else
                        {
                            sourceReturn = new Rectangle((int)marioPosition.PositionArr[thirtyFour].X, (int)marioPosition.PositionArr[thirtyFour].Y, width, height);
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
                            sourceReturn = new Rectangle((int)marioPosition.PositionArr[fourtyOne].X, (int)marioPosition.PositionArr[fourtyOne].Y, width, height);
                        }
                    }
                    else
                    {
                        if (!toDraw.MarState.crouch)
                        {
                            if (!toDraw.MarState.jump)
                            {
                                sourceReturn = new Rectangle((int)marioPosition.PositionArr[thirtyFive].X, (int)marioPosition.PositionArr[thirtyFive].Y, width, height);
                            }
                            else
                            {
                                sourceReturn = new Rectangle((int)marioPosition.PositionArr[fourtyOne].X, (int)marioPosition.PositionArr[fourtyOne].Y, width, height);
                            }
                        }
                        else
                        {
                            sourceReturn = new Rectangle((int)marioPosition.PositionArr[fourtyTwo].X, (int)marioPosition.PositionArr[fourtyTwo].Y, width, height);
                        }
                    }
                }
            }
            
            return sourceReturn;
        }
    }
}
