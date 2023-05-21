namespace SeagullflyMaui.Interfaces;
public interface ISeagullflyDatabase
{
    Task Add<T>(T filter) where T : IBaseTable;
    Task<T> Get<T>(int id) where T : IBaseTable, new();
    Task<IEnumerable<T>> GetAll<T>() where T : IBaseTable, new();
    Task Remove<T>(int id) where T : IBaseTable;
}
