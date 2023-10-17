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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable< T > CompactMap< T >( this IEnumerable self ) where T : class => self.CompactMap< T, T >( ( o ) => o );

        public static IEnumerable< U > CompactMap< T, U >( this IEnumerable self, Func< T, U? > f ) where U : class
        {
            List< U > result = new List< U >();

            foreach( object? o in self )
            {
                if( !( o is T value ) || !( f( value ) is U item ) )
                {
                    continue;
                }

                result.Add( item );
            }

            return result;
        }

        public static IEnumerable< U > CompactMap< T, U >( this IEnumerable self, Func< T, U? > f ) where U : struct
        {
            List< U > result = new List< U >();

            foreach( object? o in self )
            {
                if( !( o is T value ) || !( f( value ) is U item ) )
                {
                    continue;
                }

                result.Add( item );
            }

            return result;
        }

        public static IEnumerable< KeyValuePair< int, T > > Enumerated< T >( this IEnumerable< T > self )
        {
            int                            offset = 0;
            List< KeyValuePair< int, T > > result = new List< KeyValuePair< int, T > >();

            foreach( T o in self )
            {
                result.Add( new KeyValuePair< int, T >( offset++, o ) );
            }

            return result;
        }
    }
}
