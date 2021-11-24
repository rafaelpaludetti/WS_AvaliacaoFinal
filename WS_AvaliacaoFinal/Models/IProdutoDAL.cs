using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WS_AvaliacaoFinal.Models
{
    interface IProdutoDAL
    {
        List<ProdutoVO> GetProdutos();
        void AddProduto(ProdutoVO produto);
        void UpdateProduto(ProdutoVO produto);
        ProdutoVO GetProduto(int? idProduto);
        void DeleteProduto(int? idProduto);
    }
}
