using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Enemies
{
    public class GoombaPositionDic
    {
        private Vector2 GoombaPositionVec;
        public Vector2[] PositionArr = new Vector2[3];

        public GoombaPositionDic()
        {
            GoombaPositionVec.X = 30;// right foot
            GoombaPositionVec.Y = 0;
            PositionArr[0] = GoombaPositionVec;

            GoombaPositionVec.X = 0;// left foot
            GoombaPositionVec.Y = 0;
            PositionArr[1] = GoombaPositionVec;

            GoombaPositionVec.X = 60;// dead
            GoombaPositionVec.Y = 0;
            PositionArr[2] = GoombaPositionVec;
        }
    }
}
