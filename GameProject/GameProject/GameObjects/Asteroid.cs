﻿namespace GameProject.GameObjects
{
    using System;
    using GameProject.Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class Asteroid : MovingObject, IMovableObject, ICollidable, IDestructable, IProjectile, IRenderable
    {
        public const int AsteroidPoints = 5;

        private const int AsteroidSpeed = 4;
        private const int AsteroidDamage = 20;
        private int damage;

        // Constructor
        public Asteroid(Texture2D newTexture, Vector2 newPosition) : base(newTexture, newPosition, AsteroidSpeed)
        {
            this.Damage = AsteroidDamage;
            this.IsVisible = true;
        }

        public bool IsVisible { get; set; }

        public int Damage
        {
            get
            {
                return this.damage;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Damage can not be set to negative.");
                }

                this.damage = value;
            }
        }

        public Rectangle BoundingBox { get; set; }

        // Update
        public void Update(GameTime gameTime)
        {
            // Set bounding box for collision
            this.BoundingBox = new Rectangle((int)this.position.X, (int)this.position.Y, this.Texture.Width, this.Texture.Height);

            // update movement
            this.position.Y = this.position.Y + this.Speed;
            if (this.position.Y >= GameEngine.ScreenHeight)
            {
                this.position.Y = -50;
            }
        }

        public void DestroyObject()
        {
            this.IsVisible = false;
        }

        // Draw
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (this.IsVisible)
            {
                spriteBatch.Draw(this.Texture, this.Position, Color.White);
            }
        }
    }
}