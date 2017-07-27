using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using static Game.Utility;

namespace Game
{
    public class LargeSpinFireBeam : IItem
    {
        private Game myGame;

        private Vector2 drawLoc;
        private Vector2 origin;
        private Vector2[] rotatePosition;
        private int countMax;
        public int DrawLoc
        {
            get
            {
                return (int)drawLoc.X;
            }
        }
        private Rectangle destinationRectangle;
        private Texture2D texture;

        private int rows;
        private int columns;
        private int currentFrame;
        private int count;

        public Boolean visible { get; set; }


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

        public LargeSpinFireBeam(Game game, int x, int y)
        {
            myGame = game;
            texture = myGame.itemSprite;
            rows = 21;
            columns = 36;
            currentFrame = 403;
            count = 0;
            countMax = 24;
            drawLoc = new Vector2(x, y);
            origin = new Vector2(x, y - 32);
            loadArray();

            visible = true;

        }

        public void Update()
        {
            if (myGame.animMod % two == zero)
            {
                count = ++count % countMax;
                drawLoc.X = rotatePosition[count].X;
                drawLoc.Y = rotatePosition[count].Y;



            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (visible)
            {
                int width = texture.Width / columns;
                int height = texture.Height / rows;
                int row = currentFrame / columns;
                int column = currentFrame % columns;

                Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
                destinationRectangle = new Rectangle((int)drawLoc.X - myGame.camera.GetOffset(), (int)drawLoc.Y, width, height);

                spriteBatch.Begin();
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
                spriteBatch.End();
            }
        }

        public Rectangle DestinationRectangle()
        {
            return destinationRectangle;
        }
        private void loadArray()
        {
            rotatePosition = new Vector2[countMax];
            for (int i = 0; i < countMax; i++)
            {
                rotatePosition[i].X = origin.X + fourtyEight * (float)Math.Cos(((float)i / countMax) * two * Math.PI);
                rotatePosition[i].Y = origin.Y + fourtyEight * (float)Math.Sin(((float)i / countMax) * two * Math.PI);

            }

        }
        public void ChangeMarioState()
        {
            if (myGame.marioState.bat)
            {
                myGame.mario = new DeadMario(myGame);
            }
            else if (!myGame.marioState.inv)
            {
                if ((myGame.mario.currentStatus()).Equals(MarioStateClass.marioStatus.small))
                {
                    myGame.mario = new DeadMario(myGame);
                    myGame.gameover = true;
                    myGame.hud.looseLife();
                    myGame.hud.decreasePoints(hundred);
                }
                else if ((myGame.mario.currentStatus()).Equals(MarioStateClass.marioStatus.large))
                {
                    myGame.marioState.inv = true;
                    myGame.mario = new SmallMario(myGame);
                    myGame.hud.decreasePoints(fifty);
                }
                else if ((myGame.mario.currentStatus()).Equals(MarioStateClass.marioStatus.fire))
                {
                    myGame.marioState.inv = true;
                    myGame.mario = new LargeMario(myGame);
                    myGame.hud.decreasePoints(fifty);
                }

            }
        }








    }
}
