using System;
using System.Threading;
using System.Threading.Tasks;

namespace WebClient.Infrastructure.ConsoleMenu
{
    public class Item
    {
        bool _selected;

        public int Number { get; set; }
        public string Name { get; }
        public Func<Task> EnterFunction { get; set; }

        public Item(string name)
        {
            Name = name;

            _selected = false;
        }
        public Item(string name, Func<Task> enterFunction) : this(name)
        {
            EnterFunction = enterFunction;
        }

        public void Select(bool value)
        {
            _selected = value;
            Console.SetCursorPosition(0, Number);
            Display();
        }
        public void Display()
        {
            if (_selected)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;

                Console.WriteLine($" {Name} ");

                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine($"  {Name}");
            }
        }
        public async Task Enter()
        {
            await EnterFunction();
            ConsoleHelper.MsgMenuStepOutOrExit();
        }
    }
}
