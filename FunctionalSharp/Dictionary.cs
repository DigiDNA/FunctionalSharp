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

        public static List< U > FlatMap< TK, TV, U >( this Dictionary< TK, TV > self, Func< KeyValuePair< TK, TV >, ICollection< U > > f ) where TK : notnull where TV: System.Collections.ICollection
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
