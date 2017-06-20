namespace Game
{
    class ALCommand : ICommand
    {
        private Game myGame;

        public ALCommand(Game game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.marioState.moveL();
        }
    }
}
