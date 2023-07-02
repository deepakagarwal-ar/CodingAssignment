﻿using System;

namespace CleanupApp
{
    internal class CleanupApp
    {
        public static void Main()
        {
            // Command line zero gives the first aurgument which would be the exe
            // and 1 and 2 would be the args which we pass to the exe
            var connectionString = Environment.GetCommandLineArgs()[1]; 
            var identifier = Environment.GetCommandLineArgs()[2];

            Console.WriteLine(connectionString);
            Console.WriteLine(identifier);

            var repository = new Repository(connectionString);

            var worker = new CleanupWorker(repository);

            worker.Execute(identifier);

            Console.WriteLine("Cleanup completed");

            // Other repositories clean up
            var otherRepository = new OtherRepository(connectionString);
            worker = new CleanupWorker(otherRepository);

            worker.Execute(identifier);

            Console.WriteLine("Other repository clean up completed.");
        }
    }
}
