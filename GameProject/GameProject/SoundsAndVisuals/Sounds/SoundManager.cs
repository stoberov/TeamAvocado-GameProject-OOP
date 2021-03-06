﻿namespace GameProject.SoundsAndVisuals.Sounds
{
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Media;

    public sealed class SoundManager
    {
        private static readonly SoundManager sm = new SoundManager();

        private SoundManager()
        {
            this.PlayerShootSound = null;
            this.ExplodeSound = null;
            this.BgMusic = null;
        }

        public static SoundManager Instance
        {
            get
            {
                return sm;
            }
        }

        public SoundEffect PlayerShootSound { get; set; }

        public SoundEffect ExplodeSound { get; set; }

        public Song BgMusic { get; set; }

        public void LoadContent(ContentManager Content)
        {
            this.PlayerShootSound = Content.Load<SoundEffect>("Laser");
            this.ExplodeSound = Content.Load<SoundEffect>("Blast");
            this.BgMusic = Content.Load<Song>("Theme");
        }
    }
}