// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Microsoft.EntityFrameworkCore.Query.Associations.Navigations;

public abstract class NavigationsProjectionTestBase<TFixture>(TFixture fixture)
    : AssociationsProjectionTestBase<TFixture>(fixture)
    where TFixture : NavigationsFixtureBase, new()
{
    [ConditionalFact]
    public virtual Task LeftJoin_with_projected_nominal_type()
        => AssertQuery(
            ss => ss.Set<RootEntity>()
                .LeftJoin(
                    ss.Set<AssociateType>().Select(a => new AssociateProjection { Id = a.Id, Int = a.Int, Name = a.Name }),
                    r => r.OptionalAssociateId,
                    p => (int?)p.Id,
                    (root, projection) => new { root.Id, root.Name, Associate = projection }),
            ss => ss.Set<RootEntity>()
                .Select(r => new
                {
                    r.Id,
                    r.Name,
                    Associate = r.OptionalAssociate == null
                        ? null
                        : new AssociateProjection
                        {
                            Id = r.OptionalAssociate.Id, Int = r.OptionalAssociate.Int, Name = r.OptionalAssociate.Name
                        }
                }),
            elementSorter: e => e.Id);

    protected record AssociateProjection
    {
        public int Id { get; init; }
        public int Int { get; init; }
        public string Name { get; init; } = null!;
    }
}
