
using Microsoft.Xna.Framework.Graphics;

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
            myGame.marioState.facingLeft = false;
            myGame.marioState.jump = false;
            myGame.marioState.crouch = false;
            myGame.marioState.move = false;
            myGame.marioState.XCoor = 48;
            myGame.marioState.YCoor = 432;

            myGame.camera.reset();
            myGame.marioState.offset = 0;

            myGame.mario = new SmallMario(myGame);

            Level.LoadLists(myGame);
            myGame.enemyList = Level.enemyList;
            myGame.blockList = Level.blockList;
            myGame.itemList = Level.itemList;
            myGame.bgList = Level.bgList;
            myGame.camObj.LoadLevel();

            myGame.sound.state = Game.soundStates.reset;
        }
    }
}
