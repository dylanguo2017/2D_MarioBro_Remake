using System;

namespace Game
{
    class MarioEnemyCollisionHandler : ICollisionResponse
    {
        private Game myGame;

        public MarioEnemyCollisionHandler(Game game)
        {
            myGame = game;
        }

        public void HandleCollison(IMario mario, IObject gameObject, String marioCollidesFromHorizontalSide, String marioCollidesFromVerticalSide)
        {
            ISprite enemy = gameObject as ISprite;
            if(!enemy.type.Contains("Dead"))
                {
                if (myGame.marioState.star)
                {
                    KillEnemy(enemy);
                }
                else
                {
                    if ((marioCollidesFromVerticalSide.Equals("bottom") || marioCollidesFromHorizontalSide.Equals("left") || marioCollidesFromHorizontalSide.Equals("right")))
                    {
                        if ((myGame.mario.currentStatus()).Equals(MarioStateClass.marioStatus.small))
                        {
                            myGame.mario = new DeadMario(myGame.marioState, myGame.marioSprites);
                        }
                        else if ((myGame.mario.currentStatus()).Equals(MarioStateClass.marioStatus.large))
                        {
                            myGame.mario = new SmallMario(myGame.marioState, myGame.marioSprites);
                        }
                        else if ((myGame.mario.currentStatus()).Equals(MarioStateClass.marioStatus.fire))
                        {
                            myGame.mario = new LargeMario(myGame.marioState, myGame.marioSprites);
                        }
                    }
                    else
                    {
                        KillEnemy(enemy);
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
