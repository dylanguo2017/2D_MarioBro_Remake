namespace Game
{
    class SpaceCommand : ICommand
    {
        private Game myGame;

        public SpaceCommand(Game game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.marioState.wPress = true;
        }
    }
}
