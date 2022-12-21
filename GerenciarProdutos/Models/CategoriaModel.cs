using GerenciarProdutos.Enums;

namespace GerenciarProdutos.Models
{
    public class CategoriaModel 
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public Situacao SituacaoCategoria { get; set; }
    }
}