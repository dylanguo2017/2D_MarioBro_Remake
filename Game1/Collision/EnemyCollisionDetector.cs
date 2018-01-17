using Game.Collision;
using Game.Enemies;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Game
{
    class EnemyCollisionDetector : ICollisionDetector
    {
        private Game myGame;
        private List<IEnemy> enemyList;
        private List<IBlock> blockList;

        private CollisionDetector enemyBlock;

        public EnemyCollisionDetector(Game game)
        {
            myGame = game;
            enemyBlock = new CollisionDetector();
        }

        public void Update()
        {
            enemyList = myGame.enemyCamList;
            blockList = myGame.blockCamList;

            foreach (IEnemy enemy in enemyList)
            {
                Rectangle enemyRec = enemy.DestinationRectangle();

                foreach (IBlock block in blockList)
                {
                    Rectangle blockRec = block.DestinationRectangle();

                    if (block.visible && enemyRec.Intersects(blockRec))
                    {
                        enemyBlock.CollidesFrom(enemyRec, blockRec);
                        EnemyCollisionHandler enemyColHandler = new EnemyCollisionHandler(myGame);
                        enemyColHandler.hColFrom = enemyBlock.hColFrom;
                        enemyColHandler.vColFrom = enemyBlock.vColFrom;
                        enemyColHandler.HandleCollision(enemy);
                    }

                }
            }
        }

    }
}
