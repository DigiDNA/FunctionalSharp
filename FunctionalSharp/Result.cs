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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional
{
    public interface IResult< TSuccess, TError >
    {}

    public class Success< TSuccess, TError >: IResult< TSuccess, TError >
    {
        public TSuccess Value
        {
            get;
            private set;
        }

        public Success( TSuccess value )
        {
            this.Value = value ?? throw new ArgumentNullException( nameof( value ) );
        }
    }

    public class Error< TSuccess, TError >: IResult< TSuccess, TError >
    {
        public TError Value
        {
            get;
            private set;
        }

        public Error( TError value )
        {
            this.Value = value ?? throw new ArgumentNullException( nameof( value ) );
        }
    }
}
