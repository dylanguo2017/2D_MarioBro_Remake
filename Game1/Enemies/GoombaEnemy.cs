using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Game.Enemies
{
    public class GoombaEnemy :IEnemy
    {
        private Game myGame;
        public Physics GoombaPhys;
        public Physics enemyPhys
        {
            get
            {
                return GoombaPhys;
            }
        }
        private Rectangle destinationRectangle;
        private Rectangle sourceRectangle { get; set; }

        public int rows { get; set; }
        public int columns { get; set; }
        public int currentFrame { get; set; }
        public int totalFrame { get; set; }

        public Texture2D texture { get; set; }

        public Boolean visible { get; set; }
        public Boolean movingLeft { get; set; }
        public Boolean movingRight { get; set; }
        public Boolean dead { get; set; }

        private int timer;

        public GoombaEnemy(Game game, Texture2D texture, int rows, int columns, int pointX, int pointY)
        {
            this.texture = texture;
            this.rows = rows;
            this.columns = columns;
            currentFrame = 0;
            totalFrame = this.rows * this.columns;
            myGame = game;
            GoombaPhys = new Physics(pointX, pointY);
            visible = true;
            movingLeft = true;
            movingRight = false;
            dead = false;
            timer = 0;

        }

        public void Update()
        {
            if (myGame.animMod % 20 == 0)
            {
                currentFrame++;
                if (currentFrame == 2)
                {
                    currentFrame = 0;
                }
                else if (dead)
                {
                    currentFrame = 2;
                }
            }
            if (movingLeft)
            {
                moveLeft();
            }
            else if (movingRight)
            {
                moveRight();
            }
            GoombaPhys.Update();

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
                destinationRectangle = new Rectangle((int)GoombaPhys.XCoor - myGame.camera.GetOffset(), (int)GoombaPhys.YCoor, width, height);

                spriteBatch.Begin();
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
                spriteBatch.End();
            }
              
        }
        
        public Rectangle DestinationRectangle()
        {
            return destinationRectangle;
        }

        public void moveLeft()
        {
            GoombaPhys.XCoor--;
        }

        public void moveRight()
        {
            GoombaPhys.XCoor++;
        }

        public void StartTimer()
        {
            if (timer < 1)
            {
                timer++;
            }
            else
            {
                visible = false;
            }
        }

    }
}
