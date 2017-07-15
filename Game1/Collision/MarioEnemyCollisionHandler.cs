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
                    else if((hColFrom.Equals(Game.sides.left) || hColFrom.Equals(Game.sides.none) || vColFrom.Equals(Game.sides.bottom)) && !myGame.marioState.inv)
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
            myGame.hud.increasePoints(100);
        }

        private void ChangeMarioState()
        {
            if ((myGame.mario.currentStatus()).Equals(MarioStateClass.marioStatus.small))
            {
                myGame.mario = new DeadMario(myGame);
                myGame.hud.looseLife();
                myGame.hud.decreasePoints(100);
            }
            else if ((myGame.mario.currentStatus()).Equals(MarioStateClass.marioStatus.large))
            {
                myGame.marioState.inv = true;
                myGame.mario = new SmallMario(myGame);
                myGame.hud.decreasePoints(50);
            }
            else if ((myGame.mario.currentStatus()).Equals(MarioStateClass.marioStatus.fire))
            {
                myGame.marioState.inv = true;
                myGame.mario = new LargeMario(myGame);
                myGame.hud.decreasePoints(50);
            }
        }

    }
}
