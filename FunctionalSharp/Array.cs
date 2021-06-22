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
    public static class ArrayExtensions
    {
        public static U[] Map< T, U >( this T[] self, Func< T, U > f )
        {
            return Functions.Map( self, new List< U >(), f ).ToArray();
        }

        public static U[] CompactMap< T, U >( this T[] self, Func< T, U? > f ) where U: class
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
    }
}
