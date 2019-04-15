using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace xMessage
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
