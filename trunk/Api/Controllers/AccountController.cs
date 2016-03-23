using Api.Services;
using JobsInABA.BL.DTOs;
using JobsInABA.Workflows;
using JobsInABA.Workflows.Models;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace Api.Controllers
{
    public class AccountController : ApiController
    {
        private UserWorkflows db = new UserWorkflows();
        private BusinessWorkflows dbBusiness = new BusinessWorkflows();

        public HttpResponseMessage PostFileUser()
        {
            foreach (string fileName in HttpContext.Current.Request.Files)
            {
                var file = HttpContext.Current.Request.Files[fileName];
                var fname = Path.GetFileNameWithoutExtension(file.FileName);
                var Ext = Path.GetExtension(file.FileName);
                string FileName = System.IO.Path.GetFileName(file.FileName);
                if (file.FileName != "" || fileName != null)
                {
                    var imgPath = HttpContext.Current.Server.MapPath("~/FileUpload/UserImage");
                    if (!Directory.Exists(imgPath))
                        Directory.CreateDirectory(imgPath);
                    var _strUserid = HttpContext.Current.Request["userID"].ToString();
                    int userID = Convert.ToInt32(_strUserid);

                    string physicalPath = imgPath + "\\" + userID + Ext;
                    if (System.IO.File.Exists(physicalPath))
                    {
                        System.IO.File.Delete(physicalPath);
                    }
                    file.SaveAs(physicalPath);

                    #region Entry in database
                    UserDataModel newUserModel = new UserDataModel();
                    newUserModel.UserID = userID;
                    newUserModel.Name = file.FileName;
                    newUserModel.ImageTypeID = Convert.ToInt32(HttpContext.Current.Request["imageTypeId"].ToString());
                    newUserModel.ImageExtension = Ext;
                    newUserModel.UserimagePrimary = true;

                    db.UpdateUserImage(newUserModel);

                    #endregion
                }
            }
            //string path = string.Empty;
            //HttpRequestMessage request = this.Request;
            //if (!request.Content.IsMimeMultipartContent())
            //{
            //    throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.UnsupportedMediaType));
            //}

            //string root = System.Web.HttpContext.Current.Server.MapPath("~/FileUpload/UserImage");
            //var provider = new MultipartFormDataStreamProvider(root);

            //var task = request.Content.ReadAsMultipartAsync(provider).
            //    ContinueWith<HttpResponseMessage>(o =>
            //    {
            //        FileInfo finfo = new FileInfo(provider.FileData.First().LocalFileName);


            //        string guid = Guid.NewGuid().ToString();
            //        path = guid + "_" + provider.FileData.First().Headers.ContentDisposition.FileName.Replace("\"", "");

            //        File.Move(finfo.FullName, Path.Combine(root, path));

            //        return new HttpResponseMessage()
            //        {
            //            Content = new StringContent("File uploaded.")
            //        };
            //    }
            //);
            return Request.CreateResponse(HttpStatusCode.OK);
        }


        public HttpResponseMessage PostFileBusiness()
        {
            foreach (string fileName in HttpContext.Current.Request.Files)
            {
                var file = HttpContext.Current.Request.Files[fileName];
                var fname = Path.GetFileNameWithoutExtension(file.FileName);
                var Ext = Path.GetExtension(file.FileName);
                string FileName = System.IO.Path.GetFileName(file.FileName);
                if (file.FileName != "" || fileName != null)
                {
                    var imgPath = HttpContext.Current.Server.MapPath("~/FileUpload/CompanyImage");
                    if (!Directory.Exists(imgPath))
                        Directory.CreateDirectory(imgPath);
                    var _strbusinessid = HttpContext.Current.Request["businessID"].ToString();
                    int businessID = Convert.ToInt32(_strbusinessid);

                    string physicalPath = imgPath + "\\" + businessID + Ext;
                    if (System.IO.File.Exists(physicalPath))
                    {
                        System.IO.File.Delete(physicalPath);
                    }
                    file.SaveAs(physicalPath);

                    #region Entry in database
                    BusinessDataModel newBusinessModel = new BusinessDataModel();
                    newBusinessModel.BusinessID = businessID;
                    newBusinessModel.ImageName = file.FileName;
                    newBusinessModel.ImageTypeID = Convert.ToInt32(HttpContext.Current.Request["imageTypeId"].ToString());
                    newBusinessModel.ImageExtension = Ext;
                    newBusinessModel.BusinessImagePrimary = true;

                    dbBusiness.UpdateBusinessImage(newBusinessModel);

                    #endregion
                }
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("api/account/SignIn")]
        [HttpPost]
        [ResponseType(typeof(UserDataModel))]
        public IHttpActionResult SignIn(SignIn signIn)
        {
            if (signIn.Username == null || signIn.Password == null)
                return StatusCode(HttpStatusCode.BadRequest);

            var user = db.CanLogIn(signIn.Username, signIn.Password);

            if (user == null)
            {
                return NotFound();
            }
            else if (user.IsActive)
            {
                return Ok(user);
            }
            else
            {
                return Ok(0);
            }
        }



        //after click on register confirm link
        [Route("api/account/ActivateUser")]
        [HttpGet]
        public IHttpActionResult ActivateUser(string q)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(q);
            var plainUserID = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
            int _UserID = Convert.ToInt32(plainUserID);

            if (new UserWorkflows().ActivateUser(_UserID))
            {
                IHttpActionResult response;
                HttpResponseMessage responseMsg = new HttpResponseMessage(HttpStatusCode.RedirectMethod);
                var redirectUrl = ConfigurationManager.AppSettings["CurruntURL"].ToString() + "/#/login/1";
                responseMsg.Headers.Location = new Uri(redirectUrl);
                response = ResponseMessage(responseMsg);
                return response;
            }
            else
                return NotFound();
        }

        public IHttpActionResult EmailExist(string username)
        {
            if (new UserWorkflows().Get().Count(p => p.UserName == username) > 0)
            {
                return Ok();
            }
            else
                return NotFound();
        }

        //send forgot password mail
        public IHttpActionResult ForgotPassword(ForgotPassword forgotPwd)
        {
            var objUser = db.Get().Where(x => x.UserEmailAddress == forgotPwd.ForgotEmailAddress).FirstOrDefault();
            if (objUser != null)
            {
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(objUser.UserID.ToString());
                var encodeUserID = System.Convert.ToBase64String(plainTextBytes);
                EmailService.SendPasswordResetEmail(forgotPwd.ForgotEmailAddress, encodeUserID, objUser.UserName);
                return Ok();
            }
            else
                return NotFound();
        }


        //create new password
        public IHttpActionResult CreatePassword(ChangePassword objChangePassword)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(objChangePassword.EncodeUserID.ToString());
            var plainUserID = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
            int _userID = Convert.ToInt32(plainUserID);

            var objUser = db.Get().Where(x => x.UserID == _userID).FirstOrDefault();
            if (objUser != null && !string.IsNullOrEmpty(objChangePassword.UserAccountPassword))
            {
                ChangePassword objchange = new ChangePassword();
                objchange.UserAccountUserName = objUser.UserName;
                objchange.UserID = objUser.UserID;
                objchange.UserAccountPassword = objChangePassword.UserAccountPassword;
                objchange.UserAccountID = objChangePassword.UserAccountID;
                db.ChangePassword(objchange);
                return Ok();
            }
            else
                return NotFound();
        }

        //change password
        public IHttpActionResult ChangePassword(ChangePassword objChangePassword)
        {
            UserAccountDTO objUserAccount = db.GetUserAccountInfoByUserID(objChangePassword.UserID);

            if (objUserAccount != null  && !string.IsNullOrEmpty(objChangePassword.UserAccountPassword))
            {
                byte[] passwordInByteArray = Encoding.ASCII.GetBytes(objChangePassword.CurrentPassword);
                byte[] dbPassword = objUserAccount.Password;
                bool areEqual = passwordInByteArray.SequenceEqual(dbPassword);

                if (areEqual)
                {
                    ChangePassword objchange = new ChangePassword();
                    objchange.UserAccountUserName = objUserAccount.UserName;
                    objchange.UserID = objUserAccount.UserID;
                    objchange.UserAccountPassword = objChangePassword.UserAccountPassword;
                    objchange.UserAccountID = objChangePassword.UserAccountID;
                    db.ChangePassword(objchange);
                    return Ok();
                }
                else
                    return Json("MisMatch");
            }
            else
                return NotFound();
        }


    }
}
