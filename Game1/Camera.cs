namespace Game
{
    public class Camera
    {

        public Game myGame;
        private int marioPosition;
        public int width = 800;
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
            int maxOffset = 400;
            
            marioPosition = myGame.marioState.XCoor;

            if (marioPosition - offset > maxOffset)
            {
                offset = marioPosition - maxOffset;
            }
            
            
            return offset;
        }
    }
}
