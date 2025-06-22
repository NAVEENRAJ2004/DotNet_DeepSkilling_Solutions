namespace FactoryMethodPatternExample.Interfaces
{
    public interface IDocument
    {
        String FileName { get; }
        void Create();
        void Open();
        void Save();
        void Close();
    }
}