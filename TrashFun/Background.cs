using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace TrashFun
{
    public class Background
    {


        // Textura para o Céu (animado)
        Texture2D animado;
        // Posições para o Céu (será atualizado)
        Vector2[] posicoesAnimado;
        // Largura da Textura do Céu
        int larguraAnimado;
        // Altura da Textura do Céu
        int alturaAnimado;
        // Velocidade da animação do Céu
        int velocidade;

        // Textura do Muro ou Outro Bg fixo
        Texture2D fixo;
        Vector2 posicaoFixo;

        TimeSpan tempoAnterior;

        public Background(ContentManager content, int larguraTela)
        {
            // TODO: Achar uma velocidade legal pro Céu
            velocidade = 2;
            tempoAnterior = new TimeSpan(0);

            // TODO: Textura do Céu
//            animado = content.Load("ceu");
//            larguraAnimado = animado.Width;
//            alturaAnimado = animado.Height;
//
//            int numero_quadros = (larguraTela > larguraAnimado) ? larguraTela / larguraAnimado + 1 : 2;
//            posicoesAnimado = new Vector2[numero_quadros];
//
//            // Inicio o Céu
//            int altitudeAnimado = 0;
//
//            for(int i = 0; i < posicoesAnimado.Length; i++)
//                posicoesAnimado[i] = new Vector2(i * larguraAnimado, altitudeAnimado);

            // TODO: Textura Paisagem
//            fixo = content.Load("muro");
//            int altitudeFixo = 20;
//            posicaoFixo = new Vector2(0, altitudeFixo);

        }

        public void Update(GameTime gameTime)
        {
            TimeSpan tempoDecorrido = gameTime.ElapsedGameTime;

            if(tempoDecorrido.TotalSeconds - tempoAnterior.TotalSeconds > 2)
            {
                tempoAnterior = tempoDecorrido;

                for (int i = 0; i < posicoesAnimado.Length; i++)
                {
                    posicoesAnimado[i].X -= velocidade;

                    if(posicoesAnimado[i].X < -larguraAnimado)
                        posicoesAnimado[i].X = larguraAnimado * (posicoesAnimado.Length - 1);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            foreach(var posicao in posicoesAnimado)
            {
                Rectangle quadro = new Rectangle((int)posicao.X, (int)posicao.Y, larguraAnimado, alturaAnimado);
                spriteBatch.Draw(animado, quadro, Color.White);
            }
            spriteBatch.Draw(fixo, posicaoFixo, Color.White);
            spriteBatch.End();
        }
    }
}

