using System;
using System.Collections.Generic;
using System.Text;

public class SmartSchool
{
    public string BranchName { get; set; }

    // ВЗАЄМОЗВ'ЯЗОК: Композиція (Контент жорстко належить школі і створюється разом з нею)
    public List<PlatformContent> Database { get; private set; }

    public static string City { get; set; }

    // 3) Статичний конструктор
    // Викликається автоматично лише один раз перед створенням першого екземпляра класу
    static SmartSchool()
    {
        City = "Київ";
        Console.WriteLine($"\n[Система] Запуск статичного конструктора. Місто платформи встановлено: {City}\n");
    }

    public SmartSchool(string branchName)
    {
        BranchName = branchName;

        // Реалізація Композиції: об'єкти створюються всередині об'єкта-власника
        Database = new List<PlatformContent>
            {
                PlatformContent.CreateContent("Основи алгоритмізації", "Інтерактивна задача"),
                PlatformContent.CreateContent("Екологічна свідомість у Smart City", "Відеолекція")
            };
    }
}
