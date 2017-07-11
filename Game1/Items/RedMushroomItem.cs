﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Game
{
    public class RedMushroomItem : IItem
    {

        private Game myGame;
        public Point drawLocation;
        private Rectangle destinationRectangle;

        public int rows { get; set; }
        public int columns { get; set; }
        public Texture2D texture { get; set; }
        public int currentFrame { get; set; }
        public int totalFrame { get; set; }
        public Boolean visible { get; set; }
        public Boolean movingRight { get; set; }

        public RedMushroomItem(Game game, Texture2D texture, int rows, int columns, int pointX, int pointY)
        {
            this.texture = texture;
            this.rows = rows;
            this.columns = columns;
            currentFrame = 0;
            totalFrame = this.rows * this.columns;
            myGame = game;
            drawLocation = new Point(pointX, pointY);
            visible = true;
            movingRight = true;
        }

        public virtual void Update()
        {
            if (movingRight.Equals(true))
            {
                MoveRight();
            }
            else
            {
                MoveLeft();
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


        private void MoveLeft()
        {
            drawLocation.X = drawLocation.X - 3;
        }

        private void MoveRight()
        {
            drawLocation.X = drawLocation.X + 3;
        }

        public void PowerUp()
        {
            visible = false;
            myGame.soundEffect.PowerUp();

            if ((myGame.mario.currentStatus()).Equals(MarioStateClass.marioStatus.small))
            {
                myGame.mario = new LargeStarMario(myGame.marioState, myGame.marioSprites);
            }
        }

    }
}
