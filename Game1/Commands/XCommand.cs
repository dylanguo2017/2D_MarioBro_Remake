using static Game.Utility;

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
            if(myGame.fbDelay == zero && myGame.marioState.curStat == MarioStateClass.marioStatus.fire && !myGame.marioState.lvlComp)
            {
                Fireball newBall = new Fireball(myGame.marioState, myGame.fireballSprite);
                myGame.fireBalls.Add(newBall);
                myGame.fbDelay = 40;
                myGame.soundEffect.Fireball();
            }
        }
    }
}
