using System;
using System.Text;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;

public class AESAlg
{
    AesCryptoServiceProvider crypt_provider;

    public AESAlg()
    {
        crypt_provider = new AesCryptoServiceProvider();
        crypt_provider.BlockSize = 128;
        crypt_provider.KeySize = 256;
        crypt_provider.GenerateIV();
        crypt_provider.GenerateKey();
        crypt_provider.Mode = CipherMode.CBC;
        crypt_provider.Padding = PaddingMode.PKCS7;
    }

    public String AES_Encrypt(String text)
    {
        ICryptoTransform transform = crypt_provider.CreateEncryptor();
        
        byte[] encrypted_bytes = transform.TransformFinalBlock(ASCIIEncoding.Default.GetBytes(text), 0, text.Length);
        string str = Convert.ToBase64String(encrypted_bytes);
        return str;
    }

    public String AES_Decrypt(String text)
    {
        ICryptoTransform transform = crypt_provider.CreateDecryptor();
        byte[] enc_bytes = Convert.FromBase64String(text);
        byte[] decrypted_bytes = transform.TransformFinalBlock(enc_bytes, 0, enc_bytes.Length);
        string str = ASCIIEncoding.Default.GetString(decrypted_bytes);
        return str;
    }
}
