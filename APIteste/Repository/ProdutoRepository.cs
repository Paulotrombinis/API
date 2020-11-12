using APIteste.Entities;
using Dapper;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIteste.Repository
{
	public class ProdutoRepository : IProdutoRepository
	{
		static string connectionString = @"data source=DESKTOP-SJL2747\SQLEXPRESS;initial catalog=WEBAPI;user id=sa;password=123;Connect Timeout=60";

		public void Add(List<Produto> produtos)
		{
			using (var con = new SqlConnection(connectionString))
			{
				try
				{
					foreach (var produto in produtos)
					{
						var query = "INSERT INTO Produtos(cNmProduto, iQuantidade, nPreco) VALUES(@cNmProduto, @iQuantidade, @nPreco);";
						con.Execute(query, produto);
					}
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					con.Close();
				}
			}
		}

		public void Delete(decimal id)
		{
			using (var con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();
					var query = "DELETE FROM produtos WHERE nCdProduto = " + id;
					con.Execute(query, id);
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					con.Close();
				}
			}
		}

		public void Put(Produto produto)
		{
			using (var con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();
					var query = "UPDATE Produtos SET cNmProduto = @cNmProduto, iQuantidade = @iQuantidade, nPreco = @nPreco WHERE nCdProduto = " + produto.nCdProduto;
					con.Execute(query, produto);
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					con.Close();
				}
			}
		}

		public Produto Get(decimal id)
		{
			Produto produto = new Produto();
			using (var con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();
					var query = "SELECT * FROM Produtos WHERE nCdProduto =" + id;
					produto = con.Query<Produto>(query).FirstOrDefault();
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					con.Close();
				}
				return produto;
			}
		}

		public List<Produto> GetAll()
		{
			List<Produto> produtos = new List<Produto>();
			using (var con = new SqlConnection(connectionString))
			{
				try
				{
					con.Open();
					var query = "SELECT * FROM Produtos";
					produtos = con.Query<Produto>(query).ToList();
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					con.Close();
				}
				return produtos;
			}
		}
	}
}
