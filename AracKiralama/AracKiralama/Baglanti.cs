using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracKiralama
{
    class Baglanti
    {
        public static string appDirectory = AppDomain.CurrentDomain.BaseDirectory;
        public static string dbYolu = Path.Combine(appDirectory, "dbAracKiralama.db");
        public string Adres = (dbYolu);
    }
}
