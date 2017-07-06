using System;

namespace Game
{
    public class ProjectileBlockCollisionHandler
    {
        private Game myGame;

        public ProjectileBlockCollisionHandler(Game game)
        {
            myGame = game;
        }

        public void HandleCollision(Fireball fBalls, String projColFrom)
        {
            if (projColFrom.Equals("top"))
            {
                fBalls.Bounce();
            }
            else
            {
                fBalls.Delete();
            }
        }
    }
}
