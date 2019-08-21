using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace WindowsFormsApp7
{
    public class Curso
    {
        public string Nombre { get; set; }
        public string Profesor { get; set; }
        public string Precio { get; set; }
        public List<string> Precios = new List<string>();
        public string Horario { get; set; }
        public List<string> Horarios = new List<string>();
        public string Credencial { get; set; }
        Global Global = new Global();

        public void getPrecio()
        {
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_pago");
            var collection = database.GetCollection<BsonDocument>("cursos");
            //var filter = Builders<BsonDocument>.Filter.Empty;
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("name", this.Nombre);
            var result = collection.Find(filter).ToList();
            foreach (var doc in result)
            {
                if (doc.Contains("precios")) 
                {
                    doc.GetValue("precios").AsBsonArray.ToList().ForEach(x => this.Precios.Add(x.ToString()));
                }
                else
                {
                    this.Precio = (doc.GetElement("precio").Value.AsString);
                }

                if (doc.Contains("horarios"))
                {
                    doc.GetValue("horarios").AsBsonArray.ToList().ForEach(x => this.Horarios.Add(x.ToString()));
                }
                else
                {
                    this.Horario = (doc.GetElement("horario").Value.AsString);
                }
            }
        }

        public List<string> getPreciosReducidos()
        {
            List<string> aux = new List<string>();
            if (this.Nombre != "Meditacion" && this.Nombre != "Budismo" && this.Nombre != "Cocina Vegetariana")
            {
                int precio = Convert.ToInt32(this.Precio);
                for (var i = 6; i >= 1 ; i--)
                {
                    int precioaux = precio / i;
                    aux.Add(precioaux.ToString());
                }
            }
            else
            {
                aux.Add(this.Precio);
            }
            return aux;
        }

        public void getProfesor()
        {
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_pago");
            var collection = database.GetCollection<BsonDocument>("cursos");
            //var filter = Builders<BsonDocument>.Filter.Empty;
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("name", this.Nombre);
            var result = collection.Find(filter).ToList();
            foreach (var doc in result)
            {
                this.Profesor = (doc.GetElement("profesor").Value.AsString);
            }
        }

        public string getHorarioCurso()
        {
            string resp = String.Empty;
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_pago");
            var collection = database.GetCollection<BsonDocument>("cursos");
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("name", this.Profesor);
            var result = collection.Find(filter).ToList();
            foreach (var doc in result)
            {
                resp = doc.GetValue("horario", "No posee").AsString;
            }

            return resp;
        }

        public void getCredencial()
        {
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_pago");
            var collection = database.GetCollection<BsonDocument>("cursos");
            //var filter = Builders<BsonDocument>.Filter.Empty;
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("name", this.Nombre);
            var result = collection.Find(filter).ToList();
            foreach (var doc in result)
            {
                this.Credencial = (doc.GetValue("credencial", new BsonString("0")).AsString);
            }
        }

        public List<Curso> GetCursos()
        {
            List<Curso> aux = new List<Curso>();
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_pago");
            var collection = database.GetCollection<BsonDocument>("cursos");
            //var filter = Builders<BsonDocument>.Filter.Empty;
            var builder = Builders<BsonDocument>.Filter.Empty;
            var result = collection.Find(builder).ToList();
            foreach (var doc in result)
            {
                Curso aux2 = new Curso();
                aux2.Nombre = (doc.GetElement("name").Value.AsString);
                aux2.Profesor = (doc.GetElement("profesor").Value.AsString);
                aux2.Precio = (doc.GetElement("precio").Value.AsString);
                aux2.Credencial = (doc.GetValue("credencial", new BsonString("0")).AsString);
                aux.Add(aux2);
            }
            return aux;
        }

    }


    public class CursosTotales// : IEnumerable<Curso>
    {
        List<Curso> CursosTotal = new List<Curso>();
        public CursosTotales()
        {

        }

        public IEnumerator<Curso> GetEnumerator()
        {
            foreach (var contact in CursosTotal)
                yield return contact;
        }

    } 
}




        

    

        
  