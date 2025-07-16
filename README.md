# A web app using MVC to book a taxi
A web app inspired by uber that stores vehicle data in the db. User enters their location and the nearest vehicle to user's location is displayed on the map.

Steps for running:
1. Clone repository and add an appsettings.json similar to below
   
{
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=drivers.db"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "ApiKeys": {
    "GoogleMaps": "YOURAPIKEY"
  }
}

TODO:
1. Add authentication 
2. Add a booked trips history

# Quick demo of the app 


https://github.com/user-attachments/assets/97e7fad6-123c-463f-9d0d-d1dbdc2a629a

