#!/bin/sh

docker run -ti -p 5000:5000 -e FACEBOOK_APPID=$1 \
  -e FACEBOOK_APPSECRET=$2 \
  czifro/simple-aspnet-facebook-login:1.0.0 \
  /bin/sh -c "dotnet run"