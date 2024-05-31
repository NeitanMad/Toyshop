namespace Toyshop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ToyManager manager = new ToyManager();

            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Добавить игрушку (или изменить по ID)");
                Console.WriteLine("2. Разыграть призовую игрушку");
                Console.WriteLine("3. Выдать призовую игрушку");
                Console.WriteLine("4. Выход");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Введите ID игрушки: ");
                        string idInput = Console.ReadLine();
                        int id;
                        if (!int.TryParse(idInput, out id) || id <= 0)
                        {
                            Console.WriteLine("Некорректный ID игрушки. ID должен быть целым положительным числом.");
                            break;
                        }

                        Console.Write("Введите название игрушки: ");
                        string name = Console.ReadLine();

                        Console.Write("Введите количество игрушек: ");
                        int quantity = int.Parse(Console.ReadLine());

                        Console.Write("Введите вес (частоту выпадения) игрушки: ");
                        int weight = int.Parse(Console.ReadLine());

                        manager.AddToy(id, name, quantity, weight);
                        break;

                    case 2:
                        if (manager.GetToyCount() > 0)
                        {
                            manager.DrawPrize();
                            Console.WriteLine("Призовая игрушка разыграна.");
                        }
                        else
                        {
                            Console.WriteLine("Нет добавленных игрушек.");
                        }
                        break;

                    case 3:
                        Toy prize = manager.GetPrize();
                        if (prize != null)
                        {
                            Console.WriteLine($"Выдана игрушка: {prize.Name}");
                        }
                        else
                        {
                            Console.WriteLine("Нет призовых игрушек.");
                        }
                        break;

                    case 4:
                        return;

                    default:
                        Console.WriteLine("Неверный выбор.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}
