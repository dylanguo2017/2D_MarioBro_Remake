namespace Game
{
    class DCommand : ICommand
    {
        private Game myGame;

        public DCommand(Game game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.marioState.MoveR();
        }
    }
}
