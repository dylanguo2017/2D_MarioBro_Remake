﻿using Microsoft.Xna.Framework.Graphics;
using System;
using Microsoft.Xna.Framework;


namespace Game
{
    public interface IBlock
    {
        
        Texture2D texture { get; set; }

        int rows { get; set; }

        int columns { get; set; }

        int currentFrame { get; set; }

        int totalFrame { get; set; }

        Boolean visible { get; set; }

        Boolean hit { get; set; }

        Rectangle DestinationRectangle();

        void Update();

        void Draw(SpriteBatch spriteBatch);

        int DrawLoc { get; }

    }
}
