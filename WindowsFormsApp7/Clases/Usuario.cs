using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Windows.Forms;


namespace WindowsFormsApp7
{
    //Modela la Clase Usuario que se utiliza para entrar por primera vez a la aplicacion
    public class Usuario
    {
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public List<string> Usuarios { get; set; }
        Global Global = new Global();

        //Carga en el usuario su propia contraseña
        public void getContraseña()
        {
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("Personas");
            var collection = database.GetCollection<BsonDocument>("Usuarios");
            var filter = Builders<BsonDocument>.Filter.Eq("Nombre", this.Nombre.ToUpper());
            var result = collection.Find(filter).ToList();
            foreach (var doc in result)
            {
                this.Contraseña = (doc.GetValue("Contraseña", new BsonString(string.Empty)).AsString);
            }
        }

        //cambia la contraseña
        public void setContraseña(string newPassword)
        {
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("Personas");
            var collection = database.GetCollection<BsonDocument>("Usuarios");
            var filter = Builders<BsonDocument>.Filter.Eq("Nombre", this.Nombre.ToUpper());
            var update = Builders<BsonDocument>.Update.Set("Contraseña", newPassword);
            var result = collection.UpdateOne(filter, update);
        }

        //borra usuario
        public void deleteUser()
        {
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("Personas");
            var collection = database.GetCollection<BsonDocument>("Usuarios");
            var filter = Builders<BsonDocument>.Filter.Eq("Nombre", this.Nombre.ToUpper());
            var result = collection.DeleteOne(filter);
        }

        //devuelve el usuario que esta utilizando el programa actualmente
        public string getUsuarioActual()
        {
            string resp = string.Empty;
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_pago");
            var collection = database.GetCollection<BsonDocument>("usuarioActual");
            var filter = Builders<BsonDocument>.Filter.Eq("PcName", System.Environment.MachineName);
            var result = collection.Find(filter).ToList();
            foreach (var doc in result)
            {
                resp = (doc.GetValue("usuarioActual", new BsonString(string.Empty)).AsString);
            }
            return resp;
        }

        public List<Usuario> getAllUsers()
        {
            List<Usuario> aux = new List<Usuario>();
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("Personas");
            var collection = database.GetCollection<BsonDocument>("Usuarios");
            var filter = Builders<BsonDocument>.Filter.Empty;
            var result = collection.Find(filter).ToList();
            foreach (var doc in result)
            {
                Usuario aux2 = new Usuario();
                aux2.Nombre =(doc.GetValue("Nombre", new BsonString(string.Empty)).AsString);
                aux.Add(aux2);
            }
            return aux;
        }

    }
        public class UserValidation : Usuario
    {
        Global Global = new Global();
            public bool getUser(Usuario aux)
            {
            var client = new MongoClient(Global.Path_DataBase);
                var database = client.GetDatabase("Personas");
                var collection = database.GetCollection<BsonDocument>("Usuarios");
                //var filter = Builders<BsonDocument>.Filter.Empty;
                var builder = Builders<BsonDocument>.Filter;
                var filter = builder.Eq("Nombre", aux.Nombre.ToUpper());
                //filter = filter & Builders<BsonDocument>.Filter.Eq("NumeroComprobante", numero);
                var result = collection.Find(filter).ToList();
                long res = collection.Find(filter).CountDocuments();
                if (res == 0)
                {
                    MessageBox.Show("No Existe El Usuario");
                    return false;
                }
                foreach (var doc in result)
                {
                    if (!(aux.Contraseña == doc.GetElement("Contraseña").Value.AsString))
                    {
                        MessageBox.Show("Contraseña Incorrecta");
                        return false;
                    }
                }
                this.SetUsuario(aux);
                return true;
            }

            public void SetUsuario(Usuario aux)
            {
                Global Global = new Global();
                var client = new MongoClient(Global.Path_DataBase);
                var database = client.GetDatabase("app_pago");
                var collection = database.GetCollection<BsonDocument>("usuarioActual");
                var filter = Builders<BsonDocument>.Filter.Eq("PcName", System.Environment.MachineName);
                var result = collection.Find(filter).ToList();
                if (result.Any())
                {
                    var update = Builders<BsonDocument>.Update.Set("usuarioActual", aux.Nombre);
                    var result2 = collection.UpdateOne(filter, update);
                }
                else
                {
                    var document = new BsonDocument
                    {
                        { "PcName", System.Environment.MachineName },
                        { "usuarioActual", aux.Nombre },
                    };
                    collection.InsertOne(document);
                }
            }

            
        }
    }

