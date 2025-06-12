using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Entites.Domain.Models;

namespace Contracts.Domain
{
    public interface IDataShaper<T>
    {
        IEnumerable<ExpandoObject> ShapeData(IEnumerable<T> entities, string fieldsString);
        ExpandoObject ShapeData(T entity, string fieldsString);
        private ShapedEntity FetchDataForEntity(T entity, IEnumerable<PropertyInfo>requiredProperties)
        {
            var shapedObject = new ShapedEntity();
            foreach (var property in requiredProperties)
            {
                var objectPropertyValue = property.GetValue(entity);
                shapedObject.Entity.TryAdd(property.Name, objectPropertyValue);
            }
            var objectProperty = entity.GetType().GetProperty("Id");
            shapedObject.Id = (Guid)objectProperty.GetValue(entity);
            return shapedObject;
        }
    }

}
