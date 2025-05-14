using Newtonsoft.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class Program
{
    class Quota
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Bmats { get; set; }
        public int Emats { get; set; }
        public int Rmats { get; set; }
        public int Hmats { get; set; }
        public bool IsMassFactory { get; set; }
        public bool IsVehicle { get; set; }

        /// <summary>
        /// Квота
        /// </summary>
        /// <param name="name">Наименование предмета</param>
        /// <param name="quantity">Количество</param>
        /// <param name="bmats">Стоимость БМатов</param>
        /// <param name="emats">Стоимость ЕМатов</param>
        /// <param name="rmats">Стоимость РМатов</param>
        /// <param name="hmats">Стоимость ХМатов</param>
        /// <param name="isMassFactory">Можно ли производить на фабрике массового производства?</param>
        /// <param name="isVehicle">Техника</param>
        public Quota(string name, int quantity, int bmats, int emats, int rmats, int hmats, bool isMassFactory, bool isVehicle)
        {
            Name = name;
            Quantity = quantity;
            Bmats = bmats;
            Emats = emats;
            Rmats = rmats;
            Hmats = hmats;
            IsMassFactory = isMassFactory;
            IsVehicle = isVehicle;
        }
    }

    static void Main()
    {
        Console.Write("Введите количество подразделений: ");
        int? numberOfDivisions = int.Parse(Console.ReadLine());
        List <int> numberOfFighters = new List<int>();

        for (int i = 1; i <= numberOfDivisions; i++)
        {
            Console.Write($"Численность бойцов {i} подразделения: ");
            numberOfFighters.Add(int.Parse(Console.ReadLine()));
        }
        // Чтение данных из txt файла
        List<(string Name, int Quantity)> newQuotasData = ReadQuotasFromTxt("quotas.txt");

        string jsonFilePath = "quotas.json";

        List<Quota> quotas = LoadQuotasFromJson(jsonFilePath);

        // Создание нового массива объектов Quota
        List<Quota> newQuotas = new List<Quota>();

        foreach (var quotaData in newQuotasData)
        {
            var existingQuota = quotas.FirstOrDefault(q => q.Name == quotaData.Name);
            if (existingQuota != null)
            {
                newQuotas.Add(new Quota(existingQuota.Name, quotaData.Quantity, existingQuota.Bmats, existingQuota.Emats, existingQuota.Rmats, existingQuota.Hmats, existingQuota.IsMassFactory, existingQuota.IsVehicle));
            }
        }

        // Разделение на группы
        var groupedQuotas = SplitIntoGroups(newQuotas, numberOfFighters, true);

        // Вывод результатов
        int groupNumber = 1;
        // Название файла с результатами
        string outputPath = "Результат.txt";
        using (StreamWriter writer = new StreamWriter(outputPath))
        {
            foreach (var group in groupedQuotas)
            {
                writer.WriteLine($"Group {groupNumber++}");
                var sum = 0;

                // Создаем словарь для хранения суммы quantity по каждому уникальному Name
                var nameQuantities = new Dictionary<string, int>();

                // Перебираем массив и суммируем quantity для каждого уникального Name
                foreach (var quota in group)
                {
                    if (!nameQuantities.ContainsKey(quota.Name))
                    {
                        nameQuantities[quota.Name] = quota.Quantity;
                    }
                    else
                    {
                        nameQuantities[quota.Name] += quota.Quantity;
                    }
                }

                string header = String.Format("{0,-35} {1,-10} {2,-10} {3,-10} {4,-10} {5,-10}",
                                         "Наименование", "Количетсо", "БМаты", "ЕМаты", "РМаты", "ХЕМаты");
                Console.WriteLine(header);
                Console.WriteLine(new string('-', header.Length));

                foreach (var quota in group)
                {
                    string row = String.Format("{0,-35} {1,-10} {2,-10} {3,-10} {4,-10} {5,-10}",
                                           quota.Name, quota.Quantity, quota.Bmats, quota.Emats, quota.Rmats, quota.Hmats);
                    Console.WriteLine(row);
                }

                string result = String.Format("{0,-35} {1,-10} {2,-10} {3,-10} {4,-10} {5,-10}",
                                       "Суммарный объём квоты", group.Sum(item => item.Quantity), group.Sum(item => item.Bmats), group.Sum(item => item.Emats), group.Sum(item => item.Rmats), group.Sum(item => item.Hmats));

                Console.ForegroundColor = ConsoleColor.Green; // Установка цвета
                Console.WriteLine(result);
                Console.ResetColor(); // Сброс цвета до стандартного
                Console.WriteLine(new string('-', header.Length));

                foreach (var quota in nameQuantities)
                {
                    writer.WriteLine($"{quota.Key} - {quota.Value} ящ.");
                }
                writer.WriteLine();
            }
        }
        Console.WriteLine($"Данные успешно записаны в файл: {outputPath}");
    }

    /// <summary>
    /// Метод для загрузки данных из JSON файла
    /// </summary>
    /// <param name="filePath">Путь к JSON файлу</param>
    /// <returns></returns>
    static List<Quota> LoadQuotasFromJson(string filePath)
    {
        try
        {
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Quota>>(json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при загрузке данных из JSON файла: {ex.Message}");
            return new List<Quota>(); // Возвращаем пустой список в случае ошибки
        }
    }

    /// <summary>
    /// Чтение файла с квотой
    /// </summary>
    /// <param name="filePath">Путь к файлу</param>
    /// <param name="numberOfGroups">Количество групп</param>
    /// <returns>Список квоты</returns>
    /// <exception cref="FormatException"></exception>
    public static List<(string Name, int Quantity)> ReadQuotasFromTxt(string filePath)
    {
        var quotas = new List<(string Name, int Quantity)>();

        using (var reader = new StreamReader(filePath))
        {
            string line = reader.ReadLine();
            if (line != null)
            {
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;

                    // Нормализация строки
                    line = line.Trim();
                    line = Regex.Replace(line, @"\s+", " ");
                    line = line.Replace("–", "-").Replace("—", "-");

                    bool matched = false;

                    // Количественное значение в начале строки
                    Match numberStart = Regex.Match(line, @"^(\d+)\s*(ящ\.|шт\.)\s*[-,]\s*(.+?)\s*$", RegexOptions.IgnoreCase);
                    if (numberStart.Success && int.TryParse(numberStart.Groups[1].Value, out int quantityStart))
                    {
                        string name = numberStart.Groups[3].Value.Trim(' ', '-', ',', '.');
                        quotas.Add((name, quantityStart));
                        matched = true;
                    }

                    // Количественное значение в конце строки
                    if (!matched)
                    {
                        Match nameQuantityMatch = Regex.Match(line, @"^(.+?)\s*[-,]\s*(\d+)\s*(ящ\.|шт\.|кор\.|мм|mm)?\s*$", RegexOptions.IgnoreCase);
                        if (nameQuantityMatch.Success && int.TryParse(nameQuantityMatch.Groups[2].Value, out int quantityName))
                        {
                            string name = nameQuantityMatch.Groups[1].Value.Trim(' ', '-', ',', '.');
                            quotas.Add((name, quantityName));
                        }
                    }
                }
            }
        }

        return quotas;
    }

    /// <summary>
    /// Вычисление и распределение по группам квоты пропорционально количеству бойцов с использованием алгоритма round-robin
    /// </summary>
    /// <param name="quotas">Список с общей квотой</param>
    /// <param name="numberOfFighters">Список численности бойцов в каждом подразделении</param>
    /// <param name="isUsingMassProduct">Флаг использования фабрики массового производства</param>
    /// <returns>Готовый список с квотой</returns>
    static List<List<Quota>> SplitIntoGroups(List<Quota> quotas, List<int> numberOfFighters, bool isUsingMassProduct)
    {
        int numberOfGroups = numberOfFighters.Count;
        var groupedQuotas = new List<List<Quota>>(numberOfGroups);
        var totalFighters = numberOfFighters.Sum();

        List<Quota> splitQuotas = new List<Quota>();

        // Разбивка квот
        foreach (var quota in quotas)
        {
            if (isUsingMassProduct && quota.IsMassFactory && !quota.IsVehicle)
            {
                while (quota.Quantity > 9)
                {
                    splitQuotas.Add(new Quota(quota.Name, 9, CalculationQuota(9, quota.Bmats), CalculationQuota(9, quota.Emats), CalculationQuota(9, quota.Rmats), CalculationQuota(9, quota.Hmats), quota.IsMassFactory, quota.IsVehicle));
                    quota.Quantity -= 9;
                }
                if (quota.Quantity > 0)
                    splitQuotas.Add(new Quota(quota.Name, quota.Quantity, CalculationQuota(quota.Quantity, quota.Bmats), CalculationQuota(quota.Quantity, quota.Emats), CalculationQuota(quota.Quantity, quota.Rmats), CalculationQuota(quota.Quantity, quota.Hmats), quota.IsMassFactory, quota.IsVehicle));
            }
            else if ((!isUsingMassProduct || !quota.IsMassFactory) && !quota.IsVehicle)
            {
                while (quota.Quantity > 4)
                {
                    splitQuotas.Add(new Quota(quota.Name, 4, 4 * quota.Bmats, 4 * quota.Emats, 4 * quota.Rmats, 4 * quota.Hmats, quota.IsMassFactory, quota.IsVehicle));
                    quota.Quantity -= 4;
                }
                if (quota.Quantity > 0)
                    splitQuotas.Add(new Quota(quota.Name, quota.Quantity, quota.Quantity * quota.Bmats, quota.Quantity * quota.Emats, quota.Quantity * quota.Rmats, quota.Quantity * quota.Hmats, quota.IsMassFactory, quota.IsVehicle));
            }
            else if (quota.IsVehicle)
            {
                while (quota.Quantity > 5)
                {
                    splitQuotas.Add(new Quota(quota.Name, 5, CalculationQuota(5, quota.Bmats), CalculationQuota(5, quota.Emats), CalculationQuota(5, quota.Rmats), CalculationQuota(5, quota.Hmats), quota.IsMassFactory, quota.IsVehicle));
                    quota.Quantity -= 5;
                }
                if (quota.Quantity > 0)
                    splitQuotas.Add(new Quota(quota.Name, quota.Quantity, CalculationQuota(quota.Quantity, quota.Bmats), CalculationQuota(quota.Quantity, quota.Emats), CalculationQuota(quota.Quantity, quota.Rmats), CalculationQuota(quota.Quantity, quota.Hmats), quota.IsMassFactory, quota.IsVehicle));
            }
        }

        // Инициализация групп
        for (int i = 0; i < numberOfGroups; i++)
            groupedQuotas.Add(new List<Quota>());

        // Разделение на значимые и нейтральные квоты
        var importantQuotas = splitQuotas.Where(q => q.Bmats > 0).OrderByDescending(q => q.Bmats).ToList();
        var neutralQuotas = splitQuotas.Where(q => q.Bmats == 0).ToList();

        // Пропорциональное распределение важных квот (по численности)
        double totalBmats = importantQuotas.Sum(q => q.Bmats);
        List<double> groupBmatsLimits = numberOfFighters.Select(f => totalBmats * f / totalFighters).ToList();
        List<double> groupCurrentBmats = new List<double>(new double[numberOfGroups]);

        foreach (var quota in importantQuotas)
        {
            int targetGroup = 0;
            double minFillPercent = double.MaxValue;

            for (int i = 0; i < numberOfGroups; i++)
            {
                double percent = groupCurrentBmats[i] / groupBmatsLimits[i];
                if (percent < minFillPercent)
                {
                    minFillPercent = percent;
                    targetGroup = i;
                }
            }

            groupedQuotas[targetGroup].Add(quota);
            groupCurrentBmats[targetGroup] += quota.Bmats;
        }

        // Равномерное распределение нейтральных квот (по кругу)
        int currentNeutralIndex = 0;
        foreach (var quota in neutralQuotas)
        {
            groupedQuotas[currentNeutralIndex].Add(quota);
            currentNeutralIndex = (currentNeutralIndex + 1) % numberOfGroups;
        }

        return groupedQuotas;
    }

    /// <summary>
    /// Рассчёт стоимости для фабрики массового производства
    /// </summary>
    /// <param name="quantity">Количество</param>
    /// <param name="cost">Стоимость</param>
    /// <returns></returns>
    static int CalculationQuota(int quantity, int cost)
    {
        List<double> coefficients = new List<double> { 0.9, 0.8, 0.7, 0.6, 0.5, 0.5, 0.5, 0.5, 0.5 };
        double result = 0;

        for (int i = 0; i < quantity && i < coefficients.Count; i++)
        {
            result += coefficients[i] * cost;
        }

        return (int)Math.Round(result);
    }

}