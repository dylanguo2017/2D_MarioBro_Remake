using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace Game
{
    class MovingAnimatedSprite : Sprite
    {
        private Sprite sprite;
        private Game myGame;

        public MovingAnimatedSprite(Game game, Texture2D texture, int rows, int columns, int x, int y) : base(game, texture, rows, columns)
        {
            myGame = game;
            sprite = new Sprite(myGame, texture, rows, columns);
            location = new Point(x, y);
            type = texture.Name.ToString();
        }

        public override void Update()
        {
            currentFrame++;
            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
            }
            
            if (right.Equals(true))
            {
                moveRight(); 
            }
            else
            {
                moveLeft();
            }
        }

        public void moveLeft()
        {
            location.X--;
        }

        public void moveRight()
        {
            location.X++;
        }
    }
}
