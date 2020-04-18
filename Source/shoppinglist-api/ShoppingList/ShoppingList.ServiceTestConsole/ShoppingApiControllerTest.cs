using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingList.ServiceTestConsole
{
    class ShoppingApiControllerTest
    {
        protected string ServiceAddress = "https://localhost:44349/";
        protected string RootAddress = String.Empty;
        public ShoppingApiControllerTest()
        {
            RootAddress = "api/shopping";
        }

        
    }
}
