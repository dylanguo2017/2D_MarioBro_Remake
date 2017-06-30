using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Camera
    {

        public Game myGame;
        private int marioPosition;
        private int width = 800;
        private int height = 480;
        public static int offset;
        
        

        public Camera(Game game)
        {
            myGame = game;
        }
        
              
        public void Update()
        {
            
        }

        public int GetOffset()
        {
            int maxOffset = 300;
            
            marioPosition = myGame.marioState.XCoor;

            offset = 0;

            if (marioPosition - offset > maxOffset)
            {
                offset = marioPosition - maxOffset;
            }
            
            
            return offset;
        }
    }
}
