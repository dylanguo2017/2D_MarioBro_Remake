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
            foreach(IBlock block in myGame.blockList)
            {
                if(block is Invisible)
                {
                    Invisible invisible = block as Invisible;
                    if (!invisible.used)
                    {
                        invisible.BumpUp();
                        invisible.ChangeToUsed();
                    }
                }
            }
        }

    }
}
