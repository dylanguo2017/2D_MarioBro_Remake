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
        private List<IBlock> blockList;
        private Rectangle marioRec;
        private Rectangle enemyRec;
        private Rectangle blockRec;
        private String marioCollidesFromHorizontalSide;
        private String marioCollidesFromVerticalSide;
        private MarioEnemyCollisionHandler enemyCollisionHandler;
        private MarioBlockCollisionHandler blockCollisionHandler;
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
            blockList = Level.blockList;

            marioRec = myGame.mario.DestinationRectangle();
            
            myGame.marioState.left = true;
            myGame.marioState.right = true;
            myGame.marioState.up = true;
            myGame.marioState.down = true;

            MarioBlockCollision();
            //MarioEnemyCollision();
        }


        private void MarioBlockCollision()
        {
            foreach (IBlock block in blockList)
            {
                blockRec = block.DestinationRectangle();

                if (blockRec.X <= 800 && marioRec.Intersects(blockRec))
                {
                    CollidesFromWithBlock();
                    DisableMovement();
                    System.Diagnostics.Debug.WriteLine(marioCollidesFromVerticalSide);
                    blockCollisionHandler = new MarioBlockCollisionHandler(myGame);
                    blockCollisionHandler.HandleCollision(myGame.mario, block, marioCollidesFromHorizontalSide, marioCollidesFromVerticalSide);
                }
            }
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


        public void CollidesFromWithBlock()
        {
            marioCollidesFromHorizontalSide = "none";
            marioCollidesFromVerticalSide = "none";

            System.Diagnostics.Debug.WriteLine("collides from");
            if (marioRec.Left > blockRec.Right - 2 && ((marioRec.Top <= blockRec.Top && marioRec.Bottom >= blockRec.Top + 2) || (marioRec.Top > blockRec.Top && blockRec.Bottom >= marioRec.Top - 2)))
            {
                System.Diagnostics.Debug.WriteLine("right");
                marioCollidesFromHorizontalSide = "right";
            }
            else if (marioRec.Right < blockRec.Left + 2 && ((marioRec.Top <= blockRec.Top && marioRec.Bottom >= blockRec.Top + 2) || (marioRec.Top > blockRec.Top && blockRec.Bottom >= marioRec.Top - 2)))
            {
                System.Diagnostics.Debug.WriteLine("left");
                marioCollidesFromHorizontalSide = "left";
            }

            if (marioRec.Bottom > blockRec.Bottom && marioRec.Top > blockRec.Bottom - 2 && ((marioRec.Left <= blockRec.Left && marioRec.Right >= blockRec.Left + 2) || (marioRec.Left > blockRec.Left && blockRec.Right >= marioRec.Left - 2)))
            {
                System.Diagnostics.Debug.WriteLine("bottom");
                marioCollidesFromVerticalSide = "bottom";
            }
            else if (marioRec.Top < blockRec.Top && marioRec.Bottom < blockRec.Top + 2 && ((marioRec.Left <= blockRec.Left && marioRec.Right >= blockRec.Left + 2) || (marioRec.Left > blockRec.Left && blockRec.Right >= blockRec.Left - 2)))
            {
                System.Diagnostics.Debug.WriteLine("top");
                marioCollidesFromVerticalSide = "top";

            }

        }


        public void CollidesFrom()
        {
            marioCollidesFromHorizontalSide = "none";
            marioCollidesFromVerticalSide = "none";

            System.Diagnostics.Debug.WriteLine("collides from");
            if (marioRec.Left > enemyRec.Right - 2 && ((marioRec.Top <= enemyRec.Top && marioRec.Bottom >= enemyRec.Top + 2) || (marioRec.Top > enemyRec.Top && enemyRec.Bottom >= marioRec.Top - 2)))
            {
                System.Diagnostics.Debug.WriteLine("right");
                marioCollidesFromHorizontalSide = "right";
            }
            else if (marioRec.Right < enemyRec.Left + 2 && ((marioRec.Top <= enemyRec.Top && marioRec.Bottom >= enemyRec.Top + 2) || (marioRec.Top > enemyRec.Top && enemyRec.Bottom >= marioRec.Top - 2)))
            {
                System.Diagnostics.Debug.WriteLine("left");
                marioCollidesFromHorizontalSide = "left";
            }

            if (marioRec.Bottom > enemyRec.Bottom && marioRec.Top > enemyRec.Bottom - 2 && ((marioRec.Left <= enemyRec.Left && marioRec.Right >= enemyRec.Left + 2) || (marioRec.Left > enemyRec.Left && enemyRec.Right >= marioRec.Left - 2)))
            {
                System.Diagnostics.Debug.WriteLine("bottom");
                marioCollidesFromVerticalSide = "bottom";
            }
            else if (marioRec.Top < enemyRec.Top && marioRec.Bottom < enemyRec.Top + 2  && ((marioRec.Left <= enemyRec.Left && marioRec.Right >= enemyRec.Left + 2) || (marioRec.Left > enemyRec.Left && enemyRec.Right >= marioRec.Left - 2)))
            {
                System.Diagnostics.Debug.WriteLine("top");
                marioCollidesFromVerticalSide = "top";
                
            }

        }

        public void DisableMovement()
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
