using System;
namespace Floricultura
{
	internal class Movimento
	{
        //Propriedades
        private DateTime data;
        private decimal valor;
        private string tipo;

        //Método construtor
        public Movimento(decimal val, DateTime dat, string tip)
        {
            this.valor = val;
            this.data = dat;
            this.tipo = tip;
        }

        public DateTime Data { get => data; set => data = value; }
        public decimal Valor { get => valor; set => valor = value; }
        public string Tipo { get => tipo; set => tipo = value; }

        //Outros métodos
    }
}

