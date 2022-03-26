using System.Data.SqlClient;

namespace RamdomSort
{
    public interface ISortNameDB
    {
        string RandomSort(string DataSource);
        void InsertTableUnsorted(string Data, SqlConnection Connection);
        void InsertTableSorted(string DataSource, SqlConnection Connection);
        SqlConnection GetConnection(string DataSource);
        string SelectFromTable(string DataSource);
   
    }
}
