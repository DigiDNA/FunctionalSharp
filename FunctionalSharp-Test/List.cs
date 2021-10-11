/*******************************************************************************
 * The MIT License (MIT)
 * 
 * Copyright (c) 2021 DigiDNA - www.imazing.com
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 ******************************************************************************/

using System;
using System.Collections.Generic;
using System.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Functional;

namespace FunctionalSharp_Test
{
    [ TestClass ]
    public class List
    {
        [TestMethod]
        public void TestMap()
        {
            List< int >    input  = new List< int > { 0, 1, 2, 42 };
            List< string > output = input.Map( ( o ) => o.ToString() );

            Assert.AreEqual( 4,    output.Count );
            Assert.AreEqual( "0",  output[ 0 ] );
            Assert.AreEqual( "1",  output[ 1 ] );
            Assert.AreEqual( "2",  output[ 2 ] );
            Assert.AreEqual( "42", output[ 3 ] );
        }

        [TestMethod]
        public void TestFlatMap()
        {
            List< int[] >  input   = new List< int[] > { new int[] { 0, 1 }, new int[] { 2 }, new int[] { 42 } };
            List< int >    output1 = input.FlatMap( ( s ) => s );
            List< string > output2 = input.FlatMap( ( s ) => s.Map( ( o ) => o.ToString() ) );
            
            Assert.AreEqual( 4,  output1.Count );
            Assert.AreEqual( 0,  output1[ 0 ] );
            Assert.AreEqual( 1,  output1[ 1 ] );
            Assert.AreEqual( 2,  output1[ 2 ] );
            Assert.AreEqual( 42, output1[ 3 ] );

            Assert.AreEqual( 4,    output2.Count );
            Assert.AreEqual( "0",  output2[ 0 ] );
            Assert.AreEqual( "1",  output2[ 1 ] );
            Assert.AreEqual( "2",  output2[ 2 ] );
            Assert.AreEqual( "42", output2[ 3 ] );
        }

        [TestMethod]
        public void TestCompactMap_Reference()
        {
            List< int >    input  = new List< int > { 0, 1, 2, 42 };
            List< string > output = input.CompactMap( ( o ) => ( o == 1 || o == 2 ) ? null : o.ToString() );

            Assert.AreEqual( 2,    output.Count );
            Assert.AreEqual( "0",  output[ 0 ] );
            Assert.AreEqual( "42", output[ 1 ] );
        }

        [TestMethod]
        public void TestCompactMap_Value()
        {
            List< int >  input  = new List< int > { 0, 1, 2, 42 };
            List< long > output = input.CompactMap( ( o ) => ( o == 1 || o == 2 ) ? ( long? )null : o );

            Assert.AreEqual( 2,  output.Count );
            Assert.AreEqual( 0,  output[ 0 ] );
            Assert.AreEqual( 42, output[ 1 ] );
        }

        [TestMethod]
        public void TestFilter()
        {
            List< int > input  = new List< int > { 0, 1, 2, 42 };
            List< int > output = input.Filter( ( o ) => o != 1 && o != 2 );

            Assert.AreEqual( 2,  output.Count );
            Assert.AreEqual( 0,  output[ 0 ] );
            Assert.AreEqual( 42, output[ 1 ] );
        }

        [TestMethod]
        public void TestReduce()
        {
            List< int > input = new List< int > { 0, 1, 2, 42 };
            int         res1  = input.Reduce( 0, ( i, o ) => i + o );
            int         res2  = input.Reduce( 1, ( i, o ) => i + o );

            Assert.AreEqual( 45, res1 );
            Assert.AreEqual( 46, res2 );
        }

        [TestMethod]
        public void TestSorted()
        {
            List< int > input  = new List< int > { 42, 1, 2, 0 };
            List< int > sorted = input.Sorted( ( i1, i2 ) => i1 < i2 );

            Assert.AreEqual( input.Count, sorted.Count );
            
            Assert.AreEqual( 42, input[ 0 ] );
            Assert.AreEqual(  1, input[ 1 ] );
            Assert.AreEqual(  2, input[ 2 ] );
            Assert.AreEqual(  0, input[ 3 ] );
            
            Assert.AreEqual(  0, sorted[ 0 ] );
            Assert.AreEqual(  1, sorted[ 1 ] );
            Assert.AreEqual(  2, sorted[ 2 ] );
            Assert.AreEqual( 42, sorted[ 3 ] );
        }
    }
}
