﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Game
{
    public class StarItem : IItem
    {
        
        private Game myGame;
        public Point drawLocation;
        private Rectangle destinationRectangle;

        //private int moveUpDistance;
        public int rows { get; set; }
        public int columns { get; set; }
        public Texture2D texture { get; set; }
        public int currentFrame { get; set; }
        public int totalFrame { get; set; }
        public Boolean visible { get; set; }
        public Boolean movingRight { get; set; }
        //public Boolean movingUp { get; set; }

        public StarItem (Game game, Texture2D texture,int rows, int columns, int pointX, int pointY) 
        {
            this.texture = texture;
            this.rows = rows;
            this.columns =columns;
            currentFrame = 108;
            totalFrame = this.rows * this.columns;
            myGame = game;
            drawLocation = new Point(pointX, pointY);
            visible = true;
            this.movingRight = true;
            //this.movingUp = true;
            //moveUpDistance = 0;
        }

        public virtual void Update()
        {
            currentFrame++;
            if (currentFrame == 111)
            {
                currentFrame = 108;
            }

            if (movingRight && this.destinationRectangle.Y > 350)
            {
                moveRightUp();
            }
            else
            {
                movingRight = false;
                moveRightDown();
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (visible)
            {
                int width = texture.Width / columns;
                int height = texture.Height / rows;
                int row = (int)((float)currentFrame / (float)columns);
                int column = currentFrame % columns;

                Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
                destinationRectangle = new Rectangle((int)drawLocation.X - myGame.camera.GetOffset(), (int)drawLocation.Y, width, height);

                spriteBatch.Begin();
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
                spriteBatch.End();
            }
        }

        public Rectangle DestinationRectangle()
        {
            return destinationRectangle;
        }

        public void ToggleSpriteSheet(Texture2D texture, int rows, int columns)
        {
            this.texture = texture;
            this.rows = rows;
            this.columns = columns;
            this.currentFrame = 0;
            totalFrame = this.rows * this.columns;
            //this.movingRight = true;
        }

        public void moveRightUp()
        {
            drawLocation.X++;
            drawLocation.Y--;
        }

        public void moveRightDown()
        {
            drawLocation.X++;
            drawLocation.Y++;
        }

    }
}
