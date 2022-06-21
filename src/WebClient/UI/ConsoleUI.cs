using System;
using System.Threading.Tasks;
using WebClient.HttpClients;
using WebClient.Infrastructure.ConsoleMenu;
using WebClient.Infrastructure.Generator;

namespace WebClient.UI
{
    public class ConsoleUI : IConsoleUI
    {
        private readonly IGenerator _generator;
        private readonly ICustomerHttpClient _customerHttpClient;

        Menu menu;

        public ConsoleUI(IGenerator generator, ICustomerHttpClient customerHttpClient)
        {
            _generator = generator;
            _customerHttpClient = customerHttpClient;

            // инициализация меню
            menu = new Menu("WebClient \"Customers\"");
            menu.Add(new Item("Получить данные \"Customer\" по \"Id\"", ReadCustomerInfoByIdAsync));
            menu.Add(new Item("Добавить случайного \"Customer\"", CreateRandomCustomerAsync));
        }
        public void Run()
        {
            // обновление меню по действиям от пользователя
            menu.Updating();
        }

        public async Task ReadCustomerInfoByIdAsync()
        {
            Console.Write("Введите Id: ");

            var id = Console.ReadLine();
            if (!long.TryParse(id, out var result))
            {
                ConsoleHelper.MsgError("Ошибка! Введен некорректный Id!");
                return;
            }

            try
            {
                var customer = await _customerHttpClient.ReadAsync(id);
                Console.WriteLine(customer.ToString());
            }
            catch (Exception ex)
            {
                if(ex.Message.Contains("Response status code does not indicate success: 500"))
                    ConsoleHelper.MsgError("\"Customer\" с таким Id не найден!");
                else
                    ConsoleHelper.MsgError(ex.Message);
            }
        }

        public async Task CreateRandomCustomerAsync()
        {
            var newCustomer = _generator.NewCustomer();
            try
            {
                var id = await _customerHttpClient.CreateAsync(newCustomer);
                Console.WriteLine($"Id: {id}");

                var customer = await _customerHttpClient.ReadAsync(id);
                Console.WriteLine(customer.ToString());
            }
            catch (Exception ex)
            {
                ConsoleHelper.MsgError(ex.Message);
            }
        }
    }
}
