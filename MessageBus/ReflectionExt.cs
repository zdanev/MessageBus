using System;

namespace MessageBus
{
    public static class ReflectionExt
    {
        public static bool Is(this Type type, Type baseType) 
        {
            while (type != null && type != typeof(object)) 
            {
                var current = type.IsGenericType ? type.GetGenericTypeDefinition() : type;
                if (current == baseType) 
                {
                    return true;
                }
                
                type = type.BaseType;
            }

            return false;   
        }        
    }
}