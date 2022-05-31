using Microsoft.EntityFrameworkCore;

namespace gerenciadorPagamentos.Models
{
    public class PagamentoContext : DbContext
    {
        public DbSet<Pagamento> Pagamento { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=SNCCH01LABF122\TEW_SQLEXPRESS;Database=cadastroPagamento;Trusted_Connection=True;");
        }
    }
}
