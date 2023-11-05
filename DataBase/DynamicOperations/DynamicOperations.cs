using System.ComponentModel;
using System.Dynamic;

namespace DataBase.DynamicOperations
{
    public static class DynamicOperations
    {
        // Removing properties from dynamic object
        public static void RemoveProperty(dynamic dynamicType, string propertyName)
        {
            var ObjToRemove = (IDictionary<string, object>)dynamicType;
            if (ObjToRemove.ContainsKey(propertyName))
            {
                ObjToRemove.Remove(propertyName);
            }
        }
        public static dynamic ToDynamic(this object value)
        {
            IDictionary<string, object> expando = new ExpandoObject();
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(value.GetType()))
            {
                expando.Add(property.Name, property.GetValue(value));
            }
            return expando as ExpandoObject;
        }

    }
}

