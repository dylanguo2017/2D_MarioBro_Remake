using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using static Game.Utility;

namespace Game
{
    public class BlueBrick : IBlock
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

        public Texture2D texture { get; set; }
        public Boolean visible { get; set; }
        public Boolean hit { get; set; }


        public BlueBrick(Game game, int x, int y)
        {
            myGame = game;
            texture = myGame.blueBlockSprite;
            rows = 1;
            columns = 2;
            currentFrame = 1;
            totalFrame = rows * columns;
            drawLoc = new Point(x, y);

            visible = true;
            hit = false;
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

        public void BumpUp()
        {
            hit = true;
            drawLoc.Y = drawLoc.Y - two;
            myGame.soundEffect.Bump();
        }

        public void BumpDown()
        {
            drawLoc.Y = drawLoc.Y + two;
        }

        public void Break()
        {
            visible = false;
            myGame.soundEffect.Break();
        }

    }
}
