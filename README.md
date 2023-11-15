# CHAT Aspnet Core

### Overview
This is a simple chat using signalr by aspnet core implementation.
What is important to tell is that it's code is a just example to make something same
a broadcasting messages using csharp/Dotnet Core.

### How to run?

You must to restore this app and run a command docker-compose,
so after it i'll must to migrate the tables for database host

Step 0:

    dotnet restore

Step 1:

    docker-compose build

Step 2:

    docker-compose up -d

Step 3:

    dotnet dotnet-ef database update


the application will be running in host `` http://localhost:8080/``
