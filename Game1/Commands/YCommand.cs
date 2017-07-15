namespace Game
{
    class YCommand : ICommand
    {
        private Game myGame;

        public YCommand(Game game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.mario = new SmallMario(myGame);
        }
    }
}
