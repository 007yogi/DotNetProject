using System.Security.Cryptography;

namespace EncryptionDecryption.AESMgmt
{
    public class EncryptDecryptService
    {
        private readonly string _encryptionKey;
        public EncryptDecryptService(string Key)
        {
            this._encryptionKey = Key;
        }

        // Encrypt a string using AES.
        public string EncryptString(string plainText)
        {
            byte[] _key = Convert.FromBase64String(_encryptionKey);
            byte[] _iv = new byte[16];

            using (var aes = Aes.Create())
            {
                aes.Key = _key;
                aes.IV = _iv;
                //aes.GenerateKey();
                //aes.GenerateIV();
                var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (var memoStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (var streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }
                    }
                    var encryptrdData = memoStream.ToArray();
                    return Convert.ToBase64String(encryptrdData);
                }
            }
        }

        //  Decrypt a string using AES.
        public string DecryptString(string cipherText)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = Convert.FromBase64String(_encryptionKey);
                aes.IV = new byte[16];
                var decryptor = aes.CreateDecryptor(aes.Key,aes.IV);

                using (var memoStream = new MemoryStream(Convert.FromBase64String(cipherText)))
                {
                    using (var cryptoStream = new CryptoStream(memoStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (var streamReader = new StreamReader(cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
