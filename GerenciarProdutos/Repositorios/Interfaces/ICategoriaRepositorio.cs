using GerenciarProdutos.Enums;
using GerenciarProdutos.Models;

namespace GerenciarProdutos.Repositorios.Interfaces
{
    public interface ICategoriaRepositorio
    {
        Task<CategoriaModel> BuscarCategoriaPorId(int id);
        Task<List<CategoriaModel>> BuscarPorCategoria();
        Task<CategoriaModel> BuscarPorNome(string nome);
        Task<CategoriaModel> BuscarPorSituacao(Situacao situacao);

        Task<CategoriaModel> Adicionar(CategoriaModel categoria);
        Task<CategoriaModel> Atualizar(CategoriaModel categoria, int id);

        Task<bool> Apagar(int id);

    }
}
