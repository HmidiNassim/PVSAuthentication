﻿namespace VPSAuthentication.Common.Signature
{
    using System;
    using System.Security.Cryptography;
    using System.Text;


    public class CalculateSignature : ICalculateSignature
    {
        public string Signature(string secret, string value)
        {
            var secretBytes = Encoding.UTF8.GetBytes(secret);
            var valueBytes = Encoding.UTF8.GetBytes(value);
            string signature;

            using (var hmac = new HMACSHA256(secretBytes))
            {
                var hash = hmac.ComputeHash(valueBytes);
                signature = Convert.ToBase64String(hash);
            }
            return signature;
        }
    }
}