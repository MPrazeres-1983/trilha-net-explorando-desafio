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

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
            Hospedes = new List<Pessoa>();
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // ✅ TODO: Verificar se a capacidade é maior ou igual ao número de hóspedes
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
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // ✅ TODO: Retorna a quantidade de hóspedes
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            // ✅ TODO: Retorna o valor da diária
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
