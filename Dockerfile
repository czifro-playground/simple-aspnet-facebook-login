FROM microsoft/dotnet:2.0-sdk
COPY . /var/aspnet/SimpleAspNetFacebookLogin

WORKDIR /var/aspnet/SimpleAspNetFacebookLogin/SimpleFacebookLogin

RUN dotnet restore