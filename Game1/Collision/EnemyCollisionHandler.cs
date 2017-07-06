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
            }
            else if (hColFrom.Equals(Game.sides.right))
            {
                enemy.movingLeft = false;
            }
        }
        

    }
}