﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class DrawSmallMario
    {
        private SmallMario toDraw;
        private Rectangle sourceReturn;
        private MarioPositionDic marioPosition = new MarioPositionDic();

        public DrawSmallMario(SmallMario sMar)
        {
            toDraw = sMar;
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
                        sourceReturn = new Rectangle((int)this.marioPosition.PositionArr[toDraw.RightFrame].X, (int)this.marioPosition.PositionArr[toDraw.RightFrame].Y, width, height);

                    }
                    else
                    {
                        sourceReturn = new Rectangle((int)this.marioPosition.PositionArr[5].X, (int)this.marioPosition.PositionArr[5].Y, width, height);
                    }
                }
                else
                {

                    if (!toDraw.MarState.jump)
                    {
                        sourceReturn = new Rectangle((int)this.marioPosition.PositionArr[0].X, (int)this.marioPosition.PositionArr[0].Y, width, height);
                    }
                    else
                    {
                        sourceReturn = new Rectangle((int)this.marioPosition.PositionArr[5].X, (int)this.marioPosition.PositionArr[5].Y, width, height);
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
                        sourceReturn = new Rectangle((int)this.marioPosition.PositionArr[11].X, (int)this.marioPosition.PositionArr[11].Y, width, height);

                    }
                }
                else
                {
                    if (!toDraw.MarState.jump)
                    {
                        sourceReturn = new Rectangle((int)this.marioPosition.PositionArr[6].X, (int)this.marioPosition.PositionArr[6].Y, width, height);

                    }
                    else
                    {
                        sourceReturn = new Rectangle((int)this.marioPosition.PositionArr[11].X, (int)this.marioPosition.PositionArr[11].Y, width, height);

                    }
                }

            }

            return sourceReturn;
        }
    }
}
