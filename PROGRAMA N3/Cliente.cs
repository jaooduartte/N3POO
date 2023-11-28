namespace Floricultura
{
        internal class Clientes
        {
            // Propriedades Estáticas
            static public int proximoCliente= 1;
            static public int clientesCriados = 0;

            // Propriedades
            private string numero;
            private string nome;
            private string medida;
            private decimal saldo;
            private decimal totalEntradas;
            private decimal totalSaidas;
            private List<Movimento> movimentos = new List<Movimento>();

            // Método construtor
            public Clientes(string numero, string nome, string medida)
            {
                this.numero = numero;
                this.nome = nome;
                this.medida = medida;
                this.saldo = 0;
                this.totalEntradas = 0;
                this.totalSaidas = 0;
                proximoCliente++;
                clientesCriados++;
            }

            // Getters e Setters
            public string Numero { get => numero; private set => numero = value; }
            public string Nome { get => nome; private set => nome = value; }
            public string Medida { get => medida; private set => medida = value; }

            // Outros métodos
            public string consultarCliente()
            {
                string info = "";
                info += "O cliente ";
                info += this.nome;
                info += " possui em estoque: ";
                info += this.saldo.ToString() + " ";
                return info;
            }

            public void fazerEntrada(decimal val, DateTime dat, string desc)
            {
                // Guarda a movimento
                this.movimentos.Add(new Movimento(val, dat, desc, "C"));

                // Atualiza o saldo
                this.saldo += val;

                // Atualiza o total de entradas
                this.totalEntradas += val;
            }

            public void fazerSaida(decimal val, DateTime dat, string desc)
            {
                if (val <= this.saldo)
                {
                    // Guarda o movimento
                    this.movimentos.Add(new Movimento(val, dat, desc, "D"));

                    // Atualiza o saldo
                    this.saldo -= val;

                    // Atualiza o total de saídas
                    this.totalSaidas += val;
                }
            }

            public decimal TotalEntradas
            {
                get { return totalEntradas; }
            }

            public decimal TotalSaidas
            {
                get { return totalSaidas; }
            }
        }
}
