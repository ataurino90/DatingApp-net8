using System;

namespace API.DTOs;

public class MemberUpdateDto
{
    public string? Introduction { get; set; }
    public string? LookingFor { get; set; }
    public string? Interests { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }


    // public int Id { get; set; }
    // public string? UserName { get; set; }
    // public int Age { get; set; }
    // public string? PhotoUrl { get; set; }
    // public string? KnownAS { get; set; }
    // public DateTime Created { get; set; }
    // public DateTime LastActive { get; set; }
    // public string? Gender { get; set; }
    // public List<PhotoDto> Photos { get; set; }
}
