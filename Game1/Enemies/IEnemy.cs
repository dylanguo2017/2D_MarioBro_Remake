﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Game.Enemies
{
    public interface IEnemy
    {
        Texture2D texture { get; set; }

        int rows { get; set; }

        int columns { get; set; }

        int currentFrame { get; set; }

        int totalFrame { get; set; }

        Boolean visible { get; set; }
        Boolean dead { get; set; }

        Rectangle DestinationRectangle();

        void Update();

        void Draw(SpriteBatch spriteBatch);


        Boolean movingLeft { get; set; }
        void StartTimer();
    }
}
