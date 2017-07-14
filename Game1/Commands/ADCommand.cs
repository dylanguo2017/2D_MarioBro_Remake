namespace Game
{
    class ADCommand : ICommand
    {
        private Game myGame;

        public ADCommand(Game game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.marioState.MoveDown();
        }
    }
}
