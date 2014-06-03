﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace TrashFun
{
    public class Background
    {

        /// <summary>
        /// Textura para o céu
        /// </summary>
        Texture2D animado;
        /// <summary>
        /// Posições para o céu (será atualizado)
        /// </summary>
        Vector2[] posicoesAnimado;
        /// <summary>
        /// Largura da textura do Céu
        /// </summary>
        int larguraAnimado;
        /// <summary>
        /// Altura da Textura do Céu
        /// </summary>
        int alturaAnimado;
        /// <summary>
        /// Velocidade da animação do Céu
        /// </summary>
        int velocidade;

        /// <summary>
        /// Textura do Muro ou Outro Bg fixo
        /// </summary>
        Texture2D fixo;
        /// <summary>
        /// Posição do bg fixo.
        /// Deve deixar espaço para o céu.
        /// </summary>
        Vector2 posicaoFixo;

        /// <summary>
        /// Guarda o clock da última atualização.
        /// </summary>
        TimeSpan tempoAnterior;

        /// <summary>
        /// Construtor. Deve ser chamado para carregar o conteúdo.
        /// </summary>
        /// <param name="content">Gerenciador de Conteúdo</param>
        /// <param name="larguraTela">Utilizado para repetir o bg por toda tela</param>
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

        /// <summary>
        /// Atualiza posição da animação
        /// </summary>
        /// <param name="gameTime">Determina o tempo do jogo</param>
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

        /// <summary>
        /// Desenha os backgrounds.
        /// Primeiro o céu (animado) e depois a paisagem (fixa)
        /// </summary>
        /// <param name="spriteBatch">Buffer de vídeo</param>
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

