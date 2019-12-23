using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TesteMeta2.Models;

namespace TesteMeta2.Core
{
    public class Engine
    {
        public Engine(Usuario u)
        {
            this.Usuario = u;
            this.Entidades = new Entidades();
        }

        #region Vetores
        public Tabela Tabela { get; set; }
        public Entidades Entidades { get; set; }
        public List<TipoDado> TiposDados { get; set; }
        public Usuario Usuario { get; set; }
        #endregion
        #region Prenchimento
        public Tabela PrepararTabela(int id)
        {

            this.TiposDados = PreencherTiposDados();
            this.Tabela = PreencherTabela(id);
            this.Tabela = PreencherColunas(Tabela);
            this.Tabela = PreencherRelacao(Tabela);
            this.Tabela = PreencherDependencia(Tabela);
            this.Tabela = PreeencherAcao(Tabela);
            return this.Tabela;
        }
        private List<TipoDado> PreencherTiposDados()
        {
            List<TipoDado> tiposdados = new List<TipoDado>();
            foreach (tb_tipodado t in Entidades.tb_tipodado)
            {
                TipoDado novo = new TipoDado();
                novo.Codigo = t.td_codigo;
                novo.Nome = t.td_nome;
                novo.NomeCS = t.td_nomecs;
                novo.NomeSql = t.td_nomesql;
                novo.Delimitador = t.td_delimitador;
                tiposdados.Add(novo);
            }
            return tiposdados;
        }
        public Tabela PreencherTabela(int id)
        {
            Tabela = new Tabela();
            tb_tabela t = Entidades.tb_tabela.First(e => e.tb_codigo.Equals(id));
            Tabela.Nome = t.tb_nome;
            Tabela.Titulo = t.tb_titulo;
            Tabela.Codigo = t.tb_codigo;
            Tabela.Selecionar = t.tb_selecionar;
            Tabela.NomeColunaCalculada = t.nm_coluna_calculada;
            return Tabela;
        }
        public Tabela PreencherColunas(Tabela t)
        {

            foreach (tb_coluna coluna in Entidades.tb_coluna.Where(e => e.tb_codigo == t.Codigo))
            {

                Coluna c = new Coluna();
                c.Nome = coluna.col_nome;
                c.Titulo = coluna.col_titulo;
                c.PodeVazio = coluna.col_podevazio;
                c.PrimaryKey = coluna.col_primarykey;
                c.Tamanho = coluna.col_tamanho;
                c.Visivel = coluna.col_visivel;
                c.FiltrarConsulta = coluna.col_filtrar_coluna;
                c.TipoDado = TiposDados.Where(ee => ee.Codigo == coluna.td_codigo).Single();
                c.FiltroNome = coluna.col_filtro_lista;
                c.FiltroRegistros = coluna.col_filtro_registros;
                c.Alteravel_Alteracao = coluna.col_alteravel_alteracao.Value;
                c.Alteravel_Inclusao = coluna.col_alteravel_inclusao.Value;
                c.Visivel_Inclusao = coluna.col_visivel_inclusao.Value;
                c.Visivel_Alteracao = coluna.col_visivel_alteracao.Value;
                c.Visivel_Detalhe = coluna.col_visivel_detalhe == null ? false : coluna.col_visivel_detalhe.Value;
                c.ValorPadrao = coluna.col_padrao;
                c.Ordenavel = coluna.dm_ordenavel.Value;
                c.Visivel_Tablet = coluna.col_visivel_tablet.Value;
                c.QuantidadeDiasAnterior = coluna.nr_qtd_dias_anterior.Value == 0 ? -1 : coluna.nr_qtd_dias_anterior.Value;
                c.QuantidadeDiasPosterior = coluna.nr_qtd_dias_frente.Value == 0 ? -1 : coluna.nr_qtd_dias_frente.Value;
                c.ColunaVirtual = coluna.dm_virtual.Value;
                c.PodeFoto = coluna.dm_pode_foto.Value;
                c.ColunaMimeType = coluna.midia_mime_type;
                c.Ordem = coluna.col_ordem == null ? 0 : coluna.col_ordem.Value;
                c.ObrigatorioImpressao = coluna.dm_obrigatorio_impressao.Value;
                c.Uppercase = coluna.dm_uppercase == null ? false : coluna.dm_uppercase.Value;
                c.cdMarcaDagua = coluna.cd_marca_dagua == null ? -1 : coluna.cd_marca_dagua.Value;
                c.MarcaDagua = coluna.col_marca_dagua == null ? false : coluna.col_marca_dagua.Value;
                c.SubPasta = coluna.col_subpasta ==null ? false : coluna.col_subpasta.Value;
                c.Diretorio = c.SubPasta ? coluna.col_diretorio : String.Empty;
                c.OrdemPadrao = coluna.col_ordenacao_padrao == null ? false : coluna.col_ordenacao_padrao.Value;
                c.OrdemCrescente = coluna.col_ordenacao_crescente == null ? false : coluna.col_ordenacao_crescente.Value;
                t.Colunas.Add(c);

            }
            return t;
        }
        public Tabela PreencherRelacao(Tabela t)
        {
            foreach (Coluna c in t.Colunas)
            {
                foreach (tb_relacao r in Entidades.tb_relacao.Where(ee => ee.col_nome.Equals(c.Nome) && ee.dm_situacao.Value))
                {
                    Relacao nova = new Relacao();
                    nova.Coluna = r.col_nome;
                    nova.Campo_Pai = r.pai_campo;
                    nova.Nome_Pai = r.pai_nome;
                    nova.Tabela_Pai = r.pai_tabela;
                    nova.auto_relacionamento = r.dm_auto_relacionamento.Value;
                    t.Relacoes.Add(nova);
                }
            }
            return t;
        }
        public Tabela PreencherDependencia(Tabela t)
        {
            foreach (Coluna c in t.Colunas)
            {
                foreach (tb_dependencia d in Entidades.tb_dependencia.Where(ee => ee.col_nome.Equals(c.Nome)))
                {
                    Dependencia nova = new Dependencia();
                    nova.Nome = d.dep_nome;
                    nova.Valor = d.dep_valor;
                    c.Dependencia.Add(nova);
                }
            }
            return t;
        }
        public Tabela PreeencherAcao(Tabela t)
        {
            var query = from acao in Entidades.tb_tabela_acao
                        where acao.dm_situacao
                        && acao.cd_tabela_acao_pai == null
                        && acao.tb_codigo == t.Codigo
                        select acao;
            List<tb_tabela_acao> acoesDestino = query.ToList();
            List<Acao> acoes = CarregarObjetoAcao(acoesDestino);
            t.Acoes.AddRange(acoes);
            return t;
        }
        public List<Acao> PreencherAcoesFilho(int codigo)
        {
            var query = from acao in Entidades.tb_tabela_acao
                        where acao.dm_situacao && acao.cd_tabela_acao_pai == codigo
                        select acao;

            List<Acao> acoes = new List<Acao>(); ;
            List<tb_tabela_acao> acoesOrigem = query.ToList();
            if (acoesOrigem.Count > 0)
            {
                acoes = CarregarObjetoAcao(acoesOrigem);
            }
            return acoes;
        }
        public List<Acao> CarregarObjetoAcao(List<tb_tabela_acao> acoesOrigem)
        {
            List<Acao> acoes = new List<Acao>();
            foreach (tb_tabela_acao acao in acoesOrigem)
            {
                Acao a = new Acao();
                a.Codigo = acao.cd_tabela_acao;
                a.Nome = acao.nm_acao;
                a.Titulo = acao.ds_acao;
                a.Habilitado = acao.dm_habilitado.Value;
                a.AcaoNoRegistro = acao.dm_registro;
                a.UrlImagem = acao.nm_imagem;
                a.Procedure = acao.nm_procedure;
                a.AcaoMultiploRegistro = acao.dm_registro_multiplo.Value;
                a.pos_condicao = acao.ds_pos_condicao == null ? "" : acao.ds_pos_condicao;
                a.pre_condicao = acao.ds_pre_condicao == null ? "" : acao.ds_pre_condicao;
                a.Acoes = PreencherAcoesFilho(a.Codigo);
                acoes.Add(a);
            }
            return acoes;
        }
        #endregion

        #region instruções dml
        public String ConstruirSqlInserirRegistro(Tabela tabela)
        {

            String sql = "insert into " + tabela.Nome + " (";
            String parametros = "";
            foreach (Coluna c in tabela.Colunas.Where(ee => !ee.PrimaryKey))
            {
                sql += c.Nome + ",";
                parametros += "'@" + c.Nome + "',";
                parametros = parametros.Replace("@" + c.Nome, c.Conteudo);
            }

            sql = sql.Substring(0, sql.Length - 1);
            parametros = parametros.Substring(0, parametros.Length - 1);
            sql += ") values ( " + parametros + ")";
            return sql;
        }
        public String ConstruirSqlAlterarRegistro(Tabela tabela)
        {

            String sql = "update " + tabela.Nome + " set ";

            foreach (Coluna c in tabela.Colunas)
            {
                sql += c.Nome + " = '@" + c.Nome + "',";
                sql = sql.Replace("@" + c.Nome, c.Conteudo);
            }
            sql = sql.Substring(0, sql.Length - 1);

            sql += " where ";
            foreach (Coluna c in tabela.Colunas.Where(ee => ee.PrimaryKey))
            {
                sql += c.Nome + " = '@" + c.Nome + "' and ";
                sql = sql.Replace("@" + c.Nome, c.Conteudo);
            }


            return sql;
        }
        public String ConstruirSqlExcluirRegistro(Tabela tabela)
        {

            String sql = "update " + tabela.Nome + " set dm_situacao = 0 where ";
            foreach (Coluna c in tabela.Colunas.Where(ee => ee.PrimaryKey))
            {
                sql += c.Nome + " = '@" + c.Nome + "' and ";
                sql = sql.Replace("@" + c.Nome, c.Conteudo);
            }

            sql = sql.Substring(0, sql.Length - 4);
            return sql;
        }
        public String ConstruirSqlConsultarRegistros(Tabela tabela)
        {
            String sql = "select ";
            String joins = "";

            foreach (Coluna c in tabela.Colunas.Where(ee => ee.Visivel || ee.PrimaryKey).OrderBy(ee=>ee.Ordem))
            {

                if (tabela.Relacoes.Where(ee => ee.Tabela_Pai != tabela.Nome && ee.Coluna.Equals(c.Nome)).Count() == 0)
                {
                    sql +=tabela.Nome + "."+c.Nome + ", ";
                } else
                {
                    Relacao r = tabela.Relacoes.Where(ee => ee.Tabela_Pai != tabela.Nome && ee.Coluna.Equals(c.Nome)).Single();
                    joins += " inner join " + r.Tabela_Pai +
                        " on " + r.Tabela_Pai + "." + r.Campo_Pai + " = " + tabela.Nome + "." + r.Coluna;
                    sql += r.Tabela_Pai + "." + r.Nome_Pai + " as " + c.Nome + ", ";
                }
            }

            sql = sql.Substring(0, sql.Length - 2);
            sql += " from " + tabela.Nome + joins;

            if (tabela.Colunas.Count(ee => ee.Equals("dm_situacao")) > 0)
            {
                sql += " where dm_situacao = 1";
            }
           
            return sql;
        }
        public String AdicionarFiltroConsultarRegistro( Tabela tabela, String sql, String filtro, String conteudo)
        {
            String novoSql = string.Empty;
            //Coluna coluna = tabela.Colunas.Where(ee => ee.Nome.Equals(filtro)).First();
            List<Coluna> pesquisar = tabela.Colunas.Where(ee => ee.FiltrarConsulta).ToList();
            String whereor = " where ";

            foreach(Coluna c in pesquisar)
            {
               // novoSql = whereand + c.Nome + " like '%" + conteudo + "%'";
               
                if (c.TipoDado.Nome.Equals("Numero"))
                {
                    novoSql += whereor + c.Nome + " = " + conteudo ;
                }
                else
                {
                    novoSql += whereor + c.Nome + " like '%" + conteudo + "%'";
                }
                whereor = " or ";
            }
          
            return novoSql;
        }
        public String AdicionarOrdenarConsultarRegistro(Tabela tabela, String sql, String ordem)
        {
            string novoSql;
            novoSql = " order by " + ordem;
            return novoSql;
        }
        public void InserirRegistro(Tabela tabela)
        {
            String sql = ConstruirSqlInserirRegistro(tabela);
            // TODO: Implementar Insert aqui...

        }
        public void AlterarRegistro(Tabela tabela)
        {
            String sql = ConstruirSqlAlterarRegistro(tabela);
            // TODO: Implementar Update Aqui
        }
        public List<Registro> ConsultarRegistros(DadosController dc)
        {
            String sql = ConstruirSqlConsultarRegistros(dc.Tabela);
            if (dc.Filtro!=null)
            {
                sql += AdicionarFiltroConsultarRegistro(dc.Tabela, sql, dc.Filtro.Filtrar, dc.Filtro.Conteudo);
            }
            if (!String.IsNullOrEmpty(dc.Ordenacao))
            {
                sql += AdicionarOrdenarConsultarRegistro(dc.Tabela, sql, dc.Ordenacao);
            } else
            {
                sql += AdicionarOrdemPadrao(dc.Tabela);
            }
            return RecuperarRegistros(dc.Tabela, sql);
        }
        public String AdicionarOrdemPadrao(Tabela tabela)
        {
            String sql = String.Empty;

            String ordercomma = " order by ";
            foreach (Coluna c in tabela.Colunas.Where(ee => ee.OrdemPadrao))
            {
                sql += ordercomma + c.Nome + (c.OrdemCrescente ? " asc " : " desc ") + " ";
                ordercomma = ", ";
            }
            return sql;
        }
        public List<Registro> ConsultarRegistros(Tabela tabela, int pagina)
        {
            String sql = ConstruirSqlConsultarRegistros(Tabela);
            return RecuperarRegistros(tabela, sql); 
        }
        public List<Registro> RecuperarRegistros(Tabela tabela, String sql)
        {
            List<Registro> registros = new List<Registro>();
            SqlConnection conexao = new SqlConnection(Entidades.Database.Connection.ConnectionString);
            conexao.Open();
            SqlCommand comando = new SqlCommand(sql, conexao);

            using (SqlDataReader reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    Registro r = new Registro();
                    foreach (Coluna c in tabela.Colunas.Where(ee => ee.Visivel || ee.PrimaryKey).OrderBy(ee => ee.Ordem))
                    {

                        if (c.PrimaryKey)
                        {
                            r.codigo = (int)reader[c.Nome];
                        }
                        if (c.TipoDado.Nome.Equals("Logico"))
                        {
                            bool valor = false;
                            try
                            {
                                valor = (bool)reader[c.Nome];
                                r.Dados.Add(valor ? "Sim" : "Não");
                            } catch (Exception e)
                            {
                                bool erro = valor;

                            }
                            
                            
                        }
                        else
                        {
                            r.Dados.Add((string)reader[c.Nome].ToString());
                        }
                    }
                    registros.Add(r);
                }
            }
            return registros;
        }
        #endregion

    }
}