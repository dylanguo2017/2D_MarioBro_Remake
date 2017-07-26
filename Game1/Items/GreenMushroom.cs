using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Game
{
    public class GreenMushroom : IItem
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
        public Physics gmPhysics;
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

        public GreenMushroom(Game game, int x, int y)
        {
            myGame = game;
            texture = myGame.itemSprite;
            rows = 21;
            columns = 36;
            currentFrame = 1;
            gmPhysics = new Physics(x, y);
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

            gmPhysics.Update();
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
                destinationRectangle = new Rectangle(gmPhysics.XCoor - myGame.camera.GetOffset(), gmPhysics.YCoor - spawnCtr, width, height);

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
            gmPhysics.xVel--;
        }

        private void MoveRight()
        {
            gmPhysics.xVel++;
        }

        public void OneUp()
        {
            visible = false;
            myGame.soundEffect.OneUp();
            myGame.hud.gainLife();
        }

    }
}
