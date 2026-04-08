// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Microsoft.EntityFrameworkCore.Diagnostics;

/// <summary>
///     The <see cref="DiagnosticSource" /> event payload for
///     <see cref="RelationalEventId.OldMigrationVersionWarning" />.
/// </summary>
/// <remarks>
///     See <see href="https://aka.ms/efcore-docs-diagnostics">Logging, events, and diagnostics</see> for more information and examples.
/// </remarks>
public class MigrationVersionEventData : MigrationTypeEventData
{
    /// <summary>
    ///     Constructs the event payload.
    /// </summary>
    /// <param name="eventDefinition">The event definition.</param>
    /// <param name="messageGenerator">A delegate that generates a log message for this event.</param>
    /// <param name="migrationType">The migration type.</param>
    /// <param name="migrationVersion">The EF Core version that was used to create the migration.</param>
    public MigrationVersionEventData(
        EventDefinitionBase eventDefinition,
        Func<EventDefinitionBase, EventData, string> messageGenerator,
        TypeInfo migrationType,
        string? migrationVersion)
        : base(eventDefinition, messageGenerator, migrationType)
        => MigrationVersion = migrationVersion;

    /// <summary>
    ///     The EF Core version that was used to create the migration, or <see langword="null" /> if it is not known.
    /// </summary>
    public virtual string? MigrationVersion { get; }
}
