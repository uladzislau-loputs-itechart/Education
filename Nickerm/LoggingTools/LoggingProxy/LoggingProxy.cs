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
        private Logger logger;
        public LoggingProxy()
        {
            logger = new Logger();
        }
        public LoggingProxy(LogDestination logDestination)
        {
            logger = new Logger(logDestination);
        }
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
                            logger.Info($"{method.Name}");
                        }
                        catch (Exception e)
                        {
                            logger.Error($"{method.Name}");
                            throw new Exception(e.Message);                         
                        }               
                    }));
                }             }
            T logObj = Impromptu.ActLike(loggedObjDictionary);

            return logObj;

        }
    }
}
