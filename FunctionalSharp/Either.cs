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
    public interface IEither< TLeft, TRight >
    {}

    public class Left< TLeft, TRight >: IEither< TLeft, TRight >
    {
        public TLeft Value
        {
            get;
            private set;
        }

        public Left( TLeft value )
        {
            this.Value = value ?? throw new ArgumentNullException( nameof( value ) );
        }
    }

    public class Right< TLeft, TRight >: IEither< TLeft, TRight >
    {
        public TRight Value
        {
            get;
            private set;
        }

        public Right( TRight value )
        {
            this.Value = value ?? throw new ArgumentNullException( nameof( value ) );
        }
    }
}
