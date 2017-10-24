using System;
using SQLite.Net;

namespace Diabetes.localDB
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
