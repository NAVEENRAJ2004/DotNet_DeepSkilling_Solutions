using FactoryMethodPatternExample.Interfaces;
using FactoryMethodPatternExample.Models;

namespace FactoryMethodPatternExample.Factories
{
    public class ExcelDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            return new ExcelDocument();
        }
    }
}