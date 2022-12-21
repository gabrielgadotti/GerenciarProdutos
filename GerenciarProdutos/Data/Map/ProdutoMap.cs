using GerenciarProdutos.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GerenciarProdutos.Data.Map
{
    public class ProdutoMap : IEntityTypeConfiguration<ProdutoModel>
    {
        public void Configure(EntityTypeBuilder<ProdutoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.SituacaoProduto).IsRequired();
            builder.Property(x => x.Preco).IsRequired();
            builder.HasOne(x => x.Categoria).WithMany().HasForeignKey("CategoriaId");
        }
    }
}
