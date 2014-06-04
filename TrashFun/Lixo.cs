using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrashFun
{
    class Lixo
    {
        /// <summary>
        /// Guarda a textura do lixo
        /// </summary>
        Texture2D textura;

        /// <summary>
        /// Caixa de detecção de colisão. Também utilizada para desenhar
        /// </summary>
        Rectangle box;

        enum EstadoDoLixo
        {
            Solto, Seguro
        }

        EstadoDoLixo estado;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="textura">Define qual a aparencia do lixo</param>
        /// <param name="posicao">Posição inicial do lixo. Deve manter o lixo sempre na tela</param>
        public Lixo(Texture2D textura, Vector2 posicao)
        {
            this.textura = textura;

            this.box = new Rectangle((int)posicao.X, (int)posicao.Y, textura.Width, textura.Height);

            estado = EstadoDoLixo.Solto;
        }

        /// <summary>
        /// Atualiza a posição do lixo de acordo com a posição do mouse.
        /// </summary>
        public void Update()
        {
            MouseState mouse = Mouse.GetState();

            if (estado == EstadoDoLixo.Solto)
            {
                if (mouse.LeftButton == ButtonState.Pressed && box.Contains(mouse.Position))
                    estado = EstadoDoLixo.Seguro;
            }
            else
            {
                box.X = mouse.X - (box.Width / 2);
                box.Y = mouse.Y - (box.Height / 2);

                if (mouse.LeftButton == ButtonState.Released)
                    estado = EstadoDoLixo.Solto;
            }
        }

        /// <summary>
        /// Método básico para desenhar a textura do lixo
        /// </summary>
        /// <param name="spriteBatch">Buffer de vídeo</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(textura, box, Color.Yellow);
        }
    }
}
