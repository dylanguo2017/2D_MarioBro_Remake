using Game.Enemies;
using System.Collections.Generic;

namespace Game
{
    public class CameraObjectDetector
    {
        public Game myGame;
        private int camLoc = 0;

        public CameraObjectDetector(Game game)
        {
            myGame = game;

            myGame.enemyCamList = new List<IEnemy>();
            myGame.itemCamList = new List<IItem>();
            myGame.blockCamList = new List<IBlock>();
        }
        public void LoadLevel()
        {
            myGame.enemyCamList.Clear();
            myGame.itemCamList.Clear();
            myGame.blockCamList.Clear();
            foreach (IEnemy enemy in myGame.enemyList)
            {
                if (myGame.camera.IsInCamera(enemy.enemyPhys.XCoor))
                {
                    myGame.enemyCamList.Add(enemy);
                }
            }
            foreach (IBlock block in myGame.blockList)
            {
                if (myGame.camera.IsInCamera(block.DrawLoc))
                {
                    myGame.blockCamList.Add(block);
                }
            }
        }
        public void Update()
        {
            if (camLoc != myGame.marioState.offset)
            {
                myGame.enemyCamList.Clear();
                myGame.itemCamList.Clear();
                myGame.blockCamList.Clear();

                foreach (IEnemy enemy in myGame.enemyList)
                {
                    if (myGame.camera.IsInCamera(enemy.enemyPhys.XCoor))
                    {
                        myGame.enemyCamList.Add(enemy);
                    }
                }
                //foreach (IItem item in myGame.itemList)
                //{
                //    if (myGame.camera.IsInCamera())
                //    {
                //        myGame.itemCamList.Add(item);
                //    }
                //}
                foreach (IBlock block in myGame.blockList)
                {
                    if (myGame.camera.IsInCamera(block.DrawLoc))
                    {
                        myGame.blockCamList.Add(block);
                    }
                }
                camLoc = myGame.marioState.offset;
            }
        }
    }
}
