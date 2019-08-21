using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace WindowsFormsApp7
{
    class ComprobanteParcial
    {
        public MongoDB.Bson.ObjectId _id { get; set; }
        public string Dia { get; set; }
        public int ComprobanteLast { get; set; }
    }
}
