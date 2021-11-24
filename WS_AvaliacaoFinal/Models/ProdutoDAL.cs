using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WS_AvaliacaoFinal.Models
{
    public class ProdutoDAL : IProdutoDAL
    {
        string connectionString = @"Data Source=.;Initial Catalog=DB_AvaliacaoFinalDS;Integrated Security=True;";
        public void AddProduto(ProdutoVO produto)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = "INSERT INTO Produto (nomeProduto,categoria,quantidadeEstoque,precoVenda) VALUES (@NomeProduto, @Categoria, @Quantidade, @Preco)";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@NomeProduto", produto.NomeProduto);
                cmd.Parameters.AddWithValue("@Categoria", produto.Categoria);
                cmd.Parameters.AddWithValue("@Quantidade", produto.QuantidadeEstoque);
                cmd.Parameters.AddWithValue("@Preco", produto.PrecoVenda);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void DeleteProduto(int? idProduto)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = "DELETE FROM Produto WHERE idProduto = @ProdutoId";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ProdutoId", idProduto);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public ProdutoVO GetProduto(int? idProduto)
        {
            ProdutoVO produto = new ProdutoVO();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Produto WHERE idProduto= " + idProduto;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    produto.IdProduto = Convert.ToInt32(rdr["idProduto"]);
                    produto.NomeProduto = rdr["nomeProduto"].ToString();
                    produto.Categoria = rdr["categoria"].ToString();
                    produto.QuantidadeEstoque = Convert.ToInt32(rdr["quantidadeEstoque"]);
                    produto.PrecoVenda = Convert.ToDouble(rdr["precoVenda"]);
                }
                con.Close();
            }
            return produto;
        }

        public List<ProdutoVO> GetProdutos()
        {
            List<ProdutoVO> lstProdutos = new List<ProdutoVO>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Produto";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ProdutoVO produto = new ProdutoVO();
                    produto.IdProduto = Convert.ToInt32(rdr["idProduto"]);
                    produto.NomeProduto = rdr["nomeProduto"].ToString();
                    produto.Categoria = rdr["categoria"].ToString();
                    produto.QuantidadeEstoque = Convert.ToInt32(rdr["quantidadeEstoque"]);
                    produto.PrecoVenda = Convert.ToDouble(rdr["precoVenda"]);
                    lstProdutos.Add(produto);
                }
                con.Close();
            }
            return lstProdutos;
        }

        public void UpdateProduto(ProdutoVO produto)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string comandoSQL = "UPDATE Produto SET nomeProduto = @NomeProduto, categoria = @Categoria, quantidadeEstoque = @Quantidade, precoVenda = @Preco WHERE idProduto = @IdProduto";
                SqlCommand cmd = new SqlCommand(comandoSQL, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@IdProduto", produto.IdProduto);
                cmd.Parameters.AddWithValue("@NomeProduto", produto.NomeProduto);
                cmd.Parameters.AddWithValue("@Categoria", produto.Categoria);
                cmd.Parameters.AddWithValue("@Quantidade", produto.QuantidadeEstoque);
                cmd.Parameters.AddWithValue("@Preco", produto.PrecoVenda);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
