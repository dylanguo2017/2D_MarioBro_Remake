using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using static Game.Utility;

namespace Game.Enemies
{
    public class PiranhaPlant : IEnemy
    {
        public Texture2D texture { get; set; }
        public Boolean visible { get; set; }

        private Game myGame;
        private Rectangle destinationRec;

        public Boolean movingR { get; set; }
        public Boolean dead { get; set; }

        private bool toggle;
        private bool up;

        private int mouthOpen; 
        private int mouthClose;
        private int maxHeight;
        private int height;

        private Physics piranhaPlantPhys;
        public Physics enemyPhys
        {
            get
            {
                return piranhaPlantPhys;
            }
        }

        public PiranhaPlant(Game game, int x, int y)
        {
            myGame = game;
            texture = myGame.piranhaPlant;

            visible = true;
            toggle = false;
            up = true;

            piranhaPlantPhys = new Physics(x + (stdSpriteSize) / two, y);
            mouthClose = 390;
            mouthOpen = 420;
            maxHeight = 24;
            height = 0;
        }

        public void Update()
        {
            if (myGame.animMod % twenty == zero)
            {
                if (!toggle)
                {
                    toggle = true;
                }
                else
                {
                    toggle = false;
                }

                StartTimer();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (visible)
            {
                int spriteY = 30;
                int width = 16;
                Rectangle sourceRec;

                if (!toggle)
                {
                    sourceRec = new Rectangle(mouthClose, spriteY, width, maxHeight);
                }
                else
                {
                    sourceRec = new Rectangle(mouthOpen, spriteY, width, maxHeight);
                }

                destinationRec = new Rectangle(piranhaPlantPhys.XCoor - myGame.camera.GetOffset(), piranhaPlantPhys.YCoor - height, width, maxHeight);

                spriteBatch.Begin();
                spriteBatch.Draw(texture, destinationRec, sourceRec, Color.White);
                spriteBatch.End();
            }
        }

        public Rectangle DestinationRectangle()
        {
            return destinationRec;
        }


        public void StartTimer()
        {
            if (up)
            {
                Up();   
            }
            else
            {
                Down();
            }
        }

        private void Up()
        {
            if (height < maxHeight)
            {
                height += 2;
            }
            else
            {
                up = false;
            }
        }

        private void Down()
        {
            if (height > minusTen)
            {
                height -= 2;
            }
            else
            {
                up = true;
            }
        }

    }
}
