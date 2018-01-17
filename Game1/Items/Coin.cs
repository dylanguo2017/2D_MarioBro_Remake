using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using static Game.Utility;

namespace Game
{
    public class Coin : IItem
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

        public Boolean visible { get; set; }

        public Coin(Game game, int x, int y)
        {
            myGame = game;
            texture = myGame.itemSprite;
            rows = 21;
            columns = 36;
            currentFrame = 216;
            drawLoc = new Point(x , y);
            visible = true;
            
        }

        public void Update()
        {
            if(myGame.animMod % ten == zero)
            {
                currentFrame++;
                if (currentFrame == twoHundredNineteen)
                {
                    currentFrame = 252;
                }
                if (currentFrame == twoHundredFiftyFive)
                {
                    currentFrame = 216;
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
                destinationRectangle = new Rectangle(drawLoc.X - myGame.camera.GetOffset(), drawLoc.Y - (spawnCtr * two), width, height);

                spriteBatch.Begin();
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
                spriteBatch.End();
            }
        }

        public Rectangle DestinationRectangle()
        {
            return destinationRectangle;
        }
        
        public void Collect()
        {
            visible = false;
            myGame.soundEffect.Coin();
            myGame.hud.addCoin();
        }

        
    }
}
