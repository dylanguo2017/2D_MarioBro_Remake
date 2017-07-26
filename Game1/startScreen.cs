using Game.Infinite_Level;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Windows.Input;
using static Game.Game;
using static Game.Utility;

namespace Game
{
    public class startScreen
    {
        public Game myGame;
        SpriteFont font1;
        Vector2 welcomePos;
        Vector2 normalPos;
        Vector2 infinitePos;
        //RCommand reset;

        public startScreen(Game game)
        {
            myGame = game;
            font1 = myGame.Content.Load<SpriteFont>("Courier New");
            welcomePos.X = 225;
            welcomePos.Y = 100;
            normalPos.X = 200;
            normalPos.Y = 250;
            infinitePos.X = 200;
            infinitePos.Y = 350;
            
            //reset = new RCommand(myGame);
        }

        public void Update()
        {
            if(myGame.begin && Keyboard.GetState().IsKeyDown(Keys.N))
            {
                myGame.begin = false;
                myGame.normal = true;

                myGame.enemyList = Level.enemyList;
                myGame.blockList = Level.blockList;
                myGame.itemList = Level.itemList;

                myGame.enemyPipeList = Level.enemyPipeList;
                myGame.blockPipeList = Level.blockPipeList;
                myGame.itemPipeList = Level.itemPipeList;
                myGame.camObj.LoadLevel();

                myGame.bgList = Level.bgList;
                foreach (IBlock block in myGame.blockList)
                {
                    if (block is Question)
                    {
                        myGame.countOfPopItem++;
                    }

                }
            }
            else if(myGame.begin && Keyboard.GetState().IsKeyDown(Keys.F))
            {
                myGame.begin = false;
                myGame.infinite = true;

                myGame.enemyList = InfiniteLevelLoader.enemyList;
                myGame.blockList = InfiniteLevelLoader.blockList;
                myGame.itemList = InfiniteLevelLoader.itemList;
                myGame.camObj.LoadLevel();
                myGame.bgList = InfiniteLevelLoader.bgList;

                foreach (IBlock block in myGame.blockList)
                {
                    if (block is Question)
                    {
                        myGame.countOfPopItem++;
                    }

                }
            }
            else if(myGame.begin)
            {
                
            }

        }
        

        public void Draw(SpriteBatch spriteBatch)
        {
            if (myGame.begin)
            {
                myGame.GraphicsDevice.Clear(Color.Indigo);
                spriteBatch.Begin();
                string welcome = "WELCOME   TO   MARIO!";
                spriteBatch.DrawString(font1, welcome, welcomePos, Color.White);

                string normalMode = "NORMAL   MODE   PRESS   N";
                spriteBatch.DrawString(font1, normalMode, normalPos, Color.White);

                string infiniteMode = "INFINITE   MODE   PRESS   F";
                spriteBatch.DrawString(font1, infiniteMode, infinitePos, Color.White);

                spriteBatch.End();
            }
        }
    }
}
