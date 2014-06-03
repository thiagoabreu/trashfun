using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrashFun
{
    enum Fase
        {
            Inicial, Partida, Final
        }

    static class EstadoDeJogo
    {
        public static int Pontuacao { get; set; }
        public static Fase FaseDeExecucao { get; set; }

        public static void ZeraJogo()
        {
            Pontuacao = 0;
            FaseDeExecucao = Fase.Inicial;
        }
    }
}
