using System;
using System.Collections.Generic;
using System.Text;

namespace UtilityManagerXamarin.Parameters
{
    class Parametre
    {
        public string ServeurName = string.Empty;
        public Parametre()
        {
            //ServeurName = "http:///TeamIsUMProject";
              ServeurName = "http://192.168.43.101/TeamIsUMProject"; //S8+
            // ServeurName = "http://192.168.1.106/TeamIsUMProject";
            // ServeurName = "http://192.168.1.105/TeamIsUMProject"; // Vodafone
            // ServeurName = "http://192.168.1.109/TeamIsUMProject"; // Isoft
             //  ServeurName = "http://192.168.1.104/TeamIsUMProject"; 
            // ServeurName = "http://192.168.1.171/TeamIsUMProject"; 






        }

        public Parametre(string newserveurname)
        {
            ServeurName = newserveurname;
        }

        public void SetServeurName(string newserveurname)
        {
            ServeurName = newserveurname;
        }

        public string GetServeurName()
        {
            return ServeurName;
        }
    }
}
