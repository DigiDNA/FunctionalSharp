﻿/*******************************************************************************
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
    public class LinkedList
    {
        [TestMethod]
        public void TestMap()
        {
            LinkedList< int > input = new LinkedList< int >();

            _ = input.AddLast( 0 );
            _ = input.AddLast( 1 );
            _ = input.AddLast( 2 );
            _ = input.AddLast( 42 );

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

            _ = input.AddLast( new int[] { 0, 1 } );
            _ = input.AddLast( new int[] { 2 } );
            _ = input.AddLast( new int[] { 42 } );
            
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

            _ = input.AddLast( 0 );
            _ = input.AddLast( 1 );
            _ = input.AddLast( 2 );
            _ = input.AddLast( 42 );

            LinkedList< string > output = input.CompactMap( ( o ) => ( o == 1 || o == 2 ) ? null : o.ToString() );

            Assert.AreEqual( 2, output.Count );
            Assert.IsTrue( output.Contains( "0" ) );
            Assert.IsTrue( output.Contains( "42" ) );
        }

        [TestMethod]
        public void TestCompactMap_Value()
        {
            LinkedList< int > input = new LinkedList< int >();

            _ = input.AddLast( 0 );
            _ = input.AddLast( 1 );
            _ = input.AddLast( 2 );
            _ = input.AddLast( 42 );

            LinkedList< long > output = input.CompactMap( ( o ) => ( o == 1 || o == 2 ) ? ( long? )null : o );

            Assert.AreEqual( 2, output.Count );
            Assert.IsTrue( output.Contains( 0 ) );
            Assert.IsTrue( output.Contains( 42 ) );
        }

        [TestMethod]
        public void TestFilter()
        {
            LinkedList< int > input = new LinkedList< int >();

            _ = input.AddLast( 0 );
            _ = input.AddLast( 1 );
            _ = input.AddLast( 2 );
            _ = input.AddLast( 42 );

            LinkedList< int > output = input.Filter( ( o ) => o != 1 && o != 2 );

            Assert.AreEqual( 2, output.Count );
            Assert.IsTrue( output.Contains( 0 ) );
            Assert.IsTrue( output.Contains( 42 ) );
        }

        [TestMethod]
        public void TestReduce()
        {
            LinkedList< int > input = new LinkedList< int >();

            _ = input.AddLast( 0 );
            _ = input.AddLast( 1 );
            _ = input.AddLast( 2 );
            _ = input.AddLast( 42 );

            int res1 = input.Reduce( 0, ( i, o ) => i + o );
            int res2 = input.Reduce( 1, ( i, o ) => i + o );

            Assert.AreEqual( 45, res1 );
            Assert.AreEqual( 46, res2 );
        }
    }
}
