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

        private String itemColFromHorizontalSide;
        private String itemColFromVerticalSide;
        private ItemCollisionHandler itemColHandler;

        private int diff;

        public ItemCollisionDetector(Game game)
        {
            myGame = game;
        }

        public void Update()
        {
            blockList = myGame.blockList;
            itemList = myGame.itemList;

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
                        itemColHandler.HandleCollision(item, itemColFromHorizontalSide, itemColFromVerticalSide, diff);
                    }
                }

            }
        }

        public void CollidesFrom(Rectangle blockRec)
        {
            itemColFromHorizontalSide = "none";
            itemColFromVerticalSide = "none";

            if (itemRec.Left <= blockRec.Right - 2 && ((itemRec.Top <= blockRec.Top && itemRec.Bottom >= blockRec.Top + 2) || (itemRec.Top > blockRec.Top && blockRec.Bottom >= itemRec.Top - 2)))
            {
                itemColFromHorizontalSide = "right";
            }
            else if (itemRec.Right >= blockRec.Left + 2 && ((itemRec.Top <= blockRec.Top && itemRec.Bottom >= blockRec.Top + 2) || (itemRec.Top > blockRec.Top && blockRec.Bottom >= itemRec.Top - 2)))
            {
                itemColFromHorizontalSide = "left";
            }

            if (itemRec.Bottom > blockRec.Bottom && itemRec.Top <= blockRec.Bottom - 2 && ((itemRec.Left <= blockRec.Left && itemRec.Right >= blockRec.Left + 2) || (itemRec.Left > blockRec.Left && blockRec.Right >= itemRec.Left - 2)))
            {
                itemColFromVerticalSide = "bottom";
            }
            else if (itemRec.Top < blockRec.Top && itemRec.Bottom >= blockRec.Top + 2 && ((itemRec.Left <= blockRec.Left && itemRec.Right >= blockRec.Left + 2) || (itemRec.Left > blockRec.Left && blockRec.Right >= itemRec.Left - 2)))
            {
                itemColFromVerticalSide = "top";
                diff = itemRec.Bottom - blockRec.Top - 2;
            }
        }

    }
}
