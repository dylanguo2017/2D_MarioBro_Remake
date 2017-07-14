namespace Game
{
    public class Camera
    {

        public Game myGame;
        private int marioPosition;
        private int maxOffset = 400;
        public static int offset;
        private bool camIn;
        
        public Camera(Game game)
        {
            myGame = game;
        }
        
              
        public bool IsInCamera(int xCoor)
        {
            camIn = false;
            if (xCoor > myGame.marioState.offset - 16 && xCoor < (myGame.marioState.offset + 800))
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
