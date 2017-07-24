using Game.Enemies;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using static Game.Utility;

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

        private sides hColFrom;
        private sides vColFrom;

        private MarioBlockCollisionHandler blockColHandler;
        private MarioEnemyCollisionHandler enemyColHandler;
        private MarioItemCollisionHandler itemColHandler;

        public MarioCollisionDetector(Game game)
        {
            myGame = game;
            hColFrom = sides.none;
            vColFrom = sides.none;
            blockList = myGame.blockCamList;
            enemyList = myGame.enemyCamList;
            itemList = myGame.itemCamList;
        }

        public void Update()
        {
            
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

                if (marioRec.Intersects(blockRec))
                {
                    CollidesFrom(blockRec);
                    blockColHandler = new MarioBlockCollisionHandler(myGame);
                    blockColHandler.hColFrom = hColFrom;
                    blockColHandler.vColFrom = vColFrom;
                    blockColHandler.intersecRec = Rectangle.Intersect(marioRec, blockRec);
                    blockColHandler.HandleCollision(myGame.mario, block);
                }
            }
        }


        private void DetectMarioEnemyCol()
        {
            foreach (IEnemy enemy in enemyList)
            {
                enemyRec = enemy.DestinationRectangle();

                if (enemy.visible && marioRec.Intersects(enemyRec))
                {
                    CollidesFrom(enemyRec);
                    enemyColHandler = new MarioEnemyCollisionHandler(myGame);
                    enemyColHandler.hColFrom = hColFrom;
                    enemyColHandler.vColFrom = vColFrom;
                    enemyColHandler.HandleCollision(myGame.mario, enemy);
                }
            }
        }

        private void DetectMarioItemCol()
        {
            foreach (IItem item in itemList)
            {
                itemRec = item.DestinationRectangle();

                if (marioRec.Intersects(itemRec))
                {
                    CollidesFrom(itemRec);
                    itemColHandler = new MarioItemCollisionHandler(myGame);
                    itemColHandler.HandleCollision(myGame.mario, item);
                }
            }
        }
        
        public void CollidesFrom(Rectangle objectRec)
        {
            hColFrom = sides.none;
            vColFrom = sides.none;

            if ((marioRec.Top <= objectRec.Top && marioRec.Bottom >= objectRec.Top + two) || (marioRec.Top > objectRec.Top && objectRec.Bottom >= marioRec.Top - two))
            {
                if (marioRec.Right > objectRec.Right)
                {
                    hColFrom = sides.right;
                }
                else if (marioRec.Left < objectRec.Left)
                {
                    hColFrom = sides.left;
                }
            }

            if ((marioRec.Left <= objectRec.Left && marioRec.Right >= objectRec.Left + two) || (marioRec.Left > objectRec.Left && objectRec.Right >= marioRec.Left - two))
            {
                if (marioRec.Bottom > objectRec.Bottom)
                {
                    vColFrom = sides.bottom;
                }
                else if (marioRec.Top < objectRec.Top)
                {
                    vColFrom = sides.top;
                }
            }

        }


    }
}
