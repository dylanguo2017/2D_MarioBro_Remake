﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Fireball
    {
        public Physics ballPhys;
        Texture2D texture;
        Boolean deleted;

        Rectangle sourceRectangle, destinationRectangle;
        public int XCoor
        {
            get
            {
                return ballPhys.XCoor;
            }
            set
            {
                ballPhys.XCoor = value;
            }
        }
        public int YCoor
        {
            get
            {
                return ballPhys.YCoor;
            }
            set
            {
                ballPhys.YCoor = value;
            }
        }

        public Fireball(MarioStateClass mainState, Texture2D spriteSheet)
        {
            texture = spriteSheet;
            ballPhys = new Physics(mainState.XCoor + 8, mainState.YCoor);
            ballPhys.xVel = 1;
            deleted = false;
     
        }
        public void Update()
        {
            ballPhys.Update();
            ballPhys.xVel = 1;
        }

        public void Delete()
        {
            destinationRectangle = new Rectangle(0, 0, 0, 0);
            deleted = true;
        }
        public void Bounce()
        {
            ballPhys.yVel = -1;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (!deleted)
            {
                sourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
                destinationRectangle = new Rectangle(ballPhys.XCoor, ballPhys.YCoor, texture.Width, texture.Height);
                spriteBatch.Begin();
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
                spriteBatch.End();
            }
        }

        public Rectangle DestinationRectangle()
        {
            return destinationRectangle;
        }
    }
}
