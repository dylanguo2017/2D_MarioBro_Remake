using Game.Enemies;
using Microsoft.Xna.Framework;
using System;

namespace Game
{
    class EnemyCollisionHandler /*: ICollisionResponse*/
    {
        private Game myGame;

        public EnemyCollisionHandler(Game game)
        {
            myGame = game;
        }

        public void HandleCollision(IEnemy enemy, String enemyCollidesFrom)
        {
            if (enemyCollidesFrom.Equals("left"))
            {
                enemy.left = true;
                enemy.right = false;
            }
            else if (enemyCollidesFrom.Equals("right"))
            {
                enemy.right = true;
                enemy.left = false;
            }
        }
        

    }
}