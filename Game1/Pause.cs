﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game
{
    public class Pause
    {
        public Game myGame;
        private Game.soundStates placeHol;
        private int delay = 0;
        SpriteFont font1;
        Vector2 fontPos;

        public Pause(Game game)
        {
            myGame = game;
            font1 = myGame.Content.Load<SpriteFont>("Courier New");
            fontPos.X = 400;
            fontPos.Y = 100;
        }

        public void Update()
        {
            KeyboardState asd = Keyboard.GetState();
            if (asd.IsKeyDown(Keys.P) && delay == 0)
            {
                delay = 10;
                myGame.pause = !myGame.pause;
                if (myGame.pause)
                {
                    placeHol = myGame.sound.state;
                    myGame.sound.state = Game.soundStates.pause;
                    myGame.sound.Pause();
                }
                else
                {
                    myGame.sound.state = placeHol;
                }
            }
            if(delay > 0)
            {
                delay--;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (myGame.pause)
            {
                spriteBatch.Begin();
                string paused = "GAME IS PAUSED";
                spriteBatch.DrawString(font1,paused,fontPos,Color.White);
                spriteBatch.End();
            }
        }
    }
}