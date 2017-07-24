using static Game.Utility;

namespace Game
{
    public class Camera
    {

        public Game myGame;
        private int marioPosition;
        private int maxOffset = 400;
        public static int offset;        
        public int pipeTransitionOffset;
        private bool camIn;
        
        public Camera(Game game)
        {
            myGame = game;
        }
        

        public bool IsInCamera(int xCoor)
        {
            camIn = false;
            if (xCoor > myGame.marioState.offset - stdSpriteSize && xCoor < (myGame.marioState.offset + screenWidth))
            {
                camIn = true;
            }
            return camIn;
        }

        public int GetOffset()
        {

            
            marioPosition = myGame.marioState.XCoor;

            if (marioPosition - offset > maxOffset)
            {
                offset = marioPosition - maxOffset;
            }
            
            
            return offset;
        }

        public void reset()
        {
            offset = 0;
        }
    }
}
