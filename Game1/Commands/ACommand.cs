namespace Game
{
    class ACommand : ICommand
    {
        private Game myGame;

        public ACommand(Game game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.marioState.MoveL();
        }
    }
}
