using Microsoft.EntityFrameworkCore;
using ShoppingList.Core;
using ShoppingList.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ShoppingList.Data.SqlServerDataProvider
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            List<Type> typeToRegisters = new List<Type>();
            foreach (var module in GlobalConfiguration.Modules)
            {
                typeToRegisters.AddRange(module.Assembly.DefinedTypes.Select(t => t.AsType()));
            }

            RegisterEntities(modelBuilder, typeToRegisters);
        }

        private static void RegisterEntities(ModelBuilder modelBuilder, IEnumerable<Type> typeToRegisters)
        {
            var entityTypes = typeToRegisters.Where(x => x.GetTypeInfo().IsSubclassOf(typeof(EntityBase)) && !x.GetTypeInfo().IsAbstract);
            foreach (var type in entityTypes)
            {
                var entityBuilder = modelBuilder.Entity(type);
                FieldInfo dataTimestampField = type.GetField("DataTimestamp");
                if (dataTimestampField != null)
                {
                    entityBuilder.Property(dataTimestampField.Name).IsConcurrencyToken().ValueGeneratedOnAddOrUpdate();
                }
            }
        }
    }
}
