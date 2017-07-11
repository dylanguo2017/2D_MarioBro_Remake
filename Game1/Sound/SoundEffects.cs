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

        // call when item pops out of question mark block
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

        // call when Mario jumps
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
            myGame.sound.state = Game.sounds.none;
            effect = myGame.Content.Load<SoundEffect>("SoundEffects/mariodies");
            effect.Play();
        }
        
        // call when flag comes down
        public void Flagpole()
        {
            effect = myGame.Content.Load<SoundEffect>("SoundEffects/flagpole");
            effect.Play();
        }

        // call when level complete
        public void LevelComplete()
        {
            myGame.sound.state = Game.sounds.none;
            effect = myGame.Content.Load<SoundEffect>("SoundEffects/into-the-tunnel");
            effect.Play();
        }

        // call when Mario goes in the tunnel
        public void IntoTheTunnel()
        {
            myGame.sound.state = Game.sounds.none;
            effect = myGame.Content.Load<SoundEffect>("SoundEffects/level-complete");
            effect.Play();
        }


    }
}
