using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Models.Dtos.Categories.Responses;

public sealed record CategoryResponseDto
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public DateTime CreatedDate { get; init; }
}