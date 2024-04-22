#!/usr/bin/bash

docker run -it --network=asp.chat.network -v .:/App -w /App mcr.microsoft.com/dotnet/sdk:7.0 /bin/bash
