namespace Game
{
    class AUCommand : ICommand
    {
        private Game myGame;

        public AUCommand(Game game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.soundEffect.Jump();
            myGame.marioState.moveUp();
        }
    }
}
