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
        }
    }

    static void Main()
    {
        // Хардкод массива объектов Quota
        Quota[] quotas = new Quota[]
        {
            new Quota("Штурмовая винтовка Booker Model 838", 0, 165, 0, 0, 0, true, false),
            new Quota("Штурмовая винтовка Aalto 24", 0, 165, 0, 0, 0, true, false),
            new Quota("7.92-мм", 0, 120, 0, 0, 0, true, false),
            new Quota("Malone MK.2", 0, 0, 0, 25, 0, true, false),
            new Quota("Осколочная граната A3 Harpa", 0, 100, 20, 0, 0, true, false),
            new Quota("Cascadier 873", 0, 60, 0, 0, 0, true, false),
            new Quota("8-mm", 0, 40, 0, 0, 0, true, false),
            new Quota("Cometa T2-9", 0, 60, 0, 0, 0, true, false),
            new Quota("Хангман 757", 0, 125, 0, 0, 0, true, false),
            new Quota(".44", 0, 40, 0, 0, 0, true, false),
            new Quota("Автоматическая винтовка Sampo 77", 0, 125, 0, 0, 0, true, false),
            new Quota("Blacherow 871", 0, 140, 0, 0, 0, true, false),
            new Quota("Clancy cinder M3", 0, 130, 0, 0, 0, true, false),
            new Quota("No.2B hawthorne", 0, 70, 0, 0, 0, true, false),
            new Quota("No.2 Loughcaster", 0, 100, 0, 0, 0, true, false),
            new Quota("Clancy-Raca M4", 0, 200, 0, 15, 0, true, false),
            new Quota("7.62-мм", 0, 80, 0, 0, 0, true, false),
            new Quota("Дробовик Brasa", 0, 80, 0, 0, 0, true, false),
            new Quota("Дробь", 0, 80, 0, 0, 0, true, false),
            new Quota("Пистолет-пулемет No.1 \"The Liar\"", 0, 120, 0, 0, 0, true, false),
            new Quota("Пистолет-пулемет Fiddler Model 868", 0, 120, 0, 0, 0, true, false),
            new Quota("9-мм", 0, 80, 0, 0, 0, true, false),
            new Quota("Дымовая граната PT-815", 0, 120, 0, 0, 0, true, false),
            new Quota("Газовая граната", 0, 140, 0, 0, 0, true, false),
            new Quota("12.7-мм", 0, 100, 0, 0, 0, true, false),

            new Quota("Противотанковое ружье Neville 20", 0, 150, 0, 0, 0, true, false),
            new Quota("20-мм", 0, 100, 0, 0, 0, true, false),
            new Quota("Станковый Bonesaw MK.3", 0, 100, 0, 5, 0, true, false),
            new Quota("Bonesaw MK.3", 0, 100, 0, 0, 0, true, false),
            new Quota("Навесная кумулятивная граната", 0, 60, 75, 0, 0, true, false),
            new Quota("Willow's Bane Model 845", 0, 165, 0, 30, 0, true, false),
            new Quota("Граната Tremola Gpb-1", 0, 75, 50, 0, 0, true, false),
            new Quota("Malone Ratcatcher MK.1", 0, 100, 0, 5, 0, true, false),
            new Quota("30-mm", 0, 80, 20, 0, 0, true, false),
            new Quota("Мортира Cremari", 0, 100, 0, 0, 0, true, false),
            new Quota("Осветительный Минометный Снаряд", 0, 60, 0, 0, 0, true, false),
            new Quota("Осколочный Минометный Снаряд", 0, 60, 15, 0, 0, true, false),
            new Quota("Минометный Снаряды", 0, 60, 35, 0, 0, true, false),
            new Quota("BF5 White Ash Flask Grenade", 0, 100, 40, 0, 0, true, false),
            new Quota("Mammon 91-b", 0, 100, 0, 0, 0, true, false),
            new Quota("Противотанковая Липкая Бомба", 0, 50, 50, 0, 0, true, false),
            new Quota("Catler Foebreaker", 0, 100, 0, 5, 0, true, false),
            new Quota("Cutler Launcher 4", 0, 100, 0, 35, 0, true, false),
            new Quota("РПГ", 0, 60, 45, 0, 0, true, false),

            new Quota("150-мм", 0, 120, 0, 0, 0, true, false),
            new Quota("120-мм", 0, 60, 15, 0, 0, true, false),
            new Quota("250-мм", 0, 120, 0, 0, 0, true, false),
            new Quota("68-мм", 0, 120, 120, 0, 0, true, false),
            new Quota("40-мм", 0, 160, 120, 0, 0, true, false),

            new Quota("Припасы обслуживания", 0, 250, 0, 0, 0, true, false),

            new Quota("Шинель Специалиста", 0, 100, 0, 0, 0, true, false),
            new Quota("Стальная кираса", 0, 100, 0, 0, 0, true, false),
            new Quota("Саперное снаряжение", 0, 100, 0, 0, 0, true, false),
            new Quota("Куртка врача", 0, 100, 0, 0, 0, true, false),
            new Quota("Офицерская регалия", 0, 100, 0, 0, 0, true, false),
            new Quota("Дозорная мантия", 0, 100, 0, 0, 0, true, false),
            new Quota("Caovish Парка", 0, 100, 0, 0, 0, true, false),
            new Quota("Стеганный Комбинезон", 0, 100, 0, 0, 0, true, false),

            new Quota("Колючая проволока", 0, 15, 0, 0, 0, false, false),
            new Quota("Бинокль", 0, 75, 0, 0, 0, false, false),
            new Quota("Хавок Заряд", 0, 75, 0, 0, 0, false, false),
            new Quota("Топливо для Willow's Bane", 0, 135, 0, 0, 5, false, false),
            new Quota("Набор для прослушивания", 0, 150, 0, 0, 0, false, false),
            new Quota("Металлическая балка", 0, 25, 0, 0, 0, false, false),
            new Quota("Радиорюкзак", 0, 150, 0, 0, 0, false, false),
            new Quota("Мешок с песком", 0, 15, 0, 0, 0, false, false),
            new Quota("Детонатор Хавок Заряда", 0, 75, 0, 0, 5, false, false),
            new Quota("Alligator Charge", 0, 150, 80, 0, 0, false, false),
            new Quota("Лопата", 0, 200, 0, 0, 0, false, false),
            new Quota("Кувалда", 0, 200, 0, 0, 0, false, false),
            new Quota("Abisme AT-99", 0, 100, 0, 0, 0, false, false),
            new Quota("Тренога", 0, 100, 0, 0, 0, false, false),
            new Quota("Ключ", 0, 75, 0, 0, 0, false, false),
            new Quota("Ведро для воды", 0, 80, 0, 0, 0, false, false),
            new Quota("Buckhorn CCQ-18", 0, 40, 0, 0, 0, false, false),
            new Quota("Противогаз", 0, 160, 0, 0, 0, false, false),
            new Quota("Фильтр для противогаза", 0, 100, 0, 0, 0, false, false),
            new Quota("Osrpeay", 0, 85, 0, 0, 0, false, false),
            new Quota("Рация", 0, 75, 0, 0, 0, false, false),

            new Quota("Бинты", 0, 80, 0, 0, 0, false, false),
            new Quota("Набор Первой Помощи", 0, 60, 0, 0, 0, false, false),
            new Quota("Реанимационный набор", 0, 80, 0, 0, 0, false, false),
            new Quota("Плазма", 0, 80, 0, 0, 0, false, false),
            new Quota("Солдатское снаряжение", 0, 100, 0, 0, 0, false, false)

        };

        int numberOfGroups;
        // Чтение данных из txt файла
        List<(string Name, int Quantity)> newQuotasData = ReadQuotasFromTxt("quotas.txt", out numberOfGroups);

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
        var groupedQuotas = SplitIntoGroups(newQuotas, 4, true);

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
    /// Чтение файла с квотой
    /// </summary>
    /// <param name="filePath">Путь к файлу</param>
    /// <param name="numberOfGroups">Количество групп</param>
    /// <returns>Список квоты</returns>
    /// <exception cref="FormatException"></exception>
    public static List<(string Name, int Quantity)> ReadQuotasFromTxt(string filePath, out int numberOfGroups)
    {
        var quotas = new List<(string Name, int Quantity)>();
        numberOfGroups = 0;

        using (var reader = new StreamReader(filePath))
        {
            string line = reader.ReadLine();
            if (line != null)
            {
                var parts = line.Split('-');
                if (parts.Length == 2 && int.TryParse(parts[1].Trim(), out int result))
                {
                    numberOfGroups = result;
                }
                else
                {
                    throw new FormatException("Отсутствует количество групп/участников для квоты.");
                }

                while ((line = reader.ReadLine()) != null)
                {
                    parts = line.Split(',');
                    if (parts.Length == 2 && int.TryParse(parts[1].Trim(), out int quantity))
                    {
                        var name = parts[0].Trim();
                        quotas.Add((name, quantity));
                    }
                }
            }
        }

        return quotas;
    }

    /// <summary>
    /// Вычисление и распределение по группам квоты
    /// </summary>
    /// <param name="quotas">Список с общей квотой</param>
    /// <param name="numberOfGroups">Количество групп для распределения</param>
    /// <param name="isUsingMassProduct">Флаг использование фабрики массвого производства</param>
    /// <returns></returns>
    static List<List<Quota>> SplitIntoGroups(List<Quota> quotas, int numberOfGroups, bool isUsingMassProduct)
    {
        var groupedQuotas = new List<List<Quota>>(numberOfGroups);

        List<Quota> splitQuotas = new List<Quota>();

        // Сплит квот по группам
        foreach (var quota in quotas)
        {
            //С учётом фабрики массового производства
            if (isUsingMassProduct && quota.IsMassFactory && !quota.IsVehicle)
            {
                while (quota.Quantity > 9)
                {
                    var newQuota = new Quota(quota.Name, 9, CalculationQuota(9, quota.Bmats), CalculationQuota(9, quota.Emats), CalculationQuota(9, quota.Rmats), CalculationQuota(9, quota.Hmats), quota.IsMassFactory, quota.IsVehicle);
                    splitQuotas.Add(newQuota);
                    quota.Quantity -= 9;
                }
                splitQuotas.Add(new Quota(quota.Name, quota.Quantity, CalculationQuota(quota.Quantity, quota.Bmats), CalculationQuota(quota.Quantity, quota.Emats), CalculationQuota(quota.Quantity, quota.Rmats), CalculationQuota(quota.Quantity, quota.Hmats), quota.IsMassFactory, quota.IsVehicle));
            }

            //Обычная фабрика
            if ((!isUsingMassProduct || !quota.IsMassFactory) && !quota.IsVehicle)
            {
                while (quota.Quantity > 4)
                {
                    var newQuota = new Quota(quota.Name, 4, 4 * quota.Bmats, 4 * quota.Emats, 4 * quota.Rmats, 4 * quota.Hmats, quota.IsMassFactory, quota.IsVehicle);
                    splitQuotas.Add(newQuota);
                    quota.Quantity -= 4;
                }
                splitQuotas.Add(new Quota(quota.Name, quota.Quantity, quota.Quantity * quota.Bmats, quota.Quantity * quota.Emats, quota.Quantity * quota.Rmats, quota.Quantity * quota.Hmats, quota.IsMassFactory, quota.IsVehicle));
            }

            //Техника и коробочки
            if (quota.IsVehicle)
            {
                while (quota.Quantity > 5)
                {
                    var newQuota = new Quota(quota.Name, 5, CalculationQuota(5, quota.Bmats), CalculationQuota(5, quota.Emats), CalculationQuota(5, quota.Rmats), CalculationQuota(5, quota.Hmats), quota.IsMassFactory, quota.IsVehicle);
                    splitQuotas.Add(newQuota);
                    quota.Quantity -= 5;
                }
                splitQuotas.Add(new Quota(quota.Name, quota.Quantity, CalculationQuota(quota.Quantity, quota.Bmats), CalculationQuota(quota.Quantity, quota.Emats), CalculationQuota(quota.Quantity, quota.Rmats), CalculationQuota(quota.Quantity, quota.Hmats), quota.IsMassFactory, quota.IsVehicle));
            }
        }

        // Инициализация групп
        for (int i = 0; i < numberOfGroups; i++)
        {
            groupedQuotas.Add(new List<Quota>());
        }

        // Сортировка по Bmats
        var sortedQuotas = splitQuotas.OrderByDescending(q => q.Bmats);
        //q.Quantity * q.Bmats + q.Quantity * q.Emats * ratio + q.Quantity * q.Rmats + q.Quantity * q.Hmats);

        // Распределение по группам
        foreach (var quota in sortedQuotas)
        {
            var minGroup = groupedQuotas.OrderBy(g => g.Sum(q => q.Bmats)).First();
         //q.Quantity* q.Bmats + q.Quantity * q.Emats * ratio + q.Quantity * q.Rmats + q.Quantity * q.Hmats)).First();
            minGroup.Add(quota);
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

        double results = 0;

        for (int i = 0; i < quantity;  i++)
        {
            results += coefficients[i] * cost;
        }

        return (int)results;
    }
}