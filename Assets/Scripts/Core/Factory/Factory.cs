using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Factory
{
    public class Factory
    {
        private readonly IDictionary<Type, IDictionary<Type, Func<object[], object>>> _variants =
            new Dictionary<Type, IDictionary<Type, Func<object[], object>>>();

        public void AddVariantFunc<T>(Type key, Func<object[], object> type)
        {
            var baseType = typeof(T);
            if (!_variants.ContainsKey(baseType))
            {
                _variants.Add(baseType, new Dictionary<Type, Func<object[], object>>());
            }
            
            _variants[baseType].Add(key, type);
        }

        public T Build<T>(Type key, params object[] param)
        {
            var type = typeof(T);

            var variantBuilder = _variants[type];
            
            return BuildItem<T>(key, param, variantBuilder);
            
        }

        private T BuildItem<T>(Type key, object[] objects, IDictionary<Type, Func<object[], object>> variantBuilder)
        {
            try
            {
                if (!variantBuilder.TryGetValue(key, out var constructor))
                {
                    throw new Exception("There is no such variant for this type");
                }

                return (T) constructor.Invoke(objects);
            }
            catch (Exception ex)
            {
                Debug.LogError($"key:'{key}' ex:{ex}");
                throw;
            }
        }
    }
}