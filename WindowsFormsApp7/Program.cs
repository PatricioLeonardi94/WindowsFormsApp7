using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;


namespace WindowsFormsApp7
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!BsonClassMap.IsClassMapRegistered(typeof(UserData)))
            {
                // register class map for MyClass
                BsonClassMap.RegisterClassMap<UserData>(cm =>
                {
                    cm.AutoMap();
                    cm.MapCreator(p => new UserData());
                });
            }
            Application.Run(new UsuarioyContraseña());
        }
    }
}
