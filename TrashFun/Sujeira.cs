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

            int aleatorio = rand.Next();
            Lixo lixo;
            if(aleatorio % 2 == 0)
                lixo = new Lixo(TexturaLixo.Metal, new Vector2(largura, altura), TipoDeLixo.Metal);
            else
                lixo = new Lixo(TexturaLixo.Papel, new Vector2(largura, altura), TipoDeLixo.Papel);


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
            if(lastUpdate >= 5000)
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
        /// Verifica colisões com as lixeiras
        /// </summary>
        /// <returns><c>true</c>, se houve colisão, <c>false</c> caso contrario.</returns>
        /// <param name="lixeiros">Lixeiros.</param>
        /// <param name="mesmoTipo">Se é a lixeira correta.</param>
        public static bool VerificaColisoes(List<Lixeiro> lixeiros, out bool mesmoTipo) {
            foreach(var lixeiro in lixeiros)
            {
                if(ativo.IsCollidedWith(lixeiro))
                {
                    mesmoTipo = (ativo.tipo == lixeiro.tipo);
                    return true;
                }
            }
            mesmoTipo = false;
            return false;
        }

        /// <summary>
        /// Verifica colisções com outros lixos.
        /// </summary>
        /// <returns><c>true</c>, se houve colisão, <c>false</c> caso contrário.</returns>
        /// <param name="outro">Outro.</param>
        /// <param name="mesmoTipo">Mesmo tipo.</param>
        public static bool VerificaColisoes(out Lixo outro, out bool mesmoTipo) {
            foreach(var lixo in lixosNoChao)
            {
                if(ativo != lixo && ativo.IsCollidedWith(lixo))
                {
                    mesmoTipo = (ativo.tipo == lixo.tipo);
                    outro = lixo;
                    return true;
                }
            }
            mesmoTipo = false;
            outro = null;
            return false;
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

