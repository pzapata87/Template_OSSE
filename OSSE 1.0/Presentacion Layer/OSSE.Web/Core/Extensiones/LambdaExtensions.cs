﻿using System;

namespace OSSE.Web.Core.Extensiones
{
    public static class LambdaExtensions
    {
        public static Func<T, bool> AndAlso<T>(
            this Func<T, bool> predicate1,
            Func<T, bool> predicate2)
        {
            return arg => predicate1(arg) && predicate2(arg);
        }
    }
}