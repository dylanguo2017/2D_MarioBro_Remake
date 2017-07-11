using Game.Enemies;

namespace Game
{
    public class MarioEnemyCollisionHandler
    {
        private Game myGame;
        public Game.sides hColFrom { get; set; }
        public Game.sides vColFrom { get; set; }

        public MarioEnemyCollisionHandler(Game game)
        {
            myGame = game;
        }

        public void HandleCollision(IMario mario, IEnemy enemy)
        {
            if (enemy.visible)
            {
                if (myGame.marioState.star)
                {
                    KillEnemy(enemy);
                }
                else
                {
                    if(vColFrom.Equals(Game.sides.top))
                    {
                        KillEnemy(enemy);
                    }
                    else if((hColFrom.Equals(Game.sides.left) || hColFrom.Equals(Game.sides.none) || vColFrom.Equals(Game.sides.bottom)) && !myGame.marioState.inv)
                    {
                        ChangeMarioState();   
                    }
                }
            }
        }


        private void KillEnemy(IEnemy enemy)
        {
            enemy.dead = true;
            enemy.StartTimer();
        }

        private void ChangeMarioState()
        {
            if ((myGame.mario.currentStatus()).Equals(MarioStateClass.marioStatus.small))
            {
                myGame.mario = new DeadMario(myGame);
            }
            else if ((myGame.mario.currentStatus()).Equals(MarioStateClass.marioStatus.large))
            {
                myGame.marioState.inv = true;
                myGame.mario = new SmallMario(myGame.marioState, myGame.marioSprites);
            }
            else if ((myGame.mario.currentStatus()).Equals(MarioStateClass.marioStatus.fire))
            {
                myGame.marioState.inv = true;
                myGame.mario = new LargeMario(myGame.marioState, myGame.marioSprites);
            }
        }

    }
}
