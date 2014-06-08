using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TrashFun
{
    public class Collider
    {
        /// <summary>
        /// Guarda a textura do objeto
        /// </summary>
        protected Texture2D textura;

        /// <summary>
        /// Box utilizado para detecção de colisão
        /// </summary>
        protected Rectangle box;

        /// <summary>
        /// Initializes a new instance of the <see cref="TrashFun.Collider"/> class.
        /// </summary>
        /// <param name="text">Text.</param>
        /// <param name="posicao">Posicao.</param>
        public Collider(Texture2D text, Vector2 posicao)
        {
            this.textura = text;

            this.box = new Rectangle();
            this.box.X = (int)posicao.X;
            this.box.Y = (int)posicao.Y;
            this.box.Width = this.textura.Width;
            this.box.Height = this.textura.Height;
        }

        /// <summary>
        /// Determines whether this instance is collided with the specified other.
        /// </summary>
        /// <returns><c>true</c> if this instance is collided with the specified other; otherwise, <c>false</c>.</returns>
        /// <param name="other">Other.</param>
        public bool IsCollidedWith(Collider other)
        {
            return box.Intersects(other.box);
        }

        /// <summary>
        /// Método básico para desenhar o objeto
        /// </summary>
        /// <param name="spriteBatch">Batch de video.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textura, box, Color.White);
        }

    }
}

