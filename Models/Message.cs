using System.ComponentModel.DataAnnotations;
using Chat_AspnetCore.Areas.Identity.Data;

namespace Chat_AspnetCore.Models;

public class Message
{
    [Key]
    public ulong Id { get; set; }

    public string? Content { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? UserId { get; set; }

    public string? UserName { get; set; }
}