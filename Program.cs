int elementCount = 16_000_000;
int stepCount = 2;
int bytesPerElement = 4;
double bytesPerMiB = 1024.0 * 1024;
List<int[]> blocks = new List<int[]>();

long startMemory = Environment.WorkingSet;
Console.WriteLine($"Шаг 0. Рабочий набор: {startMemory / bytesPerMiB:F2} MiB");

for ( byte step = 1; step <= stepCount; step++)
        {
            Console.WriteLine("Нажмите Enter, чтобы добавить блок данных.");
            Console.ReadLine();

            int[] block = new int[elementCount];
            for (int i = 0; i < block.Length; i++)
            {
                block[i] = 1_000_000;
            }
            blocks.Add(block);

            long currentMemory = Environment.WorkingSet;
            long dataBytes = 1L * blocks.Count * elementCount * bytesPerElement;
            Console.WriteLine($"Шаг {step}. Сохранено массивов: {blocks.Count}");
            Console.WriteLine($"Объём элементов: {dataBytes / bytesPerMiB:F2} MiB");
            Console.WriteLine($"Рабочий набор: {currentMemory / bytesPerMiB:F2} MiB");
            Console.WriteLine($"Изменение от начала: {(currentMemory - startMemory) / bytesPerMiB:F2} MiB");
        }

        Console.WriteLine("Данные сохранены в памяти. Нажмите Enter для завершения.");
        Console.ReadLine();
        
        long check = 0;
        foreach(int[] block in blocks)
        {
            check += block[0];
        }
Console.WriteLine($"Контрольная сумма первых элементов: {check}");
