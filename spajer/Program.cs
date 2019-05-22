using Spire.Xls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spajer
{
    class Program
    {
        static void Main(string[] args)
        {
            ExtractFromExcel();
        }

        private static void ExtractFromExcel()
        {
            var dataTable = new ExcelExtractor().Extract();
        }
    }
}
