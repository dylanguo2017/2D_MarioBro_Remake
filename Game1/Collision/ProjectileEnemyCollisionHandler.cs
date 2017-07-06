using Game.Enemies;
using Microsoft.Xna.Framework;
using System;

namespace Game
{
    class ProjectileEnemyCollisionHandler
    {
        private Game myGame;

        public ProjectileEnemyCollisionHandler(Game game)
        {
            myGame = game;
        }
        public void HandleCollision(IEnemy enemy)
        {
            if (enemy.visible)
            {
                KillEnemy(enemy);
            }
        }

        private void KillEnemy(IEnemy enemy)
        {
            //if (enemy is GoombaEnemy)
            //{
            //    GoombaEnemy goomba = enemy as GoombaEnemy;
            //    goomba.sourceRectangle = new Rectangle((int)goomba.goombaPosition.PositionArr[2].X, (int)goomba.goombaPosition.PositionArr[2].Y, 16, 16);
            //}
            //else
            //{
            //    KoopaEnemy koopa = enemy as KoopaEnemy;
            //    koopa.sourceRectangle = new Rectangle((int)koopa.koopaPosition.PositionArr[9].X, (int)koopa.koopaPosition.PositionArr[9].Y, 16, 16);
            //}
            enemy.visible = false;
        }
    }

}

