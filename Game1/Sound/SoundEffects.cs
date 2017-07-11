using Microsoft.Xna.Framework.Audio;

namespace Game
{
    public class SoundEffects
    {
        private Game myGame;
        private SoundEffect effect;

        public SoundEffects(Game game)
        {
            myGame = game;
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
            effect = myGame.Content.Load<SoundEffect>("SoundEffects/jump");
            effect.Play();
        }

        public void Fireball()
        {
            effect = myGame.Content.Load<SoundEffect>("SoundEffects/fireball");
            effect.Play();
        }

        public void MarioDies()
        {
            myGame.sound.Stop();
            effect = myGame.Content.Load<SoundEffect>("SoundEffects/mariodies");
            effect.Play();
        }

        public void LevelComplete()
        {
            myGame.sound.Stop();
            effect = myGame.Content.Load<SoundEffect>("SoundEffects/into-the-tunnel");
            effect.Play();
        }

        public void IntoTheTunnel()
        {
            myGame.sound.Stop();
            effect = myGame.Content.Load<SoundEffect>("SoundEffects/level-complete");
            effect.Play();
        }


    }
}
