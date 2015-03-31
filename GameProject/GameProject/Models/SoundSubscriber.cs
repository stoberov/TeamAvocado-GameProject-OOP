﻿namespace GameProject.Models
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Content;

    public class SoundSubscriber
    {
        public void Subscribe(SoundPublisher publisher)
        {
            publisher.Tick += new SoundPublisher.EventHandler(TakeAction);
        }

        private void TakeAction(SoundPublisher publisher, EventArgs e)
        {
            publisher.SoundEffect.Play();
        }
    }
}