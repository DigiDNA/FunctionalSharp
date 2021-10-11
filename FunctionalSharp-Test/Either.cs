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
    public class Either
    {
        private static IEither< T1, T2 > GetLeft< T1, T2 >( T1 value )
        {
            return new Left< T1, T2 >( value );
        }

        private static IEither< T1, T2 > GetRight< T1, T2 >( T2 value )
        {
            return new Right< T1, T2 >( value );
        }
        
        [TestMethod]
        public void TestLeft_Value_Value()
        {
            IEither< int, long > either = GetLeft< int, long >( 42 );

            Assert.IsTrue(  either is Left<  int, long > );
            Assert.IsFalse( either is Right< int, long > );

            if( either is Left< int, long > left )
            {
                Assert.AreEqual( 42, left.Value );
            }
            else
            {
                Assert.IsTrue( false );
            }
        }
        
        [TestMethod]
        public void TestLeft_Value_Reference()
        {
            IEither< int, string > either = GetLeft< int, string >( 42 );
            
            Assert.IsTrue(  either is Left<  int, string > );
            Assert.IsFalse( either is Right< int, string > );

            if( either is Left< int, string > left )
            {
                Assert.AreEqual( 42, left.Value );
            }
            else
            {
                Assert.IsTrue( false );
            }
        }
        
        [TestMethod]
        public void TestLeft_Reference_Value()
        {
            IEither< string, long > either = GetLeft< string, long >( "hello, world" );
            
            Assert.IsTrue(  either is Left<  string, long > );
            Assert.IsFalse( either is Right< string, long > );

            if( either is Left< string, long > left )
            {
                Assert.AreEqual( "hello, world", left.Value );
            }
            else
            {
                Assert.IsTrue( false );
            }
        }
        
        [TestMethod]
        public void TestLeft_Reference_Reference()
        {
            IEither< string, string > either = GetLeft< string, string >( "hello, world" );
            
            Assert.IsTrue(  either is Left<  string, string > );
            Assert.IsFalse( either is Right< string, string > );

            if( either is Left< string, string > left )
            {
                Assert.AreEqual( "hello, world", left.Value );
            }
            else
            {
                Assert.IsTrue( false );
            }
        }
        
        [TestMethod]
        public void TestRight_Value_Value()
        {
            IEither< int, long > either = GetRight< int, long >( 42 );

            Assert.IsFalse( either is Left<  int, long > );
            Assert.IsTrue(  either is Right< int, long > );

            if( either is Right< int, long > right )
            {
                Assert.AreEqual( 42, right.Value );
            }
            else
            {
                Assert.IsTrue( false );
            }
        }
        
        [TestMethod]
        public void TestRight_Value_Reference()
        {
            IEither< int, string > either = GetRight< int, string >( "hello, world" );
            
            Assert.IsFalse( either is Left<  int, string > );
            Assert.IsTrue(  either is Right< int, string > );

            if( either is Right< int, string > right )
            {
                Assert.AreEqual( "hello, world", right.Value );
            }
            else
            {
                Assert.IsTrue( false );
            }
        }
        
        [TestMethod]
        public void TestRight_Reference_Value()
        {
            IEither< string, long > either = GetRight< string, long >( 42 );
            
            Assert.IsFalse( either is Left<  string, long > );
            Assert.IsTrue(  either is Right< string, long > );

            if( either is Right< string, long > right )
            {
                Assert.AreEqual( 42, right.Value );
            }
            else
            {
                Assert.IsTrue( false );
            }
        }
        
        [TestMethod]
        public void TestRight_Reference_Reference()
        {
            IEither< string, string > either = GetRight< string, string >( "hello, world" );
            
            Assert.IsFalse( either is Left<  string, string > );
            Assert.IsTrue(  either is Right< string, string > );

            if( either is Right< string, string > right )
            {
                Assert.AreEqual( "hello, world", right.Value );
            }
            else
            {
                Assert.IsTrue( false );
            }
        }
    }
}
