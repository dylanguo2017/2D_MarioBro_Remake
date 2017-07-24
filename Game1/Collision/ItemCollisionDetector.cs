using Game.Collision;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Game
{
    class ItemCollisionDetector : ICollisionDetector
    {
        private Game myGame;
        private List<IItem> itemList;
        private List<IBlock> blockList;

        private CollisionDetector itemBlock;

        private ItemCollisionHandler itemColHandler;

        public ItemCollisionDetector(Game game)
        {
            myGame = game;
            itemBlock = new CollisionDetector();
        }

        public void Update()
        {
            itemList = myGame.itemCamList;
            blockList = myGame.blockCamList;

            foreach (IItem item in itemList)
            {
                Rectangle itemRec = item.DestinationRectangle();

                foreach (IBlock block in blockList)
                {
                    Rectangle blockRec = block.DestinationRectangle();

                    if (block.visible && itemRec.Intersects(blockRec))
                    {
                        itemBlock.CollidesFrom(itemRec, blockRec);
                        itemColHandler = new ItemCollisionHandler(myGame);
                        itemColHandler.hColFrom = itemBlock.hColFrom;
                        itemColHandler.vColFrom = itemBlock.vColFrom;
                        itemColHandler.HandleCollision(item);
                    }
                }

            }
        }

    }
}
