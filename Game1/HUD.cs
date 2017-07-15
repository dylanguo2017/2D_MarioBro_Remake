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
            timeString.X = 700;
            timeString.Y = 25;
            timePos.X = 700;
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

            string world = "WORLD";
            spriteBatch.DrawString(font1, world, worldString, Color.White);

            string time = "TIME";
            spriteBatch.DrawString(font1, time, timeString, Color.White);

            

           // string coins = "MARIO";
           // spriteBatch.DrawString(font1, mario, marioString, Color.White);


            spriteBatch.End();
        }

    }
    
}
