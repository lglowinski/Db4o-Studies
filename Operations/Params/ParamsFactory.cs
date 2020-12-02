using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Db4o_Sprawozdanie.Models;

namespace Db4o_Sprawozdanie.Operations.Params
{
    public class ParamsFactory
    {
        public T GetParams<T>() where T : IOperationParams, new()
        {
            var newParam = new T();
            var properties = typeof(T).GetProperties();
            foreach(var property in properties)
            {
                Console.Write($"{property.Name}: ");
                if (property.PropertyType == typeof(Mechanic) || property.PropertyType == typeof(Customer))
                {
                    var propertyObject = Activator.CreateInstance(property.PropertyType);
                    foreach(var propertyInClass in propertyObject.GetType().GetProperties())
                    {
                        Console.Write($"\n{propertyInClass.Name}: ");
                        var consoleResult = Console.ReadLine();
                        if (propertyInClass.PropertyType.IsEnum)
                        {
                            var enumValue = GetValueFromEnum(propertyInClass.PropertyType, consoleResult);
                            propertyObject.GetType().GetProperty(propertyInClass.Name).SetValue(propertyObject, enumValue, null);
                        }
                        else
                        {
                            var propertyValue = Convert.ChangeType(consoleResult, propertyInClass.PropertyType);
                            propertyObject.GetType().GetProperty(propertyInClass.Name).SetValue(propertyObject, propertyValue, null);
                        }
                    }
                    newParam.GetType().GetProperty(property.Name).SetValue(newParam, propertyObject, null);
                }
                else
                {
                    
                    var consoleResult = Console.ReadLine();
                    object propertyValue;
                    if (string.IsNullOrEmpty(consoleResult))
                    {
                        propertyValue = null;
                    }
                    else
                    {
                        propertyValue = Convert.ChangeType(consoleResult, property.PropertyType);
                    }
                    newParam.GetType().GetProperty(property.Name).SetValue(newParam, propertyValue, null);
                    Console.Write('\n');
                }
            }

            return newParam;
        }

        private TitleEnum GetValueFromEnum(Type type, string consoleResult)
        {
            return (TitleEnum) Enum.Parse(type, consoleResult);
        }
    }
}
