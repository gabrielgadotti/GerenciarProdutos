using GerenciarProdutos.Enums;

namespace GerenciarProdutos.DTO
{
    public class CriarProdutoDTO
    {
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public double Preco { get; set; }
        public Situacao SituacaoProduto { get; set; }

        public int CategoriaId { get; set; }
    }
}
