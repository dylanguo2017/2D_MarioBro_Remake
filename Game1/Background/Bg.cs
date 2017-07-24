using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Game.Utility;

namespace Game
{
    public class Bg : IBg
    {
        public Texture2D texture { get; set; }

        private Game myGame;
        private Point location;

        public Bg(Game game, Texture2D texture, int x, int y)
        {
            this.texture = texture;
            location = new Point(x * stdSpriteSize, y * stdSpriteSize);

            myGame = game;
        }

        public virtual void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int width = texture.Width;
            int height = texture.Height;

            Rectangle sourceRectangle = new Rectangle(zero, zero, width, height);
            Rectangle destinationRectangle = new Rectangle(location.X - myGame.camera.GetOffset(), location.Y, width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
        
    }
}
