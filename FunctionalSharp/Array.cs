﻿/*******************************************************************************
 * The MIT License (MIT)
 * 
 * Copyright (c) 2021 DigiDNA - www.imazing.com
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 ******************************************************************************/

using System;
using System.Collections.Generic;

namespace Functional
{
    public static class ArrayExtensions
    {
        public static U[] Map< T, U >( this T[] self, Func< T, U > f )
        {
            return Functions.Map( self, new List< U >(), f ).ToArray();
        }

        public static U[] FlatMap< T, U >( this T[] self, Func< T, ICollection< U > > f )
        {
            return Functions.FlatMap( self, new List< U >(), f ).ToArray();
        }

        public static U[] CompactMap< T, U >( this T[] self, Func< T, U > f ) where U: class
        {
            return Functions.CompactMap( self, new List< U >(), f ).ToArray();
        }

        public static U[] CompactMap< T, U >( this T[] self, Func< T, U? > f ) where U: struct
        {
            return Functions.CompactMap( self, new List< U >(), f ).ToArray();
        }

        public static T[] Filter< T >( this T[] self, Func< T, bool > f )
        {
            return Functions.Filter( self, new List< T >(), f ).ToArray();
        }

        public static U Reduce< T, U >( this T[] self, U initialResult, Func< U, T, U > f )
        {
            return Functions.Reduce( self, initialResult, f );
        }

        public static T[] Sorted< T >( this T[] self, Func< T, T, bool > predicate )
        {
            T[] copy = ( T[] )self.Clone();

            Array.Sort
            (
                copy,
                delegate( T o1, T o2 )
                {
                    return predicate( o1, o2 ) ? -1 : 1;
                }
            );

            return copy;
        }
    }
}
