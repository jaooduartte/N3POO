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
            private string cidade;

        // Método construtor
            public Clientes(string numero, string nome, string cidade)
            {
                this.numero = numero;
                this.nome = nome;
                this.cidade = cidade;
                proximoCliente++;
                clientesCriados++;
            }

            // Getters e Setters
            public string Numero { get => numero; private set => numero = value; }
            public string Nome { get => nome; private set => nome = value; }
            public string Cidade { get => cidade; private set => cidade = value; }

            // Outros métodos
            public string consultarCliente()
            {
                string info = "";
                info += "O cliente ";
                info += this.nome.ToUpper();
                info += " mora na cidade: ";
                info += this.cidade.ToString() + " ";
                return info;
            }
    }
}
