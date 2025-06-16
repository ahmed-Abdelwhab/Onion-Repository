using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Infrastructure.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "8D04DCE2-969A-435D-BBA4-DF3F325983DC", Name = "Manager", NormalizedName = "MANAGER" },
                new IdentityRole { Id = "9F37A1B6-A234-4D3A-9C3B-2A1D3C8D76B2", Name = "Administrator", NormalizedName = "ADMINISTRATOR" }
            );
        }
    }

}   
