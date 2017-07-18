using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using static Game.Utility;

namespace Game.Enemies
{
    public class KoopaEnemy : IEnemy
    {
        private Game myGame;
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
        public Boolean almostDead { get; set; }
        public Boolean dead { get; set; }
        public Physics enemyPhys
        {
            get
            {
                return KoopaPhys;
            }
        }
        private Physics KoopaPhys;
        private int timer;
        private int lifeTimer;

        public KoopaEnemy(Game game, Texture2D texture, int rows, int columns, int pointX, int pointY)
        {
            this.texture = texture;
            this.rows = rows;
            this.columns = columns;
            currentFrame = 3;
            totalFrame = this.rows * this.columns;
            myGame = game;
            KoopaPhys = new Physics(pointX, pointY);
            visible = true;
            movingLeft = true;
            movingRight = false;
            almostDead = false;
            dead = false;
            timer = 0;
            lifeTimer = 0;
            
        }

        public void Update()
        {
            if(myGame.animMod % twenty == zero)
            {
                if (movingLeft)
                {
                    currentFrame--;
                    if (currentFrame == one)
                    {
                        currentFrame = 3;
                    }
                    moveLeft();
                }
                else if (movingRight)
                {
                    currentFrame++;
                    if (currentFrame == six)
                    {
                        currentFrame = 4;
                    }
                    moveRight();
                }
                else if (almostDead)
                {
                    currentFrame = 8;
                }
                else if (dead)
                {
                    currentFrame = 9;
                }
            }

            KoopaPhys.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (visible)
            {
                int width = texture.Width / columns;
                int height = texture.Height / rows;
                int row = currentFrame / columns;
                int column = currentFrame % columns;

                sourceRectangle = new Rectangle(width * column, height * row, width, height);
                destinationRectangle = new Rectangle(KoopaPhys.XCoor - myGame.camera.GetOffset(), KoopaPhys.YCoor - seven, width, height);

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
            KoopaPhys.XCoor--;
        }

        public void moveRight()
        {
            KoopaPhys.XCoor++;
        }

        public void StartTimer()
        {
            if(timer < 1)
            {
                timer++;
            }
            else
            {
                visible = false;
            }
        }

        public void LifeTimer()
        {
            if (currentFrame == 8 && lifeTimer < 4)
            {
                lifeTimer++;
            }
            else
            {
                currentFrame = 3;
                movingLeft = true;
            }
        }

    }
}
