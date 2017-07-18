using static Game.Utility;

namespace Game
{
    public class Transition
    {
        public Game myGame;
        private static bool transition = false;
        private int sinking;
        public bool transitioning
        {
            get
            {
                return transition;
            }
        }

        public Transition(Game game)
        {
            myGame = game;
            sinking = 33;
        }

        public void Update()
        {
            if (transition)
            {
                TransUpdate();
                if (!transition)
                {
                    myGame.camObj.LoadPipe();
                    myGame.pipeLevel = true;
                }
            }
        }

        public void TransUpdate()
        {
            myGame.marioState.left = false;
            myGame.marioState.right = false;
            myGame.marioState.up = false;
            myGame.marioState.down = false;
            if (myGame.animMod % four == zero)
            {
                myGame.marioState.marioPhys.YCoor++;
                sinking--;
                if(sinking == zero)
                {
                    transition = false;
                }
            }
        }
        public static void StartTransition()
        {
            transition = true;
        }
    }
}
