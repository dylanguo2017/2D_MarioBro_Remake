using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Game
{
    class ProjectileCollisionDetector
    {
        private Game myGame;
        private List<ISprite> projectileCollisionList;
        private Rectangle projectileRec;
        private Rectangle objectRec;
        private String projectileCollidesFromHorizontalSide;
        private String projectileCollidesFromVerticalSide;
        private ICollisionResponseProjectile projectileCollisionHandler;
        List<Fireball> proj;
        List<Fireball> toBeRemoved;

        public ProjectileCollisionDetector(Game game,List<Fireball> projectile)
        {
            myGame = game;
            projectileCollisionList = new List<ISprite>();
            proj = projectile;
        }

        public void Update()
        {
            toBeRemoved = new List<Fireball>();
            if (proj.Count != 0)
            {
                foreach (Fireball fBalls in proj)
                {
                    projectileCollisionList = myGame.bgList;

                    projectileRec = fBalls.DestinationRectangle();

                    foreach (ISprite sprite in projectileCollisionList)
                    {
                        objectRec = sprite.DestinationRectangle();

                        if (projectileRec.Intersects(objectRec))
                        {
                            if (!sprite.type.Contains("BgElement"))
                            {
                                CollidesFrom();
                                Type(sprite);
                                projectileCollisionHandler.HandleCollision(fBalls, sprite, projectileCollidesFromHorizontalSide, projectileCollidesFromVerticalSide);
                            }
                        }
                    }
                    if (fBalls.deleted)
                    {
                        toBeRemoved.Add(fBalls);
                    }
                }
                if (toBeRemoved.Count > 0)
                {
                    foreach (Fireball fireB in toBeRemoved)
                    {
                        proj.Remove(fireB);
                    }
                }
            }
        }

        public void CollidesFrom()
        {
            projectileCollidesFromHorizontalSide = "none";
            projectileCollidesFromVerticalSide = "none";

            if (projectileRec.Left > objectRec.Right - 2 && ((projectileRec.Top <= objectRec.Top && projectileRec.Bottom >= objectRec.Top + 2) || (projectileRec.Top > objectRec.Top && objectRec.Bottom >= projectileRec.Top - 2)))
            {
                projectileCollidesFromHorizontalSide = "right";
            }
            else if (projectileRec.Right < objectRec.Left + 2 && ((projectileRec.Top <= objectRec.Top && projectileRec.Bottom >= objectRec.Top + 2) || (projectileRec.Top > objectRec.Top && objectRec.Bottom >= projectileRec.Top - 2)))
            {
                projectileCollidesFromHorizontalSide = "left";
            }

            if (projectileRec.Bottom > objectRec.Bottom && projectileRec.Top > objectRec.Bottom - 2 && ((projectileRec.Left <= objectRec.Left && projectileRec.Right >= objectRec.Left + 2) || (projectileRec.Left > objectRec.Left && objectRec.Right >= projectileRec.Left - 2)))
            {
                projectileCollidesFromVerticalSide = "bottom";
            }
            else if (projectileRec.Top < objectRec.Top && projectileRec.Bottom < objectRec.Top + 2 && ((projectileRec.Left <= objectRec.Left && projectileRec.Right >= objectRec.Left + 2) || (projectileRec.Left > objectRec.Left && objectRec.Right >= projectileRec.Left - 2)))
            {
                projectileCollidesFromVerticalSide = "top";

            }

        }

        private void Type(ISprite sprite)
        {
            if (sprite.type.Contains("Block"))
            {
                projectileCollisionHandler = new ProjectileBlockCollisionHandler(myGame);
            }
            else if (sprite.type.Contains("Enemy"))
            {
                projectileCollisionHandler = new ProjectileEnemyCollisionHandler(myGame);
            }
        }


    }
}
