using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using static Game.Utility;

namespace Game
{
    public class FireFlower : IItem
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

        public FireFlower(Game game, int x, int y)
        {
            myGame = game;
            texture = myGame.itemSprite;
            rows = 21;
            columns = 36;
            currentFrame = 72;
            drawLoc = new Point(x, y);
            visible = true;            
        }

        public void Update()
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
