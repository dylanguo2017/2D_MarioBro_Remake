using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Game.Enemies
{
    public class GoombaEnemy :IEnemy
    {
        public Texture2D texture;

        public Boolean visible { get; set; }

        public GoombaPositionDic goombaPosition = new GoombaPositionDic();

        private int rightFacingCurrentFrame;
        private int leftFacingCurrentFrame;

        public Boolean move;
        public Boolean left;
        public Boolean right;

        private Rectangle destinationRectangle;
        public Rectangle sourceRectangle { get; set; }

        private Game myGame;

        public GoombaEnemy(Texture2D spriteSheet, Game game)
        {
            texture = spriteSheet;
            myGame = game;

            move = true;
            left = true;
            right = true;
            visible = true;

            rightFacingCurrentFrame = 0;
            leftFacingCurrentFrame = 1;

        }

        public void Update()
        {
            
            if (move && left)
            {
                leftFacingCurrentFrame++;
                if (leftFacingCurrentFrame == 2)
                {
                    leftFacingCurrentFrame = 1;
                }

            }
            else if (move && right)
            {

                rightFacingCurrentFrame++;
                if (rightFacingCurrentFrame == 0)
                {
                    rightFacingCurrentFrame = 1;
                }

            }
           

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int width = 16;
            int height = 16;

            if (visible)
            {
                if (move && right)
                {

                    sourceRectangle = new Rectangle((int)this.goombaPosition.PositionArr[rightFacingCurrentFrame].X, (int)this.goombaPosition.PositionArr[rightFacingCurrentFrame].Y, width, height);

                }
                else
                {
                    sourceRectangle = new Rectangle((int)this.goombaPosition.PositionArr[leftFacingCurrentFrame].X, (int)this.goombaPosition.PositionArr[leftFacingCurrentFrame].Y, width, height);

                }
                destinationRectangle = new Rectangle((int)goombaPosition.PositionArr[rightFacingCurrentFrame].X - myGame.camera.GetOffset(), (int)goombaPosition.PositionArr[rightFacingCurrentFrame].Y, width, height);

                spriteBatch.Begin();
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
                spriteBatch.End();
            }
            
        }
        public Rectangle DestinationRectangle()
        {
            return destinationRectangle;
        }

    }
}
