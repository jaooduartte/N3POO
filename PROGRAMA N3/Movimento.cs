using System;
namespace Floricultura
{
	internal class Movimento
	{
        //Propriedades
        private string descricao;
        private DateTime data;
        private decimal valor;
        private string tipo;

        //Método construtor
        public Movimento(decimal val, DateTime dat, string des, string tip)
        {
            this.valor = val;
            this.data = dat;
            this.descricao = des;
            this.tipo = tip;
        }

        public string Descricao { get => descricao; set => descricao = value; }
        public DateTime Data { get => data; set => data = value; }
        public decimal Valor { get => valor; set => valor = value; }
        public string Tipo { get => tipo; set => tipo = value; }

        //Outros métodos
    }
}

