using System;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using MongoDB.Bson;
using MongoDB.Driver;
using System.IO;
using

System.Drawing;

using

System.Drawing.Printing;



namespace WindowsFormsApp7
{
    public class CreaTicket
    {
            public string impresora { get; set; }
            int linea = 44;
            string ticket = "";
            string parte1, parte2;
            
            // string impresora = "\\\\FARMACIA-PVENTA\\Generic / Text Only"; // nombre exacto de la impresora como esta en el panel de control
            int max, cort;
            public void LineasGuion()
            {
                string aux = string.Empty;
                for (var i = 0; i < linea; i++)
                {
                    aux += "-";
                }
                aux += "\n";
                ticket = aux;   // agrega lineas separadoras -
                RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime linea
            }
            public void SetPrinter(string name)
            {
                this.impresora = name;
            }
            public void AgregaLinea(int number)
            {
                string aux = string.Empty;
                for (var i = 0; i < linea; i++)
                {
                    aux += " ";
                }
                aux += "\n";

                for (var i = 0; i < number; i++)
                {
                    ticket = aux;   // agrega lineas -
                    RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime linea
                }
            }
            public void LineasAsterisco()
            {
                string aux = string.Empty;
                for (var i = 0; i < linea; i++)
                {
                    aux += "*";
                }
                aux += "\n";
                ticket = aux;   // agrega lineas separadoras *
                RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime linea
            }
            public void LineasIgual()
            {
                string aux = string.Empty;
                for (var i = 0; i < linea; i++)
                {
                    aux += "=";
                }
                aux += "\n";
                ticket = aux;   // agrega lineas separadoras =
                RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime linea
            }
            public void LineasTotales()
            {
                string aux = string.Empty;
                for (var i = 0; i < (linea / 4) * 3; i++)
                {
                    aux += " ";
                }
                for (var i = 0; i < (linea / 4); i++)
                {
                    aux += "-";
                }
                aux += "\n";
                ticket = aux; ;   // agrega lineas de total
                RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime linea
            }
            public void EncabezadoVenta()
            {
                ticket = "Clase               Cantidad     Importe\n";   // agrega lineas de  encabezados
                RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime texto
            }
            public void TextoIzquierda(string par1)                          // agrega texto a la izquierda
            {
                max = par1.Length;
                if (max > linea)                                 // **********
                {
                    cort = max - linea;
                    parte1 = par1.Remove(linea, cort);        // si es mayor que 40 caracteres, lo corta
                }
                else { parte1 = par1; }                      // **********
                ticket = parte1 + "\n";
                RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime texto
            }
            public void TextoDerecha(string par1)
            {
                ticket = "";
                max = par1.Length;
                if (max > linea)                                 // **********
                {
                    cort = max - linea;
                    parte1 = par1.Remove(linea, cort);           // si es mayor que 40 caracteres, lo corta
                }
                else { parte1 = par1; }                      // **********
                max = linea - par1.Length;                     // obtiene la cantidad de espacios para llegar a 40
                for (int i = 0; i < max; i++)
                {
                    ticket += " ";                          // agrega espacios para alinear a la derecha
                }
                ticket += parte1 + "\n";                    //Agrega el texto
                RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime texto
            }
            public void TextoCentro(string par1)
            {
                ticket = "";
                max = par1.Length;
                if (max > linea)                                 // **********
                {
                    cort = max - linea;
                    parte1 = par1.Remove(linea, cort);          // si es mayor que 40 caracteres, lo corta
                }
                else { parte1 = par1; }                      // **********
                max = (int)(linea - parte1.Length) / 2;         // saca la cantidad de espacios libres y divide entre dos
                for (int i = 0; i < max; i++)                // **********
                {
                    ticket += " ";                           // Agrega espacios antes del texto a centrar
                }                                            // **********
                ticket += parte1 + "\n";
                RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime texto
            }
            public void TextoExtremos(string par1, string par2)
            {
                max = par1.Length;
                if (max > 16)                                 // **********
                {
                    cort = max - 16;
                    parte1 = par1.Remove(16, cort);          // si par1 es mayor que 18 lo corta
                }
                else { parte1 = par1; }                      // **********
                ticket = parte1;                             // agrega el primer parametro
                max = par2.Length;
                if (max > 13)                                 // **********
                {
                    cort = max - 13;
                    parte2 = par2.Remove(13, cort);          // si par2 es mayor que 18 lo corta
                }
                else { parte2 = par2; }
                max = linea - (parte1.Length + parte2.Length);
                for (int i = 0; i < max; i++)                 // **********
                {
                    ticket += " ";                            // Agrega espacios para poner par2 al final
                }                                             // **********
                ticket += parte2 + "\n";                     // agrega el segundo parametro al final
                RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime texto
            }
            public void TextoExtremos2(string par1, string par2)
            {
                max = par1.Length;
                if (max > 6)                                 // **********
                {
                    cort = max - 6;
                    parte1 = par1.Remove(6, cort);          // si par1 es mayor que 18 lo corta
                }
                else { parte1 = par1; }                      // **********
                ticket = parte1;                             // agrega el primer parametro
                max = par2.Length;
                if (max > 22)                                 // **********
                {
                    cort = max - 22;
                    parte2 = par2.Remove(22, cort);          // si par2 es mayor que 18 lo corta
                }
                else { parte2 = par2; }
                max = linea - (parte1.Length + parte2.Length);
                for (int i = 0; i < max; i++)                 // **********
                {
                    ticket += " ";                            // Agrega espacios para poner par2 al final
                }                                             // **********
                ticket += parte2 + "\n";                     // agrega el segundo parametro al final
                RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime texto
            }
            public void AgregaTotales(string par1, string total)
            {
                max = par1.Length;
                if (max > 25)                                 // **********
                {
                    cort = max - 25;
                    parte1 = par1.Remove(25, cort);          // si es mayor que 25 lo corta
                }
                else { parte1 = par1; }                      // **********
                ticket = parte1;
                parte2 = total;
                max = linea - (parte1.Length + parte2.Length);
                for (int i = 0; i < max; i++)                // **********
                {
                    ticket += " ";                           // Agrega espacios para poner el valor de moneda al final
                }                                            // **********
                ticket += parte2 + "\n";
                RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime texto

            }
            public void TextoCentro2(string par1)
            {
                ticket = "";
                max = par1.Length;
                if (max > linea)                                 // **********
                {
                    cort = max - linea;
                    parte1 = par1.Remove(linea, cort);          // si es mayor que 40 caracteres, lo corta
                }
                else { parte1 = par1; }                      // **********
                max = (int)(linea - parte1.Length) / 2;         // saca la cantidad de espacios libres y divide entre dos
                for (int i = 0; i < max; i++)                // **********
                {
                    ticket += " ";                           // Agrega espacios antes del texto a centrar
                }                                            // **********
                ticket += parte1 + "\n";
                RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime texto
            }
            /*
            public void AgregaArticulo(string par1, string cant, string precio)
            {
                if (cant.Length <= 13 && precio.Length <= 12) // valida que cant precio y total esten dentro de rango
                {
                    max = par1.Length;
                    if (max > 15)                                 // **********
                    {
                        cort = max - 15;
                        parte1 = par1.Remove(15, cort);          // corta a 20 la descripcion del articulo
                    }
                    else { parte1 = par1; }                      // **********
                    ticket = parte1;                             // agrega articulo
                    max = (13 - cant.ToString().Length) + (15 - parte1.Length);
                    for (int i = 0; i < max; i++)                // **********
                    {
                        ticket += " ";                           // Agrega espacios para poner el valor de cantidad
                    }
                    ticket += cant;                   // agrega cantidad
                    max = 12 - (precio.Length);
                    for (int i = 0; i < max; i++)                // **********
                    {
                        ticket += " ";                           // Agrega espacios
                    }                                            // **********
                    ticket += precio; // agrega precio
                    ticket += "\n";
                    RawPrinterHelper.SendStringToPrinter(impresora, ticket); // imprime texto
                }
                else
                {
                    MessageBox.Show("Valores fuera de rango");
                    RawPrinterHelper.SendStringToPrinter(impresora, "Error, valor fuera de rango\n"); // imprime texto
                }
            }*/
            public void CortaTicket()
            {
                string corte = "\x1B" + "m";                  // caracteres de corte
                string avance = "\x1B" + "d" + "\x07";        // avanza 9 renglones
                RawPrinterHelper.SendStringToPrinter(impresora, avance); // avanza
                RawPrinterHelper.SendStringToPrinter(impresora, corte); // corta
                /*PrintDocument p = new PrintDocument();
                p.Print();*/
            }
            /*public void AbreCajon()
            {
                string cajon0 = "\x1B" + "p" + "\x00" + "\x0F" + "\x96";                  // caracteres de apertura cajon 0
                string cajon1 = "\x1B" + "p" + "\x01" + "\x0F" + "\x96";                 // caracteres de apertura cajon 1
                RawPrinterHelper.SendStringToPrinter(impresora, cajon0); // abre cajon0
                //RawPrinterHelper.SendStringToPrinter(impresora, cajon1); // abre cajon1
            }*/
        }

        //ejemplo de CrearTicket
        // TextoIzquierda("Empleado 1")                    40                      Empleado 1      
        // TextoDerecha("Caja 1")                          40                                                        Caja 1
        // TextoCentro("Ticket")                           40                                         Ticket   
        // TextoExtremos("Fecha 6/1/2011","Hora:13:25")     18 y 18                 Fecha 6/1/2011                Hora:13:25
        // EncabezadoVenta()                                n/a                     Clase        Cant Clases     Importe
        // LineasGuion()                                    n/a                     ----------------------------------------
        // AgregaArticulo("Aspirina","2",45.25,90.5)        16,3,10,11              Aspirina          2           $90.50
        // LineasTotales()                                  n/a                                                ----------
        // AgregaTotales("Subtotal",235.25)                 25 y 15                Subtotal                      $235.25
        // LineasAsterisco()                                n/a                     ****************************************
        // LineasIgual()                                    n/a                     ========================================
        // CortaTicket()
        // AbreCajon()         
    }

    public class RawPrinterHelper
    {
        // Structure and API declarions:
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDocName;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pOutputFile;
            [MarshalAs(UnmanagedType.LPStr)]
            public string pDataType;
        }
        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, Int32 level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, Int32 dwCount, out Int32 dwWritten);

        // SendBytesToPrinter()
        // When the function is given a printer name and an unmanaged array
        // of bytes, the function sends those bytes to the print queue.
        // Returns true on success, false on failure.
        public static bool SendBytesToPrinter(string szPrinterName, IntPtr pBytes, Int32 dwCount)
        {
            Int32 dwError = 0, dwWritten = 0;
            IntPtr hPrinter = new IntPtr(0);
            DOCINFOA di = new DOCINFOA();
            bool bSuccess = false; // Assume failure unless you specifically succeed.

            di.pDocName = "My C#.NET RAW Document";
            di.pDataType = "RAW";

            // Open the printer.
            if (OpenPrinter(szPrinterName.Normalize(), out hPrinter, IntPtr.Zero))
            {
                // Start a document.
                if (StartDocPrinter(hPrinter, 1, di))
                {
                    // Start a page.
                    if (StartPagePrinter(hPrinter))
                    {
                        // Write your bytes.
                        bSuccess = WritePrinter(hPrinter, pBytes, dwCount, out dwWritten);
                        EndPagePrinter(hPrinter);
                    }
                    EndDocPrinter(hPrinter);
                }
                ClosePrinter(hPrinter);
            }
            // If you did not succeed, GetLastError may give more information
            // about why not.
            if (bSuccess == false)
            {
                dwError = Marshal.GetLastWin32Error();
            }
            return bSuccess;
        }

        public static bool SendFileToPrinter(string szPrinterName, string szFileName)
        {
            // Open the file.
            FileStream fs = new FileStream(szFileName, FileMode.Open);
            // Create a BinaryReader on the file.
            BinaryReader br = new BinaryReader(fs);
            // Dim an array of bytes big enough to hold the file's contents.
            Byte[] bytes = new Byte[fs.Length];
            bool bSuccess = false;
            // Your unmanaged pointer.
            IntPtr pUnmanagedBytes = new IntPtr(0);
            int nLength;

            nLength = Convert.ToInt32(fs.Length);
            // Read the contents of the file into the array.
            bytes = br.ReadBytes(nLength);
            // Allocate some unmanaged memory for those bytes.
            pUnmanagedBytes = Marshal.AllocCoTaskMem(nLength);
            // Copy the managed byte array into the unmanaged array.
            Marshal.Copy(bytes, 0, pUnmanagedBytes, nLength);
            // Send the unmanaged bytes to the printer.
            bSuccess = SendBytesToPrinter(szPrinterName, pUnmanagedBytes, nLength);
            // Free the unmanaged memory that you allocated earlier.
            Marshal.FreeCoTaskMem(pUnmanagedBytes);
            fs.Close();
            fs.Dispose();
            fs = null;
            return bSuccess;
        }

        public static bool SendStringToPrinter(string szPrinterName, string szString)
        {
            IntPtr pBytes;
            Int32 dwCount;
            // How many characters are in the string?
            dwCount = szString.Length;
            // Assume that the printer is expecting ANSI text, and then convert
            // the string to ANSI text.
            pBytes = Marshal.StringToCoTaskMemAnsi(szString);
            // Send the converted ANSI string to the printer.
            SendBytesToPrinter(szPrinterName, pBytes, dwCount);
            Marshal.FreeCoTaskMem(pBytes);
            return true;
        }
    }
