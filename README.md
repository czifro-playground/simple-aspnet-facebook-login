# simple-aspnet-facebook-login
Simple ASP.NET Web API illustrating Facebook Login

## Description

This project is adapted from [JWT Authentication with ASP.NET Core 2 Web API, Angular 5, .NET Core Identity and Facebook Login](https://fullstackmark.com/post/13/jwt-authentication-with-aspnet-core-2-web-api-angular-5-net-core-identity-and-facebook-login). This project focuses on the subsection of the article, "Generating JWT tokens for authenticated Facebook users". There are 4 steps, the first 3 steps are taken care of and the 4th step is left to be integrated with your solution (with a 5th step that is to change the return value).

## Run As Is

(Disclaimer: .NET Core 2.0 is required)

The project is in a working state. There is a single API endpoint, `/api/externalauth/facebook`. There are two options to run the code at its working state: run from source or use docker.

To run from source:

1. clone repo
2. `cd <repo>`
3. `sh run.sh <facebook-appid> <facebook-appsecret>`

To run using docker:

1. `docker run -ti -p 5000:5000 -e FACEBOOK_APPID=<facebook-appid> FACEBOOK_APPSECRET=<facebook-appsecret> czifro/simple-aspnet-facebook-login:1.0.0 /bin/sh -c "dotnet run"`

You need to provide a Facebook AppId and AppSecret to connect to facebook.