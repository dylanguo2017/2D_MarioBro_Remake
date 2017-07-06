using Microsoft.Xna.Framework.Graphics;
using System;

namespace Game
{
    public interface IBackground
    {
        Texture2D texture { get; set; }
        int rows { get; set; }
        int columns { get; set; }
        Boolean visible { get; set; }
        int currentFrame { get; set; }
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
