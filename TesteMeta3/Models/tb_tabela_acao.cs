//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TesteMeta2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_tabela_acao
    {
        public int cd_tabela_acao { get; set; }
        public int tb_codigo { get; set; }
        public string nm_acao { get; set; }
        public string ds_acao { get; set; }
        public bool dm_situacao { get; set; }
        public bool dm_registro { get; set; }
        public Nullable<int> cd_tabela_acao_pai { get; set; }
        public Nullable<bool> dm_habilitado { get; set; }
        public string nm_imagem { get; set; }
        public string nm_procedure { get; set; }
        public Nullable<int> cd_usuario_inc { get; set; }
        public Nullable<System.DateTime> dt_inclusao { get; set; }
        public Nullable<bool> dm_registro_multiplo { get; set; }
        public string ds_pre_condicao { get; set; }
        public string ds_pos_condicao { get; set; }
    }
}
