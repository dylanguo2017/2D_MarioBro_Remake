using Microsoft.Xna.Framework;
using static Game.Utility;

namespace Game
{
    public class MarioPositionDic
    {
        private Vector2 MarioPositionVec;
        private int idx = 0;
        public Vector2[] PositionArr = new Vector2[posDicMax];

        public MarioPositionDic()
        {
            //Small mario facing right, the first one is idle mario facing right.

            MarioPositionVec = new Vector2(211, 0); // [0] small right face idle
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(241, 0); // [1] right run 1
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(272, 0); // [2] right run 2
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(300, 0); // [3] right run 3
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(331, 0);
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(359, 0); // [5] small mario right jumping
            PositionArr[idx++] = MarioPositionVec;
            // End of small mario facing right.


            //Small mario facing left, the first one is idle mario facing left.
            MarioPositionVec = new Vector2(181, 0); // [6] small left face idle
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(150, 0); // [7] small left run 1
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(121, 0); // [8] small left run 2
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(89, 0);  // [9] small left run 3
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(60, 0);
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(29, 0); // [11] small mario left jumping
            PositionArr[idx++] = MarioPositionVec;
            // End of small mario facing right.


            // this one is small DEAD mario.
            MarioPositionVec = new Vector2(0, 16);
            PositionArr[idx++] = MarioPositionVec;
            // Dead mario end.

            //Big mario facing right, the first one is Big idle mario facing right.
            MarioPositionVec = new Vector2(209, 52);
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(239, 52); // [14] right big run 1
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(270, 52); // [15] right big run 2
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(299, 53); // [16] right big run 3
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(329, 52); // [17] right brake
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(359, 52); // [18] big mario right jumping
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(389, 47); // [19] big mario right crunch
            PositionArr[idx++] = MarioPositionVec;
            // End of big mario facing right.


            //Big mario facing left, the first one is big idle mario facing left.
            MarioPositionVec = new Vector2(180, 52); // [20] big face left idle
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(150, 52); // [21] big left run 1
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(121, 52); // [22] big left run 2
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(90, 53); // [23] big left run 3
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(60, 52); // [24] big left brake
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(30, 52); // [25] big mario left jumping
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(0, 47); // [26] big mario left crunch
            PositionArr[idx++] = MarioPositionVec;
            // End of Big mario facing left.


            //Fire mario facing right, the first one is Fire idle mario facing right.
            MarioPositionVec = new Vector2(209, 122); // [27] fire right idle
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(237, 122); // [28] fire right run 1
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(263, 122); // [29] fire right run 2
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(287, 123); // [30] fire right run 3
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(312, 123); // [31] right fire throw fireball
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(337, 122); // [32] fire right brake
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(362, 122); // [33] fire mario right jumping
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(389, 118); // [34] fire mario right crunch
            PositionArr[idx++] = MarioPositionVec;
            // End of Fire mario facing right.


            //Fire mario facing left, the first one is Fire idle mario facing left.
            MarioPositionVec = new Vector2(180, 122); // [35] fire left idle
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(152, 122); // [36] fire left run1 
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(128, 122); // [37] fire left run 2
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(102, 123); // [38] fire left run 3
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(77, 123); // [39] fire left throw fireball
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(52, 122); // [40] fire left brake
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(27, 122); // [41] fire left jumping 
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(0, 118); // [42] fire mario left crouch
            PositionArr[idx++] = MarioPositionVec;
            // End of Big mario facing left.

            //start of star small mario facing right 
            MarioPositionVec = new Vector2(211, 192); // [43] small star mario facing right idle
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(241, 192); // [44] small right run 1
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(272, 0); // [45] small right run 2
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(300, 192); // [46] small right run 3
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(331, 192); // [47] small right brake
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(359, 192); // [48] small right jump
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(181, 192); // [49] small star mario left facing idle
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(150, 192); // [50] small star mario left facing run 1
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(121, 0); // [51] small star mario left facing run 2
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(89, 192); // [52] small star mario left facing run 3
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(60, 192); // [53] small star mario left facing brake
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(29, 192); // [54] small star mario left facing jump
            PositionArr[idx++] = MarioPositionVec;
            // end of star small mario

            //beginning of big star mario
            MarioPositionVec = new Vector2(209, 212); // [55] big star mario facing right idle
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(239, 212); // [56] big star mario facing right run 1
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(270, 212); // [57] big star mario facing right run 2
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(299, 213); // [58] big star mario facing right run 3
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(329, 212); // [59] big star mario facing right brake
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(358, 212); // [60] big star mario facing right jump
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(389, 207); // [61] big star mario facing right crouch
            PositionArr[idx++] = MarioPositionVec;

            //////////
            MarioPositionVec = new Vector2(180, 212); // [62] big star mario facing left idle
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(150, 212); // [63] big star mario facing left run 1
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(121, 212); // [64] big star mario facing left run 2
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(90, 213); // [65] big star mario facing left run 3
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(60, 212); // [66] big star mario facing left brake
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(30, 212); // [67] big star mario facing left jump
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(0, 207); // [68] big star mario facing left crouch
            PositionArr[idx++] = MarioPositionVec;
            // end of big star mario

            MarioPositionVec = new Vector2(358, 27); // [69] small mario flagpole
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(361, 87); // [70] big mario flagpole
            PositionArr[idx++] = MarioPositionVec;

            MarioPositionVec = new Vector2(387, 155); // [71] fire mario flagpole
            PositionArr[idx++] = MarioPositionVec;
        }

    }
}
