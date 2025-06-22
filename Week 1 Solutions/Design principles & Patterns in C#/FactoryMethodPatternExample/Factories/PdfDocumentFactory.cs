using FactoryMethodPatternExample.Interfaces;
using FactoryMethodPatternExample.Models;

namespace FactoryMethodPatternExample.Factories
{
    public class PdfDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            return new PdfDocument();
        }
    }
}