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

        public void HandleCollision(ISprite enemy, String enemyCollidesFrom)
        {
            if (enemyCollidesFrom.Equals("left"))
            {
                //System.Diagnostics.Debug.WriteLine("change to left");
                enemy.right = false;
            }
            else if (enemyCollidesFrom.Equals("right"))
            {
                //System.Diagnostics.Debug.WriteLine("change to right");
                enemy.right = true;
            }
        }

    }
}