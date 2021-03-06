﻿// Description: Async extension methods for LINQ (Language Integrated Query).
// Website & Documentation: https://github.com/zzzprojects/LINQ-Async
// Forum: https://github.com/zzzprojects/LINQ-Async/issues
// License: http://www.zzzprojects.com/license-agreement/
// More projects: http://www.zzzprojects.com/
// Copyright (c) 2015 ZZZ Projects. All rights reserved.

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

/*
 * Reference to:
 *  ZZZProjects/LINQ-Async
 *  Author: JonathanMagnan
 *  URL: https://github.com/zzzprojects/LINQ-Async
 *  MIT
 */

namespace System.Linq
{
    public static partial class Extensions
    {
        public static Task<IEnumerable<TResult>> Cast<TResult>(
            this Task<IEnumerable> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Cast<TResult>, cancellationToken);
        }

        public static Task<IEnumerable<TResult>> CastAsync<TResult>(
            this IEnumerable source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.Cast<TResult>, cancellationToken);
        }

        public static Task<IEnumerable<TResult>> OfType<TResult>(
            this Task<IEnumerable> source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.OfType<TResult>, cancellationToken);
        }

        public static Task<IEnumerable<TResult>> OfTypeAsync<TResult>(
            this IEnumerable source,
            CancellationToken cancellationToken = default)
        {
            return Task.Factory.FromTaskEnumerable(source, Enumerable.OfType<TResult>, cancellationToken);
        }
    }
}
