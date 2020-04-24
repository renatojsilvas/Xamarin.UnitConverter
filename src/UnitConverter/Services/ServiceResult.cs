using System;
using System.Collections.Generic;
using System.Text;

namespace UnitConverter
{
    public class ServiceResult
    {
        public ServiceResult(bool success, string message, Value value)
        {
            Success = success;
            Message = message;
            Value = value;
        }

        public bool Success { get; }
        public string Message { get; }
        public Value Value { get; }
    }
}
