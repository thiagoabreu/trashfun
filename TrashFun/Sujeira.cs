using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TrashFun
{
    public class Sujeira
    {
        /// <summary>
        /// Lixo que está sendo carregado no momento
        /// </summary>
        public static Lixo ativo;

        /// <summary>
        /// Todos os lixos dispostos no chao
        /// </summary>
        public static List<Lixo> lixosNoChao;

        /// <summary>
        /// Gerador de numero aleatorio
        /// </summary>
        private static Random rand;

        /// <summary>
        /// Inicializa essa instancia
        /// </summary>
        public static void Limpa() {
            lixosNoChao = new List<Lixo>();
            rand = new Random();
        }


        /// <summary>
        /// Joga um lixo no chão
        /// </summary>
        public static void CriaLixo() {
            int altura = rand.Next(300, 500);
            int largura = rand.Next(50, 700);

            Lixo lixo = new Lixo(TexturaLixeiros.box, new Vector2(largura, altura), TipoDeLixo.Metal);

            bool ok = true;
            foreach(Lixo item in lixosNoChao)
            {
                if(lixo.IsCollidedWith(item))
                {
                    ok = false;
                    break;
                }
            }

            if(ok)
                lixosNoChao.Add(lixo);
            else
                CriaLixo();
        }

        /// <summary>
        /// Tempo(ms) desde a ultima atualização
        /// </summary>
        static int lastUpdate;

        /// <summary>
        /// Joga, periodicamente, lixo no chão
        /// </summary>
        /// <param name="gameTime">Game time.</param>
        public static void CriaLixo(GameTime gameTime) {
            lastUpdate += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if(lastUpdate >= 10000)
            {
                lastUpdate = 0;
                for(int i = 0; i < 5; i++)
                {
                    CriaLixo();
                }
            }
        }

        /// <summary>
        /// Atualiza a posição dos lixos, se necessario
        /// </summary>
        public static void Update() {
            foreach(var lixo in lixosNoChao)
                            lixo.Update();
        }

        /// <summary>
        /// Desenha os lixos jogados no chão
        /// </summary>
        /// <param name="spriteBatch">Sprite batch.</param>
        public static void DrawLixoNoChao(SpriteBatch spriteBatch) {
            foreach(var lixo in lixosNoChao)
            {
                lixo.Draw(spriteBatch);
            }
        }
    }
}

