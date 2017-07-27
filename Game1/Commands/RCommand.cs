using Game.Infinite_Level;
using Microsoft.Xna.Framework.Input;

namespace Game
{
    class RCommand : ICommand
    {
        private Game myGame;

        public RCommand(Game game)
        {
            myGame = game;
        }

        public void Execute()
        {
            if (myGame.hud.lives == 0 || Keyboard.GetState().IsKeyDown(Keys.R))
            {
                myGame.begin = true;
                myGame.normal = false;
                myGame.infinite = false;
            }
            else if (myGame.normal)
            {
                Level.LoadLists(myGame);
                myGame.enemyList = Level.enemyList;
                myGame.blockList = Level.blockList;
                myGame.itemList = Level.itemList;
                myGame.bgList = Level.bgList;
                myGame.camObj.LoadLevel();
            }
            
            myGame.marioState.facingLeft = false;
            myGame.marioState.jump = false;
            myGame.marioState.crouch = false;
            myGame.marioState.move = false;
            myGame.marioState.lvlComp = false;
            myGame.marioState.XCoor = 48;
            myGame.marioState.YCoor = 432;

            myGame.camera.reset();
            myGame.marioState.offset = 0;

            myGame.hud.reset();

            myGame.gameover = false;

            myGame.mario = new SmallMario(myGame);

            Level.LoadLists(myGame);
           InfiniteLevelLoader.InfiniteLevelLoad(myGame);

            myGame.sound.state = Utility.soundStates.reset;
        }
    }
}
