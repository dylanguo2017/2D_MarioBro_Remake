using Game.Collision;
using Game.Enemies;
using Microsoft.Xna.Framework;
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

        private CollisionDetector marioBlock;
        private CollisionDetector marioEnemy;
        private CollisionDetector marioItem;

        public MarioCollisionDetector(Game game)
        {
            myGame = game;

            marioBlock = new CollisionDetector();
            marioEnemy = new CollisionDetector();
            marioItem = new CollisionDetector();
        }

        public void Update()
        {
            marioRec = myGame.mario.DestinationRectangle();

            blockList = myGame.blockCamList;
            enemyList = myGame.enemyCamList;
            itemList = myGame.itemCamList;

            DetectMarioBlockCol();
            DetectMarioEnemyCol();
            DetectMarioItemCol();
        }


        private void DetectMarioBlockCol()
        {
            foreach (IBlock block in blockList)
            {
                Rectangle blockRec = block.DestinationRectangle();

                if (marioRec.Intersects(blockRec))
                {
                    marioBlock.CollidesFrom(marioRec, blockRec);
                    MarioBlockCollisionHandler blockColHandler = new MarioBlockCollisionHandler(myGame);
                    blockColHandler.hColFrom = marioBlock.hColFrom;
                    blockColHandler.vColFrom = marioBlock.vColFrom;
                    blockColHandler.intersecRec = Rectangle.Intersect(marioRec, blockRec);
                    blockColHandler.HandleCollision(myGame.mario, block);
                }
            }
        }

        private void DetectMarioEnemyCol()
        {
            foreach (IEnemy enemy in enemyList)
            {
                Rectangle enemyRec = enemy.DestinationRectangle();

                if (enemy.visible && marioRec.Intersects(enemyRec))
                {
                    System.Diagnostics.Debug.WriteLine(marioRec.Bottom + "   " + enemyRec.Top);
                    marioEnemy.CollidesFrom(marioRec, enemyRec);
                    MarioEnemyCollisionHandler enemyColHandler = new MarioEnemyCollisionHandler(myGame);
                    enemyColHandler.hColFrom = marioEnemy.hColFrom;
                    enemyColHandler.vColFrom = marioEnemy.vColFrom;
                    enemyColHandler.HandleCollision(myGame.mario, enemy);
                }
            }
        }

        private void DetectMarioItemCol()
        {
            foreach (IItem item in itemList)
            {
                Rectangle itemRec = item.DestinationRectangle();

                if (item.visible && marioRec.Intersects(itemRec))
                {
                    MarioItemCollisionHandler itemColHandler = new MarioItemCollisionHandler(myGame);
                    itemColHandler.HandleCollision(myGame.mario, item);
                }
            }
        }

    }
}
