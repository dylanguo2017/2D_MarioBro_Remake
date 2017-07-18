using Microsoft.Xna.Framework.Audio;
using static Game.Game;

namespace Game
{
    public class Sounds
    {
        private Game myGame;

        public soundStates state;

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
            state = soundStates.mainTheme;
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
            if (state.Equals(soundStates.mainTheme))
            {
                state = soundStates.starman;
            }
        }

        public void Update()
        {
            if (state.Equals(soundStates.mainTheme))
            {
                starman.Stop();
                mainTheme.Resume();
            }
            else if (state.Equals(soundStates.starman))
            {
                mainTheme.Pause();
                starman.Play();
            }
            else if (state.Equals(soundStates.hurry))
            {
                mainTheme.Stop();
                starman.Stop();
                hurry.Play();
            }
            else if (state.Equals(soundStates.gameOver))
            {
                mainTheme.Stop();
                starman.Stop();
                hurry.Stop();
                gameOver.Play();
            }
            else if(state.Equals(soundStates.stop))
            {
                Stop();
            }
            else
            {
                Stop();
                mainTheme.Play();
                state = soundStates.mainTheme;
            }
        }
        
        private void Stop()
        {
            mainTheme.Stop();
            starman.Stop();
            hurry.Stop();
            gameOver.Stop();
        }

        public void Pause()
        {
            mainTheme.Pause();
            starman.Pause();
            hurry.Pause();
            gameOver.Pause();
        }
        


    }
}
