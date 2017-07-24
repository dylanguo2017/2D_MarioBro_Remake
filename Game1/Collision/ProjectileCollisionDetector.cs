using Game.Collision;
using Game.Enemies;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using static Game.Utility;

namespace Game
{
    class ProjectileCollisionDetector : ICollisionDetector
    {
        private Game myGame;
        private List<IBlock> blockList;
        private List<IEnemy> enemyList;

        private Rectangle projRec;

        private CollisionDetector projBlock;

        private ProjectileBlockCollisionHandler projBlockColHandler;
        private ProjectileEnemyCollisionHandler projEnemyColHandler;

        List<Fireball> proj;
        List<Fireball> toBeRemoved;

        public ProjectileCollisionDetector(Game game, List<Fireball> projectile)
        {
            myGame = game;
            proj = projectile;

            projBlock = new CollisionDetector();
        }

        public void Update()
        {
            blockList = myGame.blockCamList;
            enemyList = myGame.enemyCamList;

            toBeRemoved = new List<Fireball>();
            if (proj.Count != zero)
            {
                foreach (Fireball fBalls in proj)
                {
                    projRec = fBalls.DestinationRectangle();

                    DetectProjBlockCol(fBalls);
                    DetectProjEnemyCol(fBalls);

                    if (fBalls.deleted)
                    {
                        toBeRemoved.Add(fBalls);
                    }
                }
                if (toBeRemoved.Count > zero)
                {
                    foreach (Fireball fireB in toBeRemoved)
                    {
                        proj.Remove(fireB);
                    }
                }
            }
        }

        private void DetectProjBlockCol(Fireball fBalls)
        {
            foreach (IBlock block in blockList)
            {
                Rectangle blockRec = block.DestinationRectangle();

                if (block.visible && projRec.Intersects(blockRec))
                {
                    projBlock.CollidesFrom(projRec, blockRec);
                    projBlockColHandler = new ProjectileBlockCollisionHandler(myGame);
                    projBlockColHandler.vColFrom = projBlock.vColFrom;
                    projBlockColHandler.HandleCollision(fBalls);
                }
            }
        }

        private void DetectProjEnemyCol(Fireball fBalls)
        {
            foreach (IEnemy enemy in enemyList)
            {
                Rectangle enemyRec = enemy.DestinationRectangle();

                if (enemy.visible && projRec.Intersects(enemyRec))
                {
                    projEnemyColHandler = new ProjectileEnemyCollisionHandler(myGame);
                    projEnemyColHandler.HandleCollision(enemy);
                }
            }
        }

    }
}
