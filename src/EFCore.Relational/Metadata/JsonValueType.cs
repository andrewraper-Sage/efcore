// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Microsoft.EntityFrameworkCore.Metadata;

/// <summary>
///     Specifies the JSON value type of a scalar property in a JSON column.
/// </summary>
/// <remarks>
///     See <see href="https://aka.ms/efcore-docs-modeling">Modeling entity types and relationships</see> for more information and examples.
/// </remarks>
public enum JsonValueType
{
    /// <summary>
    ///     A JSON string value.
    /// </summary>
    String,

    /// <summary>
    ///     A JSON number value.
    /// </summary>
    Number,

    /// <summary>
    ///     A JSON boolean value.
    /// </summary>
    Bool
}
