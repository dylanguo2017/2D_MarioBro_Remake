using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Game
{
    public class RedMushroomItem : IItem
    {

        private Game myGame;
       
        public Physics rmPhysics;
        public int currentLoc
        {
            get
            {
                return rmPhysics.XCoor;
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
        public int spawnCtr = 0;

        public RedMushroomItem(Game game, Texture2D texture, int rows, int columns, int pointX, int pointY)
        {
            this.texture = texture;
            this.rows = rows;
            this.columns = columns;
            currentFrame = 0;
            totalFrame = this.rows * this.columns;
            myGame = game;
          
            rmPhysics = new Physics(pointX, pointY);
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
            rmPhysics.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (visible)
            {
                int width = texture.Width / columns;
                int height = texture.Height / rows;
                int row = (int)((float)currentFrame / (float)columns);
                int column = currentFrame % columns;

                Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
                destinationRectangle = new Rectangle((int)rmPhysics.XCoor - myGame.camera.GetOffset(), (int)rmPhysics.YCoor-spawnCtr, width, height);

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
                    myGame.mario = new LargeMario(myGame.marioState, myGame.marioSprites);
                }
            }
        }

    }
}
