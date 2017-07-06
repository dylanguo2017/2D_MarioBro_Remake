using Microsoft.Xna.Framework.Graphics;
using System;

namespace Game
{
    public interface ISprite 
    {
        Texture2D texture { get; set; }
        int rows { get; set; }
        int columns { get; set; }
        String type { get; set; }
        Boolean visible { get; set; }
        int currentFrame { get; set; }
        Boolean right { get; set; }
        void Update();
        void Draw(SpriteBatch spriteBatch);
        void ToggleSpriteSheet(Texture2D texture, int rows, int columns);
    }
}
