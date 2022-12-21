using GerenciarProdutos.Data.Map;
using GerenciarProdutos.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciarProdutos.Data
{
    public class GerenciarProdutosDBContex : DbContext
    {
        public GerenciarProdutosDBContex(DbContextOptions<GerenciarProdutosDBContex> options)
            : base(options)
        {
        }

        public DbSet<ProdutoModel> Produtos { get; set; }
        public DbSet<CategoriaModel> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
