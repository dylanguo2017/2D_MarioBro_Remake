using Game.Enemies;
using Microsoft.Xna.Framework;
using System;

namespace Game
{
    public class MarioEnemyCollisionHandler
    {
        private Game myGame;

        public MarioEnemyCollisionHandler(Game game)
        {
            myGame = game;
        }

        public void HandleCollision(IMario mario, IEnemy enemy, String marioColFromHorizontalSide, String marioColFromVerticalSide)
        {
            if (enemy.visible)
            {
                if (myGame.marioState.star)
                {
                    KillEnemy(enemy);
                }
                else
                {
                    if (((marioColFromVerticalSide.Equals("bottom") || marioColFromHorizontalSide.Equals("left") || marioColFromHorizontalSide.Equals("right"))) && !myGame.marioState.inv)
                    {
                        ChangeMarioState();   
                    }
                    else if (marioColFromVerticalSide.Equals("top"))
                    {
                        KillEnemy(enemy);
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
                myGame.mario = new DeadMario(myGame.marioState, myGame.marioSprites);
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
