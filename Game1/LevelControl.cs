using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game
{
    public class LevelControl
    {

        public Game myGame;

        public LevelControl(Game game)
        {
            myGame = game;
        }

        public void Update()
        {
            myGame.paused.Update();
            if (myGame.pause)
            {
                return;
            }
            if (myGame.fbDelay > 0)
            {
                myGame.fbDelay--;
            }

            myGame.marioColDetector.Update();
            myGame.projColDet.Update();
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
                if (myGame.starDuration < 0)
                {
                    myGame.sound.state = Game.soundStates.mainTheme;
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

            myGame.itemSpawn.Update();
            

            myGame.mario.Update();
            myGame.camObj.Update();
            if (myGame.fireBalls.Count != 0)
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
            if (myGame.animMod % 20 == 0)
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
            if (myGame.fireBalls.Count != 0)
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
       