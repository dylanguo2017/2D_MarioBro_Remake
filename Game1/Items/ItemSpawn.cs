using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using static Game.Utility;

namespace Game
{
    public class ItemSpawn
    {
        private Game myGame;
        private List<RedMushroom> spawnItem;
        private List<RedMushroom> spawned;

        public ItemSpawn(Game game)
        {
            myGame = game;
            spawnItem = new List<RedMushroom>();
            spawned = new List<RedMushroom>();
        }

        public void SpawnItem(Point spawnLoc)
        {
            RedMushroom spawnThis = new RedMushroom(myGame, spawnLoc.X, spawnLoc.Y);
            spawnItem.Add(spawnThis);
        }

        public void Update()
        {
            if(spawnItem.Count != 0)
            {
                foreach (RedMushroom spawnIt in spawnItem)
                {
                    spawnIt.spawnCtr++;
                    if (spawnIt.spawnCtr > stdSpriteSize)
                    {
                        spawned.Add(spawnIt);
                    }
                }
            }
            if(spawned.Count != zero)
            {
                foreach (RedMushroom spawnIt in spawned)
                {
                    spawnItem.Remove(spawnIt);
                    myGame.itemList.Add(spawnIt);
                    myGame.itemCamList.Add(spawnIt);
                }
                spawned.Clear();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (RedMushroom spawnIt in spawnItem)
            {
                spawnIt.Draw(spriteBatch);
            }
        }
    }
}
