using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Game
{
    public class Star : IItem
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

        public Boolean visible { get; set; }
        public bool movingR;
        public bool movingUp;
        private int spawnCtr = 0;
        public int spwnCtr
        {
            get
            {
                return spawnCtr;
            }
            set
            {
                spawnCtr = value;
            }
        }

        public Star (Game game, int x, int y)
        {
            myGame = game;
            texture = myGame.itemSprite;
            rows = 21;
            columns = 36;
            currentFrame = 108;
            drawLoc = new Point(x, y);

            visible = true;
            movingR = true;
            movingUp = true;
        }

        public virtual void Update()
        {
            if (myGame.animMod % 20 == 0)
            {
                currentFrame++;
                if (currentFrame == 111)
                {
                    currentFrame = 108;
                }
            }
            if (movingR)
            {
                MoveRight();
            }
            else
            {
                movingR = false;
                MoveLeft();
            }

            if (movingUp && destinationRectangle.Y > 300)
            {
                MoveUp();
            }
            else
            {
                movingUp = false;
                MoveDown();
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


        private void MoveUp()
        {
            drawLoc.Y--;
        }

        private void MoveDown()
        {
            drawLoc.Y++;
        }

        private void MoveLeft()
        {
            drawLoc.X--;
        }

        private void MoveRight()
        {
            drawLoc.X++;
        }

        public void PowerUp()
        {
            visible = false;
            myGame.soundEffect.PowerUp();

            if ((myGame.mario.currentStatus()).Equals(MarioStateClass.marioStatus.small))
            {
                myGame.mario = new SmallStarMario(myGame);
            }
            else
            {
                myGame.mario = new LargeStarMario(myGame);
            }
        }

    }
}
