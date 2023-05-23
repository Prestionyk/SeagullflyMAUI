using SeagullflyMaui.Interfaces;
using SeagullflyMaui.Model;
using SQLite;
using SQLiteNetExtensionsAsync.Extensions;

namespace SeagullflyMaui.Storage;

public class SeagullflyDatabase : ISeagullflyDatabase
{
    static SQLiteAsyncConnection Database;
    static async Task Init()
    {
        if (Database != null)
            return;

        var databasePath = Path.Combine(FileSystem.AppDataDirectory, "SeagullflyTestDatabase5.db");
        Database = new SQLiteAsyncConnection(databasePath);

        await Database.CreateTableAsync<SearchQuery>();
        await Database.CreateTableAsync<Flight>();
        await Database.CreateTableAsync<Passenger>();
    }

    public async Task Add<T>(T filter) where T : IBaseTable
    {
        await Init();
        await Database.InsertWithChildrenAsync(filter);
    }

    public async Task Remove<T>(int id) where T : IBaseTable
    {
        await Init();
        await Database.DeleteAsync<T>(id);
    }

    public async Task<T> Get<T>(int id) where T : IBaseTable, new()
    {
        await Init();
        return await Database.GetWithChildrenAsync<T>(id);
    }

    public async Task<IEnumerable<T>> GetAll<T>() where T : IBaseTable, new()
    {
        await Init();
        var items = await Database.GetAllWithChildrenAsync<T>();
        return items;
    }
}
