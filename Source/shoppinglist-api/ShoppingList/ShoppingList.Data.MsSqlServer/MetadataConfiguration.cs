using LinqToDB.Mapping;

namespace ShoppingList.Data.MsSqlServer
{
    public class MetadataConfiguration
    {
        private static MappingSchema _metadataMapping;

        public static MappingSchema MappingSchemaInstance
        {
            get => _metadataMapping;
            set
            {
                _metadataMapping = value;
            }
        }
    }
}
