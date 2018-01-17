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
        Vector2 normalPos;
        Vector2 infinitePos;
        Vector2 titlePos;

        public startScreen(Game game)
        {
            myGame = game;
            font1 = myGame.Content.Load<SpriteFont>("Courier New");
            normalPos.X = 200;
            normalPos.Y = 300;
            infinitePos.X = 200;
            infinitePos.Y = 350;
            titlePos.X = 0;
            titlePos.Y = 0;
        }

        public void Update()
        {
            myGame.sound.Update();
            if (myGame.begin && Keyboard.GetState().IsKeyDown(Keys.N))
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
                myGame.GraphicsDevice.Clear(Color.CornflowerBlue);

                spriteBatch.Begin();
                spriteBatch.Draw(myGame.startScreen, titlePos, null);
                
                string normalMode = "NORMAL   MODE   PRESS   N";
                spriteBatch.DrawString(font1, normalMode, normalPos, Color.White);

                string infiniteMode = "INFINITE   MODE   PRESS   F";
                spriteBatch.DrawString(font1, infiniteMode, infinitePos, Color.White);

                spriteBatch.End();
            }
        }
    }
}
