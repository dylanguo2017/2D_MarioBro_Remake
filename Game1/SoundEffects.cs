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

        public void OneUp()
        {
            effect = myGame.Content.Load<SoundEffect>("SoundEffects/1-up");
            effect.Play();
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

        public void PowerUp()
        {
            effect = myGame.Content.Load<SoundEffect>("SoundEffects/powerup");
            effect.Play();
        }

        public void Coin()
        {
            effect = myGame.Content.Load<SoundEffect>("SoundEffects/coin");
            effect.Play();
        }

        public void Jump()
        {
            effect = myGame.Content.Load<SoundEffect>("SoundEffects/jump");
            effect.Play();
        }

        public void MarioDies()
        {
            effect = myGame.Content.Load<SoundEffect>("SoundEffects/mariodies");
            effect.Play();
        }

        public void Fireball()
        {
            effect = myGame.Content.Load<SoundEffect>("SoundEffects/fireball");
            effect.Play();
        }
    }
}
