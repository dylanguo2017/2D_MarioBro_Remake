using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework;


namespace Game
{
    public interface IBlock
    {
        Texture2D texture { get; set; }
        Boolean visible { get; set; }
        int DrawLoc { get; }
        Rectangle DestinationRectangle();
        void Draw(SpriteBatch spriteBatch);
        void Update();
    }
}
