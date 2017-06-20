using System;
using System.Collections;

namespace Game
{
    public class LevelList
    {
        private Game myGame;
        public ArrayList list;

        public LevelList(Game game)
        {
            myGame = game;
            list = new ArrayList();
        }

        public ArrayList Load()
        {
            list = Level.Load(myGame);

            list.Add(myGame.questionMarkBlock);
            list.Add(myGame.diamondBlock);
            list.Add(myGame.brickBlock);
            list.Add(myGame.crackBlock);
            list.Add(myGame.pipe);
            list.Add(myGame.usedBlock);
            list.Add(myGame.invisibleBlock);
                        
            list.Add(myGame.star);
            list.Add(myGame.greenMushroom);
            list.Add(myGame.redMushroom);
            list.Add(myGame.coin);
            list.Add(myGame.fireFlower);

            list.Add(myGame.goomba);
            list.Add(myGame.koopa);
            
            list.Add(myGame.oneCloud);
            list.Add(myGame.threeClouds);
            list.Add(myGame.threeBushes);
            list.Add(myGame.smallMountain);
            list.Add(myGame.bigMountain);

            return list;
        }

    }
}
