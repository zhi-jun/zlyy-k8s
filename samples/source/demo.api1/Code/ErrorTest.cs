using Serilog;
using System;

namespace demo.api1.Code
{
    public class ErrorTest
    {
        public void RunError()
        {
            try
            {
                throw new Exception("出错了");
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }
        }
    }
}
