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
    public class Result
    {
        private static IResult< T1, T2 > GetSuccess< T1, T2 >( T1 value )
        {
            return new Success< T1, T2 >( value );
        }

        private static IResult< T1, T2 > GetError< T1, T2 >( T2 value )
        {
            return new Error< T1, T2 >( value );
        }
        
        [TestMethod]
        public void Testsuccess_Value_Value()
        {
            IResult< int, long > result = GetSuccess< int, long >( 42 );

            Assert.IsTrue(  result is Success< int, long > );
            Assert.IsFalse( result is Error<   int, long > );

            if( result is Success< int, long > success )
            {
                Assert.AreEqual( 42, success.Value );
            }
            else
            {
                Assert.IsTrue( false );
            }
        }
        
        [TestMethod]
        public void Testsuccess_Value_Reference()
        {
            IResult< int, string > result = GetSuccess< int, string >( 42 );
            
            Assert.IsTrue(  result is Success< int, string > );
            Assert.IsFalse( result is Error<   int, string > );

            if( result is Success< int, string > success )
            {
                Assert.AreEqual( 42, success.Value );
            }
            else
            {
                Assert.IsTrue( false );
            }
        }
        
        [TestMethod]
        public void Testsuccess_Reference_Value()
        {
            IResult< string, long > result = GetSuccess< string, long >( "hello, world" );
            
            Assert.IsTrue(  result is Success< string, long > );
            Assert.IsFalse( result is Error<   string, long > );

            if( result is Success< string, long > success )
            {
                Assert.AreEqual( "hello, world", success.Value );
            }
            else
            {
                Assert.IsTrue( false );
            }
        }
        
        [TestMethod]
        public void Testsuccess_Reference_Reference()
        {
            IResult< string, string > result = GetSuccess< string, string >( "hello, world" );
            
            Assert.IsTrue(  result is Success< string, string > );
            Assert.IsFalse( result is Error<   string, string > );

            if( result is Success< string, string > success )
            {
                Assert.AreEqual( "hello, world", success.Value );
            }
            else
            {
                Assert.IsTrue( false );
            }
        }
        
        [TestMethod]
        public void Testerror_Value_Value()
        {
            IResult< int, long > result = GetError< int, long >( 42 );

            Assert.IsFalse( result is Success< int, long > );
            Assert.IsTrue(  result is Error<   int, long > );

            if( result is Error< int, long > error )
            {
                Assert.AreEqual( 42, error.Value );
            }
            else
            {
                Assert.IsTrue( false );
            }
        }
        
        [TestMethod]
        public void Testerror_Value_Reference()
        {
            IResult< int, string > result = GetError< int, string >( "hello, world" );
            
            Assert.IsFalse( result is Success< int, string > );
            Assert.IsTrue(  result is Error<   int, string > );

            if( result is Error< int, string > error )
            {
                Assert.AreEqual( "hello, world", error.Value );
            }
            else
            {
                Assert.IsTrue( false );
            }
        }
        
        [TestMethod]
        public void Testerror_Reference_Value()
        {
            IResult< string, long > result = GetError< string, long >( 42 );
            
            Assert.IsFalse( result is Success< string, long > );
            Assert.IsTrue(  result is Error<   string, long > );

            if( result is Error< string, long > error )
            {
                Assert.AreEqual( 42, error.Value );
            }
            else
            {
                Assert.IsTrue( false );
            }
        }
        
        [TestMethod]
        public void Testerror_Reference_Reference()
        {
            IResult< string, string > result = GetError< string, string >( "hello, world" );
            
            Assert.IsFalse( result is Success< string, string > );
            Assert.IsTrue(  result is Error<   string, string > );

            if( result is Error< string, string > error )
            {
                Assert.AreEqual( "hello, world", error.Value );
            }
            else
            {
                Assert.IsTrue( false );
            }
        }
    }
}
