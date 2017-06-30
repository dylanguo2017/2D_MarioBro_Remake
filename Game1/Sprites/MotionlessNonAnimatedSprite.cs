using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Sprites
{
    public class MotionlessNonAnimatedSprite : Sprite
    {
        private Sprite sprite;
        private Game myGame;

        public MotionlessNonAnimatedSprite(Game game, Texture2D texture, int rows, int columns, int x, int y) : base(game, texture, rows, columns)
        {
            myGame = game;
            sprite = new Sprite(myGame, texture, rows, columns);
            location = new Point(x, y);
            type = texture.Name.ToString();
        }

        public override void Update()
        {
        }
    }
}
