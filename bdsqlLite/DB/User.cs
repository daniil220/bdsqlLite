using System.Collections.Generic;

namespace SQLlitleForIS_19_03.DB
{
    public class User
    {
        public static float user;
        
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Email> Emails { get; set; }

        public override string ToString()
        {
            return Name ;
        }



    }
}