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
    public static class LinkedListExtensions
    {
        public static LinkedList< U > Map< T, U >( this LinkedList< T > self, Func< T, U > f )
        {
            return Functions.Map( self, new LinkedList< U >(), f );
        }

        public static LinkedList< U > CompactMap< T, U >( this LinkedList< T > self, Func< T, U? > f ) where U: class
        {
            return Functions.CompactMap( self, new LinkedList< U >(), f );
        }

        public static LinkedList< U > CompactMap< T, U >( this LinkedList< T > self, Func< T, U? > f ) where U: struct
        {
            return Functions.CompactMap( self, new LinkedList< U >(), f );
        }

        public static LinkedList< T > Filter< T >( this LinkedList< T > self, Func< T, bool > f )
        {
            return Functions.Filter( self, new LinkedList< T >(), f );
        }

        public static U Reduce< T, U >( this LinkedList< T > self, U initialResult, Func< U, T, U > f )
        {
            return Functions.Reduce( self, initialResult, f );
        }
    }
}
