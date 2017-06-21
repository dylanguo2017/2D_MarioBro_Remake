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
            Level.ReloadList(myGame.list, myGame.invisibleBlockSprite, "BrickBlock", 1);
        }
    }
}
