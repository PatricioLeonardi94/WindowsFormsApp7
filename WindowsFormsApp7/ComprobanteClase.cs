using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace WindowsFormsApp7
{
    class ComprobanteClase
    {
        public string NombrePersona { get; set; }
        public string Descripcion { get; set; }
        public string Cantidad { get; set; }
        public string Profesor { get; set; }
        public int MontoAbonado { get; set; }
        public int NumeroComprobante { get; set; }
        public string Fecha { get; set; }

        public void getComprobante(int numeroComprobante)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Personas");
            var collection = database.GetCollection<BsonDocument>("Comprobantes");
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("Nombre", NombrePersona) & builder.Eq("NumeroComprobante", numeroComprobante);
            //filter = filter & Builders<BsonDocument>.Filter.Eq("NumeroComprobante", numero);
            var result = collection.Find(filter).ToList();
            foreach(var doc in result)
            {

                this.NumeroComprobante = doc.GetElement("NumeroComprobante").Value.AsInt32;
                this.Descripcion = doc.GetElement("Descripcion").Value.AsString;
                this.Cantidad = doc.GetElement("Cantidad").Value.AsString;
                this.Profesor = doc.GetElement("Profesor").Value.AsString;
                this.MontoAbonado = doc.GetElement("MontoAbonado").Value.AsInt32;
                this.Fecha = doc.GetElement("Fecha").Value.AsString;
            }
        }
    }
}
