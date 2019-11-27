using System;
using SQLite.Net;

namespace Model
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
