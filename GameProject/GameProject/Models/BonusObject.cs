﻿namespace GameProject.Models
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using GameProject.Interfaces;

    public abstract class BonusObject : MovingObject, IMovableObject, ICollidable, IDestructable, IRenderable
    {
        public BonusObject(Texture2D texture, Vector2 position, int speed)
            : base(texture, position, speed)
        {
            this.IsVisible = true;
        }

        public Rectangle BoundingBox { get; set; }

        public bool IsVisible { get; set; }

        public void DestroyObject()
        {
            this.IsVisible = false;
        }

        public abstract void DistributeBonusEffect(Player p);

        // Update
        public void Update(GameTime gameTime)
        {
            // Set bounding box for collision
            this.BoundingBox = new Rectangle((int)this.position.X, (int)this.position.Y, this.Texture.Width, this.Texture.Height);

            // update movement
            this.position.X = this.position.X + this.Speed;
            if (this.position.X >= Game1.ScreenWidth)
            {
                this.DestroyObject();// So they don't come so often as asteroids - correction if necessary;
            }
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