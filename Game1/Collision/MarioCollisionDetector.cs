using Game.Enemies;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Game
{
    class MarioCollisionDetector //: ICollisionDetector
    {
        private Game myGame;
        private List<IEnemy> enemyList;
        private Rectangle marioRec;
        private Rectangle enemyRec;
        private String marioCollidesFromHorizontalSide;
        private String marioCollidesFromVerticalSide;
        private MarioEnemyCollisionHandler enemyCollisionHandler;
        private int differenceCoor = 0;
        public int dCoor
        {
            get
            {
                return differenceCoor;
            }
        }

        public MarioCollisionDetector(Game game)
        {
            myGame = game;
        }

        public void Update()
        {
            enemyList = Level.EnemyList();

            marioRec = myGame.mario.DestinationRectangle();
            
            myGame.marioState.left = true;
            myGame.marioState.right = true;
            myGame.marioState.up = true;
            myGame.marioState.down = true;

            MarioEnemyCollision();
        }
       

        private void MarioEnemyCollision()
        {
            foreach (IEnemy enemy in enemyList)
            {
                enemyRec = enemy.DestinationRectangle();

                if (enemyRec.X <= 800 && marioRec.Intersects(enemyRec))
                {
                    CollidesFrom();
                    enemyCollisionHandler = new MarioEnemyCollisionHandler(myGame);
                    enemyCollisionHandler.HandleCollision(myGame.mario, enemy, marioCollidesFromHorizontalSide, marioCollidesFromVerticalSide);
                }
            }
        }


        public void CollidesFrom()
        {
            marioCollidesFromHorizontalSide = "none";
            marioCollidesFromVerticalSide = "none";
            
            if (marioRec.Left > enemyRec.Right - 2 && ((marioRec.Top <= enemyRec.Top && marioRec.Bottom >= enemyRec.Top + 2) || (marioRec.Top > enemyRec.Top && enemyRec.Bottom >= marioRec.Top - 2)))
            {
                marioCollidesFromHorizontalSide = "right";
            }
            else if (marioRec.Right < enemyRec.Left + 2 && ((marioRec.Top <= enemyRec.Top && marioRec.Bottom >= enemyRec.Top + 2) || (marioRec.Top > enemyRec.Top && enemyRec.Bottom >= marioRec.Top - 2)))
            {
                marioCollidesFromHorizontalSide = "left";
            }

            if (marioRec.Bottom > enemyRec.Bottom && marioRec.Top > enemyRec.Bottom - 2 && ((marioRec.Left <= enemyRec.Left && marioRec.Right >= enemyRec.Left + 2) || (marioRec.Left > enemyRec.Left && enemyRec.Right >= marioRec.Left - 2)))
            {
                marioCollidesFromVerticalSide = "bottom";
            }
            else if (marioRec.Top < enemyRec.Top && marioRec.Bottom < enemyRec.Top + 2  && ((marioRec.Left <= enemyRec.Left && marioRec.Right >= enemyRec.Left + 2) || (marioRec.Left > enemyRec.Left && enemyRec.Right >= marioRec.Left - 2)))
            {
                marioCollidesFromVerticalSide = "top";
                
            }

        }

        private void DisableMovement()
        {
            if(marioCollidesFromHorizontalSide.Equals("right"))
            {
                myGame.marioState.left = false;
            }
            else if (marioCollidesFromHorizontalSide.Equals("left"))
            {
                myGame.marioState.right = false;
            }

            if (marioCollidesFromVerticalSide.Equals("bottom"))
            {
                myGame.marioState.up = false;
            }
            else if (marioCollidesFromVerticalSide.Equals("top"))
            {
                myGame.marioState.down = false;
            }
        }

    }
}
