using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Game.Enemies
{
    public class KoopaEnemy : IEnemy
    {
        private Game myGame;
        public Point drawLocation;
        private Rectangle destinationRectangle;
        public Rectangle sourceRectangle { get; set; }

        public int rows { get; set; }
        public int columns { get; set; }
        public int currentFrame { get; set; }
        public int totalFrame { get; set; }

        public Texture2D texture { get; set; }

        public Boolean visible { get; set; }
        public Boolean movingLeft { get; set; }
        public Boolean dead { get; set; }

        private int timer;

        public KoopaEnemy(Game game, Texture2D texture, int rows, int columns, int pointX, int pointY)
        {
            this.texture = texture;
            this.rows = rows;
            this.columns = columns;
            currentFrame = 3;
            totalFrame = this.rows * this.columns;
            myGame = game;
            drawLocation = new Point(pointX, pointY);
            visible = true;
            this.movingLeft = true;
            this.dead = false;
            myGame = game;
            timer = 0;
            
        }

        public void Update()
        {
            
               
            if (movingLeft)
            {
                currentFrame--;
                if (currentFrame == 1)
                {
                    currentFrame = 3;
                }
            }
            else
            {
                currentFrame++;
                if (currentFrame == 6)
                {
                    currentFrame = 4;
                }

            }
            if (movingLeft.Equals(true))
            {
                moveLeft();
            }
            else
            {
                moveRight();
            }
            if (dead)
            {
                currentFrame = 8;
                visible = false;
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

                sourceRectangle = new Rectangle(width * column, height * row, width, height);
                destinationRectangle = new Rectangle((int)drawLocation.X - myGame.camera.GetOffset(), (int)drawLocation.Y - 7, width, height);

                spriteBatch.Begin();
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
                spriteBatch.End();
            }
        }
        public void ToggleSpriteSheet(Texture2D texture, int rows, int columns)
        {
            this.texture = texture;
            this.rows = rows;
            this.columns = columns;
            this.currentFrame = 3;
            totalFrame = this.rows * this.columns;
            this.movingLeft = true;
        }
        public Rectangle DestinationRectangle()
        {
            return destinationRectangle;
        }

        public void moveLeft()
        {
            drawLocation.X--;
        }

        public void moveRight()
        {
            drawLocation.X++;
        }

        public void StartTimer()
        {
            if(timer < 1)
            {
                timer++;
            }
            else
            {
                this.visible = false;
            }
        }

    }
}
