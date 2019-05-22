using Finance.Core.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Finance.Domain.Models
{
    public class Despesa: Poco
    {
        [Required]
        [MaxLength(100)]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [Required] 
        [Column("CATEGORIA")]
        public int Categoria { get; set; }

        [Required]
        [Column("PRECO")]
        public double Preco { get; set; }
    }
}
