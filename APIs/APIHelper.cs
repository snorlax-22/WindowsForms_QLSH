using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForms_QLSH.APIs
{
    class APIHelper
    {
        public System.Net.HttpWebRequest initRequest(string apiCalled, string method)
        {
            //Tạo ra 1 http request + Add bearer token + add Accept Type + add contentType
            HttpWebRequest httpWebRequest = WebRequest.Create(Program.baseURL + apiCalled) as HttpWebRequest;
            httpWebRequest.Method = method;
            httpWebRequest.Accept = Program.contentType;
            httpWebRequest.Headers.Add("Authorization", Program.bearerToken);
            httpWebRequest.ContentType = Program.contentType;

            return httpWebRequest;
        }
    }
}
