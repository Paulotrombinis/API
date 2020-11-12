using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIteste.Entities
{
	public class Produto
	{
		[Key]
		[Display(Name = "Id")]
		public decimal nCdProduto { get; set; }

		[Required]
		[Display(Name = "Nome do Produto")]
		[StringLength(100, ErrorMessage = "O nome do produto deve ter entre 1 at'e 100 caracteres")]
		public string cNmProduto { get; set; }

		[Required]
		[Display(Name = "Quantidade")]
		[Range(1, Int32.MaxValue, ErrorMessage = "Valor deve ser maior ou igual a 1")]
		public int iQuantidade { get; set; }

		[Required]
		[Display(Name = "Preço")]
		public decimal nPreco { get; set; }
	}
}
