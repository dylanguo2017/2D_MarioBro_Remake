using Game.Enemies;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static Game.Utility;

namespace Game.Infinite_Level
{
    public class InfiniteLevel
    {
        public Game myGame;
        private RCommand reset;
       
        public InfiniteLevel(Game game)
        {
            myGame = game;
            reset = new RCommand(game);
        }
        
        public void Update()
        {
            if (myGame.marioState.marioPhys.YCoor > 800 && !myGame.gameover)
            {
                myGame.hud.lives = 0;
                reset.Execute();
            }

            myGame.paused.Update();
            if (myGame.pause)
                return;

            myGame.gameOver.Update();
            if (myGame.gameover)
            {
                myGame.hud.lives = 0;
                reset.Execute();
            }

            if (myGame.fbDelay > zero)
                myGame.fbDelay--;

            myGame.marioState.left = true;
            myGame.marioState.right = true;
            myGame.marioState.up = true;
            myGame.marioState.down = true;

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
                if (myGame.starDuration < zero)
                {
                    myGame.sound.state = soundStates.mainTheme;
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
            foreach (IEnemy enemy in myGame.enemyCamList)
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
                foreach (IBg background in myGame.bgList)
                {
                    background.Update();
                }
                foreach (IBlock block in myGame.blockCamList)
                {
                    block.Update();
                }
            }
            myGame.sound.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            myGame.GraphicsDevice.Clear(Color.CornflowerBlue);
            myGame.itemSpawn.Draw(spriteBatch);

            foreach (IBg background in myGame.bgList)
            {
                background.Draw(spriteBatch);
            }

            myGame.mario.Draw(spriteBatch);
            foreach (IEnemy enemy in myGame.enemyCamList)
            {
                if(enemy is PiranhaPlant)
                {
                    enemy.Draw(spriteBatch);
                }
            }

            foreach (IBlock block in myGame.blockCamList)
            {
                block.Draw(spriteBatch);
            }

            foreach (IItem item in myGame.itemCamList)
            {
                item.Draw(spriteBatch);
            }

            foreach (IEnemy enemy in myGame.enemyCamList)
            {
                if (enemy is PiranhaPlant == false)
                {
                    enemy.Draw(spriteBatch);
                }
            }

            if (myGame.fireBalls.Count != zero)
            {
                foreach (Fireball fBalls in myGame.fireBalls)
                {
                    fBalls.Draw(spriteBatch);
                }
            }

        }
    }
}
