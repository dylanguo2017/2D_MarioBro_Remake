using Game.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;

namespace Game
{
    public class Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public ISprite star;
        public ISprite greenMushroom;
        public ISprite redMushroom;
        public ISprite coin;
        public ISprite fireFlower;

        public ISprite goomba;
        public ISprite koopa;

        public ISprite oneCloud;
        public ISprite threeClouds;
        public ISprite threeBushes;
        public ISprite smallMountain;
        public ISprite bigMountain;

        public ISprite diamondBlock;
        public ISprite brickBlock;
        public ISprite crackBlock;
        public ISprite pipe;
        public ISprite usedBlock;
        public ISprite invisibleBlock;
        public ISprite questionMarkBlock;

        public MarioStateClass marioState;

        public IMario mario;
        
        private ArrayList contrl;
        
        public Texture2D starItem;
        public Texture2D greenMushroomItem;
        public Texture2D redMushroomItem;
        public Texture2D coinItem;
        public Texture2D fireFlowerItem;

        public Texture2D oneCloudBgElement;
        public Texture2D threeCloudsBgElement;
        public Texture2D threeBushesBgElement;
        public Texture2D smallMountainBgElement;
        public Texture2D bigMountainBgElement;

        public Texture2D goombaEnemy;
        public Texture2D koopaEnemy;
        public Texture2D goombaEnemyDead;
        public Texture2D koopaEnemyDead;

        public Texture2D marioSprites;

        public Texture2D invisibleBlockSprite;
        public Texture2D usedBlockSprite;
        public Texture2D pipeSprite;
        public Texture2D crackBlockSprite;
        public Texture2D brickBlockSprite;
        public Texture2D diamondBlockSprite;
        public Texture2D questionMarkBlockSprite;

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
        
        public ArrayList list;
        private ICollisionDetector collisionDetector;

        public Game()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {   
            contrl = new ArrayList();
            
            collisionDetector = new MarioCollisionDetector(this);

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

            marioState = new MarioStateClass(false, false, false, false);

            animationModifier = 0;
            starDuration = 500;

            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            starItem = Content.Load<Texture2D>("StarItem");
            greenMushroomItem = Content.Load<Texture2D>("GreenMushroomItem");
            redMushroomItem = Content.Load<Texture2D>("RedMushroomItem");
            coinItem = Content.Load<Texture2D>("CoinItem");
            fireFlowerItem = Content.Load<Texture2D>("FireFlowerItem");

            oneCloudBgElement = Content.Load<Texture2D>("1CloudBgElement");
            threeCloudsBgElement = Content.Load<Texture2D>("3CloudsBgElement");
            threeBushesBgElement = Content.Load<Texture2D>("3BushesBgElement");
            smallMountainBgElement = Content.Load<Texture2D>("SmallMountainBgElement");
            bigMountainBgElement = Content.Load<Texture2D>("BigMountainBgElement");
        
            goombaEnemy = Content.Load<Texture2D>("GoombaEnemy");
            koopaEnemy = Content.Load<Texture2D>("KoopaEnemy");
            goombaEnemyDead = Content.Load<Texture2D>("GoombaEnemyDead");
            koopaEnemyDead = Content.Load<Texture2D>("KoopaEnemyDead");

            questionMarkBlockSprite = Content.Load<Texture2D>("QuestionMarkBlock");
            diamondBlockSprite = Content.Load<Texture2D>("DiamondBlock");
            brickBlockSprite = Content.Load<Texture2D>("BrickBlock");
            crackBlockSprite = Content.Load<Texture2D>("CrackBlock");
            pipeSprite = Content.Load<Texture2D>("Pipe");
            invisibleBlockSprite = Content.Load<Texture2D>("InvisibleBlock");
            usedBlockSprite = Content.Load<Texture2D>("UsedBlock");

            marioSprites = this.Content.Load<Texture2D>("BlockSpriteSheet/MarioSpriteSheet");

            mario = new SmallMario(marioState, marioSprites);

            list = Level.Load(this);
        }

        protected override void UnloadContent()
        {
            Content.Unload();
        }
        

        protected override void Update(GameTime gameTime)
        {
            collisionDetector.Update();
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


            if (animationModifier % 20 == 0)
            {
                foreach (ISprite sprite in list)
                {
                    sprite.Update();
                }
                
                mario.Update();
            }
            base.Update(gameTime);
        }
        

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            foreach (ISprite sprite in list)
            {
                sprite.Draw(spriteBatch);
            }

            mario.Draw(spriteBatch);
                        
            base.Draw(gameTime);
        }

    }
}
