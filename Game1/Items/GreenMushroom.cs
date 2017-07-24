using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Game
{
    public class GreenMushroom : IItem
    {

        private Game myGame;
        public Point drawLocation;
        public Physics gmPhysics;
        public int currentLoc
        {
            get
            {
                return gmPhysics.XCoor;
            }
        }
        private Rectangle destinationRectangle;
        

        public int rows { get; set; }
        public int columns { get; set; }
        public Texture2D texture { get; set; }
        public int currentFrame { get; set; }
        public int totalFrame { get; set; }
        public Boolean visible { get; set; }
        public Boolean movingRight { get; set; }

        public GreenMushroom(Game game, Texture2D texture, int rows, int columns, int pointX, int pointY)
        {
            this.texture = texture;
            this.rows = rows;
            this.columns = columns;
            currentFrame = 1;
            totalFrame = this.rows * this.columns;
            myGame = game;
            gmPhysics = new Physics(pointX, pointY);
            visible = true;
            movingRight = true;
        }

        public virtual void Update()
        {
            if (movingRight.Equals(true))
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
                destinationRectangle = new Rectangle(gmPhysics.XCoor - myGame.camera.GetOffset(), gmPhysics.YCoor, width, height);

                spriteBatch.Begin();
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
                spriteBatch.End();
            }
        }

        public Rectangle DestinationRectangle()
        {
            return destinationRectangle;
        }


        public void MoveLeft()
        {
            gmPhysics.xVel--;
        }

        public void MoveRight()
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
