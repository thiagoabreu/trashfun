using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace TrashFun
{
    public class Lixeiro : Collider
    {
        /// <summary>
        /// Tipo de lixo que o Lixeiro deve receber
        /// </summary>
        TipoDeLixo tipo;

        /// <summary>
        /// Initializes a new instance of the <see cref="TrashFun.Lixeiro"/> class.
        /// </summary>
        /// <param name="textura">Textura.</param>
        /// <param name="posicao">Posicao.</param>
        public Lixeiro(Vector2 posicao, TipoDeLixo tipo) : base(posicao)
        {
            this.TexturaPorTipo(tipo);
            this.tipo = tipo;
            this.box.Width = 80;
            this.box.Height = 115;
        }

        /// <summary>
        /// Carrega textura de acordo com o tipo
        /// </summary>
        /// <param name="tipo">Tipo.</param>
        void TexturaPorTipo(TipoDeLixo tipo) {
            switch(tipo)
            {
            case TipoDeLixo.Metal:
                this.textura = TexturaLixeiros.MetalBin;
                break;
            case TipoDeLixo.Papel:
                this.textura = TexturaLixeiros.PaperBin;
                break;
            case TipoDeLixo.Plastico:
                this.textura = TexturaLixeiros.PlasticBin;
                break;
            case TipoDeLixo.Vidro:
                this.textura = TexturaLixeiros.GlassBin;
                break;
            case TipoDeLixo.Organico:
            default:
                this.textura = TexturaLixeiros.NotRecycleBin;
                break;
            }
        }
    }
}

