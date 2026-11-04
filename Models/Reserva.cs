using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva()
        {
            Hospedes = new List<Pessoa>();
        }

        public Reserva(int diasReservados) : this()
        {
            if (diasReservados <= 0)
                throw new ArgumentOutOfRangeException(nameof(diasReservados), "A reserva deve ter pelo menos um dia.");
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (hospedes == null)
                throw new ArgumentNullException(nameof(hospedes));
            if (Suite == null)
                throw new InvalidOperationException("É necessário selecionar uma suíte antes de adicionar hóspedes.");
            if (hospedes.Count <= Suite.Capacidade)
            {
                Hospedes = hospedes;
            }
            else
            {
                // ✅ TODO: Retornar exception caso exceda a capacidade
                throw new ArgumentException(
                    $"Quantidade de hóspedes ({hospedes.Count}) excede a capacidade da suíte ({Suite.Capacidade}).");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            if (suite == null)
                throw new ArgumentNullException(nameof(suite));
            if (suite.Capacidade <= 0 || suite.ValorDiaria < 0)
                throw new ArgumentException("Capacidade ou valor de diária inválido.", nameof(suite));
            if (Hospedes.Count > suite.Capacidade)
                throw new ArgumentException("A suíte não comporta os hóspedes já registados.", nameof(suite));
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // ✅ TODO: Retorna a quantidade de hóspedes
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            if (Suite == null)
                throw new InvalidOperationException("É necessário selecionar uma suíte antes de calcular o preço.");
            if (DiasReservados <= 0 || Suite.ValorDiaria < 0)
                throw new InvalidOperationException("A duração e o preço da suíte devem ser válidos.");
            // Cálculo: DiasReservados X Suite.ValorDiaria
            decimal valor = DiasReservados * Suite.ValorDiaria;

            // ✅ Regra: Caso os dias reservados forem >= 10, conceder desconto de 10%
            if (DiasReservados >= 10)
            {
                valor = valor - (valor * 0.10m); // Aplica 10% de desconto
            }

            return valor;
        }
    }
}
