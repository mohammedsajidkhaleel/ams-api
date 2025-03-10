﻿using ams.domain.LicensedAssets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ams.infrastructure.Configurations;
internal sealed class LicensedAssetConfiguration
    : IEntityTypeConfiguration<LicensedAsset>
{
    public void Configure(EntityTypeBuilder<LicensedAsset> builder)
    {
        builder.ToTable("licensed_assets");
        builder.HasKey(x => x.Id);
    }
}

