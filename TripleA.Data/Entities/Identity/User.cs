﻿using Microsoft.AspNetCore.Identity;

namespace TripleA.Data.Entities.Identity
{
    public class User : IdentityUser
    {
        public int Votes { get; set; } = 0;
    }
}
