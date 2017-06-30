using Microsoft.Xna.Framework;

namespace Game.Enemies
{
    public class KoopaPositionDic
    {
        private Vector2 KoopaPositionVec;
        public Vector2[] PositionArr = new Vector2[10];

        public KoopaPositionDic()
        {
            KoopaPositionVec.X = 120;// right face idle
            KoopaPositionVec.Y = 0;
            PositionArr[0] = KoopaPositionVec;

            KoopaPositionVec.X = 90;// left face idle
            KoopaPositionVec.Y = 0;
            PositionArr[1] = KoopaPositionVec;

            KoopaPositionVec.X = 151;// right walk
            KoopaPositionVec.Y = 0;
            PositionArr[2] = KoopaPositionVec;

            KoopaPositionVec.X = 90;// left walk
            KoopaPositionVec.Y = 0;
            PositionArr[3] = KoopaPositionVec;

            KoopaPositionVec.X = 180;// right fly 1
            KoopaPositionVec.Y = 0;
            PositionArr[4] = KoopaPositionVec;

            KoopaPositionVec.X = 211;// right fly 2
            KoopaPositionVec.Y = 0;
            PositionArr[5] = KoopaPositionVec;

            KoopaPositionVec.X = 30;// left fly 1
            KoopaPositionVec.Y = 0;
            PositionArr[6] = KoopaPositionVec;

            KoopaPositionVec.X = 0;// left fly 2
            KoopaPositionVec.Y = 0;
            PositionArr[7] = KoopaPositionVec;

            KoopaPositionVec.X = 241;// shell 1
            KoopaPositionVec.Y = 0;
            PositionArr[8] = KoopaPositionVec;

            KoopaPositionVec.X = 271;// shell dead
            KoopaPositionVec.Y = 0;
            PositionArr[9] = KoopaPositionVec;
        }
    }
}
