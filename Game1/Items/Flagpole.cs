using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using static Game.Utility;

namespace Game
{
    public class Flagpole : IItem
    {
        public int DrawLoc
        {
            get
            {
                return poleLoc.X;
            }
        }

        private Game myGame;
        private int rows;
        private int columns;
        private int currentFrame;
        private Texture2D texture;
        private Point poleLoc;
        private Point flagLoc;
        private Rectangle poleDestinationRec;

        public bool flagDown;
        public Boolean visible { get; set; }

        public Flagpole(Game game, int x, int y)
        {
            myGame = game;
            texture = myGame.flagpole;
            rows = 1;
            columns = 1;
            currentFrame = 0;
            poleLoc = new Point(x * stdSpriteSize, y * stdSpriteSize);

            visible = true;
            flagDown = false;
            flagLoc = poleLoc;
        }

        public void Update()
        {
            if (flagDown)
            {
                myGame.soundEffect.Flagpole();
                if (flagLoc.Y != fourHundredSixteen)
                {
                    flagLoc.Y++;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (visible)
            {
                int flagSize = 16;
                int ballSize = 8;
                int polWidth = 2;
                int polHeight = 128;

                Rectangle ballSourceRec = new Rectangle(thirteen, one, ballSize, ballSize);
                Rectangle ballDestinationRec = new Rectangle(poleLoc.X - myGame.camera.GetOffset() - three, poleLoc.Y - ballSize, ballSize, ballSize);

                Rectangle poleSourceRec = new Rectangle(stdSpriteSize, twentyFive, polWidth, polHeight);
                poleDestinationRec = new Rectangle(poleLoc.X - myGame.camera.GetOffset(), poleLoc.Y, polWidth, polHeight);

                Rectangle flagSourceRec = new Rectangle(zero, nine, flagSize, flagSize);
                Rectangle flagDestinationRec = new Rectangle(poleLoc.X - myGame.camera.GetOffset() - flagSize, flagLoc.Y , flagSize, flagSize);

                spriteBatch.Begin();
                spriteBatch.Draw(texture, poleDestinationRec, poleSourceRec, Color.White);
                spriteBatch.Draw(texture, flagDestinationRec, flagSourceRec, Color.White);
                spriteBatch.Draw(texture, ballDestinationRec, ballSourceRec, Color.White);
                spriteBatch.End();
            }
        }

        public Rectangle DestinationRectangle()
        {
            return poleDestinationRec;
        }


    }
}
