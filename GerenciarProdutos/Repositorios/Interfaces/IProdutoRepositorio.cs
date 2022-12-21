using GerenciarProdutos.DTO;
using GerenciarProdutos.Enums;
using GerenciarProdutos.Models;

namespace GerenciarProdutos.Repositorios.Interfaces
{
    public interface IProdutoRepositorio
    {
        Task<ProdutoModel> BuscarProdutoPorId(int id);

        Task<List<ProdutoModel>> BuscarProdutos();
        Task<ProdutoModel> BuscarPorCategoria(string nome);
        Task<ProdutoModel> BuscarPorDescricao(string descricao);
        Task<ProdutoModel> BuscarPorSituacao(Situacao situacao);

        Task<ProdutoModel> Adicionar(CriarProdutoDTO produto);
        Task<ProdutoModel> Atualizar(ProdutoModel produto, int id);

        Task<bool> Apagar(int id);

    }
}
