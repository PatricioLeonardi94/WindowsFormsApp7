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
    class Alumno
    {
        public string Name { get; set; }
        public string Telefono { get; set; }
        public string Mail { get; set; }
        string Clase;
        int Cantidad;
        string Fecha;
        public List<MinComprobante> ComprobantesCompletosAlumnos = new List<MinComprobante>();
        public Stack<Alumno> datosAlum { get; set; }
        Global Global = new Global();

        public class Comprobante
        {
            public string Nombre { get; set; }
            public int NumeroComprobante { get; set; }
            public string Fecha { get; set; }
            public string Descripcion { get; set; }
            public string Cantidad { get; set; }
            public string Profesor { get; set; }
            public int MontoAbonado { get; set; }
        }

        public Alumno(string nombre, string telefono, string mail)
        {
            this.Name = nombre;
            this.Telefono = telefono;
            this.Mail = mail;
        }

        public Alumno()
        {
            
        }

        public void CargarComprobantes()
        {
            Stack<string> resp = new Stack<string>();
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("Personas");
            var collection = database.GetCollection<BsonDocument>("Alumnos");
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("Nombre", this.Name);
            var result = collection.Find(filter).ToList();
            foreach (var doc in result)
            {
                var aux = (doc.GetValue("Comprobantes", new BsonArray(string.Empty)).AsBsonArray);
                foreach (var elem in aux.Reverse().Take(6))
                {                 
                    resp.Push(elem.ToString());
                }

            }
            CargarComprobanteEnAlumno(resp);

        }



        public void CargarComprobanteEnAlumno(Stack<string> comprobantes)
        {
            Stack<MinComprobante> stackComprobantes = new Stack<MinComprobante>();
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("Personas");
            var collection = database.GetCollection<BsonDocument>("Comprobantes");
            foreach(var recibo in comprobantes)
            {
                var builder = Builders<BsonDocument>.Filter;
                var filter = builder.Eq("NumeroComprobante", recibo) & builder.Eq("Nombre", this.Name);
                var result = collection.Find(filter).ToList();
                MinComprobante auxComprobante = new MinComprobante();
                foreach (var doc in result)
                {
                    auxComprobante.Fecha = doc.GetValue("Fecha", "no posee").AsString;
                    auxComprobante.NumeroComprobante = doc.GetValue("NumeroComprobante", "no posee").AsString;
                    auxComprobante.Nombre = doc.GetValue("Nombre", "no posee").AsString;

                    var clase = doc.GetValue("Clases", "No posee").AsBsonArray;
                    foreach(var doc2 in clase)
                    {
                        var clase2 = doc2.AsBsonDocument;
                        Comprobantemin comprobanteaux = new Comprobantemin();
                        comprobanteaux.CantidadClases = clase2.GetValue("CantidadClases", "No Posee").AsString;
                        comprobanteaux.Profesor = clase2.GetValue("Profesor", "No Posee").AsString;
                        comprobanteaux.Precio = clase2.GetValue("Precio", "No Posee").AsString;
                        comprobanteaux.ClasesTomar = clase2.GetValue("ClasesTomar", "No Posee").AsString;
                        comprobanteaux.Descripcion = clase2.GetValue("Descripcion", "No Posee").AsString;
                        comprobanteaux.cantidadElegidos = clase2.GetValue("cantidadElegidos", "No Posee").AsString;
                        comprobanteaux.Total = clase2.GetValue("Total", "No Posee").AsString;
                        auxComprobante.comprobantes.Add(comprobanteaux);
                    }
                    this.ComprobantesCompletosAlumnos.Add(auxComprobante);
                }
                
            }
        }

        public void CargarDatos()
        {
            Stack<Alumno> aux = new Stack<Alumno>();
            Alumno aux2 = new Alumno();
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("Personas");
            var collection = database.GetCollection<BsonDocument>("Alumnos");
            //var filter = Builders<BsonDocument>.Filter.Empty;
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("Nombre", this.Name);
            var result = collection.Find(filter).ToList();
            foreach (var doc in result)
            {
                aux2.Telefono = (doc.GetElement("Telefono").Value.AsString);
                aux2.Mail = (doc.GetElement("Mail").Value.AsString);
                aux.Push(aux2);
            }
            this.datosAlum = aux;
        }

        public void UpdateAlumno(string Nombre, string Campo, string newCampo)
        {
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("Personas");
            var collection = database.GetCollection<BsonDocument>("Alumnos");
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("Nombre", Nombre);
            var update = Builders<BsonDocument>.Update.Set(Campo, newCampo);
            var result = collection.UpdateOne(filter, update);        
        }


        public string getName()
        {
            return this.Name;
        }

        public string getTelefono()
        {
            return this.Telefono;
        }

        public string getMail()
        {
            return this.Mail;
        }

        public string getClase()
        {
            string resp = string.Empty;
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("Personas");
            var collection = database.GetCollection<BsonDocument>("Alumnos");
            //var filter = Builders<BsonDocument>.Filter.Empty;
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("Nombre", this.Name);
            var result = collection.Find(filter).ToList();
            foreach (var doc in result)
            {
                resp = "Clase de: " +(doc.GetElement("Clase").Value.AsString);
                resp += ", Cantidad de Clases: " +(doc.GetElement("CantidadClases").Value.AsString);
                resp += ", Profesor: " +  (doc.GetElement("Profesor").Value.AsString);
            }
            return resp;
        }

        public void addClase(string clase, string cantidad, string profesor)
        {
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("Personas");
            var collection = database.GetCollection<BsonDocument>("Alumnos");
            var filter = Builders<BsonDocument>.Filter.Eq("Nombre", this.Name);
            var update = Builders<BsonDocument>.Update.Set("Clase", clase).Set("CantidadClases", cantidad).Set("Profesor", profesor);
            var result = collection.UpdateOne(filter, update);
            }
        }
    }
