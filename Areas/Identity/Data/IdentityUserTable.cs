using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrownGardenRazorEmilLocal.Model;
using Microsoft.AspNetCore.Identity;

namespace CrownGardenRazorEmilLocal.Areas.Identity.Data;

// Add profile data for application users by adding properties to the IdentityUserTable class
public class IdentityUserTable : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? ProfilePicture { get; set; }
    public DateTime DateJoined { get; set; } = DateTime.Now;
    public bool IsGolfMember { get; set; }
    public string MembershipLevel { get; set; }
    public List<Order> Orders { get; set; }
}

