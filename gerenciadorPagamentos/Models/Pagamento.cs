using System.ComponentModel.DataAnnotations.Schema;

namespace gerenciadorPagamentos.Models
{
    public class Pagamento
    {
        public int Id { get; set; }
        [Column(TypeName = "ntext")]
        public string descricao { get; set; }

        public decimal valor { get; set; }

        public string codigo_barras { get; set; }

        public DateTime data_vencimento { get; set; }

        public DateTime data_pagamento { get; set; }
    }
}
