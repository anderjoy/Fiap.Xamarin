using SQLite;

namespace XF.LocalDB.Data
{
    public interface ISQLite
    {
        SQLiteConnection GetConexao();
    }
}
