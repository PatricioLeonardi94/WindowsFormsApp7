using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp7
{
    class DayMinClase
    {
        public int FirstDay { get; set; }
        public List<int> Dias = new List<int>();
        public string Day { get; set; }
        public int CantidadDeClasesPorDia { get; set; }
        string diaAux = string.Empty;
        int mesSelected;

        public DayMinClase(string dia, int cantidad, int mes)
        {
            this.mesSelected = mes;        
            var day = dia;
            if (dia == "Martes")
            {
                day = "Tuesday";
                this.Day = "Ma";
            }
            else if (dia == "Miercoles")
            {
                day = "Wednesday";
                this.Day = "Mi";
            }
            else if (dia == "Jueves")
            {
                day = "Thursday";
                this.Day = "Ju";
            }
            else if (dia == "Viernes")
            {
                day = "Friday";
                this.Day = "Vi";
            }
            else if (dia == "Sabado")
            {
                day = "Saturday";
                this.Day = "Sa";
            }
            diaAux = day;
            this.CantidadDeClasesPorDia = cantidad;
            getFirstDay();
        }

        private void getFirstDay()
        {
            List<int> respDiaParcial = new List<int>();
            int aux1 = DateTime.Now.Year;
            int aux2 = this.mesSelected;
            int lastDay = System.DateTime.DaysInMonth(aux1, aux2);
            var firstDat = new DateTime(aux1, aux2, 1);
            int firstDay = 1;



            while (firstDat.DayOfWeek.ToString() != diaAux)
            {
                firstDat = firstDat.AddDays(1);
                firstDay++;
            }
            this.FirstDay = firstDay;

            while (firstDay <= lastDay)
            {
                respDiaParcial.Add(firstDay);
                firstDay += 7;
            }

            this.Dias = respDiaParcial;
        }
    }

    class AllDayMinClass
    {
        public List<DayMinClase> dias = new List<DayMinClase>();


        public AllDayMinClass()
        {
            
        }

        public void add(DayMinClase dia)
        {
            this.dias.Add(dia);
        }

        public DayMinClase getMin()
        {
            int aux = this.dias.Min(dia => dia.FirstDay);
            DayMinClase resp = this.dias.Find(dia => dia.FirstDay == aux);
            var itemToRemove = this.dias.Single(dia => dia.FirstDay == aux);
            this.dias.Remove(itemToRemove);
            return resp;
        }

        public bool Any()
        {
            return this.dias.Any();
        }

        public int getWholeDays()
        {
            int resp = 0;
            foreach (var dia in this.dias)
            {
                resp += dia.CantidadDeClasesPorDia;
            }
            return resp;
        }

        public int getTotalDays()
        {
            int resp = 0;
            foreach(var dia in this.dias)
            {
                resp += dia.CantidadDeClasesPorDia * dia.Dias.Count(); 
            }
            return resp;
        }


    }
}
