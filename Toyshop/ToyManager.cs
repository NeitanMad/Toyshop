using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toyshop
{
    internal class ToyManager
    {
        private List<Toy> toys;
        private List<Toy> prizeList;
        private string fileName = "prize_log.txt";

        public ToyManager()
        {
            toys = new List<Toy>();
            prizeList = new List<Toy>();
        }

        /// <summary>
        /// Добавляет новую игрушку или обновляет существующую.
        /// </summary>
        /// <param name="id">Идентификатор игрушки</param>
        /// <param name="name">Название игрушки</param>
        /// <param name="quantity">Количество игрушек</param>
        /// <param name="frequency">Вес (частота выпадения) игрушки</param>
        public void AddToy(int id, string name, int quantity, int frequency)
        {
            // Проверяем, что количество и вес игрушки положительные
            if (quantity <= 0 || frequency <= 0)
            {
                Console.WriteLine("Количество и вес игрушки должны быть больше 0.");
                return;
            }

            // Проверяем, что игрушка с таким ID уже существует
            Toy existingToy = toys.Find(t => t.Id == id);
            if (existingToy != null)
            {
                // Обновляем существующую игрушку
                existingToy.Quantity = quantity;
                existingToy.Frequency = frequency;
                Console.WriteLine($"Игрушка '{existingToy.Name}' обновлена.");
            }
            else
            {
                // Добавляем новую игрушку
                Toy newToy = new Toy(id, name, quantity, frequency);
                toys.Add(newToy);
                Console.WriteLine($"Игрушка '{newToy.Name}' добавлена.");
            }
        }

        /// <summary>
        /// Изменяет вес (частоту выпадения) игрушки.
        /// </summary>
        /// <param name="id">Идентификатор игрушки</param>
        /// <param name="frequency">Новый вес игрушки</param>
        public void ChangeToyWeight(int id, int frequency)
        {
            // Проверяем, что вес игрушки положительный
            if (frequency <= 0)
            {
                Console.WriteLine("Вес игрушки должен быть больше 0.");
                return;
            }

            Toy toy = toys.Find(t => t.Id == id);
            if (toy != null)
            {
                toy.Frequency = frequency;
                Console.WriteLine($"Вес игрушки '{toy.Name}' изменен на {frequency}.");
            }
            else
            {
                Console.WriteLine($"Игрушка с ID {id} не найдена.");
            }
        }

        /// <summary>
        /// Разыгрывает случайную призовую игрушку.
        /// Добавляет выигранную игрушку в список призовых игрушек.
        /// </summary>
        public void DrawPrize()
        {
            int totalFrequency = 0;
            foreach (var toy in toys)
            {
                totalFrequency += toy.Frequency;
            }

            int rand = new Random().Next(1, totalFrequency + 1);
            int currentWeight = 0;
            foreach (var toy in toys)
            {
                currentWeight += toy.Frequency;
                if (rand <= currentWeight)
                {
                    if (toy.Quantity > 0)
                    {
                        prizeList.Add(toy);
                        toy.Quantity--;
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// Выдает первую призовую игрушку из списка, записывает её в файл и возвращает.
        /// </summary>
        /// <returns>Призовая игрушка или null, если нет призовых игрушек</returns>
        public Toy GetPrize()
        {
            if (prizeList.Count > 0)
            {
                Toy prize = prizeList[0];
                prizeList.RemoveAt(0);
                SavePrizeToFile(prize);
                return prize;
            }
            return null;
        }

        /// <summary>
        /// Возвращает количество добавленных игрушек
        /// </summary>
        /// <returns>Количество добавленых игрушек</returns>
        public int GetToyCount()
        {
            return toys.Count;
        }

        /// <summary>
        /// Сохраняет информацию о выданной призовой игрушке в файл.
        /// </summary>
        /// <param name="prize">Призовая игрушка</param>
        private void SavePrizeToFile(Toy prize)
        {
            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine($"Выдана игрушка: {prize.Name}");
            }
        }
    }
}
