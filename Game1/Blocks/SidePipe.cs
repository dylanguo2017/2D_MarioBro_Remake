using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Blocks
{
    public class SidePipe : IBlock
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


        public SidePipe(Game game, Texture2D texture, int rows, int columns, int pointX, int pointY)
        {
            this.texture = texture;
            this.rows = rows;
            this.columns = columns;
            currentFrame = 266;
            totalFrame = this.rows * this.columns;
            myGame = game;
            drawLocation = new Point(pointX, pointY);
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
                int row = (int)((float)currentFrame / (float)columns);
                int column = currentFrame % columns;

                Rectangle sourceRectangle = new Rectangle(width * column, height * row, width * 2, height * 2);
                destinationRectangle = new Rectangle((int)drawLocation.X - myGame.camera.GetOffset(), (int)drawLocation.Y, width * 2, height * 2);

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
