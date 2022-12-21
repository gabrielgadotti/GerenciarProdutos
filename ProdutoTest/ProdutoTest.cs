using GerenciarProdutos.Repositorios;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProdutoTest
{
    public class ProdutoTest
    {
        [TestMethod]
        public void Ao_cadastrar_produto_deve_retornar_true()
        {
            var produtoRepositorio = new ProdutoRepositorio();

            Assert.Equal("s", 0," ");
        }
    }
}