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
            enemyList = Level.enemyList;
            blockList = Level.blockList;

            marioRec = myGame.mario.DestinationRectangle();
            
            myGame.marioState.left = true;
            myGame.marioState.right = true;
            myGame.marioState.up = true;
            myGame.marioState.down = true;

            MarioBlockCollision();
            MarioEnemyCollision();
        }


        private void MarioBlockCollision()
        {
            foreach (IBlock block in blockList)
            {
                blockRec = block.DestinationRectangle();

                if (blockRec.X <= 800 && marioRec.Intersects(blockRec))
                {
                    CollidesFrom(blockRec);
                    DisableMovement();
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
                    CollidesFrom(enemyRec);
                    enemyCollisionHandler = new MarioEnemyCollisionHandler(myGame);
                    enemyCollisionHandler.HandleCollision(myGame.mario, enemy, marioCollidesFromHorizontalSide, marioCollidesFromVerticalSide);
                }
            }
        }
        

        public void CollidesFrom(Rectangle objectRec)
        {
            marioCollidesFromHorizontalSide = "none";
            marioCollidesFromVerticalSide = "none";

            if (marioRec.Left > objectRec.Right - 2 && ((marioRec.Top <= objectRec.Top && marioRec.Bottom >= objectRec.Top + 2) || (marioRec.Top > objectRec.Top && objectRec.Bottom >= marioRec.Top - 2)))
            {
                marioCollidesFromHorizontalSide = "right";
            }
            else if (marioRec.Right < objectRec.Left + 2 && ((marioRec.Top <= objectRec.Top && marioRec.Bottom >= objectRec.Top + 2) || (marioRec.Top > objectRec.Top && objectRec.Bottom >= marioRec.Top - 2)))
            {
                marioCollidesFromHorizontalSide = "left";
            }

            if (marioRec.Bottom > objectRec.Bottom && marioRec.Top > objectRec.Bottom - 2 && ((marioRec.Left <= objectRec.Left && marioRec.Right >= objectRec.Left + 2) || (marioRec.Left > objectRec.Left && objectRec.Right >= marioRec.Left - 2)))
            {
                marioCollidesFromVerticalSide = "bottom";
            }
            else if (marioRec.Top < objectRec.Top && marioRec.Bottom < objectRec.Top + 2  && ((marioRec.Left <= objectRec.Left && marioRec.Right >= objectRec.Left + 2) || (marioRec.Left > objectRec.Left && objectRec.Right >= marioRec.Left - 2)))
            {
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
