﻿namespace University.Common.Authentication
{
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;

    public static class TokenExtensions
    {
        public static string GetClaim(this string token, string claim)
        {
            if (!string.IsNullOrEmpty(token))
            {
                var jwt = new JwtSecurityToken(token);
                object value = null;
                jwt.Payload.TryGetValue(claim, out value);
                return value.ToString();
            }

            return null;
        }
    }
}
