using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SimpleFacebookLogin.Models;
using SimpleFacebookLogin.ViewModels;

namespace SimpleFacebookLogin.Controllers
{
  [Route("api/[controller]/[action]")]
  public class ExternalAuthController : Controller
  {
    private readonly string _facebookAppAccessTokenUrl =
      "https://graph.facebook.com/oauth/access_token?client_id={0}&client_secret={1}&grant_type=client_credentials";

    private readonly string _facebookUserUrl =
      "https://graph.facebook.com/v2.9/me?fields=id,email,first_name,last_name,name,gender,locale,birthday,picture&access_token={0}";

    private readonly string _facebookAccessTokenValidationUrl =
      "https://graph.facebook.com/debug_token?input_token={0}&access_token={1}";

    private readonly FacebookAuthSettings _fbAuthSettings;

    private static readonly HttpClient Client = new HttpClient();

    public ExternalAuthController(FacebookAuthSettings fbAuthSettings)
    {
      _fbAuthSettings = fbAuthSettings;
    }

    // POST api/externalauth/facebook
    [HttpPost]
    public async Task<IActionResult> Facebook([FromBody] FacebookAuthViewModel model)
    {
      // 1.generate an app access token
      var appAccessTokenResponse = await Client.GetStringAsync(
        string.Format(_facebookAppAccessTokenUrl, _fbAuthSettings.AppId, _fbAuthSettings.AppSecret));
      var appAccessToken = JsonConvert.DeserializeObject<FacebookAppAccessToken>(appAccessTokenResponse);
      // 2. validate the user access token
      var userAccessTokenValidationResponse = await Client.GetStringAsync(
        string.Format(_facebookAccessTokenValidationUrl, model.AccessToken, appAccessToken.AccessToken));
      var userAccessTokenValidation =
        JsonConvert.DeserializeObject<FacebookUserAccessTokenValidation>(userAccessTokenValidationResponse);

      if (!userAccessTokenValidation.Data.IsValid)
      {
        return BadRequest(new {Error = "Invalid facebook token."});
      }

      // 3. we've got a valid token so we can request user data from fb
      var userInfoResponse = await Client.GetStringAsync(
        string.Format(_facebookUserUrl, model.AccessToken));
      var userInfo = JsonConvert.DeserializeObject<FacebookUserData>(userInfoResponse);

      // 4. plug in below:
      // Find user in database
      // If no user exists, add user to database
      // Create new access token for logged in user

      // 5. change this to return created access token
      return Ok(userInfo);
    }
  }
}