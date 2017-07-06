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
            enemy.dead = true;
            enemy.StartTimer();
        }
    }

}

