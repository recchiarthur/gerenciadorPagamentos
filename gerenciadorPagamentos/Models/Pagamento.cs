namespace gerenciadorPagamentos.Models
{
    public class Pagamento
    {
        public int Id { get; set; }

        public string descricao { get; set; }

        public float valor { get; set; }

        public string codigo_barras { get; set; }

        public DateOnly data_vencimento { get; set; }

        public DateOnly data_pagamento { get; set; }
    }
}
