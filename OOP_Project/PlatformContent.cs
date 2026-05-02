using System;
using System.Collections.Generic;
using System.Text;
public class PlatformContent
{
    public string Title { get; set; }
    public string ContentType { get; set; }

    // 4) Закритий конструктор (Private constructor)
    // Не дозволяє створити об'єкт через 'new PlatformContent()' поза межами класу
    private PlatformContent(string title, string contentType)
    {
        Title = title;
        ContentType = contentType;
    }

    public static PlatformContent CreateContent(string title, string contentType)
    {
        return new PlatformContent(title, contentType);
    }

    public override string ToString() => $"Контент: '{Title}' (Формат: {ContentType})";
}
