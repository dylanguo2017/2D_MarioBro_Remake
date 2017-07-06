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
                enemy.movingLeft = false;
            }
            else if (enemyColFrom.Equals("right"))
            {
                enemy.movingLeft = true;
            }
        }
        

    }
}