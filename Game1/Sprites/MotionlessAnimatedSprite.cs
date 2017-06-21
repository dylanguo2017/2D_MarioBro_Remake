using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game.Sprites
{
    class MotionlessAnimatedSprite : Sprite
    {
        private Sprite sprite;

        public MotionlessAnimatedSprite(Texture2D texture, int rows, int columns, int x, int y) : base(texture, rows, columns)
        {
            sprite = new Sprite(texture, rows, columns);
            location = new Point(x, y);
            type = texture.Name.ToString();
        }

        public override void Update()
        {
            currentFrame++;
            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
            }
        }

        public override void ToggleSpriteSheet(Texture2D texture, int rows, int columns)
        {
            this.texture = texture;
            this.rows = rows;
            this.columns = columns;
            this.currentFrame = 0;
            totalFrames = this.rows * this.columns;
            type = texture.Name.ToString();
        }

    }
}
