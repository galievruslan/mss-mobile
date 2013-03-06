using System;
using System.Collections.Generic;

namespace MSS.WinMobile.Domain.Models.ActiveRecord
{
    public static class TransactionContext
    {
        private static readonly Queue<string> Queue = new Queue<string>();

        public static void Enqueue(string command)
        {
            lock (Queue)
            {
                Queue.Enqueue(command);    
            }
        }

        public static string Dequeue()
        {
            string command;
            lock (Queue)
            {
                command = Queue.Dequeue();
            }
            return command;
        }

        public static int Count {
            get
            {
                int count;
                lock (Queue)
                {
                    count = Queue.Count;
                }

                return count;
            }
        }

        public static void Clear()
        {
            lock (Queue)
            {
                Queue.Clear();   
            }
        }
    }

    public class AlreadyInTransactionException : Exception
    {
    }
}
