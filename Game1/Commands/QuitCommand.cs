namespace Game
{
    class QuitCommand : ICommand
    {
        private Game myGame;

        public QuitCommand(Game game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.Exit();
        }
    }
}
