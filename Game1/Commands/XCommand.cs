using Game.Sprites;

namespace Game
{
    class XCommand : ICommand
    {
        private Game myGame;

        public XCommand(Game game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.brickBlock.texture = myGame.invisibleBlockSprite;
            myGame.brickBlock.columns = 1;
        }
    }
}
