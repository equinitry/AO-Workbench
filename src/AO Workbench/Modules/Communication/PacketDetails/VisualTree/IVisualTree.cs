﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IVisualTree.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the IVisualTree type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Modules.Communication.PacketDetails.VisualTree
{
    using System.Collections.Generic;

    public interface IVisualTree
    {
        #region Public Properties

        IReadOnlyCollection<IHexDigit> HexDigits { get; }

        IReadOnlyCollection<IProperty> Properties { get; }

        #endregion
    }
}