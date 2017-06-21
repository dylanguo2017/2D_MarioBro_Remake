using Game.Sprites;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;

namespace Game
{
    public static class Level
    {
        public static List<ISprite> LoadList(Game myGame)
        {
            List<ISprite> list = new List<ISprite>();
            StreamReader levelFile = new StreamReader(
         Path.Combine(Directory.GetCurrentDirectory(),
                      "Content", "Levels", "TLevel1-1.txt")
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
                        ISprite gameObject = new MotionlessNonAnimatedSprite(myGame.brickBlockSprite, 1, 1, positionColumn * 16, positionRow * 16);
                        list.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("crack"))
                    {
                        ISprite gameObject = new MotionlessNonAnimatedSprite(myGame.crackBlockSprite, 1, 1, positionColumn * 16, positionRow * 16);
                        list.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("diamond"))
                    {
                        ISprite gameObject = new MotionlessNonAnimatedSprite(myGame.diamondBlockSprite, 1, 1, positionColumn * 16, positionRow * 16);
                        list.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("question"))
                    {
                        ISprite gameObject = new MotionlessAnimatedSprite(myGame.questionMarkBlockSprite, 1, 3, positionColumn * 16, positionRow * 16);
                        list.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("used"))
                    {
                        ISprite gameObject = new MotionlessNonAnimatedSprite(myGame.usedBlockSprite, 1, 1, positionColumn * 16, positionRow * 16);
                        list.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("invisible"))
                    {
                        ISprite gameObject = new MotionlessNonAnimatedSprite(myGame.invisibleBlockSprite, 1, 1, positionColumn * 16, positionRow * 16);
                        list.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("pipe"))
                    {
                        ISprite gameObject = new MotionlessNonAnimatedSprite(myGame.pipeBlockSprite, 1, 1, positionColumn * 16, positionRow * 16);
                        list.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("star"))
                    {
                        ISprite gameObject = new MotionlessAnimatedSprite(myGame.starItem, 1, 4, positionColumn * 16, positionRow * 16);
                        list.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("coin"))
                    {
                        ISprite gameObject = new MotionlessAnimatedSprite(myGame.coinItem, 1, 4, positionColumn * 16, positionRow * 16);
                        list.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("goomba"))
                    {
                        ISprite gameObject = new MotionlessAnimatedSprite(myGame.goombaEnemy, 1, 2, positionColumn * 16, positionRow * 16);
                        list.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("koopa"))
                    {
                        ISprite gameObject = new MotionlessAnimatedSprite(myGame.koopaEnemy, 1, 3, positionColumn * 16, positionRow * 16);
                        list.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("flower"))
                    {
                        ISprite gameObject = new MotionlessAnimatedSprite(myGame.fireFlowerItem, 1, 4, positionColumn * 16, positionRow * 16);
                        list.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("redMushroom"))
                    {
                        ISprite gameObject = new MotionlessNonAnimatedSprite(myGame.redMushroomItem, 1, 1, positionColumn * 16, positionRow * 16);
                        list.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("greenMushroom"))
                    {
                        ISprite gameObject = new MotionlessNonAnimatedSprite(myGame.greenMushroomItem, 1, 1, positionColumn * 16, positionRow * 16);
                        list.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("oneCloud"))
                    {
                        ISprite gameObject = new MotionlessNonAnimatedSprite(myGame.oneCloudBgElement, 1, 1, positionColumn * 16, positionRow * 16);
                        list.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("threeClouds"))
                    {
                        ISprite gameObject = new MotionlessNonAnimatedSprite(myGame.threeCloudsBgElement, 1, 1, positionColumn * 16, positionRow * 16);
                        list.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("threeBushes"))
                    {
                        ISprite gameObject = new MotionlessNonAnimatedSprite(myGame.threeBushesBgElement, 1, 1, positionColumn * 16, positionRow * 16);
                        list.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("smallMountain"))
                    {
                        ISprite gameObject = new MotionlessNonAnimatedSprite(myGame.smallMountainBgElement, 1, 1, positionColumn * 16, positionRow * 16);
                        list.Add(gameObject);
                    }
                    else if (target[positionColumn].Equals("bigMountain"))
                    {
                        ISprite gameObject = new MotionlessNonAnimatedSprite(myGame.bigMountainBgElement, 1, 1, positionColumn * 16, positionRow * 16);
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
                    modifiedGameObject.ToggleSpriteSheet(texture, 1, 1);
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
