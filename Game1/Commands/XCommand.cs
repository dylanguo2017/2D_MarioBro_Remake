
namespace Game
{
    class XCommand : ICommand
    {
        private Game myGame;

        public XCommand(Game game)
        {
            myGame = game;
        }

        public void Execute()
        {
            if(myGame.fbDelay == 0 && myGame.marioState.curStat == MarioStateClass.marioStatus.fire)
            {
                Fireball newBall = new Fireball(myGame.marioState, myGame.fireballSprite);
                myGame.fireBalls.Add(newBall);
                myGame.fbDelay = 40;
            }
        }
    }
}
