using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using APIteste.Entities;
using APIteste.Repository;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.IdentityModel.Protocols;

namespace APIteste.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ValuesController : ControllerBase
	{
		private readonly ProdutoRepository produtoRepository;

		public ValuesController()
		{
			produtoRepository = new ProdutoRepository();
		}

		// GET api/values
		[HttpGet]
		public List<Produto> Get()
		{
			return produtoRepository.GetAll();
		}

		// GET api/values/5
		[HttpGet("{id}")]
		public Produto Get(decimal id)
		{
			return produtoRepository.Get(id);
		}

		// POST api/values
		[HttpPost]
		public void Post([FromBody] List<Produto> produtos)
		{
			produtoRepository.Add(produtos);
		}

		// PUT api/values/5
		[HttpPut("{id}")]
		public void Put(decimal id, [FromBody] Produto produto)
		{
			produto.nCdProduto = id;
			if (ModelState.IsValid)
			{
				produtoRepository.Put(produto);
			}
		}

		// DELETE api/values/5
		[HttpDelete("{id}")]
		public void Delete(decimal id)
		{
			produtoRepository.Delete(id);
		}
	}
}
