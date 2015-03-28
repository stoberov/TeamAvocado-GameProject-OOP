﻿namespace GameProject
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    public class Asteroid
    {
        public Rectangle boundingBox;
        public Texture2D texture;
        public Vector2 position;
        public Vector2 origin;
        public float rotationAngle;
        public int speed;

        public bool isVisible;
        Random random = new Random();
        public float randX, randY;

        // Constructor
        public Asteroid(Texture2D newTexture, Vector2 newPosition)
        {
            this.position = newPosition;
            this.texture = newTexture;
            this.speed = 4;

            this.isVisible = true;
            this.randX = this.random.Next(0, 750);
            this.randY = this.random.Next(-600, -50);

        }

        // Load Content
        public void LoadContent(ContentManager content)
        {
            this.texture = content.Load<Texture2D>("asteroid");
            this.origin.X = this.texture.Width / 2;
            this.origin.Y = this.texture.Height / 2;
        }

        // Update
        public void Update(GameTime gameTime)
        {
            // Set bounding box for collision
            this.boundingBox = new Rectangle((int)this.position.X, (int)this.position.Y, 45, 45);

            // update movement
            this.position.Y = this.position.Y + speed;
            if (this.position.Y >= 950)
            {
                this.position.Y = -50;
            }

            // Rotate asteriod
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            this.rotationAngle += elapsed;
            float circle = MathHelper.Pi * 2;
            this.rotationAngle = this.rotationAngle % circle;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!this.isVisible)
            {
                spriteBatch.Draw(this.texture, this.position, null, Color.White, this.rotationAngle, this.origin, 1.0f, SpriteEffects.None, 0f);
            }
        }
    }
}
