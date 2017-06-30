using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class ProjectileEnemyCollisionHandler : ICollisionResponseProjectile
    {
        private Game myGame;

        public ProjectileEnemyCollisionHandler(Game game)
        {
            myGame = game;
        }
        public void HandleCollision(Fireball fBalls, IObject gameObject, String marioCollidesFromHorizontalSide, String marioCollidesFromVerticalSide)
        {
            ISprite enemy = gameObject as ISprite;
            if (!enemy.type.Contains("Dead"))
            {
                KillEnemy(enemy);
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

