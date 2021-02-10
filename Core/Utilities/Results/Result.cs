using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //:this(success) this Result class ı demek tek parametreli constructerı çalıştır demek
        //Result classındaki tek parametreli contructer ı çalıştır demek oluyor.yani 2 constructer çalıştırıyoruz.
        public Result(bool success, string message):this(success) //bu çalıştıktan sonra alttakide çalışıyor.
        {
            Message = message;
        }

        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
