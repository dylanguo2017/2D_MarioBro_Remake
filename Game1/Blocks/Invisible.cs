using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using static Game.Utility;

namespace Game
{
    public class Invisible : IBlock
    {

        private Game myGame;
        public Point drawLocation;
        public int DrawLoc
        {
            get
            {
                return drawLocation.X;
            }
        }
        private Rectangle destinationRectangle;

        public int rows { get; set; }
        public int columns { get; set; }
        public Texture2D texture { get; set; }
        public int currentFrame { get; set; }
        public int totalFrame { get; set; }
        public Boolean visible { get; set; }
        public Boolean hit { get; set; }
        public int timer;
        public Boolean used;
        

        public Invisible(Game game, Texture2D texture, int rows, int columns, int pointX, int pointY)
        {
            this.texture = texture;
            this.rows = rows;
            this.columns = columns;
            currentFrame = 920;
            totalFrame = this.rows * this.columns;
            myGame = game;
            drawLocation = new Point(pointX, pointY);
            visible = true;
            hit = false;
            timer = 0;
            used = false;
        }

        public void Update()
        {
            if (currentFrame != twentySeven)
            {

                currentFrame = 920;

            }
            if (hit)
            {
                if (timer < one)
                {
                    timer++;
                }
                else
                {
                    timer = 0;
                    hit = false;
                    BumpDown();
                    myGame.marioState.marioPhys.YCoor += two;
                }
            }


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (visible)
            {
                int width = texture.Width / columns;
                int height = texture.Height / rows;
                int row = currentFrame / columns;
                int column = currentFrame % columns;

                Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
                destinationRectangle = new Rectangle(drawLocation.X - myGame.camera.GetOffset(), drawLocation.Y, width, height);

                spriteBatch.Begin();
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
                spriteBatch.End();
            }
        }

        public Rectangle DestinationRectangle()
        {
            return destinationRectangle;
        }

        public void BumpUp()
        {
            hit = true;
            drawLocation.Y -= two;
            myGame.soundEffect.Bump();
        }

        public void BumpDown()
        {
            drawLocation.Y += two;
        }

        public void ChangeToUsed()
        {
            currentFrame = 27;
            used = true;
        }



    }
}
