using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WS_AvaliacaoFinal.Models
{
    [Table("Produto")]
    public class ProdutoVO
    {
        [Key]
        public int IdProduto { get; set; }
        [Required]
        public string NomeProduto { get; set; }

        public string Categoria { get; set; }

        public int QuantidadeEstoque { get; set; }

        public double PrecoVenda { get; set; }
    }
}
