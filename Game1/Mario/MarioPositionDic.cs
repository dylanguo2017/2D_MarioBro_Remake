using Microsoft.Xna.Framework;

namespace Game
{
    public class MarioPositionDic
    {
        private Vector2 MarioPositionVec;
        public Vector2[] PositionArr = new Vector2[100];

        public MarioPositionDic()
        {
            //Small mario facing right, the first one is idle mario facing right.

            MarioPositionVec.X = 211;// small right face idle
            MarioPositionVec.Y = 0;
            PositionArr[0] = MarioPositionVec;

            MarioPositionVec.X = 241;// right run 1
            MarioPositionVec.Y = 0;
            PositionArr[1] = MarioPositionVec;

            MarioPositionVec.X = 272;// right run 2
            MarioPositionVec.Y = 0;
            PositionArr[2] = MarioPositionVec;

            MarioPositionVec.X = 300;// right run 3
            MarioPositionVec.Y = 0;
            PositionArr[3] = MarioPositionVec;

            MarioPositionVec.X = 331;
            MarioPositionVec.Y = 0;
            PositionArr[4] = MarioPositionVec;

            MarioPositionVec.X = 359;// this one is small mario right jumping.
            MarioPositionVec.Y = 0;
            PositionArr[5] = MarioPositionVec;
            // End of small mario facing right.



            //Small mario facing left, the first one is idle mario facing left.
            MarioPositionVec.X = 181;// small left face idle
            MarioPositionVec.Y = 0;
            PositionArr[6] = MarioPositionVec;

            MarioPositionVec.X = 150;// small left run1
            MarioPositionVec.Y = 0;
            PositionArr[7] = MarioPositionVec;

            MarioPositionVec.X = 121;// small left run2
            MarioPositionVec.Y = 0;
            PositionArr[8] = MarioPositionVec;

            MarioPositionVec.X = 89;// small left run3
            MarioPositionVec.Y = 0;
            PositionArr[9] = MarioPositionVec;

            MarioPositionVec.X = 60;
            MarioPositionVec.Y = 0;
            PositionArr[10] = MarioPositionVec;

            MarioPositionVec.X = 29;// this one is small mario left jumping.
            MarioPositionVec.Y = 0;
            PositionArr[11] = MarioPositionVec;
            // End of small mario facing right.


            // this one is small DEAD mario.
            MarioPositionVec.X = 0;
            MarioPositionVec.Y = 16;
            PositionArr[12] = MarioPositionVec;
            // Dead mario end.

            //Big mario facing right, the first one is Big idle mario facing right.
            MarioPositionVec.X = 209;// big face right idle
            MarioPositionVec.Y = 52;
            PositionArr[13] = MarioPositionVec;

            MarioPositionVec.X = 239;// right big run 1
            MarioPositionVec.Y = 52;
            PositionArr[14] = MarioPositionVec;

            MarioPositionVec.X = 270;// right big run 2
            MarioPositionVec.Y = 52;
            PositionArr[15] = MarioPositionVec;

            MarioPositionVec.X = 299;// right big run 3
            MarioPositionVec.Y = 53;
            PositionArr[16] = MarioPositionVec;

            MarioPositionVec.X = 329;// right brake
            MarioPositionVec.Y = 52;
            PositionArr[17] = MarioPositionVec;

            MarioPositionVec.X = 359;// this one is big mario right jumping.
            MarioPositionVec.Y = 52;
            PositionArr[18] = MarioPositionVec;

            MarioPositionVec.X = 389;//this is big mario right crunch
            MarioPositionVec.Y = 47;
            PositionArr[19] = MarioPositionVec;
            // End of big mario facing right.


            //Big mario facing left, the first one is big idle mario facing left.
            MarioPositionVec.X = 180;// big face left idel
            MarioPositionVec.Y = 52;
            PositionArr[20] = MarioPositionVec;

            MarioPositionVec.X = 150;// big left run 1
            MarioPositionVec.Y = 52;
            PositionArr[21] = MarioPositionVec;

            MarioPositionVec.X = 121;// big left run 2
            MarioPositionVec.Y = 52;
            PositionArr[22] = MarioPositionVec;

            MarioPositionVec.X = 90;// big left run 3
            MarioPositionVec.Y = 53;
            PositionArr[23] = MarioPositionVec;

            MarioPositionVec.X = 60;// big left brake
            MarioPositionVec.Y = 52;
            PositionArr[24] = MarioPositionVec;

            MarioPositionVec.X = 30;// this one is Big mario left jumping.
            MarioPositionVec.Y = 52;
            PositionArr[25] = MarioPositionVec;

            MarioPositionVec.X = 0;//this is big mario left crunch
            MarioPositionVec.Y = 47;
            PositionArr[26] = MarioPositionVec;
            // End of Big mario facing left.



            //Fire mario facing right, the first one is Fire idle mario facing right.
            MarioPositionVec.X = 209;// Fire right idle
            MarioPositionVec.Y = 122;
            PositionArr[27] = MarioPositionVec;

            MarioPositionVec.X = 237;// fire right run1
            MarioPositionVec.Y = 122;
            PositionArr[28] = MarioPositionVec;

            MarioPositionVec.X = 263;// fire right run 2
            MarioPositionVec.Y = 122;
            PositionArr[29] = MarioPositionVec;

            MarioPositionVec.X = 287;// fire right run3
            MarioPositionVec.Y = 123;
            PositionArr[30] = MarioPositionVec;

            MarioPositionVec.X = 312;// right fire throw fireball
            MarioPositionVec.Y = 123;
            PositionArr[31] = MarioPositionVec;

            MarioPositionVec.X = 337;// fire right brake
            MarioPositionVec.Y = 122;
            PositionArr[32] = MarioPositionVec;

            MarioPositionVec.X = 362;// this one is fire mario right jumping.
            MarioPositionVec.Y = 122;
            PositionArr[33] = MarioPositionVec;

            MarioPositionVec.X = 389;//this is fire mario right crunch
            MarioPositionVec.Y = 118;
            PositionArr[34] = MarioPositionVec;
            // End of Fire mario facing right.


            //Fire mario facing left, the first one is Fire idle mario facing left.
            MarioPositionVec.X = 180;// fire left idle
            MarioPositionVec.Y = 122;
            PositionArr[35] = MarioPositionVec;

            MarioPositionVec.X = 152;// fire left run1 
            MarioPositionVec.Y = 122;
            PositionArr[36] = MarioPositionVec;

            MarioPositionVec.X = 128;// fire left run 2
            MarioPositionVec.Y = 122;
            PositionArr[37] = MarioPositionVec;

            MarioPositionVec.X = 102;// fire left run3
            MarioPositionVec.Y = 123;
            PositionArr[38] = MarioPositionVec;

            MarioPositionVec.X = 77;// fire left throw fireball
            MarioPositionVec.Y = 123;
            PositionArr[39] = MarioPositionVec;

            MarioPositionVec.X = 52;// fire left brake
            MarioPositionVec.Y = 122;
            PositionArr[40] = MarioPositionVec;

            MarioPositionVec.X = 27;// fire left jumping 
            MarioPositionVec.Y = 122;
            PositionArr[41] = MarioPositionVec;

            MarioPositionVec.X = 0;// this one is fire mario left crouch
            MarioPositionVec.Y = 118;
            PositionArr[42] = MarioPositionVec;
            // End of Big mario facing left.

            //start of star small mario facing right 
            MarioPositionVec.X = 211;// this is small star mario facing right idle
            MarioPositionVec.Y = 192;
            PositionArr[43] = MarioPositionVec;

            MarioPositionVec.X = 241;// small right run 1
            MarioPositionVec.Y = 192;
            PositionArr[44] = MarioPositionVec;

            MarioPositionVec.X = 272;// small right run 2
            MarioPositionVec.Y = 0;
            PositionArr[45] = MarioPositionVec;

            MarioPositionVec.X = 300;// small right run 3
            MarioPositionVec.Y = 192;
            PositionArr[46] = MarioPositionVec;

            MarioPositionVec.X = 331;// small right brake
            MarioPositionVec.Y = 192;
            PositionArr[47] = MarioPositionVec;

            MarioPositionVec.X = 359;// small right jump
            MarioPositionVec.Y = 192;
            PositionArr[48] = MarioPositionVec;

            MarioPositionVec.X = 181;// this is small star mario left facing idle
            MarioPositionVec.Y = 192;
            PositionArr[49] = MarioPositionVec;

            MarioPositionVec.X = 150;// small star mario left facing run 1
            MarioPositionVec.Y = 192;
            PositionArr[50] = MarioPositionVec;

            MarioPositionVec.X = 121;// small star mario left facing run 2
            MarioPositionVec.Y = 0;
            PositionArr[51] = MarioPositionVec;

            MarioPositionVec.X = 89;// small star mario left facing run 3
            MarioPositionVec.Y = 192;
            PositionArr[52] = MarioPositionVec;

            MarioPositionVec.X = 60;// small star mario left facing brake
            MarioPositionVec.Y = 192;
            PositionArr[53] = MarioPositionVec;

            MarioPositionVec.X = 29;// small star mario left facing jump
            MarioPositionVec.Y = 192;
            PositionArr[54] = MarioPositionVec;
            // end of star small mario

            //beginning of big star mario
            MarioPositionVec.X = 209;// big star mario facing right idle
            MarioPositionVec.Y = 212;
            PositionArr[55] = MarioPositionVec;

            MarioPositionVec.X = 239;// big star mario facing right run 1
            MarioPositionVec.Y = 212;
            PositionArr[56] = MarioPositionVec;

            MarioPositionVec.X = 270;// big star mario facing right run 2
            MarioPositionVec.Y = 212;
            PositionArr[57] = MarioPositionVec;

            MarioPositionVec.X = 299;// big star mario facing right run 3
            MarioPositionVec.Y = 213;
            PositionArr[58] = MarioPositionVec;

            MarioPositionVec.X = 329;// big star mario facing right brake
            MarioPositionVec.Y = 212;
            PositionArr[59] = MarioPositionVec;

            MarioPositionVec.X = 358;// big star mario facing right jump
            MarioPositionVec.Y = 212;
            PositionArr[60] = MarioPositionVec;

            MarioPositionVec.X = 389;// big star mario facing right crouch
            MarioPositionVec.Y = 207;
            PositionArr[61] = MarioPositionVec;

            //////////
            MarioPositionVec.X = 180;// big star mario facing left idle
            MarioPositionVec.Y = 212;
            PositionArr[62] = MarioPositionVec;

            MarioPositionVec.X = 150;// big star mario facing left run 1
            MarioPositionVec.Y = 212;
            PositionArr[63] = MarioPositionVec;

            MarioPositionVec.X = 121;// big star mario facing left run 2
            MarioPositionVec.Y = 212;
            PositionArr[64] = MarioPositionVec;

            MarioPositionVec.X = 90;// big star mario facing left run 3
            MarioPositionVec.Y = 213;
            PositionArr[65] = MarioPositionVec;

            MarioPositionVec.X = 60;// big star mario facing left brake
            MarioPositionVec.Y = 212;
            PositionArr[66] = MarioPositionVec;

            MarioPositionVec.X = 30;// big star mario facing left jump
            MarioPositionVec.Y = 212;
            PositionArr[67] = MarioPositionVec;

            MarioPositionVec.X = 0;// big star mario facing left crouch
            MarioPositionVec.Y = 207;
            PositionArr[68] = MarioPositionVec;
            // end of big star mario
            
            MarioPositionVec.X = 358;// small mario flagpole
            MarioPositionVec.Y = 27;
            PositionArr[69] = MarioPositionVec;

            MarioPositionVec.X = 386;// big mario flagpole
            MarioPositionVec.Y = 54;
            PositionArr[70] = MarioPositionVec;

            MarioPositionVec.X = 387;// fire mario flagpole
            MarioPositionVec.Y = 155;
            PositionArr[71] = MarioPositionVec;
        }

    }
}
