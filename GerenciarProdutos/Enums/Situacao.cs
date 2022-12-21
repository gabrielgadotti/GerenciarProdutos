using System.ComponentModel;

namespace GerenciarProdutos.Enums
{
    public enum Situacao
    {
        [Description("Inativo")]
        Inativo = 0,

        [Description("Ativo")]
        Ativo = 1
    }
}