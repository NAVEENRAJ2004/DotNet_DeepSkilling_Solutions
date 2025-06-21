using FactoryMethodPatternExample.Interfaces;
using FactoryMethodPatternExample.Models;

namespace FactoryMethodPatternExample.Factories
{
    public class WordDocumentFactory : DocumentFactory
    {
        public override IDocument CreateDocument()
        {
            return new WordDocument();
        }
    }
}