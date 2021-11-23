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
    public static class DictionaryExtensions
    {
        public static Dictionary< TK, U > MapValues< TK, TV, U >( this Dictionary< TK, TV > self, Func< KeyValuePair< TK, TV >, U > f ) where TK: notnull
        {
            if( self == null )
            {
                throw new ArgumentNullException( nameof( self ) );
            }

            if( f == null )
            {
                throw new ArgumentNullException( nameof( f ) );
            }

            Dictionary< TK, U > destination = new Dictionary< TK, U >();

            foreach( KeyValuePair< TK, TV > p in self )
            {
                destination[ p.Key ] = f( p );
            }

            return destination;
        }

        public static List< U > Map< TK, TV, U >( this Dictionary< TK, TV > self, Func< KeyValuePair< TK, TV >, U > f ) where TK : notnull
        {
            return Functions.Map( self, new List< U >(), f );
        }

        public static List< U > FlatMap< TK, TV, U >( this Dictionary< TK, TV > self, Func< KeyValuePair< TK, TV >, ICollection< U > > f ) where TK : notnull
        {
            if( self == null )
            {
                throw new ArgumentNullException( nameof( self ) );
            }

            if( f == null )
            {
                throw new ArgumentNullException( nameof( f ) );
            }

            List< U > destination = new List< U >();

            foreach( KeyValuePair< TK, TV > p in self )
            {
                foreach( U o in f( p ) )
                {
                    destination.Add( o );
                }
            }

            return destination;
        }

        public static List< U > CompactMap< TK, TV, U >( this Dictionary< TK, TV > self, Func< KeyValuePair< TK, TV >, U? > f ) where TK : notnull where U: class
        {
            return Functions.CompactMap( self, new List< U >(), f );
        }

        public static List< U > CompactMap< TK, TV, U >( this Dictionary< TK, TV > self, Func< KeyValuePair< TK, TV >, U? > f ) where TK : notnull where U: struct
        {
            return Functions.CompactMap( self, new List< U >(), f );
        }

        public static Dictionary< TK, U > CompactMapValues< TK, TV, U >( this Dictionary< TK, TV > self, Func< KeyValuePair< TK, TV >, U? > f ) where TK: notnull where U: class
        {
            if( self == null )
            {
                throw new ArgumentNullException( nameof( self ) );
            }

            if( f == null )
            {
                throw new ArgumentNullException( nameof( f ) );
            }

            Dictionary< TK, U > destination = new Dictionary< TK, U >();

            foreach( KeyValuePair< TK, TV > p in self )
            {
                if( f( p ) is U o )
                {
                    destination[ p.Key ] = o;
                }
            }

            return destination;
        }

        public static Dictionary< TK, U > CompactMapValues< TK, TV, U >( this Dictionary< TK, TV > self, Func< KeyValuePair< TK, TV >, U? > f ) where TK: notnull where U: struct
        {
            if( self == null )
            {
                throw new ArgumentNullException( nameof( self ) );
            }

            if( f == null )
            {
                throw new ArgumentNullException( nameof( f ) );
            }

            Dictionary< TK, U > destination = new Dictionary< TK, U >();

            foreach( KeyValuePair< TK, TV > p in self )
            {
                if( f( p ) is U o )
                {
                    destination[ p.Key ] = o;
                }
            }

            return destination;
        }

        public static Dictionary< TK, TV > Filter< TK, TV >( this Dictionary< TK, TV > self, Func< KeyValuePair< TK, TV >, bool > f ) where TK : notnull
        {
            return Functions.Filter( self, new Dictionary< TK, TV >(), f );
        }

        public static U Reduce< TK, TV, U >( this Dictionary< TK, TV > self, U initialResult, Func< U, KeyValuePair< TK, TV >, U > f ) where TK : notnull
        {
            return Functions.Reduce( self, initialResult, f );
        }
    }
}
