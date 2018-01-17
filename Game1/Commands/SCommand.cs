namespace Game
{
    class SCommand : ICommand
    {
        private Game myGame;

        public SCommand(Game game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.marioState.MoveDown();
        }
    }
}
