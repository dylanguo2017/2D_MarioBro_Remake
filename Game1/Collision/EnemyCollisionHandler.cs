using Game.Enemies;
using System;

namespace Game
{
    class EnemyCollisionHandler 
    {
        private Game myGame;

        public EnemyCollisionHandler(Game game)
        {
            myGame = game;
        }

        public void HandleCollision(IEnemy enemy, String enemyColFrom)
        {
            if (enemyColFrom.Equals("left"))
            {
                enemy.left = true;
                enemy.right = false;
            }
            else if (enemyColFrom.Equals("right"))
            {
                enemy.right = true;
                enemy.left = false;
            }
        }
        

    }
}