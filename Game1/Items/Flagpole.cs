using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using static Game.Utility;

namespace Game
{
    public class Flagpole : IItem
    {

        private Game myGame;
        public Point poleLoc;
        private Rectangle poleDestinationRec;
        public int currentLoc
        {
            get
            {
                return poleLoc.X;
            }
        }
        public int rows { get; set; }
        public int columns { get; set; }
        public Texture2D texture { get; set; }
        public int currentFrame { get; set; }
        public int totalFrame { get; set; }
        public Boolean visible { get; set; }

        private Point flagLoc;

        public Flagpole(Game game, Texture2D texture, int rows, int columns, int pointX, int pointY)
        {
            this.texture = texture;
            this.rows = rows;
            this.columns = columns;
            currentFrame = 0;
            totalFrame = this.rows * this.columns;
            myGame = game;
            poleLoc = new Point(pointX, pointY);
            visible = true;
            flagLoc = poleLoc;
        }

        public virtual void Update()
        {
            if (myGame.marioState.flagpole || myGame.marioState.levelComp)
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

                Rectangle poleSourceRec = new Rectangle(sixteen, twentyFive, polWidth, polHeight);
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
