using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comp424Assign2
{
    class BlockChain
    {
        public List<Block> blockList = new List<Block>();

        /// <summary>
        /// Creates the first block of the chain
        /// </summary>
        /// <param name="newData"></param>
        public BlockChain(string newData)
        {
            blockList = new List<Block>();
            blockList.Add(new Block(newData, "0"));
        }

        /// <summary>
        /// Adds a block to the chain
        /// </summary>
        /// <param name="newData"></param>
        public void AddBlock(string newData)
        {
            if(blockList.Count > 0)
                blockList.Add(new Block(newData, blockList[blockList.Count - 1].hash));
            else
                Console.WriteLine("Failed to call constructor.");
        }

        public Block GetLastBlock()
        {
            if (blockList.Count > 0)
                return blockList[blockList.Count - 1];
            else
                return null;
        }

        /// <summary>
        /// Checks validation of the chain
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            Block previousBlock;
            Block currentBlock;

            for (int index = 1; index < blockList.Count; index++)
            {
                previousBlock = blockList[index - 1];
                currentBlock = blockList[index];

                if(!(currentBlock.hash == currentBlock.CalculateHash()))
                {
                    Console.WriteLine("Block has a miss match hash");
                    return false;
                }
                if (!(currentBlock.previousHash == previousBlock.hash))
                {
                    Console.WriteLine("Chain has a miss match hash");
                    return false;
                }
            }
            return true;
        }
    }
}
