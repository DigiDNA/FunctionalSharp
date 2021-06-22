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

namespace UnitTests
{
    [ TestClass ]
    public class LinkedList
    {
        [TestMethod]
        public void TestMap()
        {
            LinkedList< int > input = new LinkedList< int >();

            input.AddLast( 0 );
            input.AddLast( 1 );
            input.AddLast( 2 );
            input.AddLast( 42 );

            LinkedList< string > output = input.Map( ( o ) => o.ToString() );

            Assert.AreEqual( 4, output.Count );
            Assert.IsTrue( output.Contains( "0" ) );
            Assert.IsTrue( output.Contains( "1" ) );
            Assert.IsTrue( output.Contains( "2" ) );
            Assert.IsTrue( output.Contains( "42" ) );
        }

        [TestMethod]
        public void TestFlatMap()
        {
            LinkedList< int[] > input = new LinkedList< int[] >();

            input.AddLast( new int[] { 0, 1 } );
            input.AddLast( new int[] { 2 } );
            input.AddLast( new int[] { 42 } );
            
            LinkedList< int >    output1 = input.FlatMap( ( s ) => s );
            LinkedList< string > output2 = input.FlatMap( ( s ) => s.Map( ( o ) => o.ToString() ) );

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
            LinkedList< int > input = new LinkedList< int >();

            input.AddLast( 0 );
            input.AddLast( 1 );
            input.AddLast( 2 );
            input.AddLast( 42 );

            LinkedList< string > output = input.CompactMap( ( o ) => ( o == 1 || o == 2 ) ? null : o.ToString() );

            Assert.AreEqual( 2, output.Count );
            Assert.IsTrue( output.Contains( "0" ) );
            Assert.IsTrue( output.Contains( "42" ) );
        }

        [TestMethod]
        public void TestCompactMap_Value()
        {
            LinkedList< int > input = new LinkedList< int >();

            input.AddLast( 0 );
            input.AddLast( 1 );
            input.AddLast( 2 );
            input.AddLast( 42 );

            LinkedList< long > output = input.CompactMap( ( o ) => ( o == 1 || o == 2 ) ? ( long? )null : o );

            Assert.AreEqual( 2, output.Count );
            Assert.IsTrue( output.Contains( 0 ) );
            Assert.IsTrue( output.Contains( 42 ) );
        }

        [TestMethod]
        public void TestFilter()
        {
            LinkedList< int > input = new LinkedList< int >();

            input.AddLast( 0 );
            input.AddLast( 1 );
            input.AddLast( 2 );
            input.AddLast( 42 );

            LinkedList< int > output = input.Filter( ( o ) => o != 1 && o != 2 );

            Assert.AreEqual( 2, output.Count );
            Assert.IsTrue( output.Contains( 0 ) );
            Assert.IsTrue( output.Contains( 42 ) );
        }

        [TestMethod]
        public void TestReduce()
        {
            LinkedList< int > input = new LinkedList< int >();

            input.AddLast( 0 );
            input.AddLast( 1 );
            input.AddLast( 2 );
            input.AddLast( 42 );

            int res1 = input.Reduce( 0, ( i, o ) => i + o );
            int res2 = input.Reduce( 1, ( i, o ) => i + o );

            Assert.AreEqual( 45, res1 );
            Assert.AreEqual( 46, res2 );
        }
    }
}
