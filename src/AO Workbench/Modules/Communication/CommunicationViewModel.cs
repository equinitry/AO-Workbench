// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommunicationViewModel.cs" company="SmokeLounge">
//   Copyright � 2013 SmokeLounge.
//   This program is free software. It comes without any warranty, to
//   the extent permitted by applicable law. You can redistribute it
//   and/or modify it under the terms of the Do What The Fuck You Want
//   To Public License, Version 2, as published by Sam Hocevar. See
//   http://www.wtfpl.net/ for more details.
// </copyright>
// <summary>
//   Defines the CommunicationViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SmokeLounge.AoWorkbench.Modules.Communication
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.Contracts;

    using Caliburn.Micro;

    using SmokeLounge.AoWorkbench.Models.Domain;
    using SmokeLounge.AoWorkbench.Modules.Communication.PacketDetails;
    using SmokeLounge.AoWorkbench.Modules.Communication.PacketList;
    using SmokeLounge.AoWorkbench.ViewModels.Workbench;

    public class CommunicationViewModel : DocumentItemViewModel
    {
        #region Fields

        private readonly PacketDetailsViewModel packetDetails;

        private readonly PacketListViewModel packetList;

        private readonly IProcess process;

        #endregion

        #region Constructors and Destructors

        public CommunicationViewModel(
            IProcess process, 
            PacketListViewModel packetList, 
            PacketDetailsViewModel packetDetails, 
            IEventAggregator events)
            : base(events)
        {
            Contract.Requires<ArgumentNullException>(process != null);
            Contract.Requires<ArgumentNullException>(packetList != null);
            Contract.Requires<ArgumentNullException>(packetDetails != null);
            Contract.Requires<ArgumentNullException>(events != null);

            this.process = process;
            this.packetList = packetList;
            this.packetDetails = packetDetails;

            Func<string> getTitle =
                () =>
                "Communication: " + (this.process.Player != null ? this.process.Player.Name : this.process.DisplayName);
            this.Title = getTitle();
            PropertyChangedEventManager.AddHandler(
                this.process, (sender, args) => this.Title = getTitle(), string.Empty);
            PropertyChangedEventManager.AddHandler(
                this.packetList, 
                (sender, args) => this.packetDetails.Packet = this.packetList.SelectedPacket, 
                "SelectedPacket");
        }

        #endregion

        #region Public Properties

        public PacketDetailsViewModel PacketDetails
        {
            get
            {
                return this.packetDetails;
            }
        }

        public PacketListViewModel PacketList
        {
            get
            {
                return this.packetList;
            }
        }

        #endregion

        #region Methods

        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(this.process != null);
            Contract.Invariant(this.packetList != null);
            Contract.Invariant(this.packetDetails != null);
        }

        #endregion
    }
}