using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spajer
{
    public class ScheduleItem
    {
        /// <summary>
        /// dzien tygodnia i godzina
        /// </summary>
        public DateTime Time { get; set; }
        
        /// <summary>
        /// nazwa zajęć
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// prowadzący
        /// </summary>
        public string Leader { get; set; }

        public Place Place { get; set; }
    }
}
