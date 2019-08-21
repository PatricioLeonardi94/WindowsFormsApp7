using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;




namespace WindowsFormsApp7
{
    //Modela la class Clase que refiere a una clase o curso (ej: clase de yoga con el profesor Martin)
    public class Clase
    {
        Global Global = new Global();
        public string CantidadClases { get; set; }
        public string Profesor { get; set; }
        public string Precio { get; set; }
        public string ClasesTomar { get; set; }
        public string Descripcion { get; set; }
        public string cantidadElegidos { get; set; }
        public string Total { get; set; }
        public List<string> Horarios { get; set; }
        public string Usuario { get; set; }
        public string Diferencia_Comprobante_Numero = string.Empty;
        bool PoseeRecargoAdministrativo = false;
        public bool EsDiferencia = false;
        public bool EsSenia = false;


        public List<string> Clases = new List<string>();
        public List<string> Alumnos = new List<string>();



        static internal List<Clase> GET()
        {

            List<Clase> newList = new List<Clase>();
            Clase aux = new Clase();
            newList.Add(aux);
            return newList;
        }

        //para Clases: Dependiendo de la cantidad de clases que vaya la persona a tomar por mes, se busca el precio en la lista
        public void getPrice()
        {
            string resp = string.Empty;
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_pago");
            var collection = database.GetCollection<BsonDocument>("profesor");
            //var filter = Builders<BsonDocument>.Filter.Empty;
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("name", this.Profesor);
            var result = collection.Find(filter).ToList();
            foreach (var doc in result)
            {
                this.Precio = (doc.GetElement(this.CantidadClases).Value.AsString);
            }
        }

        public void change_recargo()
        {
            this.PoseeRecargoAdministrativo = true;
        }

        public bool tiene_recargo()
        {
            return this.PoseeRecargoAdministrativo;
        }

        public void getAlumnos(string profesor, string clase)
        {
            var resp = (DateTime.Now).ToString("yyyy MMMM");
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_clases");
            var collection = database.GetCollection<BsonDocument>(resp);
            //var filter = Builders<BsonDocument>.Filter.Empty;
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("Profesor", profesor) & builder.Eq("Clase", clase);
            try
            {
                var result = collection.Find(filter).ToList().First();
                var alumno = result.GetValue("Alumnos", "No posee").AsBsonArray;
                foreach (var doc in alumno)
                {
                    if (!(this.Alumnos.Contains(doc.AsString)))
                    {
                        this.Alumnos.Add(doc.AsString);
                    }
                }
            }
            catch
            {

            }  
        }

        public void getAlumnosRange(string profesor, string clase, DateTime start, DateTime finish)
        {
            DateTime aux = finish.AddMonths(1);

            while(start.Month != aux.Month)
            {
                //MessageBox.Show(start.ToString("yyyy MMMM"));
                var client = new MongoClient(Global.Path_DataBase);
                var database = client.GetDatabase("app_clases");
                var collection = database.GetCollection<BsonDocument>(start.ToString("yyyy MMMM"));
                //var filter = Builders<BsonDocument>.Filter.Empty;
                var builder = Builders<BsonDocument>.Filter;
                var filter = builder.Eq("Profesor", profesor) & builder.Eq("Clase", clase);
                try
                {
                    var result = collection.Find(filter).ToList().First();
                    var alumno = result.GetValue("Alumnos", "No posee").AsBsonArray;
                    foreach (var doc in alumno)
                    {
                        if (!(this.Alumnos.Contains(doc.AsString)))
                        {
                            this.Alumnos.Add(doc.AsString);
                        }
                    }
                }
                catch
                {

                }
                start = start.AddMonths(1);
            }
            

            /*

             & builder.;
           */
        }

        public void getAlumnoForList(string profesor, string clase)
        {
            var resp = (DateTime.Now).ToString("yyyy MMMM");
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_clases");
            var collection = database.GetCollection<BsonDocument>(resp);
            //var filter = Builders<BsonDocument>.Filter.Empty;
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("Profesor", profesor) & builder.Eq("Clase", clase);
            try
            {
                var result = collection.Find(filter).ToList().First();
                var alumno = result.GetValue("Alumnos", "No posee").AsBsonArray;
                foreach (var doc in alumno)
                {
                    if (!(this.Alumnos.Contains(doc.AsString)))
                    {
                        this.Alumnos.Add(doc.AsString);
                    }
                }
            }
            catch
            {

            }
            DateTime d = DateTime.Now;
            d = d.AddMonths(-1);
            var resp2 = (DateTime.Now).ToString("yyyy ") + d.ToString("MMMM");
            var collection2 = database.GetCollection<BsonDocument>(resp2);
            try
            {
                var result = collection2.Find(filter).ToList().First();
                var alumno = result.GetValue("Alumnos", "No posee").AsBsonArray;
                foreach (var doc in alumno)
                {
                    if (!(this.Alumnos.Contains(doc.AsString)))
                    {
                        this.Alumnos.Add(doc.AsString);
                    }
                }
            }
            catch
            {

            }
        }

        public void getClases(string name)
        {
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_pago");
            var collection = database.GetCollection<BsonDocument>("profesor");
            //var filter = Builders<BsonDocument>.Filter.Empty;
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("name", name);
            var result = collection.Find(filter).ToList().First();
            var doc = (result.GetValue("clases").AsBsonDocument);
            doc.Names.ToList().ForEach(x => this.Clases.Add(x));
        }

        //devuelve el profesor de dicha clase, curso
        public void getProfesor()
        {
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_pago");
            var collection = database.GetCollection<BsonDocument>("cursos");
            //var filter = Builders<BsonDocument>.Filter.Empty;
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("name", this.ClasesTomar);
            var result = collection.Find(filter).ToList();
            foreach (var doc in result)
            {
                this.Profesor = "Profesor " + (doc.GetElement("profesor").Value.AsString);
            }
        }

        //Para Cursos: devuelve el precio del Curso
        public void getPrecio()
        {
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_pago");
            var collection = database.GetCollection<BsonDocument>("cursos");
            //var filter = Builders<BsonDocument>.Filter.Empty;
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("name", this.ClasesTomar);
            var result = collection.Find(filter).ToList();
            foreach (var doc in result)
            {
                this.Precio = (doc.GetElement("precio").Value.AsString);
            }
        }

        public Dictionary<string, int> RetriveDays(string profesor)
        {
            Dictionary<string, int> resp = new Dictionary<string, int>();
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_pago");
            var collection = database.GetCollection<BsonDocument>("profesor");
            //var filter = Builders<BsonDocument>.Filter.Empty;
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("name", profesor);
            try
            {
                var result = collection.Find(filter).ToList().First();
                var clases = result.GetValue("clases", "No posee").AsBsonDocument;
                var clase = clases.Names.ToList();
                foreach(var doc in clase)
                {
                    var clase1 = clases.GetValue(doc, "No posee").AsBsonDocument;
                    foreach(var nombre in clase1.Names.ToList())
                    {
                        var cantidad = clase1.GetValue(nombre, "No tiene dias").AsBsonArray;                     
                        resp[nombre]=cantidad.Count();
                    }
                  
                }                       
            }
            catch
            {

            }
            return resp;
        }
   

        public List<string> getProfesoresTodos()
        {
            List<string> resp = new List<string>();
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_pago");
            var collection = database.GetCollection<BsonDocument>("profesor");
            var filter = Builders<BsonDocument>.Filter.Empty;
            var result = collection.Find(filter).ToList();
            foreach (var doc in result)
            {
                var aux = doc.GetValue("name", "No tiene nombre").AsString;
                resp.Add(aux);
            }
            return resp;
        }

        public List<Clase> getProfesorListClase()
        {
            List<Clase> resp = new List<Clase>();           
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_pago");
            var collection = database.GetCollection<BsonDocument>("profesor");
            var filter = Builders<BsonDocument>.Filter.Empty;
            var result = collection.Find(filter).ToList();
            foreach (var doc in result)
            {
                Clase aux = new Clase();
                aux.Profesor = doc.GetValue("name", "No tiene nombre").AsString;
                resp.Add(aux);
            }
            return resp;
        }

        public List<string> getCursos()
        {
            List<string> resp = new List<string>();
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_pago");
            var collection = database.GetCollection<BsonDocument>("cursos");
            var filter = Builders<BsonDocument>.Filter.Empty;
            var result = collection.Find(filter).ToList();
            foreach (var doc in result)
            {
                var aux = doc.GetValue("name", "No tiene nombre").AsString;
                resp.Add(aux);
            }
            return resp;
        }

        public bool CollectionExists(IMongoDatabase database, string collectionName)
        {
            var filter = new BsonDocument("name", collectionName);
            var options = new ListCollectionNamesOptions { Filter = filter };

            return database.ListCollectionNames(options).Any();
        }

        //funcion original que divide a los alumnos por clase y cada clase en su respectivo hroario separado
        /*
        public void InsertMonthList(string month, string namePersona)
        {

            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_clases");
            var collection = database.GetCollection<BsonDocument>(month);
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("Profesor", this.Profesor) & builder.Eq("Clase", this.ClasesTomar);
            if (collection.Find(filter).Any())
            {
                var result = collection.Find(filter).ToList();
                foreach (var doc in result)
                {
                    foreach (var horario in this.Horarios)
                    {
                        var auxhorario = doc.GetValue(horario, "no posee");
                        if (auxhorario == "no posee")
                        {
                            List<string> AlumnosParticular = new List<string>();
                            AlumnosParticular.Add(namePersona);
                            var update = Builders<BsonDocument>.Update.Set(horario, AlumnosParticular);
                            var resultFinal = collection.UpdateOne(filter, update);
                        }
                        else
                        {
                            var update = Builders<BsonDocument>.Update.Push(horario, namePersona);
                            var resultFinal = collection.UpdateOne(filter, update);
                        }
                    }
                }
            }
            else
            {
                var client2 = new MongoClient(Global.Path_DataBase);
                var database2 = client2.GetDatabase("app_clases");
                var collection2 = database2.GetCollection<BsonDocument>(month);
                foreach (var horario in this.Horarios)
                {
                    List<string> auxAlum = new List<string>();
                    auxAlum.Add(namePersona);
                    BsonDocument aux = new BsonDocument
                    {
                        { "Profesor", this.Profesor },
                        { "Clase", this.ClasesTomar },
                    };
                    collection2.InsertOne(aux);


                    var filter2 = builder.Eq("Profesor", this.Profesor) & builder.Eq("Clase", this.ClasesTomar);
                    var update = Builders<BsonDocument>.Update.Set(horario, auxAlum);
                    var resultFinal = collection2.UpdateOne(filter2, update);
                }
            }
        }
        */

// fucnion que agrupa los alumnos que van a participar de una clase, sin tener en cuenta el horario al que asistan
            public void InsertMonthListRegular(string month, string namePersona)
            {
                var client = new MongoClient(Global.Path_DataBase);
                var database = client.GetDatabase("app_clases");
                var collection = database.GetCollection<BsonDocument>(month);
                var builder = Builders<BsonDocument>.Filter;
                
            if (this.ClasesTomar == "Generico")
            {
                this.getClases(this.Profesor);
                foreach(var clase in this.Clases)
                {
                    var filter = builder.Eq("Profesor", this.Profesor) & builder.Eq("Clase", clase);
                    if (collection.Find(filter).Any())
                    {
                        var result = collection.Find(filter).ToList();
                        foreach (var doc in result)
                        {
                            var update = Builders<BsonDocument>.Update.Push("Alumnos", namePersona);
                            var resultFinal = collection.UpdateOne(filter, update);

                        }
                    }
                    else
                    {
                        var client2 = new MongoClient(Global.Path_DataBase);
                        var database2 = client2.GetDatabase("app_clases");
                        var collection2 = database2.GetCollection<BsonDocument>(month);

                        List<string> auxAlum = new List<string>();
                        auxAlum.Add(namePersona);
                        BsonDocument aux = new BsonDocument
                        {
                            { "Profesor", this.Profesor },
                            { "Clase", this.ClasesTomar },
                        };
                        collection2.InsertOne(aux);


                        var filter2 = builder.Eq("Profesor", this.Profesor) & builder.Eq("Clase", this.ClasesTomar);
                        var update = Builders<BsonDocument>.Update.Set("Alumnos", auxAlum);
                        var resultFinal = collection2.UpdateOne(filter2, update);

                    }
                }

            }
            else
            {
                var filter = builder.Eq("Profesor", this.Profesor) & builder.Eq("Clase", this.ClasesTomar);
                if (collection.Find(filter).Any())
                {
                    var result = collection.Find(filter).ToList();
                    foreach (var doc in result)
                    {
                        var update = Builders<BsonDocument>.Update.Push("Alumnos", namePersona);
                        var resultFinal = collection.UpdateOne(filter, update);
                    }
                }
                else
                {
                    var client2 = new MongoClient(Global.Path_DataBase);
                    var database2 = client2.GetDatabase("app_clases");
                    var collection2 = database2.GetCollection<BsonDocument>(month);

                    List<string> auxAlum = new List<string>();
                    auxAlum.Add(namePersona);
                    BsonDocument aux = new BsonDocument
                    {
                        { "Profesor", this.Profesor },
                        { "Clase", this.ClasesTomar },
                    };
                    collection2.InsertOne(aux);


                    var filter2 = builder.Eq("Profesor", this.Profesor) & builder.Eq("Clase", this.ClasesTomar);
                    var update = Builders<BsonDocument>.Update.Set("Alumnos", auxAlum);
                    var resultFinal = collection2.UpdateOne(filter2, update);

                }

            }

                



                /*var client = new MongoClient(Global.Path_DataBase);
                var database = client.GetDatabase("app_pago");
                var collection = database.GetCollection<BsonDocument>("profesor");
                var builder = Builders<BsonDocument>.Filter;
                var filter = builder.Eq("name", "Profesora Ana Speziale");
                var update = Builders<BsonDocument>.Update.Set("clases", clases);
                var result = collection.UpdateOne(filter, update);*/
            }

        /*public class PersonasClase
        {
            public string Profesor { get; set; }
            public string Clase { get; set; }
            public Dictionary<string, List<string>> Horario { get; set; }
            private List<string> Alumnos { get; set; }

            public PersonasClase(string alumno, string horario)
            {
                Dictionary<string, List<string>> auxHorario = new Dictionary<string, List<string>>();
                List<string> auxAlumnos = new List<string>();
                auxAlumnos.Add(alumno);
                auxHorario.Add(horario, auxAlumnos);
                Alumnos = auxAlumnos;
                Horario = auxHorario;
            }
            
        }*/

        public class innerClasee
        {
            public List<Clase> clases { get; set; }
            public string Name { get; set; }

            public innerClasee()
            {

            }
        }




        public void chargeClase(string name, List<Clase> auxlist)
        {
            innerClasee cls = new innerClasee();
            cls.Name = name;
            List<Clase> aux = new List<Clase>();
            aux = auxlist;
            cls.clases = aux;
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_pago");
            var collection = database.GetCollection<innerClasee>("UltimoTicket");
            var builder = Builders<innerClasee>.Filter.Empty;
            //var filter = Builders<BsonDocument>.Filter.Empty;
            var result = collection.Find(builder).ToList();
            if (result.Any())
            {
                foreach(var doc in result)
                {
                    
                }       
            }
            else
            {
                collection.InsertOne(cls);
            }


               /* var filter = builder.Eq("Profesor", this.Profesor) & builder.Eq("Clase", this.ClasesTomar);
            BsonDocument aux = new BsonDocument
                    {
                        { "Profesor", this.Profesor },
                        { "Clase", this.ClasesTomar },
                    };
            collection2.InsertOne(aux);


            var filter2 = builder.Eq("Profesor", this.Profesor) & builder.Eq("Clase", this.ClasesTomar);
            var update = Builders<BsonDocument>.Update.Set("Alumnos", auxAlum);
            var resultFinal = collection2.UpdateOne(filter2, update);*/
        }


        
        public Stack<string> CargarClases()
        {
            Horario auxHorario = new Horario();
            Stack<string> resp = new Stack<string>();
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_pago");
            var collection = database.GetCollection<BsonDocument>("profesor");
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("name", this.Profesor);

            var result = collection.Find(filter).ToList();
            foreach (var doc in result)
            {
                var aux = doc.GetValue("clases", "No Posee").AsBsonDocument;
                var dia = aux.GetValue("Tai Chi para Principiantes", "No posee").AsBsonDocument;
                var horario = dia.GetValue("Viernes", "No posee").AsBsonArray;

                foreach (var clase in horario)
                {
                    var aux1 = clase;
                    
                    //auxHorario.Horarios = clase;
                    //clases.Add(clase, clase.Value);
                    resp.Push(aux1.ToString());
                }
            }
            return resp;
        }

        public HashSet<string> getKeys()
        {
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_pago");
            var collection = database.GetCollection<BsonDocument>("profesor");
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("name", this.Profesor);
            var result = collection.Find(filter).ToList();

            HashSet<string> keys = new HashSet<string>();
            foreach (var doc in result)
            {
                var aux = doc.GetValue("clases", "No Posee").AsBsonDocument;

                aux.Names.ToList().ForEach(p => keys.Add(p));
                
            }
            return keys;
        }

        public HashSet<string> getKeysDays(string clase)
        {
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_pago");
            var collection = database.GetCollection<BsonDocument>("profesor");
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("name", this.Profesor);
            var result = collection.Find(filter).ToList();

            HashSet<string> keys = new HashSet<string>();
            foreach (var doc in result)
            {
                var aux = doc.GetValue("clases", "No Posee").AsBsonDocument;
                var dia = aux.GetValue(clase, "No posee Horario").AsBsonDocument;

                dia.Names.ToList().ForEach(p => keys.Add(p));
                //dia.Names.ToList().ForEach(p => keys.Add(p));

                //dia.Names.ToList().ForEach(p => keys.Add(p));

            }
            return keys;
        }

        public HashSet<string> getKeysHorarios(string horarios)
        {
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_pago");
            var collection = database.GetCollection<BsonDocument>("profesor");
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("name", this.Profesor);
            var result = collection.Find(filter).ToList();

            HashSet<string> keys = new HashSet<string>();
            foreach (var doc in result)
            {
                var aux = doc.GetValue("clases", "No Posee").AsBsonDocument;
                var dia = aux.GetValue(this.ClasesTomar, "No posee Horario").AsBsonDocument;
                var horario = dia.GetValue(horarios, "No posee Horario").AsBsonArray;

                foreach(var hora in horario)
                {
                    keys.Add(hora.ToString());
                }

            }
            return keys;
        }


        public class Horario
        {
            public Dictionary<string, string[]> clase = new Dictionary<string, string[]>();
            public string Dia { get; set; }
            public string [] Horarios { get; set; }


            public Horario()
            {

            }

            public Horario(string dia, string[] horarios)
            {
                this.Dia = dia;
                this.Horarios = horarios;
                clase.Add(Dia, Horarios);
            }

            public void addHorario(string dia, string[] horarios)
            {
                clase.Add(dia, horarios);
            }

            public Dictionary<string, string[]> getHorario()
            {
                return clase;
            }
        }

        /*
        public void updateProfesores()
        {
            Dictionary<string, Dictionary<string, string[]>> clases = new Dictionary<string, Dictionary<string, string[]>>();

            string[] horario1 = new string[1]; horario1[0]= "17:00 a 18:00";
            Horario horarios1 = new Horario("Miercoles", horario1);
            horarios1.addHorario("Viernes", horario1);

            clases.Add("Chi Kung Silla", horarios1.getHorario());

            
            string[] horario3 = new string[1]; horario3[0] = "18:00 a 19:00";
            Horario horarios2 = new Horario("Miercoles", horario3);
            horarios2.addHorario("Viernes", horario3);

            clases.Add("Chi Kung Bambu", horarios2.getHorario());

            string[] horario4 = new string[1]; horario4[0] = "19:00 a 20:00";
            Horario horarios3 = new Horario("Miercoles", horario4);
            horarios3.addHorario("Viernes", horario4);

            clases.Add("Tai Chi para Principiantes", horarios3.getHorario());


            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_pago");
            var collection = database.GetCollection<BsonDocument>("profesor");
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("name", "Profesora Ana Speziale");
            var update = Builders<BsonDocument>.Update.Set("clases", clases);
            var result = collection.UpdateOne(filter, update);

        }
        */

        


        //lastnumber get from database      

        public int LastNumberServerRecibos()
        {
            int resp = 0;
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_pago");
            var collection = database.GetCollection<BsonDocument>("numerorecibo");
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("name", "recibos");
            var result = collection.Find(filter).ToList();
            foreach (var doc in result)
            {
                resp = doc.GetValue("numero", "No posee").AsInt32;
            }
            return resp;
        } 

        public void IncrementServerRecibosNumber()
        {
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("app_pago");
            var collection = database.GetCollection<BsonDocument>("numerorecibo");
            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("name", "recibos");
            var update = Builders<BsonDocument>.Update.Inc("numero",1);
            var resultFinal = collection.UpdateOne(filter, update);
        }




        //hacer Last
        public int LastNumber(string direccion, string save)
        {
            object misValue = System.Reflection.Missing.Value;
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook;
            Excel._Worksheet xlWorksheet;
            if (!System.IO.File.Exists(save))
            {
                xlApp.Quit();
                return 0001;
            }
            else
            {
                try
                {
                    File.Copy(Global.MensualServer + Path.GetFileName(save), Global.Mensual + Path.GetFileName(save), true);
                }
                catch (System.IO.FileNotFoundException)
                {

                }
                xlWorkbook = xlApp.Workbooks.Open(direccion, Type.Missing, Type.Missing, Type.Missing, Global.Connect());
                xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1);

                Excel.Range xlRange = xlWorksheet.UsedRange;
                int rowNumber = xlRange.Rows.Count;
                while (xlRange.Cells[rowNumber, "F"].Value < 0 || (xlRange.Cells[rowNumber, "G"].Value) == null)
                {
                    rowNumber--;
                }
                var resp = (xlRange.Cells[rowNumber, "G"].Value + 1);


                xlApp.DisplayAlerts = false;
                xlWorkbook.SaveAs(direccion);
                xlWorkbook.Close();
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorksheet);
                Marshal.ReleaseComObject(xlWorkbook);
                Marshal.ReleaseComObject(xlApp);

                return Convert.ToInt32(resp);
            }
        }

        public void CargaExcelDia(string direccion, Global Global, string save, string fecha, string comprobanteNumero, string Nombre)
        {

            try
            {
                File.Copy(Global.DiarioServer + Path.GetFileName(save), Global.Diario + Path.GetFileName(save), true);
            }
            catch (System.IO.FileNotFoundException)
            {

            }

            object misValue = System.Reflection.Missing.Value;
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook;
            Excel._Worksheet xlWorksheet;
            if (!System.IO.File.Exists(save))
            {
                xlWorkbook = xlApp.Workbooks.Add(misValue);
                xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1);
                Excel.Range xlRange = xlWorksheet.UsedRange;
                int rowCount = xlRange.Rows.Count;

                xlRange.Cells[1, "A"] = "Fecha";
                xlRange.Cells[1, "B"] = "Nombre";
                xlRange.Cells[1, "C"] = "Descripcion";
                xlRange.Cells[1, "D"] = "Cantidad";
                xlRange.Cells[1, "E"] = "Profesor";
                xlRange.Cells[1, "F"] = "Precio";
                xlRange.Cells[1, "G"] = "Nro Comprobante";
                xlRange.Cells[2, "A"] = fecha;
                xlRange.Cells[2, "B"] = Nombre;
                xlRange.Cells[2, "C"] = this.ClasesTomar;
                xlRange.Cells[2, "D"] = this.CantidadClases;
                xlRange.Cells[2, "E"] = this.Profesor;
                xlRange.Cells[2, "F"] = this.Total;
                xlRange.Cells[2, "G"] = comprobanteNumero;


                xlWorkbook.Password = Global.Connect();
                xlWorkbook.SaveAs(direccion);
                xlWorkbook.Close();
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorksheet);
                Marshal.ReleaseComObject(xlWorkbook);
                Marshal.ReleaseComObject(xlApp);
                File.Copy(Global.Diario + Path.GetFileName(save), Global.DiarioServer + Path.GetFileName(save), true);

            }
            else
            {
                xlWorkbook = xlApp.Workbooks.Open(direccion, Type.Missing, Type.Missing, Type.Missing, Global.Connect());
                xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1);

                Excel.Range xlRange = xlWorksheet.UsedRange;
                int rowNumber = xlRange.Rows.Count + 1;

                xlRange.Cells[rowNumber, "A"] = fecha;
                xlRange.Cells[rowNumber, "B"] = Nombre;
                xlRange.Cells[rowNumber, "C"] = this.Descripcion;
                xlRange.Cells[rowNumber, "D"] = this.ClasesTomar;
                xlRange.Cells[rowNumber, "E"] = this.Profesor;
                xlRange.Cells[rowNumber, "F"] = this.Total;
                xlRange.Cells[rowNumber, "G"] = comprobanteNumero;

                for (var x = 1; x < 11; x++)
                {
                    xlWorksheet.Columns[x].AutoFit();
                }

                // Disable file override confirmaton message 
                xlWorkbook.Password = Global.Connect();
                xlApp.DisplayAlerts = false;
                xlWorkbook.SaveAs(direccion);
                xlWorkbook.Close();
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorksheet);
                Marshal.ReleaseComObject(xlWorkbook);
                Marshal.ReleaseComObject(xlApp);
                File.Copy(Global.Diario + Path.GetFileName(save), Global.DiarioServer + Path.GetFileName(save), true);
            }
        }


        //cargar excel mes
        public void CargaExcelMes(string direccion, Global Global, string save, string fecha, string comprobanteNumero, string Nombre)
        {
            try
            {
                File.Copy(Global.MensualServer + Path.GetFileName(save), Global.Mensual + Path.GetFileName(save), true);
            }
            catch (System.IO.FileNotFoundException)
            {

            }

            object misValue = System.Reflection.Missing.Value;
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook;
            Excel._Worksheet xlWorksheet;
            if (!System.IO.File.Exists(save))
            {
                xlWorkbook = xlApp.Workbooks.Add(misValue);
                xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1);
                Excel.Range xlRange = xlWorksheet.UsedRange;
                int rowCount = xlRange.Rows.Count;

                xlRange.Cells[1, "A"] = "Fecha";
                xlRange.Cells[1, "B"] = "Nombre";
                xlRange.Cells[1, "C"] = "Descripcion";
                xlRange.Cells[1, "D"] = "Cantidad";
                xlRange.Cells[1, "E"] = "Profesor";
                xlRange.Cells[1, "F"] = "Precio";
                xlRange.Cells[1, "G"] = "Nro Comprobante";
                xlRange.Cells[2, "A"] = fecha;
                xlRange.Cells[2, "B"] = Nombre;
                xlRange.Cells[2, "C"] = this.Descripcion;
                xlRange.Cells[2, "D"] = this.ClasesTomar;
                xlRange.Cells[2, "E"] = this.Profesor;
                xlRange.Cells[2, "F"] = this.Total;
                xlRange.Cells[2, "G"] = comprobanteNumero;

                xlWorkbook.Password = Global.Connect();
                xlWorkbook.SaveAs(direccion);
                xlWorkbook.Close();
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorksheet);
                Marshal.ReleaseComObject(xlWorkbook);
                Marshal.ReleaseComObject(xlApp);
                File.Copy(Global.Mensual + Path.GetFileName(save), Global.MensualServer + Path.GetFileName(save), true);
            }
            else
            {
                xlWorkbook = xlApp.Workbooks.Open(direccion, Type.Missing, Type.Missing, Type.Missing, Global.Connect());
                xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1);

                Excel.Range xlRange = xlWorksheet.UsedRange;
                int rowNumber = xlRange.Rows.Count + 1;

                xlRange.Cells[rowNumber, "A"] = fecha;
                xlRange.Cells[rowNumber, "B"] = Nombre;
                xlRange.Cells[rowNumber, "C"] = this.Descripcion;
                xlRange.Cells[rowNumber, "D"] = this.ClasesTomar;
                xlRange.Cells[rowNumber, "E"] = this.Profesor;
                xlRange.Cells[rowNumber, "F"] = this.Total;
                xlRange.Cells[rowNumber, "G"] = comprobanteNumero;

                for (var x = 1; x < 11; x++)
                {
                    xlWorksheet.Columns[x].AutoFit();
                }

                // Disable file override confirmaton message  
                xlWorkbook.Password = Global.Connect();
                xlApp.DisplayAlerts = false;
                xlWorkbook.SaveAs(direccion);
                xlWorkbook.Close();
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorksheet);
                Marshal.ReleaseComObject(xlWorkbook);
                Marshal.ReleaseComObject(xlApp);
                File.Copy(Global.Mensual + Path.GetFileName(save), Global.MensualServer + Path.GetFileName(save), true);
            }

        }


        //Carga el Excel del Profesor
        public void CargarExcelProfesor(string direccion, Global Global, string save, string fecha, string comprobanteNumero, string Nombre)
        {
            try
            {
                File.Copy(Global.LiquidacionesServer + Path.GetFileName(save), Global.Liquidaciones + Path.GetFileName(save), true);
            }
            catch (System.IO.FileNotFoundException)
            {

            }

            object misValue = System.Reflection.Missing.Value;
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook;
            Excel._Worksheet xlWorksheet;
            if (!System.IO.File.Exists(save))
            {
                xlWorkbook = xlApp.Workbooks.Add(misValue);
                xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1);
                Excel.Range xlRange = xlWorksheet.UsedRange;
                int rowCount = xlRange.Rows.Count;

                xlRange.Cells[1, "A"] = "Fecha";
                xlRange.Cells[1, "B"] = "Nombre";
                xlRange.Cells[1, "C"] = "Descripcion";
                xlRange.Cells[1, "D"] = "Cantidad";
                xlRange.Cells[1, "E"] = "Profesor";
                xlRange.Cells[1, "F"] = "Precio";
                xlRange.Cells[1, "G"] = "Nro Comprobante";
                xlRange.Cells[2, "A"] = fecha;
                xlRange.Cells[2, "B"] = Nombre;
                xlRange.Cells[2, "C"] = this.Descripcion;
                xlRange.Cells[2, "D"] = this.CantidadClases;
                xlRange.Cells[2, "E"] = this.Profesor;
                xlRange.Cells[2, "F"] = this.Total;
                xlRange.Cells[2, "G"] = comprobanteNumero;


                xlWorkbook.Password = Global.Connect();
                xlWorkbook.SaveAs(direccion);
                xlWorkbook.Close();
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorksheet);
                Marshal.ReleaseComObject(xlWorkbook);
                Marshal.ReleaseComObject(xlApp);
                File.Copy(Global.Liquidaciones + Path.GetFileName(save), Global.LiquidacionesServer + Path.GetFileName(save), true);

            }
            else
            {
                xlWorkbook = xlApp.Workbooks.Open(direccion, Type.Missing, Type.Missing, Type.Missing, Global.Connect());
                xlWorksheet = (Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1);

                Excel.Range xlRange = xlWorksheet.UsedRange;
                int rowNumber = xlRange.Rows.Count + 1;

                xlRange.Cells[rowNumber, "A"] = fecha;
                xlRange.Cells[rowNumber, "B"] = Nombre;
                xlRange.Cells[rowNumber, "C"] = this.Descripcion;
                xlRange.Cells[rowNumber, "D"] = this.ClasesTomar;
                xlRange.Cells[rowNumber, "E"] = this.Profesor;
                xlRange.Cells[rowNumber, "F"] = this.Total;
                xlRange.Cells[rowNumber, "G"] = comprobanteNumero;


                for (var x = 1; x < 11; x++)
                {
                    xlWorksheet.Columns[x].AutoFit();
                }

                // Disable file override confirmaton message  
                xlWorkbook.Password = Global.Connect();
                xlApp.DisplayAlerts = false;
                xlWorkbook.SaveAs(direccion);
                xlWorkbook.Close();
                xlApp.Quit();

                Marshal.ReleaseComObject(xlWorksheet);
                Marshal.ReleaseComObject(xlWorkbook);
                Marshal.ReleaseComObject(xlApp);

                File.Copy(Global.Liquidaciones + Path.GetFileName(save), Global.LiquidacionesServer + Path.GetFileName(save), true);
            }
        }

        public void addComprobante(List<Clase> ClasesList, string nombre, string comprobante, string fecha)
        {
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("Personas");
            var collection = database.GetCollection<BsonDocument>("Comprobantes");
            var document = new BsonDocument
                {
                    { "Nombre", nombre },
                    { "NumeroComprobante", comprobante },
                    { "Fecha", fecha },
                    { "Usuario",  Global.getActualUser()}
                };

            var filter = Builders<BsonDocument>.Filter.Eq("Nombre", nombre) & Builders<BsonDocument>.Filter.Eq("NumeroComprobante", comprobante) & Builders<BsonDocument>.Filter.Eq("Fecha", fecha);
            collection.InsertOne(document);
            foreach (var clase in ClasesList)
            {            
                var document2 = new BsonDocument
                {
                    { "CantidadClases", clase.CantidadClases },
                    { "Profesor", clase.Profesor },
                    { "Precio", clase.Precio },
                    { "ClasesTomar",  clase.ClasesTomar},
                    { "Descripcion",  clase.Descripcion},
                    { "cantidadElegidos",  clase.cantidadElegidos},
                    { "Total",  clase.Total},
                    { "Posee_Seña",  clase.EsSenia},
                    { "Es_Diferencia",  clase.EsDiferencia},
                };
                if (!string.IsNullOrEmpty(clase.Diferencia_Comprobante_Numero))
                {
                    var aux = new BsonDocument
                    {
                        { "Diferencia_Comprobante_Numero" , clase.Diferencia_Comprobante_Numero },
                    };
                    document2.AddRange(aux);
                }




                var update = Builders<BsonDocument>.Update.Push("Clases", document2);
                var result = collection.UpdateOne(filter, update);
            }           
            addComprobanteAlumno(nombre, comprobante);
        }

        private void addComprobanteAlumno(string name, string comprobante)
        {
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("Personas");
            var collection = database.GetCollection<BsonDocument>("Alumnos");
            var filter = Builders<BsonDocument>.Filter.Eq("Nombre", name);
            var update = Builders<BsonDocument>.Update.Push("Comprobantes", comprobante);
            var result = collection.UpdateOne(filter, update);
        }

        public void addComprobanteDiferencia(string comprobanteNew)
        {
            var client = new MongoClient(Global.Path_DataBase);
            var database = client.GetDatabase("Personas");
            var collection = database.GetCollection<BsonDocument>("Comprobantes");
            var filter = Builders<BsonDocument>.Filter.Eq("NumeroComprobante", Diferencia_Comprobante_Numero);
            var update = Builders<BsonDocument>.Update.Set("DiferenciaReciboNumero", comprobanteNew);
            var result = collection.UpdateOne(filter, update);
        }


        public void generateList(List<Clase> ClasesList, string nombre)
        {

        }

    }
}
