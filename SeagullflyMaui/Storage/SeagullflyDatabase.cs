using SeagullflyMaui.Interfaces;
using SeagullflyMaui.Model;
using SQLite;
using SQLiteNetExtensionsAsync.Extensions;

namespace SeagullflyMaui.Storage;

public class SeagullflyDatabase : ISeagullflyDatabase
{
    static SQLiteAsyncConnection Database;
    static void Init()
    {
        if (Database != null)
            return;

        var databasePath = Path.Combine(FileSystem.AppDataDirectory, "SeagullflyDataTest.db");
        Database = new SQLiteAsyncConnection(databasePath);

        Database.CreateTableAsync<SearchQuery>();
        Database.CreateTableAsync<Flight>();
        Database.CreateTableAsync<Passenger>();
    }

    public async Task Add<T>(T filter) where T : IBaseTable
    {
        Init();
        await Database.InsertWithChildrenAsync(filter);
    }

    public async Task Remove<T>(int id) where T : IBaseTable
    {
        Init();
        await Database.DeleteAsync<T>(id);
    }

    public Task<T> Get<T>(int id) where T : IBaseTable, new()
    {
        Init();
        return Database.GetWithChildrenAsync<T>(id);
    }

    public async Task<IEnumerable<T>> GetAll<T>() where T : IBaseTable, new()
    {
        Init();
        return await Database.GetAllWithChildrenAsync<T>();
    }
}
