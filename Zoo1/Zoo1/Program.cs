using System;
using System.Collections.Generic;

namespace Zoo1
{
    class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();
            zoo.OpenMenu();
        }
    }

    class Zoo
    {
        private List<Aviary> _aviaries = new List<Aviary>();
        private List<Animal> _herbivores = new List<Animal>();
        private List<Animal> _aniPredatorymals = new List<Animal>();
        private List<Animal> _woter = new List<Animal>();
        private List<Animal> _air = new List<Animal>();

        public Zoo()
        {
            _aviaries.Add(new Aviary("Травоядный вальер", _herbivores));
            _aviaries.Add(new Aviary("Хищный вальер", _aniPredatorymals));
            _aviaries.Add(new Aviary("Водный вальер", _woter));
            _aviaries.Add(new Aviary("Воздушный вальер", _air));
            _herbivores.Add(new Animal("Лошадь", "муж", "И-го-го"));
            _herbivores.Add(new Animal("Коза", "жен", "Ме-е-е-е или Бе-е-е-е"));
            _herbivores.Add(new Animal("Зебра", "жен", "ахает -ахает"));
            _herbivores.Add(new Animal("Осёл", "муж", "Ии-а Ии-а"));
            _herbivores.Add(new Animal("Корова", "жен", "Му-у-у-у"));
            _aniPredatorymals.Add(new Animal("Тигр", "жен", "рычание"));
            _aniPredatorymals.Add(new Animal("Медведь", "жен", "ревение"));
            _aniPredatorymals.Add(new Animal("Волк", "муж", "вой"));
            _aniPredatorymals.Add(new Animal("Леопард", "жен", "рычание"));
            _aniPredatorymals.Add(new Animal("Лев", "муж", "рык"));
            _aniPredatorymals.Add(new Animal("Гиена", "жен", "лай"));
            _woter.Add(new Animal("Сом", "муж", "бульканье"));
            _woter.Add(new Animal("Клоун", "муж", "бульканье"));
            _woter.Add(new Animal("Акула", "жен", "бульканье"));
            _woter.Add(new Animal("Скат", "жен", "бульканье"));
            _air.Add(new Animal("Орёл", "жен", "клёкот"));
            _air.Add(new Animal("Кукушка", "муж", "Ку-ку ку-ку"));
            _air.Add(new Animal("Стервятник", "муж", "Скрепящее-свистящее мяуканье"));
        }

        public void OpenMenu()
        {
            bool isWork = true;
            string userInput;

            while (isWork == true)
            {
                Console.WriteLine("Добро пожаловать в зоопарк!!!\n1 - показать все вальеры\n2 - выбрать вальер\n3 - выход");
                Console.Write("Введите команду: ");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ShowAviary();
                        break;
                    case "2":
                        ChooseAnAviary();
                        break;
                    case "3":
                        isWork = false;
                        break;
                    default:
                        Console.WriteLine("Не верный ввод");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void ShowAviary()
        {
            Console.Clear();
            Console.WriteLine("Вальеры: ");

            for (int i = 0; i < _aviaries.Count; i++)
            {
                Console.Write((i + 1) + ". ");
                Console.WriteLine(_aviaries[i].Name);
            }
        }

        private void ChooseAnAviary()
        {
            string userInput;
            ShowAviary();
            Console.WriteLine("\nНа какой вальер хотите посмотреть поближе?");
            Console.Write("Введите название вальера: ");
            userInput = Console.ReadLine();

            for (int i = 0; i < _aviaries.Count; i++)
            {
                if (_aviaries[i].Name.ToLower() == userInput.ToLower())
                {
                    _aviaries[i].ShowAviary();
                }
            }
        }
    }

    class Aviary
    {
        private List<Animal> _animals;

        public string Name { get; protected set; }

        public Aviary(string name, List<Animal> animals)
        {
            Name = name;
            _animals = animals;
        }

        public void ShowAviary()
        {
            Console.Clear();
            Console.WriteLine(Name);
            FindNumberOfAnimals();
            Console.WriteLine("Животные:");

            for (int i = 0; i < _animals.Count; i++)
            {
                _animals[i].ShowAnimal();
            }
        }

        public int FindNumberOfAnimals()
        {
            int numderOfAnimals = 0;

            for (int i = 0; i < _animals.Count; i++)
            {
                numderOfAnimals++;
            }
            Console.WriteLine($"В вальере обитает - {numderOfAnimals} животных\n");
            return numderOfAnimals;
        }
    }

    class Animal
    {
        private string _gender;
        private string _sound;
        public string Name { get; private set; }

        public Animal(string name, string genden, string sound)
        {
            Name = name;
            _gender = genden;
            _sound = sound;
        }

        public void ShowAnimal()
        {
            Console.WriteLine($"Животное - {Name}, пол - {_gender}, издаёт звук - {_sound}");
        }
    }
}

