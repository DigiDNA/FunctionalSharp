/*******************************************************************************
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
    public static class SortedSetExtensions
    {
        public static SortedSet< U > Map< T, U >( this SortedSet< T > self, Func< T, U > f ) => Internal.Map( self, new SortedSet< U >(), f );

        public static SortedSet< U > FlatMap< T, U >( this SortedSet< T > self, Func< T, ICollection< U > > f ) => Internal.FlatMap( self, new SortedSet< U >(), f );

        public static SortedSet< U > CompactMap< T, U >( this SortedSet< T > self, Func< T, U? > f ) where U: class => Internal.CompactMap( self, new SortedSet< U >(), f );

        public static SortedSet< U > CompactMap< T, U >( this SortedSet< T > self, Func< T, U? > f ) where U: struct => Internal.CompactMap( self, new SortedSet< U >(), f );

        public static SortedSet< T > Filter< T >( this SortedSet< T > self, Func< T, bool > f ) => Internal.Filter( self, new SortedSet< T >(), f );

        public static U Reduce< T, U >( this SortedSet< T > self, U initialResult, Func< U, T, U > f ) => Internal.Reduce( self, initialResult, f );
    }
}
