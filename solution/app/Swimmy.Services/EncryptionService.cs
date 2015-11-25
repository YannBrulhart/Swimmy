﻿namespace Swimmy.Services
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    using Swimmy.Services.Contracts;

    public class EncryptionService : IEncryptionService
    {
        public string CreateSalt()
        {
            var data = new byte[0x10];
            using (var cryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                cryptoServiceProvider.GetBytes(data);
                return Convert.ToBase64String(data);
            }
        }

        public string EncryptPassword(
            string password,
            string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var saltedPassword = $"{salt}{password}";
                var saltedPasswordAsBytes = Encoding.UTF8.GetBytes(saltedPassword);
                return Convert.ToBase64String(sha256.ComputeHash(saltedPasswordAsBytes));
            }
        }
    }
}