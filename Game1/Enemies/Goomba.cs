using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using static Game.Utility;

namespace Game.Enemies
{
    public class Goomba : IEnemy
    {
        private Game myGame;
        private Physics GoombaPhys;
        public Physics enemyPhys
        {
            get
            {
                return GoombaPhys;
            }
        }

        private int rows;
        private int columns;
        private int currentFrame;
        private int timer;

        private Rectangle destinationRectangle;
        private Rectangle sourceRectangle;

        public Texture2D texture { get; set; }

        public Boolean visible { get; set; }
        public Boolean movingL { get; set; }
        public Boolean movingR { get; set; }
        public Boolean dead { get; set; }

        public Goomba(Game game, int x, int y)
        {
            myGame = game;
            texture = myGame.goomba;
            rows = 1;
            columns = 3;
            currentFrame = 0;
            timer = 0;

            GoombaPhys = new Physics(x, y);

            visible = true;
            movingL = true;
            movingR = false;
            dead = false;
        }

        public void Update()
        {
            if (myGame.animMod % twenty == zero)
            {
                currentFrame++;
                if (currentFrame == two)
                {
                    currentFrame = 0;
                }
            }
            if (dead)
            {
                currentFrame = 2;
                timer++;
                if (timer > twenty)
                {
                    visible = false;
                }
            }
            else if (movingL)
            {
                MoveLeft();
            }
            else if (movingR)
            {
                MoveRight();
            }

            GoombaPhys.Update();
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
                destinationRectangle = new Rectangle(GoombaPhys.XCoor - myGame.camera.GetOffset(), GoombaPhys.YCoor, width, height);

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
            GoombaPhys.XCoor--;
        }

        private void MoveRight()
        {
            GoombaPhys.XCoor++;
        }

        public void StartTimer()
        {
            
        }

    }
}
