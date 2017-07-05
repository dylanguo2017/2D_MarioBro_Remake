using Game.Enemies;
using Game.Sprites;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;

namespace Game
{
    public static class Level
    {
        public static List<IEnemy> enemyList;
        public static List<IItem> itemList;
        public static List<IBlock> blockList;

        public static List<ISprite> enemyCollisionList = new List<ISprite>();
        public static List<ISprite> itemCollisionList = new List<ISprite>();

        public static List<ISprite> LoadList(Game myGame)
        {
            enemyList = new List<IEnemy>();
            itemList = new List<IItem>();
            blockList = new List<IBlock>();

            enemyCollisionList = new List<ISprite>();
            List<ISprite> list = new List<ISprite>();

            StreamReader levelFile = new StreamReader(
         Path.Combine(Directory.GetCurrentDirectory(),
                      "Content", "Levels", "Level1-1.txt")
         );
            String inComingLine;
            int positionRow = 0;

            while (!levelFile.EndOfStream)
            {
                inComingLine = levelFile.ReadLine();
                String[] target = inComingLine.Split(',');
                int positionColumn = 0;
                while (positionColumn < target.Length)
                {
                    if (target[positionColumn].Equals("brick"))
                    {
                        Brick gameObject = new Brick(myGame, myGame.blockSprite, 28, 33, positionColumn * 16, positionRow * 16);
                        blockList.Add(gameObject);
                        //list.Add(gameObject);
                        //itemCollisionList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("crack"))
                    {
                        Crack gameObject = new Crack(myGame, myGame.blockSprite, 28, 33, positionColumn * 16, positionRow * 16);
                        blockList.Add(gameObject);
                    }                    
                    else if (target[positionColumn].Equals("diamond"))
                    {
                        Diamond gameObject = new Diamond(myGame, myGame.blockSprite, 28, 33, positionColumn * 16, positionRow * 16);
                        blockList.Add(gameObject);
                        //enemyCollisionList.Add(gameObject);
                        //itemCollisionList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("question"))
                    {
                        Question gameObject = new Question(myGame, myGame.blockSprite, 28, 33, positionColumn * 16, positionRow * 16);
                        blockList.Add(gameObject);
                        //itemCollisionList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("questionRedMushroom"))
                    {
                        //make question block draw a red mushroom on top when hit
                    }
                    else if (target[positionColumn].Equals("questionGreenMushroom"))
                    {
                        //make question block draw a green mushroom on top when hit
                    }
                    else if (target[positionColumn].Equals("questionStar"))
                    {
                        //make question block draw a star on top when hit
                    }
                    else if (target[positionColumn].Equals("questionCoin"))
                    {
                        //make question block gain a coin for mario when hit
                    }
                    else if (target[positionColumn].Equals("questionFlower"))
                    {
                        //make question block draw a fire flower on top when hit
                    }
                    else if (target[positionColumn].Equals("used"))
                    {
                        Used gameObject = new Used(myGame, myGame.blockSprite, 28, 33, positionColumn * 16, positionRow * 16);
                        blockList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("invisible"))
                    {
                        Invisible gameObject = new Invisible(myGame, myGame.blockSprite, 28, 33, positionColumn * 16, positionRow * 16);
                        blockList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("smallPipe"))
                    {
                        Pipe gameObject = new Pipe(myGame, myGame.blockSprite, 28, 33, positionColumn * 16, positionRow * 16);
                        blockList.Add(gameObject);
                        //enemyCollisionList.Add(gameObject);
                       // itemCollisionList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("mediumPipe"))
                    {
                        //ISprite gameObject = new MotionlessAnimatedSprite(myGame, myGame.mediumPipeBlockSprite, 1, 1, positionColumn * 16, positionRow * 16);
                        //list.Add(gameObject);
                        //enemyCollisionList.Add(gameObject);
                        //itemCollisionList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("bigPipe"))
                    {
                        //ISprite gameObject = new MotionlessAnimatedSprite(myGame, myGame.bigPipeBlockSprite, 1, 1, positionColumn * 16, positionRow * 16);
                        //list.Add(gameObject);
                        //enemyCollisionList.Add(gameObject);
                        //itemCollisionList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("star"))
                    {
                        StarItem gameObject = new StarItem(myGame, myGame.itemSprite, 21, 36, positionColumn * 16, positionRow * 16);
                        itemList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("coin"))
                    {
                        CoinItem gameObject = new CoinItem(myGame, myGame.itemSprite, 21, 36, positionColumn * 16, positionRow * 16);
                        itemList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("flower"))
                    {
                        FlowerItem gameObject = new FlowerItem(myGame, myGame.itemSprite, 21, 36, positionColumn * 16, positionRow * 16);
                        itemList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("redMushroom"))
                    {
                        RedMushroomItem gameObject = new RedMushroomItem(myGame, myGame.itemSprite, 21, 36, positionColumn * 16, positionRow * 16);
                        itemList.Add(gameObject);
                        //itemList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("greenMushroom"))
                    {
                        GreenMushroomItem gameObject = new GreenMushroomItem(myGame, myGame.itemSprite, 21, 36, positionColumn * 16, positionRow * 16);
                        itemList.Add(gameObject);
                        //itemList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("goomba"))
                    {
                        IEnemy gameObject = new GoombaEnemy(myGame.goombaEnemy, myGame);
                       // list.Add(gameObject);
                        enemyList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("koopa"))
                    {
                        IEnemy gameObject = new KoopaEnemy(myGame.koopaEnemy, myGame);
                        //list.Add(gameObject);
                        enemyList.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("oneCloud"))
                    {
                        ISprite gameObject = new MotionlessNonAnimatedSprite(myGame, myGame.oneCloudBgElement, 1, 1, positionColumn * 16, positionRow * 16);
                        list.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("threeClouds"))
                    {
                        ISprite gameObject = new MotionlessNonAnimatedSprite(myGame, myGame.threeCloudsBgElement, 1, 1, positionColumn * 16, positionRow * 16);
                        list.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("oneBush"))
                    {
                        ISprite gameObject = new MotionlessNonAnimatedSprite(myGame, myGame.oneBushBgElement, 1, 1, positionColumn * 16, positionRow * 16);
                        list.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("threeBushes"))
                    {
                        ISprite gameObject = new MotionlessNonAnimatedSprite(myGame, myGame.threeBushesBgElement, 1, 1, positionColumn * 16, positionRow * 16);
                        list.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("smallMountain"))
                    {
                        ISprite gameObject = new MotionlessNonAnimatedSprite(myGame, myGame.smallMountainBgElement, 1, 1, positionColumn * 16, positionRow * 16);
                        list.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("bigMountain"))
                    {
                        ISprite gameObject = new MotionlessNonAnimatedSprite(myGame, myGame.bigMountainBgElement, 1, 1, positionColumn * 16, positionRow * 16);
                        list.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("smallCastle"))
                    {
                        ISprite gameObject = new MotionlessNonAnimatedSprite(myGame, myGame.smallCastle, 1, 1, positionColumn * 16, positionRow * 16);
                        list.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("flagpole"))
                    {
                        ISprite gameObject = new MotionlessNonAnimatedSprite(myGame, myGame.flagpoleElement, 1, 1, positionColumn * 16, positionRow * 16);
                        list.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("title"))
                    {
                        ISprite gameObject = new MotionlessNonAnimatedSprite(myGame, myGame.titleScreen, 1, 1, positionColumn * 16, positionRow * 16);
                        list.Add(gameObject);
                    }

                    positionColumn++;
                }
                positionRow++;
            }
            levelFile.Close();
            return list;
        }

        public static List<ISprite> ReloadList(List<ISprite> list, Texture2D texture, String type, int columns)
        {
            List<ISprite> reloadList = new List<ISprite>();
            foreach (ISprite gameObject in list)
            {
                if (gameObject.type.Equals(type))
                {
                    ISprite modifiedGameObject = gameObject;
                    modifiedGameObject.ToggleSpriteSheet(texture, 1, columns);
                    reloadList.Add(modifiedGameObject);
                }
                else
                {
                    reloadList.Add(gameObject);
                }
            }
            list = new List<ISprite>(reloadList);
            return list;
        }

    }
}
