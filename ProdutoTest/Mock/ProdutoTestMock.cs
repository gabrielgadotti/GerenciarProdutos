using GerenciarProdutos.Enums;
using GerenciarProdutos.Models;
using GerenciarProdutos.Repositorios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoTest.Mock
{
    public class ProdutoTestMock : IProdutoRepositorio
    {
        public async Task<ProdutoModel> Adicionar(ProdutoModel produto)
        {
            ProdutoModel model = new ProdutoModel();
            model.Id = 1;
            model.Descricao = "Refrigerador 500L";
            model.SituacaoProduto = Situacao.Ativo;
            model.Preco = 2500;

            return model;
        }

        public async Task<bool> Apagar(int id)
        {
            return true;
        }

        public async Task<ProdutoModel> Atualizar(ProdutoModel produto, int id)
        {
            ProdutoModel model = produto;
            model.Id = id;
            model.Descricao = "Refrigerador 650L";
            model.SituacaoProduto = Situacao.Inativo;
            model.Preco = 3500;

            return model;
        }

        public Task<ProdutoModel> BuscarPorDescricao(string descricao)
        {
            throw new NotImplementedException();
        }

        public Task<ProdutoModel> BuscarPorSituacao(Situacao situacao)
        {
            throw new NotImplementedException();
        }

        public Task<ProdutoModel> BuscarProdutoPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProdutoModel>> BuscarProdutos()
        {
            throw new NotImplementedException();
        }
    }
}
