using APIteste.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIteste.Repository
{
	public interface IProdutoRepository
	{
		void Add(List<Produto> produto);
		List<Produto> GetAll();
		Produto Get(decimal id);
		void Put(Produto produto);
		void Delete(decimal id);
	}
}
