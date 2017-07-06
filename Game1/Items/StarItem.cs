using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Game
{
    public class StarItem : IItem
    {
        
        private Game myGame;
        private Point drawLocation;
        private Rectangle destinationRectangle;

        public int rows { get; set; }
        public int columns { get; set; }
        public Texture2D texture { get; set; }
        public int currentFrame { get; set; }
        public int totalFrame { get; set; }
        public Boolean visible { get; set; }
        public Boolean movingRight { get; set; }
        public Boolean movingUp { get; set; }

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
            movingRight = true;
            movingUp = true;
        }

        public virtual void Update()
        {
            currentFrame++;
            if (currentFrame == 111)
            {
                currentFrame = 108;
            }

            if (movingRight)
            {
                Right();
            }
            else
            {
                movingRight = false;
                Left();
            }

            if (movingUp && destinationRectangle.Y > 300)
            {
                Up();
            }
            else
            {
                movingUp = false;
                Down();
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


        public void Up()
        {
            drawLocation.Y = drawLocation.Y - 5;
        }

        public void Down()
        {
            drawLocation.Y = drawLocation.Y + 5;
        }

        public void Left()
        {
            drawLocation.X = drawLocation.X - 5;
        }
        public void Right()
        {
            drawLocation.X = drawLocation.X + 5;
        }

    }
}
