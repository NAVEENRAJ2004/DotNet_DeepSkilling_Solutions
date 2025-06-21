using System;
using FactoryMethodPatternExample.Factories;
using FactoryMethodPatternExample.Interfaces;

namespace FactoryMethodPatternExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DisplayDocument(new WordDocumentFactory());
            DisplayDocument(new PdfDocumentFactory());
            DisplayDocument(new ExcelDocumentFactory());
            
            Console.ReadKey();
        }
        static void DisplayDocument(DocumentFactory factory)
        {
            IDocument doc = factory.CreateDocument();
            Console.WriteLine("-------------------------------------");
            doc.Create();
            doc.Open();
            doc.Save();
            doc.Close();
            Console.WriteLine("-------------------------------------");
        }
    }
}