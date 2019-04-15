using Core;
using Newtonsoft.Json;
using System.IO;

namespace Infrastructure
{
    public static class SqlConnectionInitializer
    {
        public static SQLConnection SQLConnection;
        public static void LoadFromFile(string path)
        {
            SQLConnection = JsonConvert.DeserializeObject<SQLConnection>(File.ReadAllText(path));
        }
    }
}
