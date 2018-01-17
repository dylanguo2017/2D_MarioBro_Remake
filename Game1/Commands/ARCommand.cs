namespace Game
{
    class ARCommand : ICommand
    {
        private Game myGame;

        public ARCommand(Game game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.marioState.MoveR();
        }
    }
}
