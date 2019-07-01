using AdondeVamos.Model;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;

namespace AdondeVamos.ActionFilters
{
        public class AxValidateDataBinding : ActionFilterAttribute
        {
            public override void OnActionExecuting(HttpActionContext actionContext)
            {
                if (actionContext.ModelState.IsValid == false)
                {
                    string errorMessage = "";
                    List<ModelErrorCollection> modelErrorCollections = actionContext.ModelState.Select(x => x.Value.Errors)
                               .Where(y => y.Count > 0)
                               .ToList();
                    foreach (ModelErrorCollection errorCollection in modelErrorCollections)
                    {
                        foreach (ModelError error in errorCollection)
                        {
                            if (error.Exception != null)
                            {
                                errorMessage += "- " + error.Exception.Message;
                            }
                            if (!string.IsNullOrEmpty(error.ErrorMessage))
                            {
                                errorMessage += "- " + error.ErrorMessage;
                            }
                        }
                    }
                    //APIResponse apiResponse = APIResponse.Error(errorMessage);
                   // actionContext.Response = actionContext.Request.CreateResponse<APIResponse>(apiResponse);
                }
            }
        }
    }
