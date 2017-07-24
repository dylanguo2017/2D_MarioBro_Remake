using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Game
{
    public class Crack : IBlock
    {
        private Game myGame;

        private Point drawLoc;
        public int DrawLoc
        {
            get
            {
                return drawLoc.X;
            }
        }
        private Rectangle destinationRectangle;

        private int rows;
        private int columns;
        private int currentFrame;
        private int totalFrame;
        private int timer;

        public Texture2D texture { get; set; }
        public Boolean visible { get; set; }
        public Boolean hit { get; set; }

        public Crack(Game game, int x, int y)
        {
            myGame = game;
            texture = myGame.blockSprite;
            rows = 28;
            columns = 33;
            currentFrame = 0;
            totalFrame = rows * columns;
            drawLoc = new Point(x, y);

            visible = true;
            hit = false;
            timer = 0;
        }

        public void Update()
        {

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
                destinationRectangle = new Rectangle(drawLoc.X - myGame.camera.GetOffset(), drawLoc.Y, width, height);

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
