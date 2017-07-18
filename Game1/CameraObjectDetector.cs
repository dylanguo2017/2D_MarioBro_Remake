﻿using Game.Enemies;
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
            IEnemy curEnemy = myGame.enemyList[0];
            while (myGame.camera.IsInCamera(curEnemy.enemyPhys.XCoor))
            {
                myGame.enemyList.RemoveAt(0);
                myGame.enemyCamList.Add(curEnemy);
                curEnemy = myGame.enemyList[0];
            }

            IBlock curBlock = myGame.blockList[0];
            while (myGame.camera.IsInCamera(curBlock.DrawLoc))
            {
                myGame.blockList.RemoveAt(0);
                myGame.blockCamList.Add(curBlock);
                curBlock = myGame.blockList[0];
            }

            IItem curItem = myGame.itemList[0];
            while (myGame.camera.IsInCamera(curItem.currentLoc))
            {
                myGame.itemList.RemoveAt(0);
                myGame.itemCamList.Add(curItem);
                curItem = myGame.itemList[0];
            }
        }

        public void LoadPipe()
        {
            myGame.enemyCamList.Clear();
            myGame.itemCamList.Clear();
            myGame.blockCamList.Clear();
            if (myGame.enemyPipeList.Count > 0)
            {
                IEnemy curEnemy = myGame.enemyPipeList[0];
                while (myGame.camera.IsInCamera(curEnemy.enemyPhys.XCoor))
                {
                    myGame.enemyPipeList.RemoveAt(0);
                    myGame.enemyCamList.Add(curEnemy);
                    if (myGame.enemyPipeList.Count > 0)
                        curEnemy = myGame.enemyPipeList[0];
                    else
                        break;
                }
            }
            IBlock curBlock = myGame.blockPipeList[0];
            while (myGame.camera.IsInCamera(curBlock.DrawLoc))
            {
                myGame.blockPipeList.RemoveAt(0);
                myGame.blockCamList.Add(curBlock);
                if (myGame.blockPipeList.Count > 0)
                    curBlock = myGame.blockPipeList[0];
                else
                    break;
            }

            IItem curItem = myGame.itemPipeList[0];
            while (myGame.camera.IsInCamera(curItem.currentLoc))
            {
                myGame.itemPipeList.RemoveAt(0);
                myGame.itemCamList.Add(curItem);
                if (myGame.itemPipeList.Count > 0)
                    curItem = myGame.itemPipeList[0];
                else
                    break;
            }
        }
        public void ReloadLevel()
        {
            if (myGame.enemyList.Count > 0)
            {
                IEnemy curEnemy = myGame.enemyList[0];
                while (curEnemy.enemyPhys.XCoor < myGame.marioState.offset)
                {
                    myGame.enemyList.RemoveAt(0);
                    curEnemy = myGame.enemyList[0];
                }
            }
            IBlock curBlock = myGame.blockList[0];
            while (curBlock.DrawLoc < myGame.marioState.offset)
            {
                myGame.blockList.RemoveAt(0);
                curBlock = myGame.blockList[0];
            }
            if (myGame.itemList.Count > 0)
            {
                IItem curItem = myGame.itemList[0];
                while (curItem.currentLoc < myGame.marioState.offset)
                {
                    myGame.itemList.RemoveAt(0);
                    curItem = myGame.itemList[0];
                }
            }

            LoadLevel();
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
            if (myGame.enemyPipeList.Count > 0)
            {
                IEnemy curEnemy = myGame.enemyPipeList[0];
                while (myGame.camera.IsInCamera(curEnemy.enemyPhys.XCoor))
                {
                    myGame.enemyPipeList.RemoveAt(0);
                    myGame.enemyCamList.Add(curEnemy);
                    if (myGame.enemyPipeList.Count > 0)
                    {
                        curEnemy = myGame.enemyPipeList[0];
                    }
                    else
                        break;
                }
            }

            if (myGame.blockPipeList.Count > 0)
            {
                IBlock curBlock = myGame.blockPipeList[0];
                while (myGame.camera.IsInCamera(curBlock.DrawLoc))
                {
                    myGame.blockPipeList.RemoveAt(0);
                    myGame.blockCamList.Add(curBlock);
                    if (myGame.blockPipeList.Count > 0)
                    {
                        curBlock = myGame.blockPipeList[0];
                    }
                    else
                        break;
                }
            }

            if (myGame.itemPipeList.Count > 0)
            {
                IItem curItem = myGame.itemPipeList[0];
                while (myGame.camera.IsInCamera(curItem.currentLoc))
                {
                    myGame.itemPipeList.RemoveAt(0);
                    myGame.itemCamList.Add(curItem);
                    if (myGame.itemPipeList.Count > 0)
                    {
                        curItem = myGame.itemPipeList[0];
                    }
                    else
                        break;
                }
            }

            if (myGame.enemyCamList.Count > 0)
            {
                IEnemy camEnemy = myGame.enemyCamList[0];
                while (!myGame.camera.IsInCamera(camEnemy.enemyPhys.XCoor))
                {
                    myGame.enemyCamList.RemoveAt(0);
                    if (myGame.enemyCamList.Count > 0)
                    {
                        camEnemy = myGame.enemyCamList[0];
                    }
                    else
                        break;
                }
            }


            if (myGame.blockCamList.Count > 0)
            {
                IBlock camBlock = myGame.blockCamList[0];
                while (!myGame.camera.IsInCamera(camBlock.DrawLoc))
                {
                    myGame.blockCamList.RemoveAt(0);
                    if (myGame.blockCamList.Count > 0)
                    {
                        camBlock = myGame.blockCamList[0];
                    }
                    else
                        break;
                }
            }


            if (myGame.itemCamList.Count > 0)
            {
                IItem camItem = myGame.itemCamList[0];
                while (!myGame.camera.IsInCamera(camItem.currentLoc))
                {
                    myGame.itemCamList.RemoveAt(0);
                    if (myGame.itemCamList.Count > 0)
                    {
                        camItem = myGame.itemCamList[0];
                    }
                    else
                        break;
                }
            }
        }
        private void UpdateNormal()
        {
            if (myGame.enemyList.Count > 0)
            {
                IEnemy curEnemy = myGame.enemyList[0];
                while (myGame.camera.IsInCamera(curEnemy.enemyPhys.XCoor))
                {
                    myGame.enemyList.RemoveAt(0);
                    myGame.enemyCamList.Add(curEnemy);
                    if (myGame.enemyList.Count > 0)
                    {
                        curEnemy = myGame.enemyList[0];
                    }
                    else
                        break;
                }
            }

            if (myGame.blockList.Count > 0)
            {
                IBlock curBlock = myGame.blockList[0];
                while (myGame.camera.IsInCamera(curBlock.DrawLoc))
                {
                    myGame.blockList.RemoveAt(0);
                    myGame.blockCamList.Add(curBlock);
                    if (myGame.blockList.Count > 0)
                    {
                        curBlock = myGame.blockList[0];
                    }
                    else
                        break;
                }
            }

            if (myGame.itemList.Count > 0)
            {
                IItem curItem = myGame.itemList[0];
                while (myGame.camera.IsInCamera(curItem.currentLoc))
                {
                    myGame.itemList.RemoveAt(0);
                    myGame.itemCamList.Add(curItem);
                    if (myGame.itemList.Count > 0)
                    {
                        curItem = myGame.itemList[0];
                    }
                    else
                        break;
                }
            }

            if (myGame.enemyCamList.Count > 0)
            {
                IEnemy camEnemy = myGame.enemyCamList[0];
                while (!myGame.camera.IsInCamera(camEnemy.enemyPhys.XCoor))
                {
                    myGame.enemyCamList.RemoveAt(0);
                    if (myGame.enemyCamList.Count > 0)
                    {
                        camEnemy = myGame.enemyCamList[0];
                    }
                    else
                        break;
                }
            }


            if (myGame.blockCamList.Count > 0)
            {
                IBlock camBlock = myGame.blockCamList[0];
                while (!myGame.camera.IsInCamera(camBlock.DrawLoc))
                {
                    myGame.blockCamList.RemoveAt(0);
                    if (myGame.blockCamList.Count > 0)
                    {
                        camBlock = myGame.blockCamList[0];
                    }
                    else
                        break;
                }
            }


            if (myGame.itemCamList.Count > 0)
            {
                IItem camItem = myGame.itemCamList[0];
                while (!myGame.camera.IsInCamera(camItem.currentLoc))
                {
                    myGame.itemCamList.RemoveAt(0);
                    if (myGame.itemCamList.Count > 0)
                    {
                        camItem = myGame.itemCamList[0];
                    }
                    else
                        break;
                }
            }
        }
    }
}
