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
    public class Array
    {
        [TestMethod]
        public void TestMap()
        {
            int[]    input  = new int[] { 0, 1, 2, 42 };
            string[] output = input.Map( ( o ) => o.ToString() );

            Assert.AreEqual( 4,    output.Length );
            Assert.AreEqual( "0",  output[ 0 ] );
            Assert.AreEqual( "1",  output[ 1 ] );
            Assert.AreEqual( "2",  output[ 2 ] );
            Assert.AreEqual( "42", output[ 3 ] );
        }

        [TestMethod]
        public void TestFlatMap()
        {
            int[][]  input   = new int[][] { new int[] { 0, 1 }, new int[] { 2 }, new int[] { 42 } };
            int[]    output1 = input.FlatMap( ( s ) => s );
            string[] output2 = input.FlatMap( ( s ) => s.Map( ( o ) => o.ToString() ) );
            
            Assert.AreEqual( 4,  output1.Length );
            Assert.AreEqual( 0,  output1[ 0 ] );
            Assert.AreEqual( 1,  output1[ 1 ] );
            Assert.AreEqual( 2,  output1[ 2 ] );
            Assert.AreEqual( 42, output1[ 3 ] );

            Assert.AreEqual( 4,    output2.Length );
            Assert.AreEqual( "0",  output2[ 0 ] );
            Assert.AreEqual( "1",  output2[ 1 ] );
            Assert.AreEqual( "2",  output2[ 2 ] );
            Assert.AreEqual( "42", output2[ 3 ] );
        }

        [TestMethod]
        public void TestCompactMap_Reference()
        {
            int[]    input  = new int[] { 0, 1, 2, 42 };
            string[] output = input.CompactMap( ( o ) => ( o == 1 || o == 2 ) ? null : o.ToString() );

            Assert.AreEqual( 2,    output.Length );
            Assert.AreEqual( "0",  output[ 0 ] );
            Assert.AreEqual( "42", output[ 1 ] );
        }

        [TestMethod]
        public void TestCompactMap_Value()
        {
            int[]  input  = new int [] { 0, 1, 2, 42 };
            long[] output = input.CompactMap( ( o ) => ( o == 1 || o == 2 ) ? ( long? )null : o );

            Assert.AreEqual( 2,  output.Length );
            Assert.AreEqual( 0,  output[ 0 ] );
            Assert.AreEqual( 42, output[ 1 ] );
        }

        [TestMethod]
        public void TestFilter()
        {
            int[] input  = new int[] { 0, 1, 2, 42 };
            int[] output = input.Filter( ( o ) => o != 1 && o != 2 );

            Assert.AreEqual( 2,  output.Length );
            Assert.AreEqual( 0,  output[ 0 ] );
            Assert.AreEqual( 42, output[ 1 ] );
        }

        [TestMethod]
        public void TestReduce()
        {
            int[] input = new int[] { 0, 1, 2, 42 };
            int   res1  = input.Reduce( 0, ( i, o ) => i + o );
            int   res2  = input.Reduce( 1, ( i, o ) => i + o );

            Assert.AreEqual( 45, res1 );
            Assert.AreEqual( 46, res2 );
        }
    }
}
