﻿using BlogSite.Models.Dtos.Tokens.Responses;
using BlogSite.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Service.Abstratcts;

public interface IJwtService
{
    Task<TokenResponseDto> CreateJwtTokenAsync(User user);
    Task<List<Claim>> GetClaims(User user, List<string> audiences);
}