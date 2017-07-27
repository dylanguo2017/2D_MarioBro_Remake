using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using static Game.Utility;

namespace Game.Enemies
{
    public class SpinFireBeam : IItem

    {
        public Texture2D texture { get; set; }
        public Boolean visible { get; set; }
        
        public Game myGame;
        
        Vector2 spriteOrigin;
        Vector2 spritePosition;
        private float rotation;
        private int rows;
        private int columns;        
        private Point drawLoc;
        public int DrawLoc
        {
            get
            {
                return drawLoc.X;
            }
        }
        private int spawnCtr = 0;
        public int spwnCtr
        {
            get
            {
                return spawnCtr;
            }
            set
            {
                spawnCtr = value;
            }
        }

        private Rectangle destinationRectangle;
        int width;
        int height;
        


        public SpinFireBeam(Game game, int x, int y)
        {
            myGame = game;
            texture = myGame.fireBeamSprite;
            visible = true;
            drawLoc = new Point(x, y);
            rows = 3;
            columns = 1;            
            width = texture.Width / columns;
            height = texture.Height / rows;
             


        }

        public void Update()
        {
            if (myGame.animMod % two == zero)
            {
               
                
                rotation += 0.1f;
               
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (visible)
            {                                                
                destinationRectangle = new Rectangle(drawLoc.X - myGame.camera.GetOffset(), drawLoc.Y, width, height*three);
                spritePosition.X = destinationRectangle.X;
                spritePosition.Y = destinationRectangle.Y;
                spriteOrigin.X = texture.Width / 2;
                spriteOrigin.Y = 2;

                spriteBatch.Begin();
                spriteBatch.Draw(texture, spritePosition, null, Color.White,rotation,spriteOrigin,1f, SpriteEffects.None,0);
                spriteBatch.End();
            }
        }

        public Rectangle DestinationRectangle()
        {
            return destinationRectangle;
        }
        








    }
}
