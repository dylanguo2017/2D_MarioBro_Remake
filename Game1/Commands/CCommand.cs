namespace Game
{
    class CCommand : ICommand
    {
        private Game myGame;

        public CCommand(Game game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.list = Level.ReloadList(myGame.list, myGame.usedBlockSprite, "InvisibleBlock", 1);
        }

    }
}
