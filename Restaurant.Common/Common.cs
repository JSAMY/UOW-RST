using Restaurant.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant.Common
{
    public static class DecoderUtil
    {
        public static Func<string, string> Encrypt = (text) =>
        {
            if (string.IsNullOrEmpty(text)) return text;

            var aesAlg = GetAESKey();
            var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
            var msEncrypt = new MemoryStream();
            using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
            using (var swEncrypt = new StreamWriter(csEncrypt))
            {
                swEncrypt.Write(text);
            }

            return Convert.ToBase64String(msEncrypt.ToArray());
        };

        public static Func<string, string> Decrypt = (cipherText) =>
        {
            if (string.IsNullOrEmpty(cipherText)) return cipherText;

            string text = "EmptyText";
            var aesAlg = GetAESKey();
            var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
            var cipher = Convert.FromBase64String(cipherText);
            if (string.IsNullOrEmpty(cipherText))
            {
                return text;
            }
            using (var msDecrypt = new MemoryStream(cipher))
            {
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (var srDecrypt = new StreamReader(csDecrypt))
                    {
                        text = srDecrypt.ReadToEnd();
                    }
                }
            }

            return text;
        };

        private static RijndaelManaged GetAESKey()
        {
            var saltBytes = Encoding.ASCII.GetBytes(Helper.GetConfigValue<string>("salt"));
            var key = new Rfc2898DeriveBytes(Helper.GetConfigValue<string>("inputkey"), saltBytes);

            var aesAlg = new RijndaelManaged();
            aesAlg.Key = key.GetBytes(aesAlg.KeySize / 8);
            aesAlg.IV = key.GetBytes(aesAlg.BlockSize / 8);

            return aesAlg;
        }
    }

    public static class Helper
    {
        public static T GetConfigValue<T>(string keyName)
        {
            if (ConfigurationManager.AppSettings.AllKeys.Where(key => key.Equals(keyName)).Any())
            {
                var configValue = ConfigurationManager.AppSettings[keyName];
                T returnValue = TConverter.ChangeType<T>(configValue);
                return returnValue;
            }
            else
            {
                return default(T);
            }
        }

        public static ReturnType Bind<ReturnType, SourceType>
   (
   SourceType srcObj,
   Boolean defaultValueInsteadOfNull = false,
   bool rstCryptography = true   
   )
    where ReturnType : class, new()
    where SourceType : class, new()
        {

            ReturnType retObj = new ReturnType();
            
            var srcProps = srcObj.GetType().GetProperties();
            var retProps = retObj.GetType().GetProperties();

            for (int propInx = 0; propInx < srcProps.Count(); propInx++)
            {
                var retExistProp = retProps.FirstOrDefault(p => p.Name.Equals(srcProps[propInx].Name));

                if (retExistProp != null)
                {
                    if (retExistProp.PropertyType.Equals(srcProps[propInx].PropertyType))
                    {
                        var noCryptography = true;
                         
                        if (rstCryptography)
                        {
                            noCryptography = false;
                            string cryptData = "";
                            //var hasDataProtection = retExistProp.GetCustomAttributes(typeof(RSTCryptographyAttribute), true);
                            var hasDataProtection = srcProps[propInx].GetCustomAttributes(typeof(RSTCryptographyAttribute), true);
                            if (hasDataProtection.Any())
                            {
                                switch (((RSTCryptographyAttribute)hasDataProtection.First()).Mode)
                                {
                                    case Mode.Encryption:
                                        cryptData = DecoderUtil.Encrypt(srcProps[propInx].GetValue(srcObj).ToString());
                                        break;
                                    case Mode.Decryption:
                                        cryptData = DecoderUtil.Decrypt(srcProps[propInx].GetValue(srcObj).ToString());
                                        break;

                                    case Mode.None:
                                        noCryptography = true;
                                        break;
                                }

                                if (!string.IsNullOrEmpty(cryptData) && !noCryptography)
                                {
                                    retExistProp.SetValue
                                    (
                                    retObj,
                                    TConverter.ChangeType(srcProps[propInx].PropertyType, cryptData),
                                    null
                                    );
                                }
                            }
                            else
                            {
                                noCryptography = true;
                            }
                        }

                        if (noCryptography )
                        {
                            retExistProp.SetValue
                            (
                            retObj,
                            TConverter.ChangeType(srcProps[propInx].PropertyType, srcProps[propInx].GetValue(srcObj)),
                            null
                            );
                        }


                    }
                }
            }

            return retObj;
        }
    }

    public static class TConverter
    {
        public static T ChangeType<T>(object value)
        {
            return (T)ChangeType(typeof(T), value);
        }

        public static object ChangeType(Type t, object value, Boolean defaultValueInsteadOfNull = false)
        {
            TypeConverter tc = TypeDescriptor.GetConverter(t);

            if (value == null)
            {
                if (defaultValueInsteadOfNull)
                {
                    if (t.IsValueType)
                    {
                        return Activator.CreateInstance(t);
                    }
                }
                else
                    return null;
            }

            return tc.ConvertFrom(value.ToString());
        }

        public static void RegisterTypeConverter<T, TC>() where TC : TypeConverter
        {
            TypeDescriptor.AddAttributes(typeof(T), new TypeConverterAttribute(typeof(TC)));
        }
    }

    
}
