//using Floricultura;


//namespace Floricultura
//{
//    class Pedido
//    {
//        // Implemente os atributos e métodos necessários para a classe Pedido
//        static public int proximoPedido = 1;
//        static public int pedidoCriado = 0;
//        public string numPedido;
//        public decimal numCliente;
//        public decimal numProduto;
//        public decimal qtdPedido;

//        public Pedido(string numPed, decimal numCli, decimal numProd, decimal qtdProd)
//        {
//            this.numPedido = numPed;
//            this.numCliente = numCli;
//            this.numProduto = numProd;
//            this.qtdPedido = qtdProd;
//            proximoPedido++;
//            pedidoCriado++;
//        }

//        public decimal saidaPedido(decimal valorProd, decimal valorPed)
//        {
//            decimal pedido = valorProd - valorPed;
//            return pedido;
//        }

//        public string consultarPedido()
//        {
//            string res = "";


//            return res;
//        }
//    }
//}

using System;
using System.Collections.Generic;

namespace Floricultura
{
    class Pedido
    {
        // Propriedades Estáticas
        static public int proximoPedido = 1;
        static public int pedidosCriados = 0;

        // Propriedades
        public string enderecoDestino { get; set; }
        private string numeroPedido;
        private string numeroCliente;
        private string numeroProduto;
        private decimal quantidadePedido;
        private List<Movimento> movimentos = new List<Movimento>();

        // Método construtor
        public Pedido(string numeroPedido, string numeroCliente, string numeroProduto, decimal quantidadePedido)
        {
            this.numeroPedido = numeroPedido;
            this.numeroCliente = numeroCliente;
            this.numeroProduto = numeroProduto;
            this.quantidadePedido = quantidadePedido;
            proximoPedido++;
            pedidosCriados++;
        }

        // Getters e Setters
        public string NumeroPedido { get => numeroPedido; private set => numeroPedido = value; }
        public string NumeroCliente { get => numeroCliente; private set => numeroCliente = value; }
        public string NumeroProduto { get => numeroProduto; private set => numeroProduto = value; }
        public decimal QuantidadePedido { get => quantidadePedido; private set => quantidadePedido = value; }

        // Outros métodos
        public string ConsultarPedido()
        {
            string info = $"Pedido #{this.numeroPedido}\n";
            info += $"Cliente: {this.numeroCliente}\n";
            info += $"Produto: {this.numeroProduto}\n";
            info += $"Quantidade: {this.quantidadePedido}\n";

            return info;
        }
    }
}
