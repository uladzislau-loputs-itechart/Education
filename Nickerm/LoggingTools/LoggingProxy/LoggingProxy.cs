using System;
using System.Collections.Generic;
using System.Text;
using ImpromptuInterface;
using System.Dynamic;
using System.Reflection;

namespace LoggingTools
{
    public class LoggingProxy<T>
    {
        public T CreateInstance(T obj)
        {
            
            dynamic loggedObj = new ExpandoObject();
            var loggedObjDictionary = (IDictionary<string, object>)loggedObj;

            var objType = obj.GetType();
            var methodInfo = objType.GetMethods();

            foreach (MethodInfo method in methodInfo)
            {
                var parameters = method.GetParameters();
                if (parameters.Length == 0)
                {
                    loggedObjDictionary.Add(method.Name, (Action)(() =>
                    {
                        try
                        {
                            method?.Invoke(obj, null);
                            new Logger(LogDestination.FileLogger).Info($"{method.Name}");
                            new Logger().Info($"{method.Name}");
                        }
                        catch (Exception e)
                        {
                            new Logger(LogDestination.FileLogger).Error($"{method.Name}");
                            new Logger().Error($"{method.Name}");
                            throw new Exception(e.Message);                         
                        }               
                    }));
                }             }
            T logObj = Impromptu.ActLike(loggedObjDictionary);

            return logObj;

        }
    }
}
