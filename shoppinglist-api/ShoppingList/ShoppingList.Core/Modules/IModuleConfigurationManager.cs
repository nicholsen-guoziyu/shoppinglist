using System.Collections.Generic;

namespace ShoppingList.Core
{
    public interface IModuleConfigurationManager
    {
        IEnumerable<ModuleInfo> GetModules();
    }
}