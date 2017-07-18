﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Game.Utility;

namespace Game
{
    public class LevelControl
    {

        public Game myGame;
        public Transition trans;

        public LevelControl(Game game)
        {
            myGame = game;
            trans = new Transition(game);
        }

        public void Update()
        {
            myGame.paused.Update();
            if (myGame.pause)
                return;
            if (myGame.fbDelay > zero)
                myGame.fbDelay--;
            
            if(!trans.transitioning)
                myGame.marioColDetector.Update();

            myGame.projColDet.Update();
            trans.Update();
            foreach (IController x in myGame.contrl)
            {
                if (x.isConnected())
                {
                    myGame.marioState.move = false;
                    x.Update();
                }
            }

            if (myGame.marioState.star)
            {
                myGame.starDuration--;
                if (myGame.starDuration < zero)
                {
                    myGame.sound.state = Utility.soundStates.mainTheme;
                    myGame.starDuration = 500;
                    if (myGame.marioState.curStat.Equals(MarioStateClass.marioStatus.small))
                    {
                        myGame.mario = new SmallMario(myGame);
                    }
                    else if (myGame.marioState.curStat.Equals(MarioStateClass.marioStatus.large))
                    {
                        myGame.mario = new LargeMario(myGame);
                    }
                    else
                    {
                        myGame.mario = new FireMario(myGame);
                    }
                }
            }
            if (!trans.transitioning)
                myGame.mario.Update();
            myGame.itemSpawn.Update();
            myGame.camObj.Update();
            if (myGame.fireBalls.Count != zero)
            {
                foreach (Fireball fBalls in myGame.fireBalls)
                {
                    fBalls.Update();
                }
            }
            foreach (Enemies.IEnemy enemy in myGame.enemyCamList)
            {
                enemy.Update();
                myGame.enemyColDetector.Update();
            }
            foreach (IItem item in myGame.itemCamList)
            {
                item.Update();
                myGame.itemColDetector.Update();
            }
            if (myGame.animMod % twenty == zero)
            {
                foreach (IBackground background in myGame.bgList)
                {
                    background.Update();
                }
                foreach (IBlock block in myGame.blockCamList)
                {
                    block.Update();
                }
                //  foreach (IBlock block in questionBlockList)
                // {
                //   block.Update();
                //  }
            }
            myGame.sound.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (myGame.pipeLevel)
            {
                DrawPipe(spriteBatch);
            }
            else
            {
                DrawNormal(spriteBatch);
            }
        }

        public void DrawPipe(SpriteBatch spriteBatch)
        {
            myGame.GraphicsDevice.Clear(Color.Black);
        }
        public void DrawNormal(SpriteBatch spriteBatch)
        {
            myGame.GraphicsDevice.Clear(Color.CornflowerBlue);
            myGame.itemSpawn.Draw(spriteBatch);
            foreach (IBackground background in myGame.bgList)
            {
                background.Draw(spriteBatch);
            }
            foreach (IBlock block in myGame.blockCamList)
            {
                block.Draw(spriteBatch);
            }

            foreach (Enemies.IEnemy enemy in myGame.enemyCamList)
            {
                enemy.Draw(spriteBatch);
            }
            foreach (IItem item in myGame.itemCamList)
            {
                item.Draw(spriteBatch);
            }
            if (myGame.fireBalls.Count != zero)
            {
                foreach (Fireball fBalls in myGame.fireBalls)
                {
                    fBalls.Draw(spriteBatch);
                }
            }
            myGame.mario.Draw(spriteBatch);
        }
    }
}
       