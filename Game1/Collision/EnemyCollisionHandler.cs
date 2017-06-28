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
                // enemy bounces back to the right
            }
            else if (enemyCollidesFrom.Equals("right"))
            {
                // enemy bounces back to the left
            }
        }

    }
}