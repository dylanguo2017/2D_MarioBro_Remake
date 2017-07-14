using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Game.Enemies
{
    public interface IEnemy
    {
        Physics enemyPhys { get; }
        Texture2D texture { get; set; }

        int rows { get; set; }

        int columns { get; set; }

        int currentFrame { get; set; }

        int totalFrame { get; set; }

        Boolean visible { get; set; }
        Boolean movingLeft { get; set; }
        Boolean movingRight { get; set; }
        Boolean dead { get; set; }

        Rectangle DestinationRectangle();

        void Update();

        void Draw(SpriteBatch spriteBatch);


       
        void StartTimer();
    }
}
