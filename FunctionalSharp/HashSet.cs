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
    public static class HashSetExtensions
    {
        public static HashSet< U > Map< T, U >( this HashSet< T > self, Func< T, U > f )
        {
            return Functions.Map( self, new HashSet< U >(), f );
        }

        public static HashSet< U > CompactMap< T, U >( this HashSet< T > self, Func< T, U? > f ) where U: class
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
