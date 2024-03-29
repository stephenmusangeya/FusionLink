﻿//  Copyright (c) RXD Solutions. All rights reserved.
//  FusionLink is licensed under the MIT license. See LICENSE.txt for details.

using System;

namespace RxdSolutions.FusionLink
{
    public interface IGlobalFunctions
    {
        event EventHandler<PortfolioCalculationEndedEventArgs> PortfolioCalculationEnded;

        event EventHandler<PortfolioAdditionEndedEventArgs> PortfolioAdditionEnded;
    }
}