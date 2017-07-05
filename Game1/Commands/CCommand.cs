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
            //myGame.bgList = Level.ReloadList(myGame.bgList, myGame.usedBlockSprite, "InvisibleBlock", 1);
        }

    }
}
