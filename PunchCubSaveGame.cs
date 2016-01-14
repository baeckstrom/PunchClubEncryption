using System.IO;

namespace PunchClub_Encryption
{
    static internal class PunchCubSaveGame
    {
        /// <summary>
        /// Decrypt data
        /// </summary>
        /// <param name="filenameInput">Input file</param>
        /// <param name="filenameOutput">Output file</param>
        public static void Decrypt(string filenameInput, string filenameOutput)
        {
            File.WriteAllText(filenameOutput, PunchClubAes.DecryptToString(File.ReadAllBytes(filenameInput)));
        }

        /// <summary>
        /// Encrypt data
        /// </summary>
        /// <param name="filenameInput">Input file</param>
        /// <param name="filenameOutput">Output file</param>
        public static void Encrypt(string filenameInput, string filenameOutput)
        {
            File.WriteAllBytes(filenameOutput, PunchClubAes.EncryptToBytes(File.ReadAllText(filenameInput)));
        }

    }
}
