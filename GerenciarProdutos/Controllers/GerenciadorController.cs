using GerenciarProdutos.Enums;
using GerenciarProdutos.Models;
using GerenciarProdutos.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciarProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GerenciadorController : ControllerBase
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        private readonly IProdutoRepositorio _produtoRepositorio;

        public GerenciadorController(ICategoriaRepositorio categoriaRepositorio,
            IProdutoRepositorio produtoRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
            _produtoRepositorio = produtoRepositorio;
        }


        /// <summary>
        /// aqui começa o crud de produtos
        /// </summary>
        /// <returns></returns>
        [HttpGet("produtos")]
        public ActionResult<List<ProdutoModel>> BuscarProdutos()
        {
            return Ok();
        }

        [HttpGet("produto/{id}")]   
        public async Task<ActionResult<ProdutoModel>> BuscarProdutoPorId(int id)
        {
            var produto = await _produtoRepositorio.BuscarProdutoPorId(id);
            return Ok(produto);
        }

        [HttpGet("produto/{descricao}")]
        public async Task<ActionResult<ProdutoModel>> BuscarProdutoPorDescricao(string descricao)
        {
            var produto = await _produtoRepositorio.BuscarPorDescricao(descricao);
            return Ok(produto);
        }

        [HttpGet("produto/{situacao}")]
        public async Task<ActionResult<ProdutoModel>> BuscarProdutoPorSituacao(Situacao situacao)
        {
            var produto = await _produtoRepositorio.BuscarPorSituacao(situacao);
            return Ok(produto);
        }

        //[HttpGet("produto/{categoria}")]
        //public async Task<ActionResult<ProdutoModel>> BuscarProdutoPorCategoria()
        //{
        //    var produto = await _produtoRepositorio.BuscarPorCategoria();
        //    return Ok(produto);
        //}


        [HttpPost("cadastrarproduto")]
        public async Task<ActionResult<ProdutoModel>> CadastrarProduto([FromBody] ProdutoModel produtoModel)
        {
            var produto = await _produtoRepositorio.Adicionar(produtoModel);
            return Ok(produto);
        }

        [HttpPost("atualizarrproduto/{id}")]
        public async Task<ActionResult<ProdutoModel>> AtualizarProduto([FromBody] ProdutoModel produtoModel, int id)
        {
            produtoModel.Id = id;
            var produto = await _produtoRepositorio.Atualizar(produtoModel, id);
            return Ok(produto);
        }

        [HttpDelete("apagarproduto/{id}")]
        public async Task<ActionResult<ProdutoModel>> ApagarProduto(int id)
        {
            bool apagado = await _produtoRepositorio.Apagar(id);
            return Ok(apagado);
        }


        /// <summary>
        /// aqui começa o crud de categorias
        /// </summary>
        /// <returns></returns>
        [HttpGet("categorias")]
        public ActionResult<List<CategoriaModel>> BuscarCategorias()
        {
            return Ok();    
        }


        [HttpGet("categoria/{nome}")]
        public async Task<ActionResult<CategoriaModel>> BuscarCategoriaPorNome(string nome)
        {
            var categoria = await _categoriaRepositorio.BuscarPorNome(nome);
            return Ok(categoria);
        }

        [HttpGet("categoria/{situacao}")]
        public async Task<ActionResult<CategoriaModel>> BuscarCategoriaPorSituacao(Situacao situacao)
        {
            var categoria = await _categoriaRepositorio.BuscarPorSituacao(situacao);
            return Ok(categoria);
        }

        [HttpPost("cadastrarcategoria")]
        public async Task<ActionResult<CategoriaModel>> CadastrarCategoria([FromBody] CategoriaModel categoriaModel)
        {
            var categoria = await _categoriaRepositorio.Adicionar(categoriaModel);
            return Ok(categoria);
        }

        [HttpPost("atualizarcategoria/{id}")]
        public async Task<ActionResult<CategoriaModel>> AtualizarCategoria([FromBody] CategoriaModel categoriaModel, int id)
        {
            categoriaModel.Id = id;
            var categoria = await _categoriaRepositorio.Atualizar(categoriaModel, id);
            return Ok(categoria);
        }

        [HttpDelete("apagarcategoria/{id}")]
        public async Task<ActionResult<CategoriaModel>> ApagarCategoria(int id)
        {
            bool apagado = await _categoriaRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
