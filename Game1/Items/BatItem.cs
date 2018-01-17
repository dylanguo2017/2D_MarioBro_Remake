using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using static Game.Utility;

namespace Game
{
    public class BatItem : IItem
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

        public BatItem(Game game, int x, int y)
        {
            myGame = game;
            texture = myGame.marioBatRight;
            drawLoc = new Point(x, y);
            visible = true;
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (visible)
            {
                Rectangle sourceRectangle = new Rectangle(nine,four, fourteen, twentyOne);
                destinationRectangle = new Rectangle(drawLoc.X - myGame.camera.GetOffset(), drawLoc.Y + spawnCtr, fourteen, twentyOne);

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
            destinationRectangle = new Rectangle(zero, zero, zero, zero);
            myGame.soundEffect.PowerUp();

            myGame.mario = new BatMario(myGame);
        }

    }
}
