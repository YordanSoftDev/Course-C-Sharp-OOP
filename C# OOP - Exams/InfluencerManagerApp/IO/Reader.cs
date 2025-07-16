
using InfluencerManagerApp.IO.Contracts;
using System;

namespace InfluencerManagerApp.IO
{
    public class Reader : IReader
    {
        public string ReadLine() => Console.ReadLine(); 
    }
}
