using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Sprites
{
    class MotionlessNonAnimatedSprite : Sprite
    {
        private Sprite sprite;

        public MotionlessNonAnimatedSprite(Texture2D texture, int rows, int columns, int x, int y) : base(texture, rows, columns)
        {
            sprite = new Sprite(texture, rows, columns);
            location = new Point(x, y);
            type = texture.Name.ToString();
        }

        public override void Update()
        {
        }
    }
}
