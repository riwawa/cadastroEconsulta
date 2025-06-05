using System;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void menu()
    {
        Console.WriteLine("=======================/ Menu /=======================");
        Console.WriteLine("1 - Cadastrar");
        Console.WriteLine("2 - Listar todos os cadastros");
        Console.WriteLine("3 - Buscar Cliente");
        Console.WriteLine("4 - Sair");
        Console.WriteLine("Faça sua escolha:");
    }

    class Cliente
    {
        private static int ultimoId = 0; 

        public int id { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public string endereco { get; set; }

        public Cliente(string nome, string cpf, string telefone, string email, string endereco)
        {
            this.id = ++ultimoId;  
            this.nome = nome;
            this.cpf = cpf;
            this.telefone = telefone;
            this.email = email;
            this.endereco = endereco;
        }

        public override string ToString()
        {
            return $"ID: {id}, " +
                   $"Nome: {nome}, " +
                   $"CPF: {cpf}, " +
                   $"Telefone: {telefone}, " +
                   $"Email: {email}, " +
                   $"Endereço: {endereco}";
        }
    }

    static void Main(string[] args)
    {
        List<Cliente> listaClientes = new List<Cliente>();

        bool sair = false;

        while (!sair)
        {
            menu();

            if(!int.TryParse(Console.ReadLine(), out int opcao))
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
                continue;
            }

            switch (opcao)
            {
                case 1:
                    Console.Write("Nome: ");
                    string nome = Console.ReadLine();

                    Console.Write("CPF: ");
                    string cpf = Console.ReadLine();

                    Console.Write("Telefone: ");
                    string telefone = Console.ReadLine();

                    Console.Write("Email: ");
                    string email = Console.ReadLine();

                    Console.Write("Endereço: ");
                    string endereco = Console.ReadLine();

                    Cliente novoCliente = new Cliente(nome, cpf, telefone, email, endereco);

                    listaClientes.Add(novoCliente);
                    Console.WriteLine("Cliente cadastrado com sucesso!");
                    break;

                case 2:
                    if (listaClientes.Count == 0)
                    {
                        Console.WriteLine("Nenhum cliente cadastrado.");
                    }
                    else
                    {
                        Console.WriteLine("Lista de clientes:");
                        foreach (var cliente in listaClientes)
                        {
                            Console.WriteLine(cliente);
                        }
                    }
                    break;

                case 3:
                    Console.Write("Qual ID do cliente deseja buscar?: ");
                    if (int.TryParse(Console.ReadLine(), out int buscaID))
                    {
                        Cliente clienteEncontrado = listaClientes.Find(c => c.id == buscaID);
                        if (clienteEncontrado != null)
                        {
                            Console.WriteLine("Cliente encontrado:");
                            Console.WriteLine(clienteEncontrado);
                        }
                        else
                        {
                            Console.WriteLine("Cliente não encontrado.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("ID inválido.");
                    }
                    break;

                case 4:
                    sair = true;
                    Console.WriteLine("Saindo...");
                    break;

                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
            Console.WriteLine(); 
        }
    }
}
