using Spire.Xls;
using System;
using System.Collections.Generic;
using System.Data;

namespace spajer
{
    enum WeekDays
    {
        Poniedziałek,
        Wtorek,
        Środa,
        Czwartek,
        Piątek,
        Sobota,
        Niedziela
    }

    public class ExcelExtractor
    {
        public List<ScheduleItem> ExtractScheduleItems()
        {
            List<ScheduleItem> result = new List<ScheduleItem>();
            var tables = Extract();
            var table = tables[0];

            for (int r = 0; r < table.Rows.Count; r++)
            {
                DateTime tryhour;
                if (!DateTime.TryParse(table.Rows[r][0].ToString(), out tryhour)) continue;

                var hour = tryhour.Hour;

                for (int c = 1; c < table.Columns.Count; c++)
                {
                    try
                    {
                        if (table.Rows[r][c].ToString() == "") continue;

                        DateTime dateTime = new DateTime(1, 1, c/*trzeba odjac przy pustej kolumnie*/, hour, 0/*lub 15,lub 30*/, 0);
                        string[] splitted = table.Rows[r][c].ToString().Split(new[] { "\n" }, StringSplitOptions.None);
                        string name = GetName(splitted);
                        string leader = GetLeader(splitted);
                        Place place = new Place() { Address = "jupiter" };

                        result.Add
                        (
                            new ScheduleItem()
                            {
                                Time = dateTime,
                                Leader = leader,//part 2 
                                Name = name,//part 1
                                Place = place//TODO:change,take name from filename or table header
                            }
                        );
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        //throw;
                    }
                }
            }

            return result;
        }

        private static string GetLeader(string[] splitted)
        {
            if (splitted.Length == 1)
            {
                return splitted[0];
            }

            return splitted[1];
        }

        private static string GetName(string[] splitted)
        {
            if (splitted.Length == 1)
            {
                return "Zumba";
            }

            return splitted[0];
        }

        public List<DataTable> Extract()
        {
            List<DataTable> res = new List<DataTable>();
            Workbook workbook = new Workbook();
            workbook.LoadFromFile(@"c:\greg\fa\xls\Jupiter_grafik-1-2019.04.01.xlsx");
            foreach (Worksheet worksheet in workbook.Worksheets)
            {
                var dataSource = worksheet.ExportDataTable();
                res.Add(dataSource);
            }
            return res;
        }
    }
}
