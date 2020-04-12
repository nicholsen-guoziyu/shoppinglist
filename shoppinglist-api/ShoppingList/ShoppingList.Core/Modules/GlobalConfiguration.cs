﻿using System.Collections.Generic;

namespace ShoppingList.Core
{
    public static class GlobalConfiguration
    {
        public static IList<ModuleInfo> Modules { get; set; } = new List<ModuleInfo>();

        public static string WebRootPath { get; set; }

        public static string ContentRootPath { get; set; }
    }
}
