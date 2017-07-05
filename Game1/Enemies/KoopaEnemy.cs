using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Game.Enemies
{
    public class KoopaEnemy : IEnemy
    {
        public Texture2D texture;

        public Boolean visible { get; set; }

        public KoopaPositionDic koopaPosition = new KoopaPositionDic();

        private int rightFacingCurrentFrame;
        private int leftFacingCurrentFrame;

        public Boolean move;
        public Boolean left;
        public Boolean right;

        private Rectangle destinationRectangle;
        public Rectangle sourceRectangle;

        private Game myGame;

        public KoopaEnemy(Texture2D spriteSheet, Game game)
        {
            texture = spriteSheet;
            myGame = game;

            move = true;
            left = true;
            right = true;
            visible = true;

            rightFacingCurrentFrame = 120;
            leftFacingCurrentFrame = 90;

        }

        public void Update()
        {
            
               
            if (move && left)
            {
                leftFacingCurrentFrame++;
                if (leftFacingCurrentFrame == 60)
                {
                    leftFacingCurrentFrame = 90;
                }

            }
            else if (move && right)
            {

                rightFacingCurrentFrame++;
                if (rightFacingCurrentFrame == 151)
                {
                    rightFacingCurrentFrame = 120;
                }

            }
            


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int width = 16;
            int height = 24;

            if (visible)
            {
                if (move && right)
                {

                    sourceRectangle = new Rectangle((int)this.koopaPosition.PositionArr[rightFacingCurrentFrame].X, (int)this.koopaPosition.PositionArr[rightFacingCurrentFrame].Y, width, height);

                }
                else
                {
                    sourceRectangle = new Rectangle((int)this.koopaPosition.PositionArr[leftFacingCurrentFrame].X, (int)this.koopaPosition.PositionArr[leftFacingCurrentFrame].Y, width, height);

                }
                destinationRectangle = new Rectangle((int)koopaPosition.PositionArr[rightFacingCurrentFrame].X - myGame.camera.GetOffset(), (int)koopaPosition.PositionArr[rightFacingCurrentFrame].Y, width, height);

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
