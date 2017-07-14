using Game.Enemies;

namespace Game
{
    class EnemyCollisionHandler 
    {
        private Game myGame;
        public Game.sides hColFrom { get; set; }
        public Game.sides vColFrom { get; set; }

        public EnemyCollisionHandler(Game game)
        {
            myGame = game;
        }

        public void HandleCollision(IEnemy enemy)
        {
            if (hColFrom.Equals(Game.sides.left))
            {
                enemy.movingLeft = true;
                enemy.movingRight = false;
            }
            else if (hColFrom.Equals(Game.sides.right))
            {
                enemy.movingRight = true;
                enemy.movingLeft = false;
            }

            if (vColFrom.Equals(Game.sides.top))
            {
                enemy.enemyPhys.DontFall();
            }
            else if (vColFrom.Equals(Game.sides.bottom))
            {
                // enemy is moving up
            }
        }
        

    }
}