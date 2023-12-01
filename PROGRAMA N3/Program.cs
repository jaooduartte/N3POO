/*
JOÃO PAULO DUARTE XAVIER
KALEBE FUKUDA
EDUARDO LITTLE HAIR
Engenharia de Software
2ª FASE - B
*/

using System;
using System.Collections.Generic;
using System.Numerics;
using Floricultura;

class Program
{
    static void Main(string[] args)
    {
        List<Produto> bancoDados = new List<Produto>();
        List<Clientes> bancoDadosClientes = new List<Clientes>();
        List<Pedido> pedidos = new List<Pedido>();
        Tela tela = new Tela();
        string opcao;

        // Adicione outras opções de menu conforme necessário
        List<string> menuPrincipal = new List<string>();
        menuPrincipal.Add("1 - Controle de estoque  ");
        menuPrincipal.Add("2 - Consultar produto    ");
        menuPrincipal.Add("3 - Cadastrar produto    ");
        menuPrincipal.Add("4 - Consultar cliente    ");
        menuPrincipal.Add("5 - Cadastrar cliente    ");
        menuPrincipal.Add("6 - Criar novo pedido    ");
        menuPrincipal.Add("0 - Sair                 ");

        tela.configurarTela();

        while (true)
        {
            tela.montarTelaSistema($"FLORICULTURA FLOWERNET - {Clientes.clientesCriados} clientes até o momento");
            opcao = tela.mostrarMenu(menuPrincipal, 3, 3);

            if (opcao == "0") break;

            if (opcao == "1")
            {
                tela.montarMoldura(10, 5, 55, 16, "Movimentar produto");

                //Pergunta o numero do produto
                Console.SetCursorPosition(11, 7);
                Console.Write("Produto nº: ");
                string con = Console.ReadLine();

                //Procura pelo produto no vetor bancoDados
                bool achou = false;
                int x;

                for (x = 0; x < bancoDados.Count; x++)
                {
                    if (bancoDados[x].Numero == con)
                    {
                        achou = true;
                        break;
                    }
                }

                if (achou)
                {
                    Console.SetCursorPosition(11, 8);
                    Console.Write("Nome do produto      : " + bancoDados[x].Nome.ToUpper());

                    Console.SetCursorPosition(11, 9);
                    Console.Write("Entrada/Saída (E/S)  : ");
                    string tip = Console.ReadLine().ToUpper();

                    Console.SetCursorPosition(11, 10);
                    Console.Write("Quantidade           : ");
                    decimal val = decimal.Parse(Console.ReadLine());

                    Console.SetCursorPosition(11, 11);
                    Console.Write("Confirma? (Y/N)      : ");
                    string resp = Console.ReadLine().ToUpper();

                    if (resp == "Y")
                    {
                        if (tip == "S") bancoDados[x].fazerSaida(val, DateTime.Now);
                        if (tip == "E") bancoDados[x].fazerEntrada(val, DateTime.Now);
                    }
                }
                else
                {
                    Console.SetCursorPosition(11, 8);
                    Console.Write("Produto não encontrado. Pressione uma tecla.");
                    Console.ReadKey(true);
                }
            }

            if (opcao == "2")
            {
                tela.montarMoldura(10, 8, 75, 15, "Consultar produto");

                // Pergunta o número do produto
                Console.SetCursorPosition(11, 10);
                Console.Write("Produto nº: ");
                string con = Console.ReadLine();

                // Procura pelo produto no vetor bancoDados
                string resultado = "Produto não encontrado!";
                decimal entradas = 0;
                decimal saidas = 0;

                foreach (Produto cta in bancoDados)
                {
                    if (cta.Numero == con)
                    {
                        resultado = cta.consultarProduto();
                        entradas = cta.TotalEntradas;
                        saidas = cta.TotalSaidas;
                        break;
                    }
                }

                Console.SetCursorPosition(11, 10);
                Console.Write(resultado);
                Console.SetCursorPosition(11, 12);
                Console.Write($"Total de Entradas: {entradas}");
                Console.SetCursorPosition(11, 13);
                Console.Write($"Total de Saídas: {saidas}");
                Console.ReadKey();
            }


            if (opcao == "3")
            {
                tela.montarMoldura(7, 7, 60, 13, "Novo produto");

                //Pergunta o numero do produto
                Console.SetCursorPosition(8, 9);
                string con = Produto.proximoProduto.ToString();
                Console.Write($"Produto                     : {con}");

                //Pergunta o nome do produto
                Console.SetCursorPosition(8, 10);
                Console.Write("Nome                        : ");
                string tit = Console.ReadLine();

                //Solicita a confirmação para cadastro
                Console.SetCursorPosition(8, 11);
                Console.Write("Confirma novo produto? (S/N): ");
                string res = Console.ReadLine();

                if (res.ToUpper() == "S")
                {
                    //Armazena novo produto no BANCO DE DADOS
                    bancoDados.Add(new Produto(con, tit));
                }
            }

            if (opcao == "4")
            {
                tela.montarMoldura(10, 8, 75, 15, "Consultar Cliente");

                // Pergunta o número do produto
                Console.SetCursorPosition(11, 10);
                Console.Write("Nº do Cliente: ");
                string con = Console.ReadLine();

                // Procura pelo cliente no vetor bancoDados
                string resultado = "Cliente não encontrado!";

                foreach (Clientes cta in bancoDadosClientes)
                {
                    if (cta.Numero == con)
                    {
                        resultado = cta.consultarCliente();
                        break;
                    }
                }

                Console.SetCursorPosition(11, 10);
                Console.Write(resultado);
                Console.SetCursorPosition(11, 12);
                Console.ReadKey();

            }

            if (opcao == "5")
            {
                tela.montarMoldura(7, 7, 60, 13, "Novo cliente");

                //Pergunta o numero do produto
                Console.SetCursorPosition(8, 9);
                string con = Clientes.proximoCliente.ToString();
                Console.Write($"Nº Cliente                  : {con}");

                //Pergunta o nome do produto
                Console.SetCursorPosition(8, 10);
                Console.Write("Nome do cliente             : ");
                string tit = Console.ReadLine();

                Console.SetCursorPosition(8, 11);
                Console.Write("Cidade                      : ");
                string cid = Console.ReadLine();

                //Solicita a confirmação para cadastro
                Console.SetCursorPosition(8, 12);
                Console.Write("Confirma novo cliente? (S/N): ");
                string res = Console.ReadLine();

                if (res.ToUpper() == "S")
                {
                    //Armazena novo cliente no BANCO DE DADOS
                    bancoDadosClientes.Add(new Clientes(con, tit, cid));
                }
            }

            //if (opcao == "6")
            //{
            //    tela.montarMoldura(7, 7, 60, 13, "Novo pedido");

            //    //Pergunta o numero do produto
            //    Console.SetCursorPosition(8, 9);
            //    string con = Pedido.proximoPedido.ToString();
            //    Console.Write($"Pedido                    : {con}");

            //    //Pergunta o nome do produto
            //    Console.SetCursorPosition(8, 10);
            //    Console.Write("Numero do Cliente          : ");
            //    decimal numC = Console.Read();

            //    Console.SetCursorPosition(8, 11);
            //    Console.Write("Numero do Produto          : ");
            //    decimal numP = Console.Read();

            //    Console.SetCursorPosition(8, 12);
            //    Console.Write("Quantidade do Produto      : ");
            //    decimal qtdP = Console.Read();

            //    //Solicita a confirmação para cadastro
            //    Console.SetCursorPosition(8, 13);
            //    Console.Write("Confirma novo pedido? (S/N): ");
            //    string res = Console.ReadLine();

            //    Pedido novoPedido = new Pedido(con, numC, numP, qtdP);

            //    pedidos.Add(novoPedido);

            //    Produto produto = bancoDados.Find(p => p.Numero == numP.ToString());
            //    if (produto != null)
            //    {
            //        produto.fazerSaida(qtdP, DateTime.Now, $"Pedido {numP}");
            //    }
            //    else
            //    {
            //        Console.SetCursorPosition(8, 13);
            //        Console.Write("Produto não encontrado. Pressione uma tecla.");
            //        Console.ReadKey(true);
            //    }

            //    if (res.ToUpper() == "S")
            //    {
            //        //Armazena novo produto no BANCO DE DADOS
            //        pedidos.Add(new Pedido(con, numC, numP, qtdP));


            //    }
            if (opcao == "6")
            {
                tela.montarMoldura(7, 7, 75, 17, "Novo pedido");

                // Pergunta o número do pedido
                Console.SetCursorPosition(8, 9);
                string con = Pedido.proximoPedido.ToString();
                Console.Write($"Pedido                      : {con}");

                // Pergunta o número do cliente
                Console.SetCursorPosition(8, 10);
                Console.Write("Número do Cliente           : ");
                string numC = Console.ReadLine();

                // Procura pelo cliente no vetor bancoDadosClientes
                Clientes clienteEncontrado = bancoDadosClientes.Find(cliente => cliente.Numero == numC);

                if (clienteEncontrado != null)
                {
                    Console.SetCursorPosition(8, 11);
                    Console.Write($"Nome do Cliente             : {clienteEncontrado.Nome.ToUpper()}");

                    // Pergunta o número do produto
                    Console.SetCursorPosition(8, 12);
                    Console.Write("Endereço de Destino         : ");
                    string enderecoDestino = Console.ReadLine();

                    

                    // Pergunta o número do produto
                    Console.SetCursorPosition(8, 13);
                    Console.Write("Número do Produto           : ");
                    string numP = Console.ReadLine();

                    // Procura pelo produto no vetor bancoDados
                    Produto produtoEncontrado = bancoDados.Find(produto => produto.Numero == numP);

                    if (produtoEncontrado != null)
                    {
                        Console.SetCursorPosition(8, 14);
                        Console.Write($"{produtoEncontrado.consultarProduto()}");

                        // Pergunta a quantidade do produto
                        Console.SetCursorPosition(8, 15);
                        Console.Write("Quantidade do Pedido        : ");
                        decimal qtdP = decimal.Parse(Console.ReadLine());

                        if (qtdP > produtoEncontrado.saldo)
                        {
                            Console.SetCursorPosition(8, 16);
                            Console.Write("Não há quantidade suficiente em estoque. Pressione uma tecla.");
                            Console.ReadKey(true);
                            continue; // Volta para o início do loop e pede a quantidade novamente
                        }

                        // Confirmação para cadastro
                        Console.SetCursorPosition(8, 16);
                        Console.Write("Confirma novo pedido? (S/N) : ");
                        string res = Console.ReadLine();

                        

                        if (res.ToUpper() == "S")
                        {
                            // Armazena novo produto no BANCO DE DADOS
                            Pedido novoPedido = new Pedido(con, numC, numP, qtdP);
                            pedidos.Add(novoPedido);
                            novoPedido.enderecoDestino = enderecoDestino;
                            produtoEncontrado.fazerSaida(qtdP, DateTime.Now);

                            tela.montarMoldura(12, 12, 65, 21, "PEDIDO REALIZADO!");
                            Console.SetCursorPosition(13, 15);
                            Console.Write($"Pedido nº {novoPedido.NumeroPedido} realizado com sucesso!");
                            Console.SetCursorPosition(13, 17);
                            Console.Write($"Cliente: {clienteEncontrado.Nome.ToUpper()}");
                            Console.SetCursorPosition(13, 18);
                            Console.Write($"Endereço de Destino: {novoPedido.enderecoDestino.ToUpper()}");
                            Console.SetCursorPosition(13, 19);
                            Console.Write($"Produto: {produtoEncontrado.Nome.ToUpper()}");
                            Console.SetCursorPosition(13, 20);
                            Console.Write($"Quantidade: {novoPedido.QuantidadePedido}");
                            Console.ReadKey(true);
                        }
                    }
                    else
                    {
                        Console.SetCursorPosition(8, 13);
                        Console.Write("Produto não encontrado. Pressione uma tecla.");
                        Console.ReadKey(true);
                    }
                }
                else
                {
                    Console.SetCursorPosition(8, 11);
                    Console.Write("Cliente não encontrado. Pressione uma tecla.");
                    Console.ReadKey(true);
                }


                // Imprime os pedidos realizados

                //int linha = 22;

                //foreach (Pedido pedido in pedidos)
                //{
                //    Console.SetCursorPosition(8, linha);
                //    Console.Write(pedido.ConsultarPedido());
                //    linha += 5; // Ajuste para a próxima linha
                //}
            }
        }

        Console.Clear();
    }
}
