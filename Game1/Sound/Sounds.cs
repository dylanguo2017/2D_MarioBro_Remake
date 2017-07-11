using Microsoft.Xna.Framework.Audio;
using static Game.Game;

namespace Game
{
    public class Sounds
    {
        private Game myGame;

        public sounds state { private get; set; }

        private SoundEffectInstance mainTheme;
        private SoundEffectInstance starman;
        private SoundEffectInstance hurry;
        private SoundEffectInstance gameOver;

        public Sounds(Game game)
        {
            myGame = game;
            Load();
            Loop();
            mainTheme.Play();
            state = Game.sounds.mainTheme;
        }

        private void Load()
        {
            mainTheme = myGame.Content.Load<SoundEffect>("Sounds/main-theme-overworld").CreateInstance();
            starman = myGame.Content.Load<SoundEffect>("Sounds/starman").CreateInstance();
            hurry = myGame.Content.Load<SoundEffect>("Sounds/hurry").CreateInstance();
            gameOver = myGame.Content.Load<SoundEffect>("Sounds/game-over").CreateInstance();
        }

        private void Loop()
        {
            mainTheme.IsLooped = true;
            starman.IsLooped = true;
            hurry.IsLooped = true;
            gameOver.IsLooped = true;
        }

        public void Starman()
        {
            if (state.Equals(Game.sounds.mainTheme))
            {
                state = Game.sounds.starman;
            }
        }

        public void Update()
        {
            if (state.Equals(Game.sounds.mainTheme))
            {
                starman.Stop();
                mainTheme.Resume();
            }
            else if (state.Equals(Game.sounds.starman))
            {
                mainTheme.Pause();
                starman.Play();
            }
            else if (state.Equals(Game.sounds.hurry))
            {
                mainTheme.Stop();
                starman.Stop();
                hurry.Play();
            }
            else if (state.Equals(Game.sounds.gameOver))
            {
                Stop();
                gameOver.Play();
            }
            else
            {
                Stop();
            }
        }
        
        private void Stop()
        {
            mainTheme.Stop();
            starman.Stop();
            hurry.Stop();
        }

        public void Reset()
        {
            state = Game.sounds.mainTheme;
            mainTheme.Stop();
            mainTheme.Play();
            hurry.Stop();
            gameOver.Stop();
        }

    }
}
