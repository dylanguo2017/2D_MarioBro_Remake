using Game.Enemies;

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
            if (enemy is PiranhaPlant)
            {
                enemy.visible = false;
            }
            else
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

