using Microsoft.Xna.Framework.Audio;
using static Game.Utility;

namespace Game
{
    public class SoundEffects
    {
        private Game myGame;
        private SoundEffect effect;
        private bool flag;

        public SoundEffects(Game game)
        {
            myGame = game;
            flag = false;
        }

        public void Break()
        {
            effect = myGame.Content.Load<SoundEffect>("SoundEffects/break");
            effect.Play();
        }

        public void Bump()
        {
            effect = myGame.Content.Load<SoundEffect>("SoundEffects/bump");
            effect.Play();
        }

        public void Coin()
        {
            effect = myGame.Content.Load<SoundEffect>("SoundEffects/coin");
            effect.Play();
        }
        
        public void PowerupAppears()
        {
            effect = myGame.Content.Load<SoundEffect>("SoundEffects/powerup-appears");
            effect.Play();
        }

        public void PowerUp()
        {
            effect = myGame.Content.Load<SoundEffect>("SoundEffects/powerup");
            effect.Play();
        }

        public void OneUp()
        {
            effect = myGame.Content.Load<SoundEffect>("SoundEffects/1-up");
            effect.Play();
        }
        
        public void Jump()
        {
            if (!myGame.marioState.marioPhys.falling)
            {
                effect = myGame.Content.Load<SoundEffect>("SoundEffects/jump-super");
                effect.Play();
            }
        }

        public void Stomp()
        {
            effect = myGame.Content.Load<SoundEffect>("SoundEffects/stomp");
            effect.Play();
        }

        public void Fireball()
        {
            effect = myGame.Content.Load<SoundEffect>("SoundEffects/fireball");
            effect.Play();
        }

        public void Pause()
        {
            myGame.sound.Pause();
            effect = myGame.Content.Load<SoundEffect>("SoundEffects/pause");
            effect.Play();
        }
        
        public void MarioDies()
        {
            myGame.sound.state = soundStates.stop;
            effect = myGame.Content.Load<SoundEffect>("SoundEffects/mariodies");
            effect.Play();
        }
        
        public void Flagpole()
        {
            if(!flag)
            {
                flag = true;
                effect = myGame.Content.Load<SoundEffect>("SoundEffects/flagpole");
                effect.Play();
                LevelComplete();
            }
        }

        private void LevelComplete()
        {
            myGame.sound.state = soundStates.stop;
            effect = myGame.Content.Load<SoundEffect>("SoundEffects/level-complete");
            effect.Play();
        }

        // call when Mario goes in the tunnel
        public void IntoTheTunnel()
        {
            myGame.sound.state = soundStates.stop;
            effect = myGame.Content.Load<SoundEffect>("SoundEffects/into-the-tunnel");
            effect.Play();
        }


    }
}
