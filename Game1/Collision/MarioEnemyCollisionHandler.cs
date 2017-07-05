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
                    else if (marioColFromVerticalSide.Equals("top"))
                    {
                        KillEnemy(enemy);
                    }
                }
            }
        }

        private void KillEnemy(IEnemy enemy)
        {
            if (enemy is GoombaEnemy)
            {
                GoombaEnemy goomba = enemy as GoombaEnemy;
                goomba.sourceRectangle = new Rectangle((int)goomba.goombaPosition.PositionArr[2].X, (int)goomba.goombaPosition.PositionArr[2].Y, 16, 16);
            }
            else
            {
                KoopaEnemy koopa = enemy as KoopaEnemy;
                koopa.sourceRectangle = new Rectangle((int)koopa.koopaPosition.PositionArr[9].X, (int)koopa.koopaPosition.PositionArr[9].Y, 16, 16);
            }
            enemy.visible = false;
        }

    }
}
