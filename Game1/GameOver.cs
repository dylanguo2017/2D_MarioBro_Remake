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
        private static int delay = 0;
        SpriteFont font1;
        Vector2 gameOverPos;
        Vector2 totalLivesPos;
        RCommand reset;
        

        public GameOver(Game game)
        {
            myGame = game;
            font1 = myGame.Content.Load<SpriteFont>("Courier New");
            gameOverPos.X = 400;
            gameOverPos.Y = 100;
            totalLivesPos.X = 400;
            totalLivesPos.Y = 300;
            reset = new RCommand(myGame);
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

        public static void SetDelay()
        {
            delay = 100;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (myGame.gameover)
            {
                myGame.GraphicsDevice.Clear(Color.Black);
                spriteBatch.Begin();
                string GameOver = "GAME OVER";
                spriteBatch.DrawString(font1, GameOver, gameOverPos, Color.White);

                string TotalLives = "Lives left:";
                spriteBatch.DrawString(font1, TotalLives, totalLivesPos, Color.White);

                spriteBatch.End();
            }
        }
    }
}
