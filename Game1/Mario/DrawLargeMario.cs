using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class DrawLargeMario
    {
        private LargeMario toDraw;
        private Rectangle sourceReturn;
        private MarioPositionDic marioPosition = new MarioPositionDic();

        public DrawLargeMario(LargeMario lMar)
        {
            toDraw = lMar;
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
                        sourceReturn = new Rectangle((int)this.marioPosition.PositionArr[18].X, (int)this.marioPosition.PositionArr[18].Y, width, height);
                    }
                }
                else
                {
                    if (!toDraw.MarState.crouch)
                    {
                        if (!toDraw.MarState.jump)
                        {
                            sourceReturn = new Rectangle((int)this.marioPosition.PositionArr[13].X, (int)this.marioPosition.PositionArr[13].Y, width, height);
                        }
                        else
                        {

                            sourceReturn = new Rectangle((int)this.marioPosition.PositionArr[18].X, (int)this.marioPosition.PositionArr[18].Y, width, height);
                        }
                    }
                    else
                    {
                        sourceReturn = new Rectangle((int)this.marioPosition.PositionArr[19].X, (int)this.marioPosition.PositionArr[19].Y, width, height);
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
                        sourceReturn = new Rectangle((int)this.marioPosition.PositionArr[25].X, (int)this.marioPosition.PositionArr[25].Y, width, height);
                    }
                }
                else
                {
                    if (!toDraw.MarState.crouch)
                    {
                        if (!toDraw.MarState.jump)
                        {
                            sourceReturn = new Rectangle((int)this.marioPosition.PositionArr[20].X, (int)this.marioPosition.PositionArr[20].Y, width, height);
                        }
                        else
                        {
                            sourceReturn = new Rectangle((int)this.marioPosition.PositionArr[25].X, (int)this.marioPosition.PositionArr[25].Y, width, height);
                        }
                    }
                    else
                    {
                        sourceReturn = new Rectangle((int)this.marioPosition.PositionArr[26].X, (int)this.marioPosition.PositionArr[26].Y, width, height);
                    }
                }
            }
            return sourceReturn;
        }
    }
}
