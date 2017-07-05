using Game.Enemies;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Game
{
    class MarioCollisionDetector : ICollisionDetector
    {
        private Game myGame;
        private List<IBlock> blockList;
        private List<IEnemy> enemyList;
        private List<IItem> itemList;

        private Rectangle marioRec;
        private Rectangle blockRec;
        private Rectangle enemyRec;
        private Rectangle itemRec;

        private String marioColFromHorizontalSide;
        private String marioColFromVerticalSide;

        private MarioBlockCollisionHandler blockColHandler;
        private MarioEnemyCollisionHandler enemyColHandler;
        private MarioItemCollisionHandler itemColHandler;

        public MarioCollisionDetector(Game game)
        {
            myGame = game;
        }

        public void Update()
        {
            blockList = myGame.blockList;
            enemyList = myGame.enemyList;
            itemList = myGame.itemList;

            marioRec = myGame.mario.DestinationRectangle();
            
            myGame.marioState.left = true;
            myGame.marioState.right = true;
            myGame.marioState.up = true;
            myGame.marioState.down = true;

            DetectMarioBlockCol();
            DetectMarioEnemyCol();
            DetectMarioItemCol();
        }


        private void DetectMarioBlockCol()
        {
            foreach (IBlock block in blockList)
            {
                blockRec = block.DestinationRectangle();

                if (blockRec.X <= 800 && marioRec.Intersects(blockRec))
                {
                    CollidesFrom(blockRec);
                    blockColHandler = new MarioBlockCollisionHandler(myGame);
                    blockColHandler.HandleCollision(myGame.mario, block, marioColFromHorizontalSide, marioColFromVerticalSide);
                }
            }
        }


        private void DetectMarioEnemyCol()
        {
            foreach (IEnemy enemy in enemyList)
            {
                enemyRec = enemy.DestinationRectangle();

                if (enemyRec.X <= 800 && marioRec.Intersects(enemyRec))
                {
                    CollidesFrom(enemyRec);
                    enemyColHandler = new MarioEnemyCollisionHandler(myGame);
                    enemyColHandler.HandleCollision(myGame.mario, enemy, marioColFromHorizontalSide, marioColFromVerticalSide);
                }
            }
        }

        private void DetectMarioItemCol()
        {
            foreach (IItem item in itemList)
            {
                itemRec = item.DestinationRectangle();

                if (itemRec.X <= 800 && marioRec.Intersects(itemRec))
                {
                    CollidesFrom(itemRec);
                    itemColHandler = new MarioItemCollisionHandler(myGame);
                    itemColHandler.HandleCollision(myGame.mario, item);
                }
            }
        }
        
        public void CollidesFrom(Rectangle objectRec)
        {
            marioColFromHorizontalSide = "none";
            marioColFromVerticalSide = "none";

            if (marioRec.Left > objectRec.Right - 2 && ((marioRec.Top <= objectRec.Top && marioRec.Bottom >= objectRec.Top + 2) || (marioRec.Top > objectRec.Top && objectRec.Bottom >= marioRec.Top - 2)))
            {
                marioColFromHorizontalSide = "right";
            }
            else if (marioRec.Right < objectRec.Left + 2 && ((marioRec.Top <= objectRec.Top && marioRec.Bottom >= objectRec.Top + 2) || (marioRec.Top > objectRec.Top && objectRec.Bottom >= marioRec.Top - 2)))
            {
                marioColFromHorizontalSide = "left";
            }

            if (marioRec.Bottom > objectRec.Bottom && marioRec.Top > objectRec.Bottom - 2 && ((marioRec.Left <= objectRec.Left && marioRec.Right >= objectRec.Left + 2) || (marioRec.Left > objectRec.Left && objectRec.Right >= marioRec.Left - 2)))
            {
                marioColFromVerticalSide = "bottom";
            }
            else if (marioRec.Top < objectRec.Top && marioRec.Bottom < objectRec.Top + 2  && ((marioRec.Left <= objectRec.Left && marioRec.Right >= objectRec.Left + 2) || (marioRec.Left > objectRec.Left && objectRec.Right >= marioRec.Left - 2)))
            {
                marioColFromVerticalSide = "top";
                
            }

        }


    }
}
