using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteMeta2.Core
{
    public class Relacao
    {
        public string Coluna { get; set; }
        public string Tabela_Pai { get; set; }
        public string Campo_Pai { get; set; }
        public string Nome_Pai { get; set; }
        public bool auto_relacionamento { get; set; }
        public string Imagem_Nome { get; set; }
        public string FiltroBase { get; set; }

        public Relacao(string coluna, string tabela_pai, string campo_pai, string nome_pai, bool auto_relacionamento, List<string> nomeTabelasMostaraPai, string filtrobase)
        {
            this.Tabela_Pai = tabela_pai;
            this.Campo_Pai = campo_pai;
            this.Coluna = coluna;
            this.Nome_Pai = nome_pai;
            this.auto_relacionamento = auto_relacionamento;
            this.FiltroBase = filtrobase;
        }

        public Relacao()
        {
            
        }

    }
}