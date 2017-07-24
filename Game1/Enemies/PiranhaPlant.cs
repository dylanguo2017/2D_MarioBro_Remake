using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Game.Enemies
{
    public class PiranhaPlant : IEnemy
    {
        public Texture2D texture { get; set; }
        public Boolean visible { get; set; }

        private Game myGame;
        private Point drawLoc;
        private Rectangle destinationRectangle;

        public Boolean movingL { get; set; }
        public Boolean movingR { get; set; }
        public Boolean dead { get; set; }

        private Physics PiranhaPlantPhys;
        public Physics enemyPhys
        {
            get
            {
                return PiranhaPlantPhys;
            }
        }


        public PiranhaPlant(Game game, int x, int y)
        {
            myGame = game;
            texture = myGame.piranhaPlant;
            drawLoc = new Point(x, y);
            PiranhaPlantPhys = new Physics(x, y);
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int spriteX = 390;
            int spriteY = 30;
            int width = 16;
            int height = 23;

            Rectangle sourceRectangle = new Rectangle(spriteX, spriteY, width, height);
            destinationRectangle = new Rectangle(drawLoc.X - myGame.camera.GetOffset(), drawLoc.Y - height, width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
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
