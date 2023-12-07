using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using Chat_AspnetCore.Models;

namespace Chat_AspnetCore.Areas.Identity.Data;

public class ApplicationUser: IdentityUser
{
    public string? FullName { get; set; }
}