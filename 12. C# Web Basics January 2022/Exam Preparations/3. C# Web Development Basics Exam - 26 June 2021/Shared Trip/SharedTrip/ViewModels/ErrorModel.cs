using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.ViewModels
{
    public class ErrorModel
    {
        public string ErrorMessage { get; init; }

        public ErrorModel(string message)
        {
            ErrorMessage = message;
        }
    }
}
