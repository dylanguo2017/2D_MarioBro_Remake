using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Game.Sprites
{
    public class MotionlessAnimatedSprite : Sprite
    {
        private Sprite sprite;
        private Game myGame;
        public Boolean hit;
        public int timer;

        public MotionlessAnimatedSprite(Game game, Texture2D texture, int rows, int columns, int x, int y) : base(game, texture, rows, columns)
        {
            myGame = game;
            sprite = new Sprite(myGame, texture, rows, columns);
            location = new Point(x, y);
            hit = false;
            timer = 0;
            type = texture.Name.ToString();
        }

        public override void Update()
        {
            currentFrame++;
            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
            }
            if (hit)
            {
                if(timer < 1)
                {
                    timer++;
                }
                else
                {
                    timer = 0;
                    hit = false;
                    BumpDown();
                    myGame.marioState.marioPhys.YCoor += 2;
                }
            }
        }

        public void BumpBlock()
        {
            hit = true;

            location.Y = location.Y - 2;
        }

        public void BumpDown()
        {
            location.Y = location.Y + 2;
        }
        
    }
}
