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
            menu.Add(new Item("Получить данные по \"Id\"", GetCustomerAsync));
            menu.Add(new Item("Сгенерировать случайного \"Customer\"", PostRandomCustomerAsync));
        }
        public void Run()
        {
            // обновление меню по действиям от пользователя
            menu.Updating();
        }

        private async Task GetCustomerAsync()
        {
            Console.Write("Введите Id: ");
            try
            {
                var id = long.Parse(Console.ReadLine());
                var customer = await _customerHttpClient.GetCustomerAsync(id);

                Console.WriteLine(customer.ToString());
            }
            catch (Exception ex)
            {
                if( ex.Message.Contains("Response status code does not indicate success: 500"))
                    ConsoleHelper.MsgError("\"Customer\" с таким Id не найден!");
                else
                    ConsoleHelper.MsgError(ex.Message); 
            }
        }

        private async Task PostRandomCustomerAsync()
        {
            try
            {
                var newCustomer = _generator.NewCustomer();
                var id = await _customerHttpClient.CreateCustomerAsync(newCustomer);
                Console.WriteLine($"Id: {id}");

                var customer = await _customerHttpClient.GetCustomerAsync(id);
                Console.WriteLine(customer.ToString());
            }
            catch (Exception ex)
            {
                ConsoleHelper.MsgError(ex.Message);
            }
        }
    }
}
