using System;
using System.Collections.Generic;
using System.Text;

namespace PCACalc
{
    public interface IDatabaseConnection
    {
        SQLite.SQLiteConnection DbConnection();
    }
}
