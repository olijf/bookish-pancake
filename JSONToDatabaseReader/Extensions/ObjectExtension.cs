﻿using System;
using System.Reflection;

namespace JSONToDatabaseReader.Extensions
{
    public static class ObjectExtension
    {
        public static void CopyDeltaProperties(this object target, object source)
        {
            Type TargetType = target.GetType();
            if (TargetType != source.GetType())
                throw new ArgumentException(string.Format("target and source should be of same type (target:{0} source: {1})", TargetType, source.GetType()));

            foreach (PropertyInfo propertyInfo in TargetType.GetProperties())
            {
                var sourceValue = propertyInfo.GetValue(source);
                var targetValue = propertyInfo.GetValue(target);
                if (sourceValue != targetValue)
                {
                    propertyInfo.SetValue(target, sourceValue, null);
                }
            }
        }
    }
}
