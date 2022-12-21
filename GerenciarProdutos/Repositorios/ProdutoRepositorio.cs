using GerenciarProdutos.Data;
using GerenciarProdutos.Enums;
using GerenciarProdutos.Models;
using GerenciarProdutos.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace GerenciarProdutos.Repositorios
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly GerenciarProdutosDBContex _dbContex;
        public ProdutoRepositorio(GerenciarProdutosDBContex gerenciarProdutosDBContex)
        {
            _dbContex = gerenciarProdutosDBContex;
        }

        public async Task<ProdutoModel> BuscarProdutoPorId(int id)
        {
            return await _dbContex.Produtos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ProdutoModel>> BuscarProdutos()
        {
            return await _dbContex.Produtos.ToListAsync();

        }

        //public async Task<ProdutoModel> BuscarPorCategoria(CategoriaModel categoria)
        //{
        //    return await _dbContex.Produtos.FirstOrDefaultAsync(x => x.Categoria.Nome == categoria.Nome);

        //}

        public async Task<ProdutoModel> BuscarPorDescricao(string descricao)
        {
            return await _dbContex.Produtos.FirstOrDefaultAsync(x => x.Descricao == descricao);
        }

        public async Task<ProdutoModel> BuscarPorSituacao(Situacao situacao)
        {
            return await _dbContex.Produtos.FirstOrDefaultAsync(x => x.SituacaoProduto == situacao);
        }


        public async Task<ProdutoModel> Adicionar(ProdutoModel produto)
        {
            await _dbContex.Produtos.AddAsync(produto);
            await _dbContex.SaveChangesAsync();

            return produto;
        }


        public async Task<ProdutoModel> Atualizar(ProdutoModel produto, int id)
        {
            var produtoPorId = await BuscarProdutoPorId(id);
            if (produtoPorId == null)
                throw new Exception($"Protudo por ID: {id} Nao foi encontrado no banco de dados.");

            produtoPorId.Nome = produto.Nome;
            produtoPorId.Descricao = produto.Descricao;
            produtoPorId.SituacaoProduto = produto.SituacaoProduto;
            produtoPorId.Preco = produto.Preco;
            //produtoPorId.Categoria.SituacaoCategoria = produto.Categoria.SituacaoCategoria;
            //produtoPorId.Categoria.Nome = produto.Categoria.Nome;

            _dbContex.Update(produtoPorId);
            await _dbContex.SaveChangesAsync();

            return produtoPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            var produtoPorId = await BuscarProdutoPorId(id);
            if (produtoPorId == null)
                throw new Exception($"Protudo por ID: {id} Nao foi encontrado no banco de dados.");

            _dbContex.Remove(produtoPorId);
            await _dbContex.SaveChangesAsync();
            return true;
        }
    }
}
