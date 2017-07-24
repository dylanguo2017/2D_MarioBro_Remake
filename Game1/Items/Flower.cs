using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using static Game.Utility;

namespace Game
{
    public class Flower : IItem
    {

        private Game myGame;
        public Point drawLocation;
        private Rectangle destinationRectangle;
        public int currentLoc
        {
            get
            {
                return drawLocation.X;
            }
        }
        public int rows { get; set; }
        public int columns { get; set; }
        public Texture2D texture { get; set; }
        public int currentFrame { get; set; }
        public int totalFrame { get; set; }
        public Boolean visible { get; set; }
        

        public Flower(Game game, Texture2D texture, int rows, int columns, int pointX, int pointY)
        {
            this.texture = texture;
            this.rows = rows;
            this.columns = columns;
            currentFrame = 72;
            totalFrame = this.rows * this.columns;
            myGame = game;
            drawLocation = new Point(pointX, pointY);
            visible = true;            
        }

        public virtual void Update()
        {
            if (myGame.animMod % twenty == zero)
            {
                currentFrame++;
                if (currentFrame == seventyFive)
                {
                    currentFrame = 72;
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
                destinationRectangle = new Rectangle(drawLocation.X - myGame.camera.GetOffset(), drawLocation.Y, width, height);

                spriteBatch.Begin();
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
                spriteBatch.End();
            }
        }

        public Rectangle DestinationRectangle()
        {
            return destinationRectangle;
        }

        public void PowerUp()
        {
            visible = false;
            myGame.soundEffect.PowerUp();

            if (myGame.marioState.star)
            {
                myGame.mario = new LargeStarMario(myGame);
                myGame.marioState.curStat = MarioStateClass.marioStatus.fire;
            }
            else
            {
                myGame.mario = new FireMario(myGame);
            }
        }

    }
}
