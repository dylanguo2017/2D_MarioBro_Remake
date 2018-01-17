using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Game.Enemies
{
    public interface IEnemy
    {
        Physics enemyPhys { get; }
        Texture2D texture { get; set; }
        Rectangle DestinationRectangle();

        Boolean visible { get; set; }
        Boolean movingR { get; set; }
        Boolean dead { get; set; }

        void Draw(SpriteBatch spriteBatch);
        void Update();
        void StartTimer();
    }
}
