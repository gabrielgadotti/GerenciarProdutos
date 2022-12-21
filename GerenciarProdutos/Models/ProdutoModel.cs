using GerenciarProdutos.Enums;

namespace GerenciarProdutos.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public double Preco { get; set; }
        public Situacao SituacaoProduto { get; set; }

        //public virtual CategoriaModel Categoria { get;}

    }
}