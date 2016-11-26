using System;

namespace Restaurant.Common
{
    //[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class RSTCryptographyAttribute : Attribute
    {
        public Mode Mode { get; set; }
    }

    public enum Mode
    {
        None,
        Encryption,
        Decryption,
    }
}
