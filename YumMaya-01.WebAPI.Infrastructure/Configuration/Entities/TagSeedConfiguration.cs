using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YumMaya_01.WebAPI.Domain.Models;

namespace YumMaya_01.WebAPI.Infrastructure.Configuration.Entities;

public sealed class TagSeedConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.HasData(
            new Tag { Id = Guid.Parse("4ee7389d-20b3-4d65-beaa-ebd8c5d984f9"), Name = "Protein" },
            new Tag { Id = Guid.Parse("262d6aa6-41ee-4824-8769-07a397dbcdc0"), Name = "Vegan" },
            new Tag { Id = Guid.Parse("462ec5fc-d3cc-4ef6-b9a2-4ec049bca6dd"), Name = "Vegetarian" },
            new Tag { Id = Guid.Parse("6557296d-8bc7-495f-8c78-ed90702d7587"), Name = "Gluten-Free" },
            new Tag { Id = Guid.Parse("20db370a-bc89-4594-a32d-f541f116d022"), Name = "Sweet" },
            new Tag { Id = Guid.Parse("8f7bcfa2-686a-4cfd-b5e4-963d1fddc9b3"), Name = "Spicy" },
            new Tag { Id = Guid.Parse("005d9684-7f2e-47eb-885b-027eac046e57"), Name = "Savory" },
            new Tag { Id = Guid.Parse("128d75d6-6184-4e24-b182-d5882805a2f2"), Name = "Fit" },
            new Tag { Id = Guid.Parse("aa0ebb7a-3061-4b76-87b2-02ef97154bf5"), Name = "Keto" },
            new Tag { Id = Guid.Parse("e475a0b8-c470-475f-a6e3-b33620628da7"), Name = "Dairy-Free" },
            new Tag { Id = Guid.Parse("c04dc859-3044-4f4f-a1cd-b49c8cf21c05"), Name = "Nut-Free" }
            );
    }
}