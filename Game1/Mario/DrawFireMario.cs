using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class DrawFireMario
    {
        private FireMario toDraw;
        private Rectangle sourceReturn;
        private MarioPositionDic marioPosition = new MarioPositionDic();

        public DrawFireMario(FireMario fMar)
        {
            toDraw = fMar;
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
            return sourceReturn;
        }
    }
}
