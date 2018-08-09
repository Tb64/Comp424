using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Comp424Assign2
{
    class Block
    {
        public string hash;
        public string previousHash;
        private string data;
        private long timeStamp;

        /// <summary>
        /// Block constructor
        /// </summary>
        /// <param name="newData"></param>
        /// <param name="pHash"></param>
        public Block(string newData, string pHash)
        {
            this.data = newData;
            this.previousHash = pHash;
            this.timeStamp = DateTime.Now.Ticks;
            this.hash = CalculateHash();
        }

        /// <summary>
        /// Makes the hash for the block
        /// </summary>
        /// <returns></returns>
        public string CalculateHash()
        {
            string cHash = Hasher(previousHash + timeStamp.ToString() + data);
            return cHash;
        }

        /// <summary>
        /// The actual hash algorithm
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string Hasher(string input)
        {
            string output = "";
            SHA256 hasher = SHA256Managed.Create();
            try
            {
                byte[] hash = Encoding.ASCII.GetBytes(input);
                output = BitConverter.ToString(hasher.ComputeHash(hash));
                return output;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
