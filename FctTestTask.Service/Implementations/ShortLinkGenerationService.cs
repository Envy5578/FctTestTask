using FctTestTask.Domain.ViewModels.Link;
using FctTestTask.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FctTestTask.Service.Implementations
{
    public class ShortLinkGenerationService : IShortLinkGenerationService
    {
        public LinkShortViewModel GenerateLink(LinkLongViewModel link)
        {
            const string Alphabet = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const int keyLength = 6;

            var random = new Random();
            var key = new char[keyLength];

            for (int i = 0; i < keyLength; i++)
            {
                key[i] = Alphabet[random.Next(Alphabet.Length)];
            }

            var shortKey = new string(key);

            return new LinkShortViewModel
            {
                LinkShort = $"shorturl.at/{shortKey}"
            };
        }
    }  
}

