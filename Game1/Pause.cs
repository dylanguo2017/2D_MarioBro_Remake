using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static Game.Game;
using static Game.Utility;

namespace Game
{
    public class Pause
    {
        public Game myGame;
        private soundStates placeHol;
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
            if (asd.IsKeyDown(Keys.P) && delay == zero)
            {
                delay = 10;
                myGame.pause = !myGame.pause;
                if (myGame.pause)
                {
                    placeHol = myGame.sound.state;
                    myGame.soundEffect.Pause();
                }
                else
                {
                    myGame.sound.state = placeHol;
                }
            }
            if(delay > zero)
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
