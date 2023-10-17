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
    public class IEnumerableTest
    {
        [TestMethod]
        public void TestCompactMap()
        {
            IEnumerable           input  = new List< object? > { "foo", null, 42, "bar" };
            IEnumerable< string > output = input.CompactMap< string >();
            List< object? >       list   = new List< object? >();

            foreach( object? o in output )
            {
                list.Add( o );
            }

            Assert.AreEqual( 2,     list.Count );
            Assert.AreEqual( "foo", list[ 0 ] );
            Assert.AreEqual( "bar", list[ 1 ] );
        }

        [TestMethod]
        public void TestCompactMap_Reference()
        {
            IEnumerable           input  = new List< object? > { 0, 1, 2, null, "hello, world", 42 };
            IEnumerable< string > output = input.CompactMap< int, string >( ( o ) => ( o == 1 || o == 2 ) ? null : o.ToString() );
            List< object? >       list   = new List< object? >();

            foreach( object? o in output )
            {
                list.Add( o );
            }

            Assert.AreEqual( 2,    list.Count );
            Assert.AreEqual( "0",  list[ 0 ] );
            Assert.AreEqual( "42", list[ 1 ] );
        }

        [TestMethod]
        public void TestCompactMap_Value()
        {
            IEnumerable         input  = new List< object? > { 0, 1, 2, null, "hello, world", 42 };
            IEnumerable< long > output = input.CompactMap< int, long >( ( o ) => ( o == 1 || o == 2 ) ? ( long? )null : o );
            List< long >        list   = new List< long >( output );

            Assert.AreEqual( 2,  list.Count );
            Assert.AreEqual( 0,  list[ 0 ] );
            Assert.AreEqual( 42, list[ 1 ] );
        }

        [TestMethod]
        public void TestEnumerated()
        {
            IEnumerable< string >                      input  = new List< string > { "foo", "bar", "hello", "world" };
            IEnumerable< KeyValuePair< int, string > > output = input.Enumerated();
            List< KeyValuePair< int, string > >        list   = new List< KeyValuePair< int, string > >( output );

            Assert.AreEqual( 4, list.Count );
            
            Assert.AreEqual( 0, list[ 0 ].Key );
            Assert.AreEqual( 1, list[ 1 ].Key );
            Assert.AreEqual( 2, list[ 2 ].Key );
            Assert.AreEqual( 3, list[ 3 ].Key );

            Assert.AreEqual( "foo",   list[ 0 ].Value );
            Assert.AreEqual( "bar",   list[ 1 ].Value );
            Assert.AreEqual( "hello", list[ 2 ].Value );
            Assert.AreEqual( "world", list[ 3 ].Value );
        }
    }
}
