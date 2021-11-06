using System;

namespace _06.HighJump
{
    class Program
    {
        static void Main(string[] args)
        {
            int targetHeight = int.Parse(Console.ReadLine());

            int startHeight = targetHeight - 30;
            int jumpsMade = 0;         

            bool isJumped = false;

            while (!isJumped)
            {
                int jumpsFailed = 0;
                for (int attempts = 1; attempts <= 3; attempts++)
                {
                    int jumpedHeight = int.Parse(Console.ReadLine());
                    jumpsMade++;

                    if (startHeight < jumpedHeight)
                    {
                        if (startHeight == targetHeight)
                        {
                            isJumped = true;                            
                        }
                        else
                        {
                            startHeight += 5;                            
                        }
                        break;                        
                    }
                    else
                    {
                        jumpsFailed++;                        
                    }
                }

                if (jumpsFailed == 3)
                {
                    break;
                }                
            }

            if (isJumped)
            {
                Console.WriteLine($"Tihomir succeeded, he jumped over {targetHeight}cm after {jumpsMade} jumps.");
            }
            else
            {
                Console.WriteLine($"Tihomir failed at {startHeight}cm after {jumpsMade} jumps.");
            }
        }
    }
}
