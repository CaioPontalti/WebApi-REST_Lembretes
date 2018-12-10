namespace Api_Lembretes.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tb_Lembrete
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Autor { get; set; }

        [Required]
        [StringLength(1000)]
        public string Conteudo { get; set; }

        [Required]
        [StringLength(10)]
        public string Prioridade { get; set; }

        public int Modificado { get; set; }
    }
}
