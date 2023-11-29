using Floricultura;


namespace Floricultura
{
    class Pedido
    {
        // Implemente os atributos e métodos necessários para a classe Pedido
        static public int proximoPedido = 1;
        static public int pedidoCriado = 0;
        public string numPedido;
        public decimal numCliente;
        public decimal numProduto;
        public decimal qtdPedido;

        public Pedido(string numPed, decimal numCli, decimal numProd, decimal qtdProd)
        {
            this.numPedido = numPed;
            this.numCliente = numCli;
            this.numProduto = numProd;
            this.qtdPedido = qtdProd;
            proximoPedido++;
            pedidoCriado++;
        }

        public decimal saidaPedido(decimal valorProd, decimal valorPed)
        {
            decimal pedido = valorProd - valorPed;
            return pedido;
        }

        public string consultarPedido()
        {
            string res = "";


            return res;
        }
    }
}
