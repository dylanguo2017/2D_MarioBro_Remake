using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Game
{
    public class RedMushroom : IItem
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
        public Boolean movingR;
        public Physics rmPhysics;
        public int spawnCtr = 0;

        public RedMushroom(Game game, int pointX, int pointY)
        {
            myGame = game;
            texture = myGame.itemSprite;
            rows = 21;
            columns = 36;
            currentFrame = 0;
          
            rmPhysics = new Physics(pointX, pointY);
            visible = true;
            movingR = true;
        }

        public void Update()
        {
            if (movingR.Equals(true))
            {
                MoveRight();
            }
            else
            {
                MoveLeft();
            }
            rmPhysics.Update();
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
                destinationRectangle = new Rectangle(rmPhysics.XCoor - myGame.camera.GetOffset(), rmPhysics.YCoor-spawnCtr, width, height);

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
            rmPhysics.xVel = -1;
        }

        private void MoveRight()
        {
            rmPhysics.xVel = 1;
        }

        public void PowerUp()
        {
            visible = false;
            myGame.soundEffect.PowerUp();

            if ((myGame.mario.currentStatus()).Equals(MarioStateClass.marioStatus.small))
            {
                if (myGame.marioState.star)
                {
                    myGame.mario = new LargeStarMario(myGame);
                }
                else
                {
                    myGame.mario = new LargeMario(myGame);
                }
            }
        }

    }
}
