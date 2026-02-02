using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHub.Common
{
    public class CountryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string FlagIcon { get; set; }
        public string PhoneCode { get; set; }
        public int Gmt { get; set; }
        public string Language { get; set; }
    }
}
