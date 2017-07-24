using static Game.Utility;
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
                enemy.movingR = false;
            }
            else if (hColFrom.Equals(sides.right))
            {
                enemy.movingR = true;
            }

            if (vColFrom.Equals(sides.top))
            {
                enemy.enemyPhys.DontFall();
            }
            else if (vColFrom.Equals(sides.bottom))
            {

            }
        }
        

    }
}