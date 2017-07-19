using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using static Game.Game;
using static Game.Utility;

namespace Game
{
    public class GameOver
    {
        public Game myGame;
        private static int delay;
        SpriteFont font1;
        Vector2 gameOverPos;
        Vector2 totalLivesPos;
        Vector2 livesPos;
        RCommand reset;
        DCommand walk;

        public GameOver(Game game)
        {
            myGame = game;
            font1 = myGame.Content.Load<SpriteFont>("Courier New");
            gameOverPos.X = 400;
            gameOverPos.Y = 100;
            totalLivesPos.X = 400;
            totalLivesPos.Y = 300;
            livesPos.X = 650;
            livesPos.Y = 300;
            

            delay = 100;
            reset = new RCommand(myGame);
            walk = new DCommand(myGame);
        }

        public void Update()
        {
            
            if (myGame.gameover && delay > zero)
            {
                delay--;
            }else if (myGame.gameover && delay == zero)
            {
                reset.Execute();
            }
        }

        public void SetDelay()
        {
            delay = 100;
        }

        public void Walk()
        {
            walk.Execute();
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            if (myGame.gameover)
            {
               myGame.GraphicsDevice.Clear(Color.Black);
                spriteBatch.Begin();
                string GameOver = "GAME   OVER";
                spriteBatch.DrawString(font1, GameOver, gameOverPos, Color.White);

                string TotalLives = "Lives   Left:";
                spriteBatch.DrawString(font1, TotalLives, totalLivesPos, Color.White);
                spriteBatch.DrawString(font1, myGame.hud.lives.ToString(), livesPos, Color.White);

                spriteBatch.End();
            }
        }
    }
}
