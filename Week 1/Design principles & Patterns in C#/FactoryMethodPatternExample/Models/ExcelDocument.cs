using FactoryMethodPatternExample.Interfaces;

namespace FactoryMethodPatternExample.Models
{
    public class ExcelDocument : IDocument
    {
        public string FileName => "Document.xlsx";
        public void Create()
        {
            Console.WriteLine($"\nCreating Excel Document");
            Console.WriteLine($"File Name   : {FileName}");
            Console.WriteLine($"Created At  : {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
        }
        public void Open()
        {
            Console.WriteLine($"Status      : Opened {FileName} successfully");
        }

        public void Save()
        {
            Console.WriteLine($"Excel Document saved successfully");
        }

        public void Close()
        {
            Console.WriteLine("Exiting the document..");
            Console.WriteLine($"Status      : Closed {FileName} Successfully\n");
        }
    }
}
