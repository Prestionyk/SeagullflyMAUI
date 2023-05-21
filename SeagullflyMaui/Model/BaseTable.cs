using SeagullflyMaui.Interfaces;
using SQLite;

namespace SeagullflyMaui.Model;
public class BaseTable : IBaseTable
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
}
