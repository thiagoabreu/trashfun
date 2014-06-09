using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace TrashFun
{
    public class Lixo : Collider
    {
        enum EstadoDoLixo
        {
            Solto,
            Seguro
        }

        /// <summary>
        /// Qual o estado atual do lixo
        /// </summary>
        EstadoDoLixo estado;

        /// <summary>
        /// Qual o tipo desse lixo
        /// </summary>
        /// <value>The tipo.</value>
        public TipoDeLixo tipo {
            get;
            private set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TrashFun.Lixo"/> class.
        /// </summary>
        /// <param name="textura">Textura.</param>
        /// <param name="posicao">Posicao.</param>
        /// <param name="tipo">Tipo.</param>
        public Lixo(Texture2D textura, Vector2 posicao, TipoDeLixo tipo) : base(textura, posicao)
        {
            this.estado = EstadoDoLixo.Solto;
            this.tipo = tipo;
        }


        /// <summary>
        /// Atualiza a posição do lixo de acordo com a posição do mouse.
        /// </summary>
        public void Update()
        {
            MouseState mouse = Mouse.GetState();

            switch(this.estado)
            {
            case EstadoDoLixo.Solto:
                if(mouse.LeftButton == ButtonState.Pressed && box.Contains(mouse.Position))
                {
                    estado = EstadoDoLixo.Seguro;
                    Sujeira.ativo = this;
                }
                break;
            case EstadoDoLixo.Seguro:
                box.X = mouse.X - (box.Width / 2);
                box.Y = mouse.Y - (box.Height / 2);

                if(mouse.LeftButton == ButtonState.Released)
                {
                    estado = EstadoDoLixo.Solto;
                    Sujeira.ativo = null;
                }

                break;
            default:
                break;
            }
        }
    }
}
