using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AlkinanaPharmaManagment.Domain.Entities.Customers.ValueObject;

public record PhoneNumber
{
    public string Value { get; }

    private PhoneNumber(string value)
    {
        if(!IsValidPhoneNumber(value))
            throw new ArgumentException("invalid phone number.",nameof(value));
        Value = value;
    }

    public static PhoneNumber Create(string value) { 
        return new PhoneNumber(value); 
    }

    private static bool IsValidPhoneNumber(string value)
    {
        var regex = new Regex(@"^\+\d{1,3}\d{9,15}$");
        return regex.IsMatch(value);
    }

    public static implicit operator PhoneNumber(string value) => new(value);
    public static implicit operator string(PhoneNumber phoneNumber) => phoneNumber.Value;
}
