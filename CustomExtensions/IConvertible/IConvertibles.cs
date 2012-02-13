using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomExtensions.IConvertible
{
    public static class IConvertibles
    {
        public static T ToNullable<T>(this System.IConvertible obj)
        {
            Type t = typeof(T);
            Type u = Nullable.GetUnderlyingType(t);

            if (u != null)
            {
                if (obj == null)
                    return default(T);

                return (T)Convert.ChangeType(obj, u);
            }
            return (T)Convert.ChangeType(obj, t);
        }

    }
}
