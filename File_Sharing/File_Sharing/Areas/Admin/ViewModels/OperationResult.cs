using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace File_Sharing.Areas.Admin.ViewModels
{
    public class OperationResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public static OperationResult NotFound(string msg = "Item not Found")
        {
            return new OperationResult
            {
                Success = false,
                Message = msg
            };
        }

        public static OperationResult Succeeded(string msg = "Operation Completed Successfully!")
        {
            return new OperationResult
            {
                Success = true,
                Message = msg
            };
        }


    }
}
