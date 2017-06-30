using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Game.Enemies
{
    public class GoombaEnemy :IEnemy
    {
        public Texture2D texture;

        GoombaPositionDic goombaPosition = new GoombaPositionDic();

        private int rightFacingCurrentFrame;
        private int leftFacingCurrentFrame;

        public Boolean move;
        public Boolean left;
        public Boolean right;

        private Rectangle destinationRectangle;

        public GoombaEnemy(Texture2D spriteSheet)
        {
            texture = spriteSheet;

            move = true;
            left = true;
            right = true;

            rightFacingCurrentFrame = 0;
            leftFacingCurrentFrame = 1;
           
        }
        public void Move()
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

        public void Update()
        {
            //if(Camera.offset + )
            if (move && left)
            {
                leftFacingCurrentFrame++;
                if (leftFacingCurrentFrame == 9)
                {
                    leftFacingCurrentFrame = 7;
                }
            }
            else if (move && right)
            {

                rightFacingCurrentFrame++;
                if (rightFacingCurrentFrame == 3)
                {
                    rightFacingCurrentFrame = 1;
                }

            }

        }

        public void Draw(SpriteBatch spritebatch)
        {
            int width = 17;
            int height = 17;
            Rectangle sourceRectangle;

           /* if (move)
            {
                if (right)
                {
                    sourceRectangle = new Rectangle((int)this.goombaPosition.PositionArr[rightFacingCurrentFrame].X, (int)this.goombaPosition.PositionArr[rightFacingCurrentFrame].Y, width, height);
                    destinationRectangle = new Rectangle();

                }
            }*/

        }
        public Rectangle DestinationRectangle()
        {
            return destinationRectangle;
        }
    }
}
