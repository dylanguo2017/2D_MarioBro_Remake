using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using static Game.Utility;

namespace Game
{
    public class Fireball
    {
        public Physics ballPhys;
        private Texture2D texture;
        public Boolean deleted;
        private Boolean left = false;
        private int offset = 0;

        Rectangle sourceRectangle, destinationRectangle;

        public int XCoor
        {
            get
            {
                return ballPhys.XCoor;
            }
            set
            {
                ballPhys.XCoor = value;
            }
        }

        public int YCoor
        {
            get
            {
                return ballPhys.YCoor;
            }
            set
            {
                ballPhys.YCoor = value;
            }
        }

        public Fireball(MarioStateClass mainState, Texture2D spriteSheet)
        {

            texture = spriteSheet;
            if (mainState.facingLeft)
            {
                ballPhys = new Physics(mainState.XCoor - eight, mainState.YCoor);
                ballPhys.xVel = -1;
                left = true;
            } else
            {
                ballPhys = new Physics(mainState.XCoor + eight, mainState.YCoor);
                ballPhys.xVel = 1;
            }
            offset = mainState.offset;
            deleted = false;
     
        }
        public void Update()
        {
            ballPhys.Update();
            if (left)
            {
                ballPhys.xVel = -2;
            }
            else
            {
                ballPhys.xVel = 2;
            }   
        }

        public void Delete()
        {
            destinationRectangle = new Rectangle(zero, zero, zero, zero);
            deleted = true;
        }

        public void Bounce()
        {
            ballPhys.Bounce();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!deleted)
            {
                sourceRectangle = new Rectangle(zero, zero, texture.Width, texture.Height);
                destinationRectangle = new Rectangle(ballPhys.XCoor - offset, ballPhys.YCoor, texture.Width, texture.Height);
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
