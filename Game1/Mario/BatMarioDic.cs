using Microsoft.Xna.Framework;
using static Game.Utility;

namespace Game
{
    public class BatMarioDic
    {
        private int idx = 0;

        private Rectangle BatRec;
        public Rectangle[] RecArrRight = new Rectangle[five];
        public Rectangle[] RecArrLeft = new Rectangle[five];

        public BatMarioDic()
        {
            BatRec = new Rectangle(43,4,22,20);
            RecArrRight[idx] = BatRec;

            idx++;
            BatRec = new Rectangle(78, 9, 19, 15);
            RecArrRight[idx] = BatRec;

            idx++;
            BatRec = new Rectangle(113, 0, 16, 29);
            RecArrRight[idx] = BatRec;

            idx++;
            BatRec = new Rectangle(114, 13, 20, 16);
            RecArrRight[idx] = BatRec;

            idx++;
            BatRec = new Rectangle(166, 0, 26, 24);
            RecArrRight[idx] = BatRec;

            idx = 0;
            BatRec = new Rectangle(127, 4, 22, 20);
            RecArrLeft[idx] = BatRec;

            idx++;
            BatRec = new Rectangle(95, 9, 19, 15);
            RecArrLeft[idx] = BatRec;

            idx++;
            BatRec = new Rectangle(62, 0, 16, 29);
            RecArrLeft[idx] = BatRec;

            idx++;
            BatRec = new Rectangle(31, 13, 20, 16);
            RecArrLeft[idx] = BatRec;

            idx++;
            BatRec = new Rectangle(0, 0, 26, 24);
            RecArrLeft[idx] = BatRec;
        }

    }
}
