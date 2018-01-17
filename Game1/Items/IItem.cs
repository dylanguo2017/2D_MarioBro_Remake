using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework;


namespace Game
{
    public interface IItem 
    {
        Boolean visible { get; set; }
        Rectangle DestinationRectangle();
        void Update();
        void Draw(SpriteBatch spriteBatch);
        int DrawLoc { get; }        
        int spwnCtr { get; set; }
    }
}
