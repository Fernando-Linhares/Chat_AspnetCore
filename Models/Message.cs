using Chat_AspnetCore.Areas.Identity.Data;

namespace Chat_AspnetCore.Models;

public class Message
{
    public ulong Id { get; set; }

    public string? Content { get; set; }

    public DateTime CreatedAt { get; set; }

    public ApplicationUser ApplicationUser { get; set; }
}