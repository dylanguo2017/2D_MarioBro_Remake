using Microsoft.Xna.Framework;
using static Game.Utility;

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
                sourceReturn = new Rectangle((int)marioPosition.PositionArr[seventy].X, (int)marioPosition.PositionArr[seventy].Y, width, height);
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
                            sourceReturn = new Rectangle((int)marioPosition.PositionArr[eighteen].X, (int)marioPosition.PositionArr[eighteen].Y, width, height);
                        }
                    }
                    else
                    {
                        if (!toDraw.MarState.crouch)
                        {
                            if (!toDraw.MarState.jump)
                            {
                                sourceReturn = new Rectangle((int)marioPosition.PositionArr[thirteen].X, (int)marioPosition.PositionArr[thirteen].Y, width, height);
                            }
                            else
                            {

                                sourceReturn = new Rectangle((int)marioPosition.PositionArr[eighteen].X, (int)marioPosition.PositionArr[eighteen].Y, width, height);
                            }
                        }
                        else
                        {
                            sourceReturn = new Rectangle((int)marioPosition.PositionArr[nineteen].X, (int)marioPosition.PositionArr[nineteen].Y, width, height);
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
                            sourceReturn = new Rectangle((int)marioPosition.PositionArr[twentyFive].X, (int)marioPosition.PositionArr[twentyFive].Y, width, height);
                        }
                    }
                    else
                    {
                        if (!toDraw.MarState.crouch)
                        {
                            if (!toDraw.MarState.jump)
                            {
                                sourceReturn = new Rectangle((int)marioPosition.PositionArr[twenty].X, (int)marioPosition.PositionArr[twenty].Y, width, height);
                            }
                            else
                            {
                                sourceReturn = new Rectangle((int)marioPosition.PositionArr[twentyFive].X, (int)marioPosition.PositionArr[twentyFive].Y, width, height);
                            }
                        }
                        else
                        {
                            sourceReturn = new Rectangle((int)marioPosition.PositionArr[twentySix].X, (int)marioPosition.PositionArr[twentySix].Y, width, height);
                        }
                    }
                }
            }
            
            return sourceReturn;
        }
    }
}
