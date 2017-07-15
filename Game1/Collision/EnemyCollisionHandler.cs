using static Game.Game;
using Game.Enemies;

namespace Game
{
    class EnemyCollisionHandler 
    {
        private Game myGame;
        public sides hColFrom { get; set; }
        public sides vColFrom { get; set; }

        public EnemyCollisionHandler(Game game)
        {
            myGame = game;
        }

        public void HandleCollision(IEnemy enemy)
        {
            if (hColFrom.Equals(sides.left))
            {
                enemy.movingLeft = true;
                enemy.movingRight = false;
            }
            else if (hColFrom.Equals(sides.right))
            {
                enemy.movingRight = true;
                enemy.movingLeft = false;
            }

            if (vColFrom.Equals(sides.top))
            {
                enemy.enemyPhys.DontFall();
            }
            else if (vColFrom.Equals(sides.bottom))
            {
                // enemy is moving up
            }
        }
        

    }
}