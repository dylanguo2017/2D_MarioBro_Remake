using Game.Enemies;
using static Game.Game;

namespace Game
{
    public class MarioEnemyCollisionHandler
    {
        private Game myGame;
        public sides hColFrom { get; set; }
        public sides vColFrom { get; set; }

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
                    if(vColFrom.Equals(sides.top))
                    {
                        if (enemy is KoopaEnemy)
                        {
                            KoopaEnemy koopa = enemy as KoopaEnemy;
                            if (koopa.movingLeft || koopa.movingRight)
                            {
                                koopa.almostDead = true;
                                koopa.movingLeft = false;
                                koopa.movingRight = false;
                               // koopa.LifeTimer();
                            }
                            else if (koopa.almostDead)
                            {
                                koopa.dead = true;
                                koopa.almostDead = false;
                                koopa.movingLeft = false;
                                koopa.movingRight = false;
                                KillEnemy(koopa);
                            }
                        }
                        else
                        {
                            KillEnemy(enemy);
                        }
                        myGame.marioState.marioPhys.Bounce();
                    }
                    else if((hColFrom.Equals(sides.left) || hColFrom.Equals(sides.none) || vColFrom.Equals(sides.bottom)) && !myGame.marioState.inv)
                    {
                        ChangeMarioState();   
                    }
                }
            }
        }


        private void KillEnemy(IEnemy enemy)
        {
            myGame.soundEffect.Stomp();
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
                myGame.mario = new SmallMario(myGame);
            }
            else if ((myGame.mario.currentStatus()).Equals(MarioStateClass.marioStatus.fire))
            {
                myGame.marioState.inv = true;
                myGame.mario = new LargeMario(myGame);
            }
        }

    }
}
