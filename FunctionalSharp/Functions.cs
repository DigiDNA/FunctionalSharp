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
    internal static class Functions
    {
        internal static R Map< T, U, R >( ICollection< T > source, R destination, Func< T, U > f ) where R: ICollection< U >
        {
            if( source == null )
            {
                throw new ArgumentNullException( nameof( source ) );
            }

            if( destination == null )
            {
                throw new ArgumentNullException( nameof( destination ) );
            }

            if( f == null )
            {
                throw new ArgumentNullException( nameof( f ) );
            }

            foreach( T o in source )
            {
                destination.Add( f( o ) );
            }

            return destination;
        }

        internal static R FlatMap< T, U, R >( ICollection< T > source, R destination, Func< T, ICollection< U > > f ) where R: ICollection< U >
        {
            if( source == null )
            {
                throw new ArgumentNullException( nameof( source ) );
            }

            if( destination == null )
            {
                throw new ArgumentNullException( nameof( destination ) );
            }

            if( f == null )
            {
                throw new ArgumentNullException( nameof( f ) );
            }

            Map( source, new List< ICollection< U > >(), f ).ForEach
            (
                ( s ) =>
                {
                    foreach( U o in s )
                    {
                        destination.Add( o );
                    }
                }
            );

            return destination;
        }

        internal static R CompactMap< T, U, R >( ICollection< T > source, R destination, Func< T, U? > f ) where R: ICollection< U > where U: class
        {
            if( source == null )
            {
                throw new ArgumentNullException( nameof( source ) );
            }

            if( destination == null )
            {
                throw new ArgumentNullException( nameof( destination ) );
            }

            if( f == null )
            {
                throw new ArgumentNullException( nameof( f ) );
            }

            foreach( T o in source )
            {
                if( f( o ) is U u )
                {
                    destination.Add( u );
                }
            }

            return destination;
        }

        internal static R CompactMap< T, U, R >( ICollection< T > source, R destination, Func< T, U? > f ) where R: ICollection< U > where U: struct
        {
            if( source == null )
            {
                throw new ArgumentNullException( nameof( source ) );
            }

            if( destination == null )
            {
                throw new ArgumentNullException( nameof( destination ) );
            }

            if( f == null )
            {
                throw new ArgumentNullException( nameof( f ) );
            }

            foreach( T o in source )
            {
                if( f( o ) is U u )
                {
                    destination.Add( u );
                }
            }

            return destination;
        }
        
        internal static R Filter< T, R >( ICollection< T > source, R destination, Func< T, bool > f ) where R: ICollection< T >
        {
            if( source == null )
            {
                throw new ArgumentNullException( nameof( source ) );
            }

            if( destination == null )
            {
                throw new ArgumentNullException( nameof( destination ) );
            }

            if( f == null )
            {
                throw new ArgumentNullException( nameof( f ) );
            }

            foreach( T o in source )
            {
                if( f( o ) )
                {
                    destination.Add( o );
                }
            }

            return destination;
        }

        internal static U Reduce< T, U >( ICollection< T > source, U initialResult, Func< U, T, U > f )
        {
            if( source == null )
            {
                throw new ArgumentNullException( nameof( source ) );
            }

            if( f == null )
            {
                throw new ArgumentNullException( nameof( f ) );
            }

            foreach( T o in source )
            {
                initialResult = f( initialResult, o );
            }

            return initialResult;
        }
    }
}
