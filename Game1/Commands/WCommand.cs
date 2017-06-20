namespace Game
{
    class WCommand : ICommand
    {
        private Game myGame;

        public WCommand(Game game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.marioState.moveUp();
        }
    }
}
