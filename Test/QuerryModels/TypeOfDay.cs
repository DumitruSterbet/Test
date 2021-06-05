using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.QuerryModels
{
    public class TypeOfDay
    {
     
        public string typeOfDay { set; get; }

        public TypeOfDay(string Type)
        {
           
            this.typeOfDay = Type;
        }
    }
}
