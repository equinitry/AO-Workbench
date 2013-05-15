﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NanosModule.cs" company="SmokeLounge">
//   Copyright © 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the NanosModule type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Modules.Nanos
{
    using System;
    using System.Diagnostics.Contracts;

    using SmokeLounge.AoWorkbench.Models.Domain;
    using SmokeLounge.AoWorkbench.Models.Modules;
    using SmokeLounge.AoWorkbench.Models.Workbench;

    public class NanosModule : IModule
    {
        #region Fields

        private readonly Uri iconSource;

        private readonly string name;

        private readonly IRemoteProcess remoteProcess;

        private readonly NanosFactory nanosFactory;

        #endregion

        #region Constructors and Destructors

        public NanosModule(IRemoteProcess remoteProcess, NanosFactory nanosFactory)
        {
            Contract.Requires<ArgumentNullException>(remoteProcess != null);
            Contract.Requires<ArgumentNullException>(nanosFactory != null);

            this.remoteProcess = remoteProcess;
            this.nanosFactory = nanosFactory;
            this.iconSource = null;
            this.name = "Nanos";
        }

        #endregion

        #region Public Properties

        public Uri IconSource
        {
            get
            {
                return this.iconSource;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        #endregion

        #region Public Methods and Operators

        public IItem CreateItem()
        {
            return this.nanosFactory.CreateItem(this.remoteProcess.Id);
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(string.IsNullOrWhiteSpace(this.name) == false);
            Contract.Invariant(this.nanosFactory != null);
            Contract.Invariant(this.remoteProcess != null);
        }

        #endregion
    }
}