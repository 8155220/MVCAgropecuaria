using MVCAgropecuaria.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCAgropecuaria.BusinessLogicLayer
{
    public class BaseBusinessLogic
    {
        protected Response responseModel;

        public BaseBusinessLogic()
        {
            responseModel = new Response();
        }
    }
}