using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WS_AvaliacaoFinal.Models;

namespace WS_AvaliacaoFinal.Controllers
{
    [ApiController] 
    [Route("products")]
    public class ProdutoWSController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ProdutoWSController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("create")]
        [Authorize(Roles = "Manager")]
        public ActionResult<dynamic> Create(ProdutoVO payload)
        {
            ProdutoDAL dal = new ProdutoDAL();

            dal.AddProduto(payload);

            return Ok();
        }

        [HttpPost]
        [Route("update")]
        [Authorize(Roles = "Manager")]
        public ActionResult<dynamic> Update(ProdutoVO payload)
        {
            ProdutoDAL dal = new ProdutoDAL();

            dal.UpdateProduto(payload);

            return Ok();
        }

        [HttpDelete]
        [Route("delete/{idProduto}")]
        [Authorize(Roles = "Manager")]
        public ActionResult<dynamic> Delete([FromRoute] int? idProduto)
        {
            ProdutoDAL dal = new ProdutoDAL();

            dal.DeleteProduto(idProduto);

            return Ok();
        }

        [HttpGet]
        [Route("{idProduto}")]
        [Authorize(Roles = "Manager,Normal")]
        public ActionResult<dynamic> GetProduto([FromRoute] int? idProduto)
        {
            ProdutoDAL dal = new ProdutoDAL();

            ProdutoVO produto = dal.GetProduto(idProduto);

            if (produto.IdProduto == 0 || produto.NomeProduto == null)
                return NotFound(new { message = "Produto não encontrado" });

            return produto;
        }

        [HttpGet]
        [Route("list")]
        [Authorize(Roles = "Manager,Normal")]
        public ActionResult<dynamic> GetProdutos()
        {
            ProdutoDAL dal = new ProdutoDAL();

            List<ProdutoVO> produtos = dal.GetProdutos();

            if (produtos.Count == 0)
                return NotFound(new { message = "Nenhum produto cadastrado" });

            return produtos;
        }
    }
}
