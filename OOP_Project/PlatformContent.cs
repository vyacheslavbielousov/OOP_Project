using System;
using System.Collections.Generic;
using System.Text;

public abstract class PlatformContent
{
    public string Title { get; set; }

    protected PlatformContent(string title)
    {
        Title = title;
    }

    // Абстрактний метод для відкриття контенту (Поліморфізм)
    public abstract void OpenContent();
}

// Похідний клас 1: Відеоурок
public class VideoLesson : PlatformContent
{
    public int DurationMinutes { get; set; }

    public VideoLesson(string title, int duration) : base(title)
    {
        DurationMinutes = duration;
    }

    public override void OpenContent()
    {
        Console.WriteLine($"[Відеоплеєр] Відтворення лекції '{Title}' ({DurationMinutes} хв)...");
    }
}

// Похідний клас 2: Інтерактивне завдання
public class InteractiveTask : PlatformContent
{
    public int MaxScore { get; set; }

    public InteractiveTask(string title, int maxScore) : base(title)
    {
        MaxScore = maxScore;
    }

    public override void OpenContent()
    {
        Console.WriteLine($"[Тренажер] Запуск задачі '{Title}'. Максимальний бал: {MaxScore}");
    }
}