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
    public class Dictionary
    {
        [TestMethod]
        public void TestMapValues()
        {
            Dictionary< string, int >    input  = new Dictionary< string, int > { { "foo", 0 }, { "bar", 42 } };
            Dictionary< string, string > output = input.MapValues( ( o ) => o.Value.ToString() );

            Assert.AreEqual( 2, output.Count );
            Assert.IsTrue( output.ContainsKey( "foo" ) );
            Assert.IsTrue( output.ContainsKey( "bar" ) );
            Assert.AreEqual( "0",  output[ "foo" ] );
            Assert.AreEqual( "42", output[ "bar" ] );
        }

        [TestMethod]
        public void TestMap()
        {
            Dictionary< string, int > input  = new Dictionary< string, int > { { "foo", 0 }, { "bar", 42 } };
            List< string >            output = input.Map( ( o ) => o.Value.ToString() );

            Assert.AreEqual( 2,    output.Count );
            Assert.AreEqual( "0",  output[ 0 ] );
            Assert.AreEqual( "42", output[ 1 ] );
        }

        [TestMethod]
        public void TestFlatMap()
        {
            Dictionary< int, int[] > input   = new Dictionary< int, int[] > { { 0, new int[] { 0, 1 } }, { 1, new int[] { 2 } }, { 2, new int[] { 42 } } };
            List< int >              output1 = input.FlatMap( ( s ) => s.Value );
            List< string >           output2 = input.FlatMap( ( s ) => s.Value.Map( ( o ) => o.ToString() ) );
            
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
            Dictionary< string, int > input  = new Dictionary< string, int > { { "foo", 0 }, { "bar", 42 }, { "hello", 1 }, { "world", 2 } };
            List< string >            output = input.CompactMap( ( o ) => ( o.Key == "foo" || o.Key == "bar" ) ? null : o.Value.ToString() );

            Assert.AreEqual( 2,   output.Count );
            Assert.AreEqual( "1", output[ 0 ] );
            Assert.AreEqual( "2", output[ 1 ] );
        }

        [TestMethod]
        public void TestCompactMap_Value()
        {
            Dictionary< string, int > input  = new Dictionary< string, int > { { "foo", 0 }, { "bar", 42 }, { "hello", 1 }, { "world", 2 } };
            List< long >              output = input.CompactMap( ( o ) => ( o.Key == "foo" || o.Key == "bar" ) ? ( long? )null : o.Value );
            
            Assert.AreEqual( 2, output.Count );
            Assert.AreEqual( 1, output[ 0 ] );
            Assert.AreEqual( 2, output[ 1 ] );
        }

        [TestMethod]
        public void TestCompactMapValues_Reference()
        {
            Dictionary< string, int >    input  = new Dictionary< string, int > { { "foo", 0 }, { "bar", 42 } };
            Dictionary< string, string > output = input.CompactMapValues( ( o ) => ( o.Key == "foo" ) ? null : o.Value.ToString() );

            Assert.AreEqual( 1, output.Count );
            Assert.IsTrue( output.ContainsKey( "bar" ) );
            Assert.AreEqual( "42", output[ "bar" ] );
        }

        [TestMethod]
        public void TestCompactMapValues_Value()
        {
            Dictionary< string, int > input  = new Dictionary< string, int > { { "foo", 0 }, { "bar", 42 } };
            Dictionary< string, int > output = input.CompactMapValues( ( o ) => ( o.Key == "foo" ) ? ( int? )null : o.Value );

            Assert.AreEqual( 1, output.Count );
            Assert.IsTrue( output.ContainsKey( "bar" ) );
            Assert.AreEqual( 42, output[ "bar" ] );
        }

        [TestMethod]
        public void TestFilter()
        {
            Dictionary< string, int > input  = new Dictionary< string, int > { { "foo", 0 }, { "bar", 42 }, { "hello", 1 }, { "world", 2 } };
            Dictionary< string, int > output = input.Filter( ( o ) => ( o.Key != "foo" && o.Key != "bar" ) );

            Assert.AreEqual( 2, output.Count );
            Assert.IsTrue( output.ContainsKey( "hello" ) );
            Assert.IsTrue( output.ContainsKey( "world" ) );
            Assert.AreEqual( 1, output[ "hello" ] );
            Assert.AreEqual( 2, output[ "world" ] );
        }

        [TestMethod]
        public void TestReduce()
        {
            Dictionary< string, int > input = new Dictionary< string, int > { { "foo", 0 }, { "bar", 42 }, { "hello", 1 }, { "world", 2 } };
            int                       res1  = input.Reduce( 0, ( i, o ) => i + o.Value );
            int                       res2  = input.Reduce( 1, ( i, o ) => i + o.Value );

            Assert.AreEqual( 45, res1 );
            Assert.AreEqual( 46, res2 );
        }
    }
}
