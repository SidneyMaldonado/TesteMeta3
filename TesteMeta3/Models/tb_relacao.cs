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
    
    public partial class tb_relacao
    {
        public int rel_codigo { get; set; }
        public string col_nome { get; set; }
        public string pai_tabela { get; set; }
        public string pai_campo { get; set; }
        public string pai_nome { get; set; }
        public Nullable<bool> dm_situacao { get; set; }
        public Nullable<bool> dm_auto_relacionamento { get; set; }
        public string nm_tabelas { get; set; }
        public Nullable<int> cd_usuario_inc { get; set; }
        public Nullable<System.DateTime> dt_inclusao { get; set; }
        public string imagem_nome { get; set; }
        public string rel_filtro { get; set; }
    }
}