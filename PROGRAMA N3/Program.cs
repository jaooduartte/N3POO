﻿/*
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
                    Console.Write("Qual o motivo        : ");
                    string mot = Console.ReadLine();

                    Console.SetCursorPosition(11, 11);
                    Console.Write("Quantidade           : ");
                    decimal val = decimal.Parse(Console.ReadLine());

                    Console.SetCursorPosition(11, 12);
                    Console.Write("Confirma? (Y/N)      : ");
                    string resp = Console.ReadLine().ToUpper();

                    if (resp == "Y")
                    {
                        if (tip == "S") bancoDados[x].fazerSaida(val, DateTime.Now, mot);
                        if (tip == "E") bancoDados[x].fazerEntrada(val, DateTime.Now, mot);
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
                Console.Write($"Nº Cliente                 : {con}");

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

            if (opcao == "6")
            {
                tela.montarMoldura(7, 7, 60, 13, "Novo pedido");

                //Pergunta o numero do produto
                Console.SetCursorPosition(8, 9);
                string con = Pedido.proximoPedido.ToString();
                Console.Write($"Pedido                     : {con}");

                //Pergunta o nome do produto
                Console.SetCursorPosition(8, 10);
                Console.Write("Numero Cliente                   : ");
                decimal numC = Console.Read();

                Console.SetCursorPosition(8, 11);
                Console.Write("Numero Produto                   : ");
                decimal numP = Console.Read();

                Console.SetCursorPosition(8, 12);
                Console.Write("Quantidade do Pedido             : ");
                decimal qtdP = Console.Read();

                //Solicita a confirmação para cadastro
                Console.SetCursorPosition(8, 11);
                Console.Write("Confirma novo pedido? (S/N): ");
                string res = Console.ReadLine();

                if (res.ToUpper() == "S")
                {
                    //Armazena novo produto no BANCO DE DADOS
                    pedidos.Add(new Pedido(con, numC, numP, qtdP));


                }
            }
        }
        Console.Clear();
    }
}
