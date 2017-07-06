using Game.Enemies;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;
using System.Collections.Generic;


namespace Game
{
    public class Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public MarioStateClass marioState;

        public Camera camera;

        public IMario mario;
        
        private ArrayList contrl;
        
        public Texture2D oneCloudBgElement;
        public Texture2D threeCloudsBgElement;
        public Texture2D oneBushBgElement;
        public Texture2D threeBushesBgElement;
        public Texture2D smallMountainBgElement;
        public Texture2D bigMountainBgElement;
        public Texture2D smallCastle;
        public Texture2D flagpoleElement;

        public Texture2D goombaEnemy;
        public Texture2D koopaEnemy;

        public Texture2D marioSprites;
        public Texture2D fireballSprite;
        public Texture2D titleScreen;

        public Texture2D blockSprite;
        public Texture2D itemSprite;

        public List<IBlock> blockList;
        public List<IEnemy> enemyList;
        public List<IItem> itemList;
        public List<ISprite> bgList;

        private ICommand qtCmd;
        private ICommand wCmd;
        private ICommand aCmd;
        private ICommand sCmd;
        private ICommand dCmd;
        private ICommand zCmd;
        private ICommand xCmd;
        private ICommand cCmd;
        private ICommand yCmd;
        private ICommand uCmd;
        private ICommand iCmd;
        private ICommand oCmd;
        private ICommand rCmd;
        private ICommand auCmd;
        private ICommand adCmd;
        private ICommand alCmd;
        private ICommand arCmd;

        private int animationModifier;
        private int starDuration;
        
        public List<Fireball> fireBalls;
        public int fbDelay;

        private ICollisionDetector marioColDetector;
        private ICollisionDetector enemyColDetector;
        private ICollisionDetector itemColDetector;
        private ICollisionDetector projColDet;

        public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {   
            contrl = new ArrayList();

            camera = new Camera(this);

            marioColDetector = new MarioCollisionDetector(this);
            enemyColDetector = new EnemyCollisionDetector(this);
            itemColDetector = new ItemCollisionDetector(this);
            
            IController keyboard = new KeyboardController();
            IController gmPad = new GamepadController();

            contrl.Add(keyboard);
            contrl.Add(gmPad);

            qtCmd = new QuitCommand(this);
            wCmd = new WCommand(this);
            aCmd = new ACommand(this);
            sCmd = new SCommand(this);
            dCmd = new DCommand(this);
            zCmd = new ZCommand(this);
            xCmd = new XCommand(this);
            cCmd = new CCommand(this);
            yCmd = new YCommand(this);
            uCmd = new UCommand(this);
            iCmd = new ICmd(this);
            oCmd = new OCommand(this);
            rCmd = new RCommand(this);
            auCmd = new AUCommand(this);
            adCmd = new ADCommand(this);
            alCmd = new ALCommand(this);
            arCmd = new ARCommand(this);
            keyboard.RegisterCommand(Keys.Q, qtCmd);
            keyboard.RegisterCommand(Keys.W, wCmd);
            keyboard.RegisterCommand(Keys.A, aCmd);
            keyboard.RegisterCommand(Keys.S, sCmd);
            keyboard.RegisterCommand(Keys.D, dCmd);
            keyboard.RegisterCommand(Keys.Z, zCmd);
            keyboard.RegisterCommand(Keys.X, xCmd);
            keyboard.RegisterCommand(Keys.C, cCmd);
            keyboard.RegisterCommand(Keys.Y, yCmd);
            keyboard.RegisterCommand(Keys.U, uCmd);
            keyboard.RegisterCommand(Keys.I, iCmd);
            keyboard.RegisterCommand(Keys.O, oCmd);
            keyboard.RegisterCommand(Keys.R, rCmd);
            keyboard.RegisterCommand(Keys.Up, auCmd);
            keyboard.RegisterCommand(Keys.Down, adCmd);
            keyboard.RegisterCommand(Keys.Left, alCmd);
            keyboard.RegisterCommand(Keys.Right, arCmd);
            gmPad.RegisterCommand(Buttons.LeftThumbstickUp, wCmd);
            gmPad.RegisterCommand(Buttons.LeftThumbstickLeft, aCmd);
            gmPad.RegisterCommand(Buttons.LeftThumbstickDown, sCmd);
            gmPad.RegisterCommand(Buttons.LeftThumbstickRight, dCmd);
            gmPad.RegisterCommand(Buttons.A, zCmd);
            gmPad.RegisterCommand(Buttons.B, xCmd);

            marioState = new MarioStateClass(false, false, false, false);
            fireBalls = new List<Fireball>();
            fbDelay = 0;
            projColDet = new ProjectileCollisionDetector(this, fireBalls);

            animationModifier = 0;
            starDuration = 500;

            base.Initialize();
        }


        protected override void LoadContent()
        {

            itemSprite = Content.Load<Texture2D>("SpriteSheets/Items");
            blockSprite = Content.Load<Texture2D>("SpriteSheets/Tileset");

            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            oneCloudBgElement = Content.Load<Texture2D>("1CloudBgElement");
            threeCloudsBgElement = Content.Load<Texture2D>("3CloudsBgElement");
            oneBushBgElement = Content.Load<Texture2D>("1BushElement");
            threeBushesBgElement = Content.Load<Texture2D>("3BushesBgElement");
            smallMountainBgElement = Content.Load<Texture2D>("SmallMountainBgElement");
            bigMountainBgElement = Content.Load<Texture2D>("BigMountainBgElement");
            smallCastle = Content.Load<Texture2D>("smallCastle");
            flagpoleElement = Content.Load<Texture2D>("flagPole");

            goombaEnemy = Content.Load<Texture2D>("goomba");
            koopaEnemy = Content.Load<Texture2D>("koopa");

            titleScreen = this.Content.Load<Texture2D>("titleScreen");
            marioSprites = this.Content.Load<Texture2D>("SpriteSheets/Mario");
            fireballSprite = Content.Load<Texture2D>("fireball");

            mario = new SmallMario(marioState, marioSprites);

            Level.LoadLists(this);
            enemyList = Level.enemyList;
            blockList = Level.blockList;
            itemList = Level.itemList;
            bgList = Level.bgList;
        }

        protected override void UnloadContent()
        {
            Content.Unload();
        }
        

        protected override void Update(GameTime gameTime)
        {
            if(fbDelay > 0)
            {
                fbDelay--;
            }

            marioColDetector.Update();
            projColDet.Update();

            if (marioState.star)
            {
                starDuration--;
                if(starDuration < 0)
                {
                    starDuration = 500;
                    if (marioState.curStat.Equals(MarioStateClass.marioStatus.small))
                    {
                        mario = new SmallMario(marioState, marioSprites);
                    }
                    else if (marioState.curStat.Equals(MarioStateClass.marioStatus.large))
                    {
                        mario = new LargeMario(marioState, marioSprites);
                    }
                    else
                    {
                        mario = new FireMario(marioState, marioSprites);
                    }
                }
            }

            animationModifier++;
            foreach (IController x in contrl)
            {
                if (x.isConnected())
                {
                    marioState.move = false;
                    x.Update();
                }
            }

            mario.Update();
            if (fireBalls.Count != 0)
            {
                foreach (Fireball fBalls in fireBalls)
                {
                    fBalls.Update();
                }
            }

            if (animationModifier % 20 == 0)
            {
                foreach (IBlock block in blockList)
                {
                    block.Update();
                }
                foreach (IEnemy enemy in enemyList)
                {
                    enemy.Update();
                    enemyColDetector.Update();
                }
                foreach (IItem item in itemList)
                {
                    item.Update();
                    itemColDetector.Update();
                }
                foreach (ISprite sprite in bgList)
                {
                    sprite.Update();
                }
            }
            base.Update(gameTime);
        }
        

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            foreach (ISprite sprite in bgList)
            {
                sprite.Draw(spriteBatch);
            }
            foreach (IEnemy enemy in enemyList)
            {
                enemy.Draw(spriteBatch);
            }
            foreach (IBlock block in blockList)
            {
                block.Draw(spriteBatch);
            }
            foreach (IItem item in itemList)
            {
                item.Draw(spriteBatch);
            }

            if (fireBalls.Count != 0)
            {
                foreach (Fireball fBalls in fireBalls)
                {
                    fBalls.Draw(spriteBatch);
                }
            }
            mario.Draw(spriteBatch);

            base.Draw(gameTime);
        }

    }
}
