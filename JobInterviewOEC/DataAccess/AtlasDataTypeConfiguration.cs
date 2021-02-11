using JobInterviewOEC.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobInterviewOEC.DataAccess
{
    internal class AtlasDataTypeConfiguration : IEntityTypeConfiguration<AtlasData>
    {
        public void Configure(EntityTypeBuilder<AtlasData> builder)
        {
            var atlasFileConfiguration = new AtlasFileConfiguration();

            builder.Property(a => a.CenterIdDealerNo).HasMaxLength(atlasFileConfiguration
                .ParametersLength[nameof(AtlasData.CenterIdDealerNo)]);

            builder.Property(a => a.GrpNameDealerName).HasMaxLength(atlasFileConfiguration
                .ParametersLength[nameof(AtlasData.GrpNameDealerName)]);

            builder.Property(a => a.DealerNo).HasMaxLength(atlasFileConfiguration
                .ParametersLength[nameof(AtlasData.DealerNo)]);

            builder.Property(a => a.BillToPartly).HasMaxLength(atlasFileConfiguration
                .ParametersLength[nameof(AtlasData.BillToPartly)]);

            builder.Property(a => a.Customer).HasMaxLength(atlasFileConfiguration
                .ParametersLength[nameof(AtlasData.Customer)]);

            builder.Property(a => a.LineMake).HasMaxLength(atlasFileConfiguration
                .ParametersLength[nameof(AtlasData.LineMake)]);

            builder.Property(a => a.EndDate).HasMaxLength(atlasFileConfiguration
                .ParametersLength[nameof(AtlasData.EndDate)]);

            builder.Property(a => a.ShipToParty).HasMaxLength(atlasFileConfiguration
                .ParametersLength[nameof(AtlasData.ShipToParty)]);

            builder.Property(a => a.LocationId).HasMaxLength(atlasFileConfiguration
                .ParametersLength[nameof(AtlasData.LocationId)]);

            builder.Property(a => a.AddrPriId).HasMaxLength(atlasFileConfiguration
                .ParametersLength[nameof(AtlasData.AddrPriId)]);

            builder.Property(a => a.AddrLineOne).HasMaxLength(atlasFileConfiguration
                .ParametersLength[nameof(AtlasData.AddrLineOne)]);

            builder.Property(a => a.AddrLineTwo).HasMaxLength(atlasFileConfiguration
                .ParametersLength[nameof(AtlasData.AddrLineTwo)]);
        }
    }
}
