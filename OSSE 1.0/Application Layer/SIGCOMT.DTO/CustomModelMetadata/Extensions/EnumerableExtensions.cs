﻿using System.Collections.Generic;
using System.Linq;

namespace SIGCOMT.DTO.CustomModelMetadata.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Replace<T>(this IEnumerable<T> collection, T source, T replacement) where T : class
        {
            var collectionWithout = collection;
            if (source != null)
            {
                collectionWithout = collectionWithout.Except(new[] {source});
            }
            return collectionWithout.Union(new[] {replacement});
        }
    }
}