using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using static Game.Utility;

namespace Game
{
    public class Pipe : IBlock
    {
        private Game myGame;

        public Point drawLoc;
        public int DrawLoc
        {
            get
            {
                return drawLoc.X;
            }
        }
        private Rectangle destinationRectangle;
        private Texture2D texture;

        private int rows;
        private int columns;
        private int currentFrame;

        public Boolean visible { get; set; }
        
        public Pipe(Game game, int x, int y)
        {
            myGame = game;
            texture = myGame.blockSprite;
            rows = 28;
            columns = 33;
            currentFrame = 264;
            drawLoc = new Point(x * stdSpriteSize, y * stdSpriteSize);
            visible = true;
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

                Rectangle sourceRectangle = new Rectangle(width * column, height * row, width*2, height*2);
                destinationRectangle = new Rectangle(drawLoc.X - myGame.camera.GetOffset(), drawLoc.Y, width*two, height* two);

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
