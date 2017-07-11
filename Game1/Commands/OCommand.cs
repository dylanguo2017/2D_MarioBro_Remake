using Microsoft.Xna.Framework.Graphics;

namespace Game
{
    class OCommand : ICommand
    {
        private Game myGame;


        public OCommand(Game game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.mario = new DeadMario(myGame.marioState, myGame.marioSprites);
            myGame.soundEffect.MarioDies();
        }
    }
}
