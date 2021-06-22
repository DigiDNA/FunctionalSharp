/*******************************************************************************
 * Copyright (c) 2021, DigiDNA
 * All rights reserved
 * 
 * Unauthorised copying of this copyrighted work, via any medium is strictly
 * prohibited.
 * Proprietary and confidential.
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
