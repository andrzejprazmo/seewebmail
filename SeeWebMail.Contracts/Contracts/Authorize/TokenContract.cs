﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SeeWebMail.Contracts.Contracts.Authorize
{
    public class TokenContract
    {
        public string UserEmail { get; set; }
        public string Token { get; set; }
        public bool IsAdmin { get; set; }

    }
}
