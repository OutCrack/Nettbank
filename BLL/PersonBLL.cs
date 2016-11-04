using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nettbank.DAL;
using Nettbank.Model;

namespace BLL
{
    public class PersonBLL
    {
        public bool regNyPerson(Person innPerson, byte[])
        {
            var PersonDAL = new PersonDAL();
            return PersonDAL.regNyPerson(innPerson);
        }
    }
}
