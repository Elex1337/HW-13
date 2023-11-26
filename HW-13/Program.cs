using System;
using System.Collections.Generic;
using System.Linq;

class Client
{
    public int Id { get; }
    public string Name { get; }
    public string ServiceType { get; }

    public Client(int id, string name, string serviceType)
    {
        Id = id;
        Name = name;
        ServiceType = serviceType;
    }
}

class BankQueue
{
    private Queue<Client> queue = new Queue<Client>();

    public void Enqueue(Client client)
    {
        queue.Enqueue(client);
        Console.WriteLine($"Клиент {client.Name} поставлен в очередь на обслуживание по услуге {client.ServiceType}.");
        DisplayQueue();
    }

    public void ServeNextClient()
    {
        if (queue.Count > 0)
        {
            Client servedClient = queue.Dequeue();
            Console.WriteLine($"Обслужен клиент {servedClient.Name} по услуге {servedClient.ServiceType}.");
            DisplayQueue();
        }
        else
        {
            Console.WriteLine("Очередь пуста. Нет клиентов для обслуживания.");
        }
    }

    private void DisplayQueue()
    {
        Console.WriteLine("Текущая очередь:");
        foreach (var client in queue)
        {
            Console.WriteLine($"Клиент {client.Name}, Услуга: {client.ServiceType}");
        }
    }
}

class Program
{
    static void Main()
    {
        BankQueue bankQueue = new BankQueue();
        int clientIdCounter = 1;

        while (true)
        {
            Console.WriteLine("\nВыберите действие:");
            Console.WriteLine("1. Встать в очередь");
            Console.WriteLine("2. Обслужить следующего клиента");
            Console.WriteLine("3. Выход");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Введите свое имя: ");
                    string name = Console.ReadLine();
                    Console.Write("Выберите услугу (кредит, вклад, консультация и т.д.): ");
                    string serviceType = Console.ReadLine();

                    Client newClient = new Client(clientIdCounter++, name, serviceType);
                    bankQueue.Enqueue(newClient);
                    break;

                case 2:
                    bankQueue.ServeNextClient();
                    break;

                case 3:
                    Console.WriteLine("Выход из программы.");
                    return;

                default:
                    Console.WriteLine("Неверный ввод. Попробуйте еще раз.");
                    break;
            }
        }
    }
}

