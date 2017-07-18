using Game.Enemies;
using System.Collections.Generic;
using static Game.Utility;

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
            IEnemy curEnemy = myGame.enemyList[zero];
            while (myGame.camera.IsInCamera(curEnemy.enemyPhys.XCoor))
            {
                myGame.enemyList.RemoveAt(zero);
                myGame.enemyCamList.Add(curEnemy);
                curEnemy = myGame.enemyList[zero];
            }

            IBlock curBlock = myGame.blockList[zero];
            while (myGame.camera.IsInCamera(curBlock.DrawLoc))
            {
                myGame.blockList.RemoveAt(zero);
                myGame.blockCamList.Add(curBlock);
                curBlock = myGame.blockList[zero];
            }

            IItem curItem = myGame.itemList[zero];
            while (myGame.camera.IsInCamera(curItem.currentLoc))
            {
                myGame.itemList.RemoveAt(zero);
                myGame.itemCamList.Add(curItem);
                curItem = myGame.itemList[zero];
            }
        }

        public void LoadPipe()
        {
            myGame.enemyCamList.Clear();
            myGame.itemCamList.Clear();
            myGame.blockCamList.Clear();
            myGame.marioState.offset = 0;
            myGame.camera.reset();
            myGame.marioState.marioPhys.Spawn(32, 10);
            if (myGame.enemyPipeList.Count > zero)
            {
                IEnemy curEnemy = myGame.enemyPipeList[zero];
                while (myGame.camera.IsInCamera(curEnemy.enemyPhys.XCoor))
                {
                    myGame.enemyPipeList.RemoveAt(zero);
                    myGame.enemyCamList.Add(curEnemy);
                    if (myGame.enemyPipeList.Count > zero)
                        curEnemy = myGame.enemyPipeList[zero];
                    else
                        break;
                }
            }
            IBlock curBlock = myGame.blockPipeList[zero];
            while (myGame.camera.IsInCamera(curBlock.DrawLoc))
            {
                myGame.blockPipeList.RemoveAt(zero);
                myGame.blockCamList.Add(curBlock);
                if (myGame.blockPipeList.Count > zero)
                    curBlock = myGame.blockPipeList[zero];
                else
                    break;
            }

            IItem curItem = myGame.itemPipeList[zero];
            while (myGame.camera.IsInCamera(curItem.currentLoc))
            {
                myGame.itemPipeList.RemoveAt(zero);
                myGame.itemCamList.Add(curItem);
                if (myGame.itemPipeList.Count > zero)
                    curItem = myGame.itemPipeList[zero];
                else
                    break;
            }
        }
        public void ReloadLevel()
        {
            myGame.marioState.offset = 2532;
            Camera.offset = 2532;
            if (myGame.enemyList.Count > zero)
            {
                IEnemy curEnemy = myGame.enemyList[zero];
                while (curEnemy.enemyPhys.XCoor < myGame.marioState.offset)
                {
                    myGame.enemyList.RemoveAt(zero);
                    curEnemy = myGame.enemyList[zero];
                }
            }
            IBlock curBlock = myGame.blockList[zero];
            while (curBlock.DrawLoc < myGame.marioState.offset)
            {
                myGame.blockList.RemoveAt(zero);
                curBlock = myGame.blockList[zero];
            }
            if (myGame.itemList.Count > zero)
            {
                IItem curItem = myGame.itemList[zero];
                while (curItem.currentLoc < myGame.marioState.offset)
                {
                    myGame.itemList.RemoveAt(zero);
                    curItem = myGame.itemList[zero];
                }
            }

            LoadLevel();
            //IBlock popPipe = myGame.blockCamList.Find()
            //myGame.marioState.marioPhys.Spawn(popPipe.DrawLoc, );
        }
        public void Update()
        {
            if (camLoc != myGame.marioState.offset)
            {
                if (myGame.pipeLevel)
                {
                    UpdatePipe();
                } else
                {
                    UpdateNormal();
                }
                camLoc = myGame.marioState.offset;
            }
        }

        private void UpdatePipe()
        {
            if (myGame.enemyPipeList.Count > zero)
            {
                IEnemy curEnemy = myGame.enemyPipeList[zero];
                while (myGame.camera.IsInCamera(curEnemy.enemyPhys.XCoor))
                {
                    myGame.enemyPipeList.RemoveAt(zero);
                    myGame.enemyCamList.Add(curEnemy);
                    if (myGame.enemyPipeList.Count > zero)
                    {
                        curEnemy = myGame.enemyPipeList[zero];
                    }
                    else
                        break;
                }
            }

            if (myGame.blockPipeList.Count > zero)
            {
                IBlock curBlock = myGame.blockPipeList[zero];
                while (myGame.camera.IsInCamera(curBlock.DrawLoc))
                {
                    myGame.blockPipeList.RemoveAt(zero);
                    myGame.blockCamList.Add(curBlock);
                    if (myGame.blockPipeList.Count > zero)
                    {
                        curBlock = myGame.blockPipeList[zero];
                    }
                    else
                        break;
                }
            }

            if (myGame.itemPipeList.Count > zero)
            {
                IItem curItem = myGame.itemPipeList[zero];
                while (myGame.camera.IsInCamera(curItem.currentLoc))
                {
                    myGame.itemPipeList.RemoveAt(zero);
                    myGame.itemCamList.Add(curItem);
                    if (myGame.itemPipeList.Count > zero)
                    {
                        curItem = myGame.itemPipeList[zero];
                    }
                    else
                        break;
                }
            }

            if (myGame.enemyCamList.Count > zero)
            {
                IEnemy camEnemy = myGame.enemyCamList[zero];
                while (!myGame.camera.IsInCamera(camEnemy.enemyPhys.XCoor))
                {
                    myGame.enemyCamList.RemoveAt(zero);
                    if (myGame.enemyCamList.Count > zero)
                    {
                        camEnemy = myGame.enemyCamList[zero];
                    }
                    else
                        break;
                }
            }


            if (myGame.blockCamList.Count > zero)
            {
                IBlock camBlock = myGame.blockCamList[zero];
                while (!myGame.camera.IsInCamera(camBlock.DrawLoc))
                {
                    myGame.blockCamList.RemoveAt(zero);
                    if (myGame.blockCamList.Count > zero)
                    {
                        camBlock = myGame.blockCamList[zero];
                    }
                    else
                        break;
                }
            }


            if (myGame.itemCamList.Count > zero)
            {
                IItem camItem = myGame.itemCamList[zero];
                while (!myGame.camera.IsInCamera(camItem.currentLoc))
                {
                    myGame.itemCamList.RemoveAt(zero);
                    if (myGame.itemCamList.Count > zero)
                    {
                        camItem = myGame.itemCamList[zero];
                    }
                    else
                        break;
                }
            }
        }
        private void UpdateNormal()
        {
            if (myGame.enemyList.Count > zero)
            {
                IEnemy curEnemy = myGame.enemyList[zero];
                while (myGame.camera.IsInCamera(curEnemy.enemyPhys.XCoor))
                {
                    myGame.enemyList.RemoveAt(zero);
                    myGame.enemyCamList.Add(curEnemy);
                    if (myGame.enemyList.Count > zero)
                    {
                        curEnemy = myGame.enemyList[zero];
                    }
                    else
                        break;
                }
            }

            if (myGame.blockList.Count > zero)
            {
                IBlock curBlock = myGame.blockList[zero];
                while (myGame.camera.IsInCamera(curBlock.DrawLoc))
                {
                    myGame.blockList.RemoveAt(zero);
                    myGame.blockCamList.Add(curBlock);
                    if (myGame.blockList.Count > zero)
                    {
                        curBlock = myGame.blockList[zero];
                    }
                    else
                        break;
                }
            }

            if (myGame.itemList.Count > zero)
            {
                IItem curItem = myGame.itemList[zero];
                while (myGame.camera.IsInCamera(curItem.currentLoc))
                {
                    myGame.itemList.RemoveAt(zero);
                    myGame.itemCamList.Add(curItem);
                    if (myGame.itemList.Count > zero)
                    {
                        curItem = myGame.itemList[zero];
                    }
                    else
                        break;
                }
            }

            if (myGame.enemyCamList.Count > zero)
            {
                IEnemy camEnemy = myGame.enemyCamList[zero];
                while (!myGame.camera.IsInCamera(camEnemy.enemyPhys.XCoor))
                {
                    myGame.enemyCamList.RemoveAt(zero);
                    if (myGame.enemyCamList.Count > zero)
                    {
                        camEnemy = myGame.enemyCamList[zero];
                    }
                    else
                        break;
                }
            }


            if (myGame.blockCamList.Count > zero)
            {
                IBlock camBlock = myGame.blockCamList[zero];
                while (!myGame.camera.IsInCamera(camBlock.DrawLoc))
                {
                    myGame.blockCamList.RemoveAt(zero);
                    if (myGame.blockCamList.Count > zero)
                    {
                        camBlock = myGame.blockCamList[zero];
                    }
                    else
                        break;
                }
            }


            if (myGame.itemCamList.Count > zero)
            {
                IItem camItem = myGame.itemCamList[zero];
                while (!myGame.camera.IsInCamera(camItem.currentLoc))
                {
                    myGame.itemCamList.RemoveAt(zero);
                    if (myGame.itemCamList.Count > zero)
                    {
                        camItem = myGame.itemCamList[zero];
                    }
                    else
                        break;
                }
            }
        }
    }
}
