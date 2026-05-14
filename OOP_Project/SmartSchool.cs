using System;
using System.Collections.Generic;
using System.Text;

public class SmartSchool
{
    public string BranchName { get; set; }
    public List<PlatformContent> Database { get; private set; }

    public SmartSchool(string branchName)
    {
        BranchName = branchName;
        Database = new List<PlatformContent>
            {
                new VideoLesson("Основи Smart City", 15),
                new InteractiveTask("Логічна задача", 10)
            };
    }

    public void GetContentByIndex(int index)
    {
        // Доступ до масиву за індексом
        PlatformContent content = Database[index];
        content.OpenContent();
    }
}