/*
 The MIT License (MIT)
//https://localhost:44332/
Copyright (c) 2018 Microsoft Corporation

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
 */

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using MODELS.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace Golf.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    //[RequiredScope(scopeRequiredByAPI)]
    public class UserAccountController : Controller
    {
        const string scopeRequiredByAPI = "access_as_user" ;
        // In-memory TodoList

        private readonly IHttpContextAccessor _contextAccessor;
     
        public UserAccountController(IHttpContextAccessor contextAccessor)
        {
            this._contextAccessor = contextAccessor;
        }

        // Get user ID
        [HttpGet]
        public string Get()
        {
            string id = User.Claims.FirstOrDefault(obj => obj.Type == "sub").Value;
            return id;
        }

    }
}