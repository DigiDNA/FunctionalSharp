﻿/*******************************************************************************
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
