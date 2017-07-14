namespace Game
{
    public class ProjectileBlockCollisionHandler
    {
        private Game myGame;
        public Game.sides hColFrom { get; set; }
        public Game.sides vColFrom { get; set; }

        public ProjectileBlockCollisionHandler(Game game)
        {
            myGame = game;
        }

        public void HandleCollision(Fireball fBalls)
        {
            if (vColFrom.Equals(Game.sides.top))
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
