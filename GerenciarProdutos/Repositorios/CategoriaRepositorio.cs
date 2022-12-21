using GerenciarProdutos.Data;
using GerenciarProdutos.Enums;
using GerenciarProdutos.Models;
using GerenciarProdutos.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GerenciarProdutos.Repositorios
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly GerenciarProdutosDBContex _dbContex;
        public CategoriaRepositorio(GerenciarProdutosDBContex gerenciarProdutosDBContex)
        {
            _dbContex = gerenciarProdutosDBContex;
        }

        public async Task<CategoriaModel> BuscarCategoriaPorId(int id)
        {
            return await _dbContex.Categorias.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<CategoriaModel>> BuscarPorCategoria()
        {
            return await _dbContex.Categorias.ToListAsync();
        }

        public async Task<CategoriaModel> BuscarPorNome(string nome)
        {
            return await _dbContex.Categorias.FirstOrDefaultAsync(x => x.Nome == nome);
        }

        public async Task<CategoriaModel> BuscarPorSituacao(Situacao situacao)
        {
            return await _dbContex.Categorias.FirstOrDefaultAsync(x => x.SituacaoCategoria == situacao);
        }

        public async Task<CategoriaModel> Adicionar(CategoriaModel categoria)
        {
            await _dbContex.Categorias.AddAsync(categoria);
            await _dbContex.SaveChangesAsync();

            return categoria;
        }

        public async Task<CategoriaModel> Atualizar(CategoriaModel categoria, int id)
        {
            var categoriaPorId = await BuscarCategoriaPorId(id);
            if (categoriaPorId == null)
                throw new Exception($"Categoria por ID: {id} Nao foi encontrado no banco de dados.");

            categoriaPorId.Nome = categoria.Nome;
            categoriaPorId.SituacaoCategoria = categoria.SituacaoCategoria;
            

            _dbContex.Update(categoriaPorId);
            await _dbContex.SaveChangesAsync();

            return categoriaPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            var categoriaPorId = await BuscarCategoriaPorId(id);
            if (categoriaPorId == null)
                throw new Exception($"Categoria por ID: {id} Nao foi encontrado no banco de dados.");

            _dbContex.Remove(categoriaPorId);
            await _dbContex.SaveChangesAsync();
            return true;
        }


    }
}
