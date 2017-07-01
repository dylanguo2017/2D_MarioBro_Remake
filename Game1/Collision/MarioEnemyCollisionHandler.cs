using System;

namespace Game
{
    public class MarioEnemyCollisionHandler : ICollisionResponse
    {
        private Game myGame;

        public MarioEnemyCollisionHandler(Game game)
        {
            myGame = game;
        }

        public void HandleCollision(IMario mario, IObject gameObject, String marioCollidesFromHorizontalSide, String marioCollidesFromVerticalSide)
        {
            ISprite enemy = gameObject as ISprite;
            if(!enemy.type.Contains("Dead"))
                {
                if (myGame.marioState.star)
                {
                    KillEnemy(enemy);
                    enemy.visible = false;
                }
                else
                {
                    if (((marioCollidesFromVerticalSide.Equals("bottom") || marioCollidesFromHorizontalSide.Equals("left") || marioCollidesFromHorizontalSide.Equals("right"))) && !myGame.marioState.inv)
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
                    else if (marioCollidesFromVerticalSide.Equals("top"))
                    {
                        KillEnemy(enemy);
                        enemy.visible = false;
                    }
                }
            }
        }

        private void KillEnemy(ISprite enemy)
        {
            if (enemy.type.Equals("GoombaEnemy"))
            {
                enemy.ToggleSpriteSheet(myGame.goombaEnemyDead, 1, 1);
            }
            else
            {
                enemy.ToggleSpriteSheet(myGame.koopaEnemyDead, 1, 1);
            }
        }
    }
}
