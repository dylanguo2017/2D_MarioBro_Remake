using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Game.Enemies
{
    public interface IEnemy
    {
        Boolean visible { get; set; }
        void Update();

        void Draw(SpriteBatch spritebatch);

        Rectangle DestinationRectangle();

        Rectangle SourceRectangle();


    }
}
