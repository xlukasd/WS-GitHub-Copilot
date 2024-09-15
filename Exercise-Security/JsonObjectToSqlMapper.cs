using System.Text.Json.Nodes;

namespace Exercise_Security
{
    public class JsonObjectToSqlMapper
    {
        private string ConnectionString { get; }

        public JsonObjectToSqlMapper(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public void MapJsonObjectPropertiesToDatabaseEntity(string tableName, Guid entityId, JsonObject jsonObject)
        {

        }
    }
}
