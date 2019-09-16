using System;

namespace Dobby.Host
{
    public class Query
    {
        public String GetGreeting(string master) => $"Dobby is gratefully serving his glorious master {master}.";
    }
}
