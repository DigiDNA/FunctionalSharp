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
    public static class ListExtensions
    {
        public static List< U > Map< T, U >( this List< T > self, Func< T, U > f )
        {
            return Functions.Map( self, new List< U >(), f );
        }

        public static List< U > FlatMap< T, U >( this List< T > self, Func< T, ICollection< U > > f ) where T: System.Collections.ICollection
        {
            return Functions.FlatMap( self, new List< U >(), f );
        }

        public static List< U > CompactMap< T, U >( this List< T > self, Func< T, U? > f ) where U: class
        {
            return Functions.CompactMap( self, new List< U >(), f );
        }

        public static List< U > CompactMap< T, U >( this List< T > self, Func< T, U? > f ) where U: struct
        {
            return Functions.CompactMap( self, new List< U >(), f );
        }

        public static List< T > Filter< T >( this List< T > self, Func< T, bool > f )
        {
            return Functions.Filter( self, new List< T >(), f );
        }

        public static U Reduce< T, U >( this List< T > self, U initialResult, Func< U, T, U > f )
        {
            return Functions.Reduce( self, initialResult, f );
        }

        public static List< T > Sorted< T >( this List< T > self, Func< T, T, bool > predicate )
        {
            List< T > copy = new List< T >( self );

            copy.Sort
            (
                delegate( T o1, T o2 )
                {
                    return predicate( o1, o2 ) ? -1 : 1;
                }
            );

            return copy;
        }
    }
}
