using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient.Infrastructure.Generator
{
    public class Generator : IGenerator
    {
        private static Random _rand = new Random(DateTime.Now.Millisecond);

        private enum Gender { Female, Male }

        private static string[] _namesFemale = new string[20]
        {
            "Александра", "Вера", "Галина", "Дарья", "Екатерина",
            "Жанна", "Зоя", "Ирина", "Ксения", "Любовь",
            "Мария", "Наталья", "Ольга", "Полина", "Роза",
            "Светлана", "Татьяна", "Ульяна", "Юлия", "Яна"
        };
        private static string[] _namesMale = new string[20]
        {
            "Александр", "Борис", "Владимир", "Григорий", "Дмитрий",
            "Евгений", "Захар", "Иван", "Кирилл", "Леонид",
            "Михаил", "Никита", "Олег", "Павел", "Роман",
            "Сергей", "Тимофей", "Федор", "Эдуард", "Юрий"
        };

        private static string[] _lastNames = new string[20]
        {
            "Иванов", "Смрнов", "Кузнецов", "Попов", "Васильев",
            "Петров", "Соколов", "Михайлов", "Новиков", "Федоров",
            "Морозов", "Волков", "Алексеев", "Лебедев", "Семенов",
            "Егоров", "Павлов", "Степанов", "Орлов", "Зайцев"
        };

        public Customer NewCustomer()
        {
            string name;
            string lastname;
            int iLastNames = _rand.Next(_lastNames.Length);
            Gender iGender = (Gender)_rand.Next(Enum.GetNames(typeof(Gender)).Length);

            if (iGender == Gender.Male)
            {
                int iNames = _rand.Next(_namesMale.Length);
                name = _namesMale[iNames];
                lastname = _lastNames[iLastNames];
            }
            else
            {
                int iNames = _rand.Next(_namesFemale.Length);
                name = _namesFemale[iNames];
                lastname = _lastNames[iLastNames] + "а";
            }

            return new Customer { Firstname = name, Lastname = lastname };
        }
    }
}
