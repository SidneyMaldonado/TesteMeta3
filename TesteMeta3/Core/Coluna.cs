using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteMeta2.Core
{
    public class Coluna
    {

        public string Nome { get; set; }
        public string Titulo { get; set; }
        public int Tamanho { get; set; }
        public bool PodeVazio { get; set; }
        public string Conteudo { get; set; }
        public bool PrimaryKey { get; set; }
        public TipoDado TipoDado { get; set; }
        public List<Dependencia> Dependencia { get; set; }
        public bool Visivel { get; set; }
        public bool FiltrarConsulta { get; set; }
        public Tabela Tabela { get; set; }
        public string FiltroNome { get; set; }
        public string FiltroRegistros { get; set; }
        public bool Alteravel_Inclusao { get; set; }
        public bool Alteravel_Alteracao { get; set; }
        public bool Visivel_Inclusao { get; set; }
        public bool Visivel_Alteracao { get; set; }
        public string ValorPadrao { get; set; }
        public bool Visivel_Tablet { get; set; }
        public bool Ordenavel { get; set; }
        public int QuantidadeDiasAnterior { get; set; }
        public int QuantidadeDiasPosterior { get; set; }
        public bool ColunaVirtual { get; set; }
        public bool PodeFoto { get; set; }
        public string ColunaMimeType { get; set; }
        public int Ordem { get; set; }
        public bool ObrigatorioImpressao { get; set; }
        public bool Uppercase { get; set; }
        public bool Visivel_Detalhe { get; set; }
        public bool MarcaDagua { get; set; }
        public int cdMarcaDagua { get; set; }
        public bool SubPasta { get; set; }
        public string Diretorio { get; set; }
        public bool OrdemPadrao { get; set; }
        public bool OrdemCrescente { get; set; }

        public Coluna(string nome, string titulo, int tamanho, bool podevazio, bool primarykey, TipoDado tipodado)
        {
            this.Nome = nome;
            this.Titulo = titulo;
            this.Tamanho = tamanho;
            this.PodeVazio = podevazio;
            this.PrimaryKey = primarykey;
            this.TipoDado = tipodado;
            this.Visivel = true;
            this.FiltrarConsulta = false;
            this.Alteravel_Inclusao = false;
            this.Alteravel_Alteracao = false;
            this.Visivel_Inclusao = true;
            this.ValorPadrao = "";
            this.Visivel_Tablet = true;
            this.Dependencia = new List<Dependencia>();
            this.PodeFoto = true;
            this.ObrigatorioImpressao = true;
        }
        public Coluna(string nome, string titulo, int tamanho, bool podevazio, bool primarykey, TipoDado tipodado, bool visivel, bool filtrarconsulta, bool ordenavel)
            : this(nome, titulo, tamanho, podevazio, primarykey, tipodado)
        {
            this.Visivel = visivel;
            this.FiltrarConsulta = filtrarconsulta;
            this.Ordenavel = ordenavel;
        }
        public Coluna(string nome, string titulo, int tamanho, bool podevazio, bool primarykey, TipoDado tipodado, List<Dependencia> dependencia, bool filtrarconsulta, bool ordenavel)
            : this(nome, titulo, tamanho, podevazio, primarykey, tipodado)
        {
            this.Dependencia = dependencia;
            this.FiltrarConsulta = filtrarconsulta;
            this.Ordenavel = ordenavel;
        }
        public Coluna(string nome, string titulo, int tamanho, bool podevazio, bool primarykey, TipoDado tipodado, List<Dependencia> dependencia, bool visivel, bool filtrarConsulta, bool ordenavel)
            : this(nome, titulo, tamanho, podevazio, primarykey, tipodado, visivel, filtrarConsulta, ordenavel)
        {
            this.Dependencia = dependencia;
        }
        public Coluna()
        {
            Dependencia = new List<Dependencia>();
        }

    }
}