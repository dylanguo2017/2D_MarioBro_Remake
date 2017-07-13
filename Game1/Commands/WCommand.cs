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
            if (!myGame.marioState.marioPhys.falling)
            {
                myGame.soundEffect.Jump();
            }
            myGame.marioState.moveUp();
        }
    }
}
