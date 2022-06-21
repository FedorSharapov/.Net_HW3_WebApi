using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebClient.Infrastructure.ConsoleMenu
{
    public class Menu
    {
        List<Item> _items;
        int _selNumItem;

        public Menu(string headerName = "")
        {
            Console.Title = headerName;
            Console.CursorVisible = false;

            _items = new List<Item>();
            _selNumItem = 0;
        }

        public void Add(Item item)
        {
            _items.Add(item);
            item.Number = _items.Count - 1;

            if (_items.Count == 1)
                _items[0].Select(true);
        }

        public void Display()
        {
            Console.Clear();

            foreach (var i in _items)
                i.Display();

            ConsoleHelper.MsgMenuControl();
        }

        private void Navigation(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.DownArrow:
                    StepDown();
                    break;
                case ConsoleKey.UpArrow:
                    StepUp();
                    break;
                case ConsoleKey.Enter:
                    StepIn();
                    break;
                case ConsoleKey.Escape:
                    Exit();
                    break;
            }
        }
        private void StepDown()
        {
            _items[_selNumItem].Select(false);

            if (_selNumItem == _items.Count - 1)
                _selNumItem = 0;
            else
                _selNumItem++;

            _items[_selNumItem].Select(true);
        }
        private void StepUp()
        {
            _items[_selNumItem].Select(false);

            if (_selNumItem == 0)
                _selNumItem = _items.Count - 1;
            else
                _selNumItem--;

            _items[_selNumItem].Select(true);
        }
        private void StepIn()
        {
            Display();

            ConsoleHelper.DisplayHeader(_items[_selNumItem].Name);
            _items[_selNumItem].Enter();

            WaitingStepOut();
        }
        private void WaitingStepOut()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey().Key;
                    if (key == ConsoleKey.Backspace)
                    {
                        Display();
                        break;
                    }
                    else if (key == ConsoleKey.Escape)
                        Exit();
                }
            }
        }

        public void Updating()
        {
            Display();

            while (true)
            {
                if (Console.KeyAvailable)
                    Navigation(Console.ReadKey(true).Key);
            }
        }

        private void Exit()
        {
            Environment.Exit(0);
        }
    }
}
