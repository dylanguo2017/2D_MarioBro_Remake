using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class HUD
    {
        public Game myGame;
        SpriteFont font1;
        Vector2 marioString;
        Vector2 pointsPos;
        Vector2 coinsPos;
        Vector2 worldString;
        Vector2 levelPos;
        Vector2 timeString;
        Vector2 timePos;

        public TimeSpan ElapsedGameTime { get; set; }

        public HUD(Game game)
        {
            myGame = game;
            font1 = myGame.Content.Load<SpriteFont>("Courier New");
            marioString.X = 100;
            marioString.Y = 25;
            pointsPos.X = 100;
            pointsPos.Y = 50;
            coinsPos.X = 300;
            coinsPos.Y = 50;
            worldString.X = 500;
            worldString.Y = 25;
            levelPos.X = 500;
            levelPos.Y = 50;
            timeString.X = 650;
            timeString.Y = 25;
            timePos.X = 650;
            timePos.Y = 50;
        }
        public void Update()
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            string mario = "MARIO";
            spriteBatch.DrawString(font1, mario, marioString, Color.White);

            string coinTotal = CoinCollector.coinOutput().ToString();
           // spriteBatch.Draw()
            spriteBatch.DrawString(font1, "x" + coinTotal, coinsPos, Color.White);

            string world = "WORLD";
            spriteBatch.DrawString(font1, world, worldString, Color.White);

            string level = "1-1";
            spriteBatch.DrawString(font1, level, levelPos, Color.White);

            string time = "TIME";
            spriteBatch.DrawString(font1, time, timeString, Color.White);

            spriteBatch.DrawString(font1, ElapsedGameTime.ToString(), timePos, Color.White);
            
            spriteBatch.End();
        }

    }
    
}
