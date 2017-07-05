using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Game
{
    class ItemCollisionDetector : ICollisionDetector
    {
        private Game myGame;
        private List<IItem> itemList;
        private List<IBlock> blockList;

        private Rectangle itemRec;

        private String itemColFrom;
        private ItemCollisionHandler itemColHandler;

        public ItemCollisionDetector(Game game)
        {
            myGame = game;
        }

        public void Update()
        {
            itemList = Level.itemList;
            blockList = Level.blockList;

            Rectangle blockRec;
            foreach (IItem item in itemList)
            {
                itemRec = item.DestinationRectangle();

                foreach (IBlock block in blockList)
                {
                    blockRec = block.DestinationRectangle();

                    if (blockRec.X <= 800 && itemRec.Intersects(blockRec))
                    {
                        CollidesFrom(blockRec);
                        itemColHandler = new ItemCollisionHandler(myGame);
                        itemColHandler.HandleCollision(item, itemColFrom);
                    }
                }

            }
        }

        public void CollidesFrom(Rectangle blockRec)
        {
            itemColFrom = "none";

            if (itemRec.Left > blockRec.Right - 2 && ((itemRec.Top <= blockRec.Top && itemRec.Bottom >= blockRec.Top + 2) || (itemRec.Top > blockRec.Top && blockRec.Bottom >= itemRec.Top - 2)))
            {
                itemColFrom = "right";
            }
            else if (itemRec.Right < blockRec.Left + 2 && ((itemRec.Top <= blockRec.Top && itemRec.Bottom >= blockRec.Top + 2) || (itemRec.Top > blockRec.Top && blockRec.Bottom >= itemRec.Top - 2)))
            {
                itemColFrom = "left";
            }
        }

    }
}
