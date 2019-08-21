using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using System.IO;
using System.Drawing.Printing;

namespace WindowsFormsApp7
{
    class AlumnoMin
    {
        Global Global = new Global();
        public string Name { get; set; }
        private ObjectId Id { get; set; }
        List<string> Comprobantes = new List<string>();

        public AlumnoMin(string name)
        {
            this.Name = name;
            getId();
        }

        private void getId()
        {
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("Personas");
            var collection = database.GetCollection<BsonDocument>("Alumnos");
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("Nombre", this.Name);
            var result = collection.Find(filter).ToList();
            foreach (var doc in result)
            {
                try
                {
                    this.Id = doc.GetValue("_id").AsObjectId;
                    var compr = doc.GetValue("Comprobantes", "No posee").AsBsonArray;
                    foreach(var x in compr)
                    {
                        this.Comprobantes.Add(x.AsString);
                    }
                }
                catch
                {

                }
                
            }
        }

        public string IdShow()
        {
            return this.Id.ToString();
        }

        public void ChangeName(string NewName)
        {
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("Personas");
            var collection = database.GetCollection<BsonDocument>("Alumnos");
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("_id", this.Id);
            var update = Builders<BsonDocument>.Update.Set("Nombre", NewName);
            collection.UpdateOne(filter, update);
            ChangeRecibos(NewName);
        }

        private void ChangeRecibos(string NewName)
        {
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("Personas");
            var collection = database.GetCollection<BsonDocument>("Comprobantes");
            foreach (var comprobante in this.Comprobantes)
            {
                var builder = Builders<BsonDocument>.Filter;
                var filter = builder.Eq("NumeroComprobante", comprobante);
                var update = Builders<BsonDocument>.Update.Set("Nombre", NewName);
                collection.UpdateOne(filter, update);
            }
        }
    }
}
