// Copyright (c) Alexander Shlyakhto (InfDev). All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.
// Created:  2020.05.03
// Modified: 2021.10.27

using System;
using CDPN.Common.Resources;

namespace CDPN.Common.Exceptions
{
#pragma warning disable CA1032

    public class NotSupportPlatformException : Exception
    {
        public NotSupportPlatformException(string currentRID, string[] supportedRID) 
            : base(string.Format(SR.OSPlatformNotSupported, currentRID, supportedRID)) { }
    }
}
