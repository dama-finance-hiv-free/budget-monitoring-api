using System.Collections.Generic;
using System.Reflection;

namespace Dama.Core.Common.Core;

public class PropertyInfoComparer : IEqualityComparer<PropertyInfo>
{
    bool IEqualityComparer<PropertyInfo>.Equals(PropertyInfo x, PropertyInfo y)
    {
        return x != null && (x.Name.Equals(y.Name));
    }

    int IEqualityComparer<PropertyInfo>.GetHashCode(PropertyInfo obj)
    {
        if (ReferenceEquals(obj, null))
            return 0;

        return obj.Name.GetHashCode();
    }
}