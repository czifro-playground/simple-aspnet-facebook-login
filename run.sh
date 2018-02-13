#!/bin/sh

export FACEBOOK_APPID=$1
export FACEBOOK_APPSECRET=$2

dotnet restore

cd SimpleFacebookLogin/

dotnet run