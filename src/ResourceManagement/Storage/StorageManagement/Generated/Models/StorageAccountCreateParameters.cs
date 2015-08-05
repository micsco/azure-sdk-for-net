// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
// 
// Code generated by Microsoft (R) AutoRest Code Generator 0.11.0.0
// Changes may cause incorrect behavior and will be lost if the code is

namespace Microsoft.Azure.Management.Storage.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    /// <summary>
    /// The parameters to provide for the account.
    /// </summary>
    public partial class StorageAccountCreateParameters : Resource
    {
        /// <summary>
        /// Gets or sets the account type. Possible values for this property
        /// include: 'Standard_LRS', 'Standard_ZRS', 'Standard_GRS',
        /// 'Standard_RAGRS', 'Premium_LRS'
        /// </summary>
        [JsonProperty(PropertyName = "properties.accountType")]
        public AccountType? AccountType { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public override void Validate()
        {
            base.Validate();
        }
    }
}
