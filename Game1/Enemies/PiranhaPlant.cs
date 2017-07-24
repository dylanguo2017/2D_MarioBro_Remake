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
        private Rectangle destinationRectangle;

        public Boolean movingR { get; set; }
        public Boolean dead { get; set; }

        private bool toggle;
        private int mouthOpen; 
        private int mouthClose;
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

            piranhaPlantPhys = new Physics(x + (stdSpriteSize) / two, y);
            mouthClose = 390;
            mouthOpen = 420;
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
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (visible)
            {
                int spriteY = 30;
                int width = 16;
                int height = 23;
                Rectangle sourceRectangle;

                if (!toggle)
                {
                    sourceRectangle = new Rectangle(mouthClose, spriteY, width, height);
                }
                else
                {
                    sourceRectangle = new Rectangle(mouthOpen, spriteY, width, height);
                }

                destinationRectangle = new Rectangle(piranhaPlantPhys.XCoor - myGame.camera.GetOffset(), piranhaPlantPhys.YCoor - height, width, height);

                spriteBatch.Begin();
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
                spriteBatch.End();
            }
        }

        public Rectangle DestinationRectangle()
        {
            return destinationRectangle;
        }


        public void StartTimer()
        {
        }

    }
}
