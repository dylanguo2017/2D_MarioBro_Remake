using Game.Sprites;
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
            myGame.marioState.XCoor = 300;
            myGame.marioState.YCoor = 300;

            myGame.initialize.Game();
        }
    }
}
