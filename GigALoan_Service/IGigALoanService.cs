using GigaLoan_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace GigALoanService
{
    [ServiceContract]
    public interface IGigALoanService
    {
        [OperationContract]
        string GetName();

        [OperationContract]
        string GetFirstCollege();

        [OperationContract]
        List<DTO_College> GetColleges();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/GetCollege", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]

        List<DTO_College> GetCollege(DTO_College token);
    }

}
