using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using static Game.Utility;

namespace Game.Enemies
{
    public class Koopa : IEnemy
    {
        private Game myGame;
        private Rectangle destinationRectangle;
        private Rectangle sourceRectangle;

        private int rows;
        private int columns;
        private int currentFrame;

        public Texture2D texture { get; set; }

        public Boolean visible { get; set; }
        public Boolean movingL { get; set; }
        public Boolean movingR { get; set; }
        public Boolean almostDead { get; set; }
        public Boolean dead { get; set; }

        private Physics KoopaPhys;
        public Physics enemyPhys
        {
            get
            {
                return KoopaPhys;
            }
        }

        private int timer;
        private int deadOffset;
        private int lifeTimer;

        public Koopa(Game game, int x, int y)
        {
            myGame = game;
            texture = myGame.koopa;
            rows = 1;
            columns = 10;
            currentFrame = 3;
            KoopaPhys = new Physics(x, y);

            deadOffset = 0;
            timer = 0;
            lifeTimer = 0;

            visible = true;
            movingL = true;
            movingR = false;
            almostDead = false;
            dead = false;
        }

        public void Update()
        {
            if (myGame.animMod % twenty == zero && movingL)
            {
                 currentFrame--;
                 if (currentFrame == one)
                 {
                     currentFrame = 3;
                 }
                 MoveLeft();
            }
            else if (myGame.animMod % twenty == zero && movingR)
            {
                 currentFrame++;
                 if (currentFrame == six)
                 {
                     currentFrame = 4;
                 }
                 MoveRight();
            }
            else if (almostDead)
            {
                currentFrame = 8;
                lifeTimer++;
                if (lifeTimer > twenty)
                {
                    dead = true;
                }
                else
                {
                    currentFrame = 3;
                    movingL = true;
                }
            }
            else if (dead)
            {
                 currentFrame = 9;
                 timer++;
                 if (timer > twenty)
                 {
                     visible = false;
                 }
                 else
                 {
                     deadOffset = deadOffset + 10;
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
                destinationRectangle = new Rectangle(KoopaPhys.XCoor - myGame.camera.GetOffset() - deadOffset, KoopaPhys.YCoor - seven, width, height);

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
            KoopaPhys.XCoor--;
        }

        private void MoveRight()
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

        public void startLifeTimer()
        {
            if (lifeTimer < one)
            {
                lifeTimer++;
            }
            else if (lifeTimer == twenty)
            {
                currentFrame = 3;
                movingL = true;
            }
            else
            {
                dead = true;
            }
        }

    }
}
