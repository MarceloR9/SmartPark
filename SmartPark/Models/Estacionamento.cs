using System;

namespace SmartPark.Models
{
    public class Estacionamento
    {
        public string Placa { get; set; }
        public DateTime HoraChegada { get; set; }
        public DateTime HoraSaida { get; set; }
        public string TipoVeiculo { get; set; }
        public double ValorAPagar { get; set; }
    }
}