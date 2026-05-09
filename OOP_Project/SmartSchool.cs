using System;
using System.Collections.Generic;
using System.Text;

public class SmartSchool
{
    public string BranchName { get; set; }
    public List<PlatformContent> Database { get; private set; }
    public static string City { get; set; }

    static SmartSchool() { City = "Київ"; }

    public SmartSchool(string branchName)
    {
        BranchName = branchName;
        Database = new List<PlatformContent>
            {
                PlatformContent.CreateContent("Основи алгоритмізації", "Інтерактивна задача"),
                PlatformContent.CreateContent("Екологічна свідомість", "Відеолекція")
            };
    }

    // --- ВЕРСІЯ 3: Предикатна функція ---
    public bool HasInteractiveContent()
    {
        // Перевіряє, чи є в базі хоча б один інтерактивний контент
        return Database.Exists(content => content.ContentType == "Інтерактивна задача");
    }
}
