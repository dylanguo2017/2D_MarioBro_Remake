using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Game.Utility;


namespace Game
{
    public class HUD
    {
        public Game myGame;

        SpriteFont font1;
        Vector2 marioString;
        Vector2 pointsPos;
        Vector2 coinString;
        Vector2 coinsPos;
        Vector2 worldString;
        Vector2 levelPos;
        Vector2 timeString;
        Vector2 timePos;

        public int numberOfCoins;
        public int pointTotal;
        public int lives;
        public int levelTime;
        private int delay;

        public TimeSpan ElapsedTime { get; set; }

        public HUD(Game game)
        {
            myGame = game;
            font1 = myGame.Content.Load<SpriteFont>("Courier New");

            marioString.X = 100;
            marioString.Y = 25;
            pointsPos.X = 100;
            pointsPos.Y = 50;
            coinString.X = 300;
            coinString.Y = 25;
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

            numberOfCoins = 0;
            pointTotal = 0;
            lives = 3;
            levelTime = 400;
            delay = 50;
        }
        public void Update()
        {

            if(delay > zero && levelTime > zero)
            {
                delay--;
            }
            else if(delay > zero && levelTime == zero)
            {
                levelTime = 400;
                delay = 50;
            }
            else if(!myGame.pause)
            {
                levelTime--;
                delay = 50;
            }
            else if(levelTime == zero)
            {
                myGame.gameover = true;
                myGame.hud.looseLife();
            }
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            string mario = "MARIO";
            spriteBatch.DrawString(font1, mario, marioString, Color.White);

            spriteBatch.DrawString(font1, pointTotal.ToString(), pointsPos, Color.White);

            string coins = "COINS";
            spriteBatch.DrawString(font1, coins, coinString, Color.White);
            
            spriteBatch.DrawString(font1, "x" + numberOfCoins.ToString(), coinsPos, Color.White);

            string world = "WORLD";
            spriteBatch.DrawString(font1, world, worldString, Color.White);
            string level = "1-1";
            spriteBatch.DrawString(font1, level, levelPos, Color.White);

            string time = "TIME";
            spriteBatch.DrawString(font1, time, timeString, Color.White);
            spriteBatch.DrawString(font1, levelTime.ToString(), timePos, Color.White);

            spriteBatch.End();
        }

        public void addCoin()
        {
           numberOfCoins++;
        }

        public void increasePoints(int amount)
        {
             pointTotal = pointTotal + amount;
        }

        public void decreasePoints(int amount)
        {
            pointTotal = pointTotal - amount;
        }

        public void looseLife()
        {
            if(lives > 0)
            {
                lives--;
            }
        }

        public void gainLife()
        {
            lives++;
        }

        public void reset()
        {
            if(lives == 0)
            {
                numberOfCoins = 0;
                lives = 3;
                pointTotal = 0;
            }
            levelTime = 400;
        }


    }
    
}
