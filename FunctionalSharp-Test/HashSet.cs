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
using System.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Functional;

namespace FunctionalSharp_Test
{
    [ TestClass ]
    public class HashSet
    {
        private class Comparer: EqualityComparer< int[] >
        {
            public override bool Equals( int[]? x, int[]? y )
            {
                return false;
            }

            public override int GetHashCode( int[] obj )
            {
                return obj[ 0 ];
            }
        }

        [TestMethod]
        public void TestMap()
        {
            HashSet< int >    input  = new HashSet< int > { 0, 1, 2, 42 };
            HashSet< string > output = input.Map( ( o ) => o.ToString() );

            Assert.AreEqual( 4, output.Count );
            Assert.IsTrue( output.Contains( "0" ) );
            Assert.IsTrue( output.Contains( "1" ) );
            Assert.IsTrue( output.Contains( "2" ) );
            Assert.IsTrue( output.Contains( "42" ) );
        }

        [TestMethod]
        public void TestFlatMap()
        {
            HashSet< int[] >  input    = new HashSet< int[] >( new Comparer() ) { new int[] { 0, 1 }, new int[] { 2 }, new int[] { 42 } };
            HashSet< int >    output1  = input.FlatMap( ( s ) => s );
            HashSet< string > output2  = input.FlatMap( ( s ) => s.Map( ( o ) => o.ToString() ) );

            Assert.AreEqual( 4, output1.Count );
            Assert.IsTrue( output1.Contains( 0 ) );
            Assert.IsTrue( output1.Contains( 1 ) );
            Assert.IsTrue( output1.Contains( 2 ) );
            Assert.IsTrue( output1.Contains( 42 ) );

            Assert.AreEqual( 4, output2.Count );
            Assert.IsTrue( output2.Contains( "0" ) );
            Assert.IsTrue( output2.Contains( "1" ) );
            Assert.IsTrue( output2.Contains( "2" ) );
            Assert.IsTrue( output2.Contains( "42" ) );
        }

        [TestMethod]
        public void TestCompactMap_Reference()
        {
            HashSet< int >    input  = new HashSet< int > { 0, 1, 2, 42 };
            HashSet< string > output = input.CompactMap( ( o ) => ( o == 1 || o == 2 ) ? null : o.ToString() );

            Assert.AreEqual( 2, output.Count );
            Assert.IsTrue( output.Contains( "0" ) );
            Assert.IsTrue( output.Contains( "42" ) );
        }

        [TestMethod]
        public void TestCompactMap_Value()
        {
            HashSet< int >  input  = new HashSet< int > { 0, 1, 2, 42 };
            HashSet< long > output = input.CompactMap( ( o ) => ( o == 1 || o == 2 ) ? ( long? )null : o );

            Assert.AreEqual( 2, output.Count );
            Assert.IsTrue( output.Contains( 0 ) );
            Assert.IsTrue( output.Contains( 42 ) );
        }

        [TestMethod]
        public void TestFilter()
        {
            HashSet< int > input  = new HashSet< int > { 0, 1, 2, 42 };
            HashSet< int > output = input.Filter( ( o ) => o != 1 && o != 2 );

            Assert.AreEqual( 2, output.Count );
            Assert.IsTrue( output.Contains( 0 ) );
            Assert.IsTrue( output.Contains( 42 ) );
        }

        [TestMethod]
        public void TestReduce()
        {
            HashSet< int > input = new HashSet< int > { 0, 1, 2, 42 };
            int            res1  = input.Reduce( 0, ( i, o ) => i + o );
            int            res2  = input.Reduce( 1, ( i, o ) => i + o );

            Assert.AreEqual( 45, res1 );
            Assert.AreEqual( 46, res2 );
        }
    }
}
