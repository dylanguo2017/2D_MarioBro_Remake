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
        private Texture2D texture;

        private int rows;
        private int columns;
        private int currentFrame;
        private int timer;

        public bool hit;

        public Boolean visible { get; set; }

        public BlueBrick(Game game, int x, int y)
        {
            myGame = game;
            texture = myGame.blueBlockSprite;
            rows = 1;
            columns = 2;
            currentFrame = 1;
            drawLoc = new Point(x * stdSpriteSize, y * stdSpriteSize);

            visible = true;
            hit = false;
            timer = 0;
        }

        public void Update()
        {
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

        private void BumpDown()
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
