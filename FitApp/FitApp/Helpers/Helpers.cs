using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FitApp.Helpers
{
    public static class Helpers
    {
        public async static Task<bool> HandleRequest(this Task serviceMethod)
        {
            try
            {
                await serviceMethod;
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }
    }
}
