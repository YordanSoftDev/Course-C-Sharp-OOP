﻿using System;
using System.Linq;
using Telephony.Models.Interfaces;

namespace Telephony.Models;

public class Smartphone : ICallable, IBrowseable
{
    public string Call(string phoneNumber)
    {
        if (!ValidatePhoneNumber(phoneNumber))
        {
            throw new ArgumentException("Invalid number!");
        }

        return $"Calling... {phoneNumber}";
    }

    public string Browse(string url)
    {
        if (!ValidateUrl(url))
        {
            throw new ArgumentException("Invalid URL!");
        }

        return $"Browsing: {url}!";
    }

    private bool ValidatePhoneNumber(string phoneNumber)
       => phoneNumber.All(c => char.IsDigit(c));

    private bool ValidateUrl(string url)
        => url.All(c => !char.IsDigit(c));
}