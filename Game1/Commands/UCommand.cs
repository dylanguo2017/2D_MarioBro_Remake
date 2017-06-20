namespace Game
{
    class UCommand : ICommand
    {
        private Game myGame;

        public UCommand(Game game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.mario = new LargeMario(myGame.marioState, myGame.marioSprites);
        }
    }
}
