/* 
--------------------DotnetDev.Homework.7--------------------
1. Программа запрашивает с сервера данные пользователя по его Id;
2. Программа генерирует случайным образом данные для создания нового "Клиента" и отправляет запрос на сервер;
3. Программа запрашивает данные "Клиента" с сервера по полученному ID от сервера.

Управление:
- DownArrow: шаг по меню вниз;
- UpArrow: шаг по меню вврех;
- Enter: вход в меню;
- Backspace: для возврата в основное меню;
- Escape: выход из программы.
 */

using System;
using System.Threading.Tasks;
using WebClient.HttpClients;
using Microsoft.Extensions.DependencyInjection;
using WebClient.Infrastructure.Generator;
using WebClient.UI;

namespace WebClient
{
    static class Program
    {
        static ServiceProvider services;
        static async Task Main(string[] args)
        {
            var provider = ConfigureServices();
            var webClient = provider.GetService<IConsoleUI>();

            webClient.Run();
        }
        private static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<IGenerator, Generator>();
            serviceCollection.AddHttpClient<ICustomerHttpClient, CustomerHttpClient>();
            serviceCollection.AddSingleton<IConsoleUI, ConsoleUI>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}