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
    public static class HashSetExtensions
    {
        public static HashSet< U > Map< T, U >( this HashSet< T > self, Func< T, U > f )
        {
            return Functions.Map( self, new HashSet< U >(), f );
        }

        public static HashSet< U > FlatMap< T, U >( this HashSet< T > self, Func< T, ICollection< U > > f )
        {
            return Functions.FlatMap( self, new HashSet< U >(), f );
        }

        public static HashSet< U > CompactMap< T, U >( this HashSet< T > self, Func< T, U > f ) where U: class
        {
            return Functions.CompactMap( self, new HashSet< U >(), f );
        }

        public static HashSet< U > CompactMap< T, U >( this HashSet< T > self, Func< T, U? > f ) where U: struct
        {
            return Functions.CompactMap( self, new HashSet< U >(), f );
        }

        public static HashSet< T > Filter< T >( this HashSet< T > self, Func< T, bool > f )
        {
            return Functions.Filter( self, new HashSet< T >(), f );
        }

        public static U Reduce< T, U >( this HashSet< T > self, U initialResult, Func< U, T, U > f )
        {
            return Functions.Reduce( self, initialResult, f );
        }
    }
}
