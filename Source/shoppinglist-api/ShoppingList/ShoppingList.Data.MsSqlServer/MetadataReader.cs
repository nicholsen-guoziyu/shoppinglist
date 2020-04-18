using System;
using System.Collections.Concurrent;
using LinqToDB.Mapping;
using System.Reflection;
using LinqToDB.Metadata;
using LinqToDB.SqlQuery;


namespace ShoppingList.Data.MsSqlServer
{
    public partial class MetadataReader : IMetadataReader
    {
        public MetadataReader()
        {
        }


        protected T GetAttribute<T>(Type type, MemberInfo memberInfo) where T : Attribute
        {
            var attribute = Types.GetOrAdd((type, memberInfo), t =>
            {
                if (typeof(T) == typeof(TableAttribute))
                    return new TableAttribute(type.Name) { Schema = null };

                if (typeof(T) != typeof(ColumnAttribute))
                    return null;

                if (memberInfo.Name.Equals("Id", StringComparison.OrdinalIgnoreCase))
                {
                    return new ColumnAttribute
                    {
                        Name = memberInfo.Name,
                        IsPrimaryKey = true,
                        IsColumn = true,
                        CanBeNull = false,
                        IsIdentity = true,
                        DataType = new SqlDataType((memberInfo as PropertyInfo)?.PropertyType ?? typeof(string)).DataType
                    };
                }
                else
                {
                    return new ColumnAttribute
                    {
                        Name = memberInfo.Name,
                        IsPrimaryKey = false,
                        IsColumn = true,
                        CanBeNull = false,
                        IsIdentity = false,
                        DataType = new SqlDataType((memberInfo as PropertyInfo)?.PropertyType ?? typeof(string)).DataType
                    };
                }
            });

            return (T)attribute;
        }

        protected T[] GetAttributes<T>(Type type, Type attributeType, MemberInfo memberInfo = null)
            where T : Attribute
        {
            if (type.IsSubclassOf(typeof(BaseEntity)) && typeof(T) == attributeType && GetAttribute<T>(type, memberInfo) is T attr)
            {
                return new[] { attr };
            }

            return Array.Empty<T>();
        }

        /// <summary>
        /// Gets attributes of specified type, associated with specified type.
        /// </summary>
        /// <typeparam name="T">Attribute type.</typeparam>
        /// <param name="type">Attributes owner type.</param>
        /// <param name="inherit">If <c>true</c> - include inherited attributes.</param>
        /// <returns>Attributes of specified type.</returns>
        public virtual T[] GetAttributes<T>(Type type, bool inherit = true) where T : Attribute
        {
            return GetAttributes<T>(type, typeof(TableAttribute));
        }

        /// <summary>
        /// Gets attributes of specified type, associated with specified type member.
        /// </summary>
        /// <typeparam name="T">Attribute type.</typeparam>
        /// <param name="type">Member's owner type.</param>
        /// <param name="memberInfo">Attributes owner member.</param>
        /// <param name="inherit">If <c>true</c> - include inherited attributes.</param>
        /// <returns>Attributes of specified type.</returns>
        public virtual T[] GetAttributes<T>(Type type, MemberInfo memberInfo, bool inherit = true) where T : Attribute
        {
            return GetAttributes<T>(type, typeof(ColumnAttribute), memberInfo);
        }

        /// <summary>
        /// Gets the dynamic columns defined on given type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>All dynamic columns defined on given type</returns>
        public MemberInfo[] GetDynamicColumns(Type type)
        {
            return Array.Empty<MemberInfo>();
        }

        protected static ConcurrentDictionary<(Type, MemberInfo), Attribute> Types => new ConcurrentDictionary<(Type, MemberInfo), Attribute>();
    }
}