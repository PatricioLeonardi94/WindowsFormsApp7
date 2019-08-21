using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Windows.Forms;
using MongoDB.Bson.Serialization;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;



namespace WindowsFormsApp7
{
    //clase que modela las propiedades del Libro
    public class UserData
    {
        public MongoDB.Bson.ObjectId _id { get; set; }
        public string Nombre { get; set; }
        public string Autor { get; set; }
        public int Cantidad { get; set; }
        public int PrecioPeso { get; set; }
        public int PrecioDolar { get; set; }
        public string ISBN { get; set; }
        public string Edicion { get; set; }
        public string AñoImpresion { get; set; }
        public string Modelo { get; set; }
        public string Idioma { get; set; }
        public string Ubicacion { get; set; }
        Global Global = new Global();


        public UserData()
        {

        }

        public UserData(string nombre, string autor, int cantidad, int preciop, int preciod, string isbn, string edicion, string año, string modelo, string idioma, string ubicacion)
        {
            Nombre = nombre;
            Autor = autor;
            Cantidad = cantidad;
            PrecioPeso = preciop;
            PrecioDolar = preciod;
            ISBN = isbn;
            Edicion = edicion;
            AñoImpresion = año;
            Modelo = modelo;
            Idioma = idioma;
            Ubicacion = ubicacion;
        }

        public void getUbicacion()
        {
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_libro");
            var collection = database.GetCollection<BsonDocument>("Stock");
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("Nombre", this.Nombre);
            var result = collection.Find(filter).ToList();
            foreach(var doc in result)
            {
                this.Ubicacion = Ubicacion = doc.GetValue("Ubicacion", "N/A").AsString;
            }
            
        }

        public void ChangeUbicacion(string aux)
        {
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_libro");
            var collection = database.GetCollection<BsonDocument>("Stock");
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("Nombre", this.Nombre) & builder.Eq("Modelo", this.Modelo);
            var update = Builders<BsonDocument>.Update.Set("Ubicacion", aux);
            var result = collection.UpdateOne(filter, update);
        }

        public void LoadUserData()
        {
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_libro");
            var collection = database.GetCollection<BsonDocument>("Stock");
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("Nombre", this.Nombre);
            var result = collection.Find(filter).ToList();
            foreach (var doc in result)
            {
                this.Autor = doc.GetValue("Autor", null).AsString;
                this.Cantidad = (doc.GetValue("Cantidad", 0).AsInt32);
                this.PrecioPeso = doc.GetValue("PrecioPeso", 0).AsInt32;
                this.PrecioDolar = doc.GetValue("PrecioDolar", 0).AsInt32;
                this.ISBN = doc.GetValue("ISBN", "N/A").AsString;
                this.Edicion = doc.GetValue("Edicion", "N/A").AsString;
                this.AñoImpresion = doc.GetValue("AñoImpresion", "N/A").AsString;
                this.Modelo = doc.GetValue("Modelo", "N/A").AsString;
                this.Idioma = doc.GetValue("Idioma", "N/A").AsString;
                this.Ubicacion = Ubicacion = doc.GetValue("Ubicacion", "N/A").AsString;
            }
        }

        public void UpdateUserData(string Nombre, string Campo, string newCampo, string Modelo)
        {
            int auxint = 0;
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_libro");
            var collection = database.GetCollection<BsonDocument>("Stock");
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("Nombre", Nombre) & builder.Eq("Modelo", Modelo);
            if (Campo == "Cantidad" || Campo == "PrecioPeso" || Campo == "PrecioDolar")
            {
                auxint = Convert.ToInt32(newCampo);
                var update = Builders<BsonDocument>.Update.Set(Campo, auxint);
                var result = collection.UpdateOne(filter, update);

            }
            else
            {
                var update = Builders<BsonDocument>.Update.Set(Campo, newCampo);
                var result = collection.UpdateOne(filter, update);
            }
        }

        public void DeleteUserData()
        {
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_libro");
            var collection = database.GetCollection<BsonDocument>("Stock");
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("Nombre", this.Nombre) & builder.Eq("Cantidad", this.Cantidad) & builder.Eq("Autor", this.Autor);
            var result = collection.DeleteOne(filter);
        }

        public void ImprimirStockLibros(List<UserData> list)
        {
            string carpeta = getDire();
            string name = "Stock Dia " + DateTime.Now.ToString("yyyy MM dd");
            string nombreticket = @carpeta + "\\LiquidacionesLibros\\" + name;
            int i = 3;
            object misValue = System.Reflection.Missing.Value;
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook;
            Excel._Worksheet xlWorksheet;
            if (!System.IO.File.Exists(name + ".xlsx"))
            {
                xlWorkbook = xlApp.Workbooks.Add(misValue);
                xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1);
                Excel.Range xlRange = xlWorksheet.UsedRange;
                int rowCount = xlRange.Rows.Count;

                xlWorksheet.Range[xlWorksheet.Cells[1, "A"], xlWorksheet.Cells[1, "B"]].Merge();
                xlRange.Cells[1, "A"] = "Stock de Libros al Dia " + DateTime.Now.ToString("dd/MM/yyyy");
                xlRange.Cells[2, "A"] = "Cantidad";
                xlRange.Cells[2, "B"] = "Libro";

                foreach (var doc in list)
                {
                    xlRange.Cells[i, "A"] = doc.Cantidad;
                    xlRange.Cells[i, "B"] = doc.Nombre;
                    i++;
                }
                xlWorksheet.Range[xlWorksheet.Cells[2, "A"], xlWorksheet.Cells[2, "B"]].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                xlWorksheet.Range[xlWorksheet.Cells[2, "A"], xlWorksheet.Cells[2, "B"]].Borders.Weight = Excel.XlBorderWeight.xlMedium;
                xlWorksheet.Range[xlWorksheet.Cells[1, "A"], xlWorksheet.Cells[1, "B"]].Font.Bold = true;
                xlWorksheet.Range[xlWorksheet.Cells[3, "A"], xlWorksheet.Cells[i-1, "B"]].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                xlWorksheet.Range[xlWorksheet.Cells[3, "A"], xlWorksheet.Cells[i-1, "B"]].Borders.Weight = Excel.XlBorderWeight.xlThin;
                xlWorksheet.Columns[1].ColumnWidth = 15;
                xlWorksheet.Columns[2].ColumnWidth = 25;
                xlWorksheet.Range[xlWorksheet.Cells[3, "B"], xlWorksheet.Cells[i, "B"]].WrapText = true;

                xlWorksheet.Columns[2].ColumnWidth = 70;
                for(var j=2; j<= rowCount; j++)
                {
                    xlWorksheet.Rows[j].RowWidth = 70;
                }

                xlWorkbook.Password = Connect();
                xlWorkbook.SaveAs(nombreticket);
                xlWorkbook.Close();
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorksheet);
                Marshal.ReleaseComObject(xlWorkbook);
                Marshal.ReleaseComObject(xlApp);
            }
            MessageBox.Show("Se ha Generado el Stock");
        }

        private static string Connect()
        {
            Global Global = new Global();
            string resp = string.Empty;
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_pago");
            var collection = database.GetCollection<BsonDocument>("contraseñas");
            //var filter = Builders<BsonDocument>.Filter.Empty;
            var filter = Builders<BsonDocument>.Filter.Empty;
            var result = collection.Find(filter).ToList();
            foreach (var doc in result)
            {
                resp = (doc.GetValue("app_pago", new BsonString(string.Empty)).AsString);
            }
            return resp;
        }

        private string getDire()
        {
            string aux = string.Empty;
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_pago");
            var collection = database.GetCollection<BsonDocument>("destinos");
            //var filter = Builders<BsonDocument>.Filter.Empty;
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("Nombre", "Excels");
            var result = collection.Find(filter).ToList();
            foreach (var doc in result)
            {
                aux = (doc.GetValue("Carpeta", new BsonString(string.Empty)).AsString);
            }
            return aux;
        }
    }



    public class UserDataMin
    {
        public MongoDB.Bson.ObjectId _id { get; set; }
        public string Nombre { get; set; }
        public int PrecioPeso { get; set; }
        public int PrecioDolar { get; set; }
        public int Cantidad { get; set; }


    }


    public class ProductSearchModel
    {
        public MongoDB.Bson.ObjectId _id { get; set; }
        public string Nombre { get; set; }
        public string Autor { get; set; }
        public int? PriceFrom { get; set; }
        public int? PriceTo { get; set; }
        public int? Cantidad { get; set; }
        public int? CantidadFrom { get; set; }
        public int? PrecioPeso { get; set; }
        public int? PrecioDolar { get; set; }
        public string ISBN { get; set; }
        public string Edicion { get; set; }
        public string AñoImpresion { get; set; }
        public string Modelo { get; set; }
        public string Idioma { get; set; }

    }
    //Para cambiar un tipo de una propiedad en toda una coleccion
    /*
    db.Stock.find( { 'PrecioDolar' : { $type : 2 } } ).forEach(function(obj) {
    obj.PrecioDolar = new NumberInt(obj.PrecioDolar);
    db.Stock.save(obj);
    });
    */

            //Una clase que implementa una busqueda con un ProductSearchModel que son los parametros introducidos por el usuario
        public class ProductLibroLogic
    {
        public ProductLibroLogic()
        {

        }

        public List<UserData> GetLibros(ProductSearchModel searchModel)
        {
            Global Global = new Global();
            var result = new List<UserData>();
            var aux2 = new UserData();
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_libro");
            var collection = database.GetCollection<BsonDocument>("Stock");
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Empty;
            if (searchModel != null)
            {
                if (!string.IsNullOrEmpty(searchModel.Nombre))
                    filter = filter & (builder.Eq("Nombre", searchModel.Nombre));
                if (!string.IsNullOrEmpty(searchModel.Autor))
                    filter = filter & (builder.Eq("Autor", searchModel.Autor));
                if (searchModel.PriceFrom.HasValue)
                    filter = filter & (builder.Gt("PrecioPeso", searchModel.PriceFrom - 1));
                if (searchModel.PriceTo.HasValue)
                    filter = filter & (builder.Lt("PrecioPeso", searchModel.PriceTo));
                if (searchModel.Cantidad.HasValue)
                    filter = filter & (builder.Eq("Cantidad", searchModel.Cantidad));
                if (searchModel.CantidadFrom.HasValue)
                    filter = filter & (builder.Gt("Cantidad", searchModel.CantidadFrom - 1));
                if (searchModel.PrecioPeso.HasValue)
                    filter = filter & (builder.Eq("PrecioPeso", searchModel.PrecioPeso));
                if (searchModel.PrecioDolar.HasValue)
                    filter = filter & (builder.Eq("PrecioDolar", searchModel.PrecioDolar));
                if (!string.IsNullOrEmpty(searchModel.ISBN))
                    filter = filter & (builder.Eq("ISBN", searchModel.ISBN));
                if (!string.IsNullOrEmpty(searchModel.Edicion))
                    filter = filter & (builder.Eq("Edicion", searchModel.Edicion));
                if (!string.IsNullOrEmpty(searchModel.AñoImpresion))
                    filter = filter & (builder.Eq("AñoImpresion", searchModel.AñoImpresion));
                if (!string.IsNullOrEmpty(searchModel.Modelo))
                    filter = filter & (builder.Eq("Modelo", searchModel.Modelo));
                if (!string.IsNullOrEmpty(searchModel.Idioma))
                    filter = filter & (builder.Eq("Idioma", searchModel.Idioma));
            }
            var result2 = collection.Find(filter).ToList();
            /*if(result2 == null)
            {
                MessageBox.Show("hola");
            }*/
            foreach (var doc in result2)
            {
                /*BsonClassMap.RegisterClassMap<UserData>(cm => {
                    cm.MapIdField("Nombre");
                    cm.MapField("Autor");
                    cm.MapIdField("Cantidad");
                    cm.MapField("PrecioPeso");
                    cm.MapIdField("PrecioDolar");
                    cm.MapField("ISBN");
                    cm.MapField("Edicion");
                    cm.MapField("AñoImpresion");
                    cm.MapField("Modelo");
                    cm.MapField("Idioma");
                });*/
                //aux2 = BsonSerializer.Deserialize<UserData>(doc);
                /*aux2 = new UserData()
                {
                    Nombre = doc["Nombre"].AsString,
                    Autor = doc["Autor"].AsString,
                    Cantidad = doc["Cantidad"].AsInt32,
                    PrecioPeso = doc["PrecioPeso"].AsInt32,
                    PrecioDolar = doc["PrecioDolar"].AsInt32,
                    ISBN = doc["ISBN"].AsString,
                    Edicion = doc["Edicion"].AsString,
                    AñoImpresion = doc["AñoImpresion"].AsString,
                    Modelo = doc["Modelo"].AsString,
                    Idioma = doc["Idioma"].AsString
                };*/

                aux2 = new UserData
                {
                    Nombre = doc.GetValue("Nombre", null).AsString,
                    Autor = doc.GetValue("Autor", null).AsString,
                    Cantidad = (doc.GetValue("Cantidad", 0).AsInt32),
                    PrecioPeso = doc.GetValue("PrecioPeso", 0).AsInt32,
                    PrecioDolar = doc.GetValue("PrecioDolar", 0).AsInt32,
                    ISBN = doc.GetValue("ISBN", "N/A").AsString,
                    Edicion = doc.GetValue("Edicion", "N/A").AsString,
                    AñoImpresion = doc.GetValue("AñoImpresion", "N/A").AsString,
                    Modelo = doc.GetValue("Modelo", "N/A").AsString,
                    Idioma = doc.GetValue("Idioma", "N/A").AsString,
                };
                result.Add(aux2);
            }
            return result;
        }
    }
}
