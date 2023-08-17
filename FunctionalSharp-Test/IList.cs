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
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Functional;

namespace FunctionalSharp_Test
{
    [TestClass]
    public class IListTest
    {
        [TestMethod]
        public void TestCompactMap()
        {
            IList           input  = new List< object? > { "foo", null, 42, "bar" };
            IList< string > output = input.CompactMap< string >();

            Assert.AreEqual( 2,     output.Count );
            Assert.AreEqual( "foo", output[ 0 ] );
            Assert.AreEqual( "bar", output[ 1 ] );
        }

        [TestMethod]
        public void TestCompactMap_Reference()
        {
            IList           input  = new List< object? > { 0, 1, 2, null, "hello, world", 42 };
            IList< string > output = input.CompactMap< int, string >( ( o ) => ( o == 1 || o == 2 ) ? null : o.ToString() );

            Assert.AreEqual( 2,    output.Count );
            Assert.AreEqual( "0",  output[ 0 ] );
            Assert.AreEqual( "42", output[ 1 ] );
        }

        [TestMethod]
        public void TestCompactMap_Value()
        {
            IList         input  = new List< object? > { 0, 1, 2, null, "hello, world", 42 };
            IList< long > output = input.CompactMap< int, long >( ( o ) => ( o == 1 || o == 2 ) ? ( long? )null : o );

            Assert.AreEqual( 2,  output.Count );
            Assert.AreEqual( 0,  output[ 0 ] );
            Assert.AreEqual( 42, output[ 1 ] );
        }

        [TestMethod]
        public void TestFilter()
        {
            IList< int > input  = new List< int > { 0, 1, 2, 42 };
            IList< int > output = input.Filter( ( o ) => o != 1 && o != 2 );

            Assert.AreEqual( 2,  output.Count );
            Assert.AreEqual( 0,  output[ 0 ] );
            Assert.AreEqual( 42, output[ 1 ] );
        }
    }
}
