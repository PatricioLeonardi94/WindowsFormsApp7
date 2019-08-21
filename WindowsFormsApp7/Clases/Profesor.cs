using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace WindowsFormsApp7
{
    class Profesor
    {
        public string name { get; set; }
        public string xClase { get; set; }
        public string cuatroxmes { get; set; }
        public string seisxmes { get; set; }
        public string ochoxmes { get; set; }
        public string paselibre { get; set; }
        public string porcentaje { get; set; }
        public List<string> clases = new List<string>();

        Global Global = new Global();
        

        public Profesor()
        {
           
        }


        
        public void modificar_profesor(Dictionary<string,string> parametros)
        {
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_pago");
            var collection = database.GetCollection<BsonDocument>("profesor");
            var filter = Builders<BsonDocument>.Filter.Eq("name", this.name);

            foreach (var parametro in parametros.Keys)
            {
                var update = Builders<BsonDocument>.Update.Set(parametro, parametros[parametro]);
                var result = collection.UpdateOne(filter, update);
            }          
        }

        public void agregar_profesor()
        {
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_pago");
            var collection = database.GetCollection<BsonDocument>("profesor");
            var document = new BsonDocument
                {
                    { "name", this.name },
                    { "xClase", this.xClase },
                    { "4xmes", this.cuatroxmes },
                    { "6xmes", this.seisxmes },
                    { "8xmes", this.ochoxmes },
                    { "paselibre",  this.paselibre},
                    { "porcentaje",  this.porcentaje}
                };
            collection.InsertOne(document);
        }

        //Add class in profesors classes
        public void add_class(List<string> clase)
        {

        }

        //Not removing clases beacuse of the update pull method (need to rethink way)
        public void modify_clases(List<string> clase)
        {
            try
            {
                var client = new MongoClient(Global.Path_DataBase);
                var database = client.GetDatabase("app_pago");
                var collection = database.GetCollection<BsonDocument>("profesor");
                var filter = Builders<BsonDocument>.Filter.Eq("name", this.name);
                var result = collection.Find(filter).ToList().First();
                var update = Builders<BsonDocument>.Update.Set("clases", clase);
                var resultFinal = collection.UpdateOne(filter, update);
            }
            catch
            {

            }
        }
    }


    class Profesores
    {
        public Dictionary<string, Profesor> profesores = new Dictionary<string, Profesor>();

        Global Global = new Global();

        public Profesores()
        {
            get_each_profesor();
        }
        
        private void get_each_profesor()
        {
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_pago");
            var collection = database.GetCollection<BsonDocument>("profesor");
            //var filter = Builders<BsonDocument>.Filter.Empty;
            var builder = Builders<BsonDocument>.Filter.Empty;
            var result = collection.Find(builder).ToList();
            foreach (var doc in result)
            {
                Profesor profesor = new Profesor();
                var name = doc.GetValue("name", "no posee nombre").AsString;
                if(name != "no posee nombre")
                {
                    try
                    {
                        profesor.name = name;
                        profesor.xClase = doc.GetValue("xClase", "no posee valor").AsString;
                        profesor.cuatroxmes = doc.GetValue("4xmes", "no posee valor").AsString;
                        profesor.seisxmes = doc.GetValue("6xmes", "no posee valor").AsString;
                        profesor.ochoxmes = doc.GetValue("8xmes", "no posee valor").AsString;
                        profesor.paselibre = doc.GetValue("paselibre", "no posee valor").AsString;
                        profesor.porcentaje = doc.GetValue("porcentaje", "no posee valor").AsString;

                   
                        var aux = doc.GetValue("clases", "No Posee").AsBsonDocument;
                        aux.Names.ToList().ForEach(p => profesor.clases.Add(p));
                        this.profesores.Add(name, profesor);
                    }
                    catch
                    {

                    }
                  
                }
            }
        }


    }
}
