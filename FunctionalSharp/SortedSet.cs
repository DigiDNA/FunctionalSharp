﻿/*******************************************************************************
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
    public static class SortedSetExtensions
    {
        public static SortedSet< U > Map< T, U >( this SortedSet< T > self, Func< T, U > f )
        {
            return Functions.Map( self, new SortedSet< U >(), f );
        }

        public static SortedSet< U > CompactMap< T, U >( this SortedSet< T > self, Func< T, U > f )
        {
            return Functions.CompactMap( self, new SortedSet< U >(), f );
        }

        public static SortedSet< T > Filter< T >( this SortedSet< T > self, Func< T, bool > f )
        {
            return Functions.Filter( self, new SortedSet< T >(), f );
        }

        public static U Reduce< T, U >( this SortedSet< T > self, U initialResult, Func< U, T, U > f )
        {
            return Functions.Reduce( self, initialResult, f );
        }
    }
}
