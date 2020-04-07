using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class Result<T>
    {
        public bool Success { get; set; }

        public T Data { get; set; }
    }
}
