# GatewayApi
General Orientations
The App is an api with a complete CRUD of Gateways and only the functions Add and Remove of Device.

Project template: ASP.NET Core Web Api
Target: net 8
Dependencies:
	Microsoft.EntityFrameworkCore 8.0.8
	Microsoft.EntityFrameworkCore.SqlServer 8.0.8
	Microsoft.EntityFrameworkCore.Tools 8.0.8
	Swashbuckle.AspNetCore 6.8.0

1. Set the ConnectionString in appsetting to your server.
2. Restore database from "GatewayBackUp", it has some data, or you can run update-database from nuget console and provide your own data.
3. Import "GatewayApi.postman_collection" to Postman and Test.
4. If it is necesary to change the url of the application, remember to change it in the postman collection urlbase variable.

Current url: https://localhost:7104
