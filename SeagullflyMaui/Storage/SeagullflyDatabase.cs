using SeagullflyMaui.Interfaces;
using SeagullflyMaui.Model;
using SQLite;
using SQLiteNetExtensions.Extensions;

namespace SeagullflyMaui.Storage;

public class SeagullflyDatabase : ISeagullflyDatabase
{
    static SQLiteConnection Database;
    static void Init()
    {
        if (Database != null)
            return;

        var databasePath = Path.Combine(FileSystem.AppDataDirectory, "SeagullflyData.db");
        Database = new SQLiteConnection(databasePath);

        Database.CreateTable<SearchQuery>();
    }

    public void Add<T>(T filter) where T : IBaseTable
    {
        Init();
        Database.InsertWithChildren(filter);
    }

    public void Remove<T>(int id) where T : IBaseTable
    {
        Init();
        Database.Delete<T>(id);
    }

    public T Get<T>(int id) where T : IBaseTable, new()
    {
        Init();
        return Database.GetWithChildren<T>(id);
    }

    public IEnumerable<T> GetAll<T>() where T : IBaseTable, new()
    {
        Init();
        return Database.GetAllWithChildren<T>();
    }
}
