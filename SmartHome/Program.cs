using System;
using SmartHome.Models;

namespace SmartHome
{
    class Program
    {
        static void Main()
        {
            SmartLight livingRoomLamp = new SmartLight("Лампа в гостиной", 60);
            livingRoomLamp.SetBrightness(85);
            livingRoomLamp.SetBrightness("evening");

            RobotVacuum vacuum = new RobotVacuum("Робот-пылесос", 92);
            vacuum.Clean();
            vacuum.Clean(2);
            Console.WriteLine(new string('-', 40));

            SmartDevice[] devices =
            {
                livingRoomLamp,
                new Thermostat("Термостат", 22.5),
                new SmartSpeaker("Колонка", 30),
                new SecurityCamera("Камера у входа"),
                vacuum,
                new SmartKettle("Чайник", 95)
            };

            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("\n=== УМНЫЙ ДОМ ===");
                Console.WriteLine("1. Показать все устройства");
                Console.WriteLine("2. Включить все устройства");
                Console.WriteLine("3. Выключить все устройства");
                Console.WriteLine("4. Включить устройство по имени");
                Console.WriteLine("5. Выключить устройство по имени");
                Console.WriteLine("6. Статистика (сколько включено / выключено)");
                Console.WriteLine("7. Показать суммарное энергопотребление");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите пункт: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        foreach (SmartDevice device in devices) Console.WriteLine(device.GetStatus());
                        break;
                    case "2":
                        foreach (SmartDevice device in devices) device.TurnOn();
                        break;
                    case "3":
                        foreach (SmartDevice device in devices) device.TurnOff();
                        break;
                    case "4":
                        ToggleDeviceByName(devices, true);
                        break;
                    case "5":
                        ToggleDeviceByName(devices, false);
                        break;
                    case "6":
                        int onCount = 0;
                        foreach (SmartDevice device in devices) if (device.IsOn) onCount++;
                        Console.WriteLine($"Включено: {onCount}, выключено: {devices.Length - onCount}");
                        break;
                    case "7":
                        double totalWatts = 0;
                        foreach (SmartDevice device in devices) totalWatts += device.GetPowerConsumption();
                        Console.WriteLine($"Текущее суммарное энергопотребление: {totalWatts} Вт");
                        break;
                    case "0":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Неверный пункт меню.");
                        break;
                }
            }
        }

        static void ToggleDeviceByName(SmartDevice[] devices, bool turnOn)
        {
            Console.Write("Введите название устройства: ");
            string inputName = Console.ReadLine();

            foreach (SmartDevice device in devices)
            {
                if (device.Name.Equals(inputName, StringComparison.OrdinalIgnoreCase))
                {
                    if (turnOn) device.TurnOn();
                    else device.TurnOff();
                    return;
                }
            }
            Console.WriteLine("Устройство с таким именем не найдено.");
        }
    }
}
