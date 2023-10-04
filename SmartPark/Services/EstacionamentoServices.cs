using SmartPark.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartPark.Services
{
    public class EstacionamentoServices
    {
        private List<Estacionamento> estacionamentoList = new List<Estacionamento>();
        private const double TaxaHoraCarro = 5.0;
        private const double TaxaHoraMoto = 3.0;

        public void Entrada(string placa, string tipoVeiculo)
        {
            var estacionamento = new Estacionamento
            {
                Placa = placa,
                HoraChegada = DateTime.Now,
                HoraSaida = DateTime.Now,
                TipoVeiculo = tipoVeiculo
            };
            estacionamentoList.Add(estacionamento);
        }

        public void Saida(string placa)
        {
            var veiculo = estacionamentoList.FirstOrDefault(e =>  e.Placa == placa);
            if (veiculo != null)
            {
                veiculo.HoraSaida = DateTime.Now;

                var tempoPermanencia = (veiculo.HoraSaida - veiculo.HoraChegada).TotalHours;

                if (veiculo.TipoVeiculo.Equals("carro", StringComparison.OrdinalIgnoreCase))
                {
                    veiculo.ValorAPagar = tempoPermanencia * TaxaHoraCarro;
                }
                else if (veiculo.TipoVeiculo.Equals("moto", StringComparison.OrdinalIgnoreCase))
                {
                    veiculo.ValorAPagar = tempoPermanencia * TaxaHoraMoto;
                }
            }
        }

        public List<Estacionamento> ListarTodos()
        {
            return estacionamentoList;
        }
    }
}
