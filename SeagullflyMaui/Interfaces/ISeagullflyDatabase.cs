namespace SeagullflyMaui.Interfaces;
public interface ISeagullflyDatabase
{
    void Add<T>(T filter) where T : IBaseTable;
    T Get<T>(int id) where T : IBaseTable, new();
    IEnumerable<T> GetAll<T>() where T : IBaseTable, new();
    void Remove<T>(int id) where T : IBaseTable;
}
