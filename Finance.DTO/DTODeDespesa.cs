using Finance.Core.Base;
using Finance.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using Finance.Commom.Extensions;

namespace Finance.DTO
{
    public class DTODeDespesa: Dto
    {
        [Required]
        [MaxLength(100)]
        public string Descricao { get; set; }

        [Required]
        public Categroria Categoria { get; set; }

        [Required]
        public double Preco { get; set; }

        public string CategoriaDescricao => Enum.IsDefined(typeof(Categroria), (int)Categoria) ? Categoria.GetDescription() : string.Empty;
    }
}
