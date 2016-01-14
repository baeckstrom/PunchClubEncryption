using System;
using System.IO;
using System.Security.Cryptography;

namespace PunchClub_Encryption
{
    internal class PunchClubAes
    {
        private static ICryptoTransform _decryptor;
        private static ICryptoTransform _encryptor;

        /// <summary>
        /// Encryption key (game version 1.01)
        /// </summary>
        private static readonly byte[] Key = 
        {
            0x7b, 0xd9, 0x4f, 0x11, 0x18, 0x02, 0x55, 0x2d, 0x72, 0xb8, 0x1b, 0x70, 0x25, 0x70, 0xde, 0xd1,
            0xf1, 0x18, 0xaf, 0x90, 0xad, 0x35, 0xc4, 0x13, 0x18, 0x1a, 0x11, 0xda, 0x83, 0xec, 0x35, 0xd1
        };

        /// <summary>
        /// Encryption vector (game version 1.01)
        /// </summary>
        private static readonly byte[] Vector = 
        {
            0x92, 0x40, 0xab, 0xa1, 0x02, 0x03, 0x71, 0x77, 0xe7, 0x79, 0xdd, 0x70, 0x4f, 0x20, 0x72, 0x10
        };

        static PunchClubAes()
        {
            CreateEncoders();
        }

        private static void CreateEncoders()
        {
            var managed = new RijndaelManaged();
            _encryptor = managed.CreateEncryptor(Key, Vector);
            _decryptor = managed.CreateDecryptor(Key, Vector);
        }

        public static string DecryptToString(byte[] buffer)
        {
            CreateEncoders();
            return GetString(Transform(buffer, _decryptor));
        }

        public static byte[] EncryptToBytes(string buffer)
        {
            CreateEncoders();
            return Transform(GetBytes(buffer), _encryptor);
        }

        private static byte[] GetBytes(string input)
        {
            var output = new byte[input.Length * 2];
            Buffer.BlockCopy(input.ToCharArray(), 0, output, 0, output.Length);
            return output;
        }

        private static string GetString(byte[] input)
        {
            var output = new char[input.Length / 2];
            Buffer.BlockCopy(input, 0, output, 0, input.Length);
            return new string(output);
        }

        private static byte[] Transform(byte[] buffer, ICryptoTransform transform)
        {
            var stream = new MemoryStream();
            using (var stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Write))
            {
                stream2.Write(buffer, 0, buffer.Length);
            }
            return stream.ToArray();
        }
    }
}
