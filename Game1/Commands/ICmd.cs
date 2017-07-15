namespace Game
{
    class ICmd : ICommand
    {
        private Game myGame;

        public ICmd(Game game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.mario = new FireMario(myGame);
        }
    }
}
