using static Game.Utility;

namespace Game
{
    public class ProjectileBlockCollisionHandler
    {
        private Game myGame;
        public sides hColFrom { get; set; }
        public sides vColFrom { get; set; }

        public ProjectileBlockCollisionHandler(Game game)
        {
            myGame = game;
        }

        public void HandleCollision(Fireball fBalls)
        {
            if (vColFrom.Equals(sides.top))
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
