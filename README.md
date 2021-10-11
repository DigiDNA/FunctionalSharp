FunctionalSharp
===============

[![Build Status](https://img.shields.io/github/workflow/status/DigiDNA/FunctionalSharp/ci-win?label=Windows&logo=windows)](https://github.com/DigiDNA/FunctionalSharp/actions/workflows/ci-win.yaml)
[![Issues](http://img.shields.io/github/issues/DigiDNA/FunctionalSharp.svg?logo=github)](https://github.com/DigiDNA/FunctionalSharp/issues)
![Status](https://img.shields.io/badge/status-active-brightgreen.svg?logo=git)
![License](https://img.shields.io/badge/license-proprietary-orange.svg?logo=open-source-initiative)  
[![Contact](https://img.shields.io/badge/follow-@DigiDNA-blue.svg?logo=twitter&style=social)](https://twitter.com/DigiDNA)

About
-----

A set of convenience functional-style utilities to make C# code more similar to Swift.

### Array:

    U[] Map       < T, U >( Func< T, U > f )
    U[] FlatMap   < T, U >( Func< T, ICollection< U > > f )
    U[] CompactMap< T, U >( Func< T, U? > f )
    T[] Filter    < T    >( Func< T, bool > f )
    U   Reduce    < T, U >( U initialResult, Func< U, T, U > f )
    T[] Sorted    < T    >( Func< T, T, bool > predicate )

### Dictionary:

    Dictionary< TK, U >  MapValues       < TK, TV, U >( Func< KeyValuePair< TK, TV >, U > f )
    List< U >            Map             < TK, TV, U >( Func< KeyValuePair< TK, TV >, U > f )
    List< U >            FlatMap         < TK, TV, U >( Func< KeyValuePair< TK, TV >, ICollection< U > > f )
    List< U >            CompactMap      < TK, TV, U >( Func< KeyValuePair< TK, TV >, U? > f )
    Dictionary< TK, U >  CompactMapValues< TK, TV, U >( Func< KeyValuePair< TK, TV >, U? > f )
    Dictionary< TK, TV > Filter          < TK, TV    >( Func< KeyValuePair< TK, TV >, bool > f )
    U                    Reduce          < TK, TV, U >( U initialResult, Func< U, KeyValuePair< TK, TV >, U > f )

### HashSet:

    HashSet< U > Map       < T, U >( Func< T, U > f )
    HashSet< U > FlatMap   < T, U >( Func< T, ICollection< U > > f )
    HashSet< U > CompactMap< T, U >( Func< T, U? > f )
    HashSet< T > Filter    < T    >( Func< T, bool > f )
    U            Reduce    < T, U >( U initialResult, Func< U, T, U > f )

### LinkedList:

    LinkedList< U > Map       < T, U >( Func< T, U > f )
    LinkedList< U > FlatMap   < T, U >( Func< T, ICollection< U > > f )
    LinkedList< U > CompactMap< T, U >( Func< T, U? > f )
    LinkedList< T > Filter    < T    >( Func< T, bool > f )
    U               Reduce    < T, U >( U initialResult, Func< U, T, U > f )

### List:

    List< U > Map       < T, U >( Func< T, U > f )
    List< U > FlatMap   < T, U >( Func< T, ICollection< U > > f )
    List< U > CompactMap< T, U >( Func< T, U? > f )
    List< T > Filter    < T    >( Func< T, bool > f )
    U         Reduce    < T, U >( U initialResult, Func< U, T, U > f )
    List< T > Sorted    < T    >( Func< T, T, bool > predicate )

### SortedSet:

    SortedSet< U > Map       < T, U >( Func< T, U > f )
    SortedSet< U > FlatMap   < T, U >( Func< T, ICollection< U > > f )
    SortedSet< U > CompactMap< T, U >( Func< T, U? > f )
    SortedSet< T > Filter    < T    >( Func< T, bool > f )
    U              Reduce    < T, U >( U initialResult, Func< U, T, U > f )

License
-------

Project is released under the terms of the MIT License.

Repository Infos
----------------

    Owner:   DigiDNA
    Web:     www.digidna.net
    Blog:    imazing.com/blog
    Twitter: @DigiDNA
    GitHub:  github.com/DigiDNA
