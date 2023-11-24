using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using Chat_AspnetCore.Models;

namespace Chat_AspnetCore.Areas.Identity.Data;

public class ApplicationUser: IdentityUser
{
    [PersonalData]
    [Column(TypeName="nvarchar(100)")]
    public string FirstName { get; set; }

    [PersonalData]
    [Column(TypeName="nvarchar(100)")]
    public string LastName { get; set; }

    public Collection<Message> Messages { get; set; }
}