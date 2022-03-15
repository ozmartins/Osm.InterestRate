# Interest Rate API

This simple API has only one endpoint that returns a fixed interest rate defined in the source code. The value returned here is used by the FutureValueApi to calculate the future value of an amount of money.

The project has three layers: Data, Domain, and API. The Data layer has just one repository that returns a fixed interest rate. I am using a repository here to make it easy to start using a database instead of the fixed interest rate value (if we want to). 

The Domain layer contains a model for interest rate and a service which consumes the repository. Finally, the API layer just exposes the service to the external world through a controller.

## Outline

 - [Libraries](#libraries)
 - [Running locally](#running-locally)
 - [Quick Reference](#quick-reference)

## Libraries

This project is using some libraries and frameworks:

 - [.NET 5.0](https://dotnet.microsoft.com/en-us/download/dotnet/5.0)
 - [Docker](https://docs.docker.com/)
 - [MSTest](https://docs.microsoft.com/en-us/dotnet/api/microsoft.visualstudio.testtools.unittesting?view=visualstudiosdk-2022)
 - [Swagger](https://swagger.io/)

## Running locally

First, clone the project to your local machine using the following command:

```
git clone https://github.com/ozmartins/Osm.InterestRate.git
```

Then, to enter into the project directory, type into the terminal:

```
cd Osm.InterestRate\Osm.InterestRate.Api
```
Finally, run the app using the command shown below:

```
dotnet run --project Osm.InterestRate.Api.csproj
```

Now, the is running and you can try it accessing the URL https://localhost:5001

## Quick Reference

### Key files

Key files to edit:

  - "app/api/endpoints/*" - Adding endpoints and APIs
  - "db/migrate" - Defining the model attributes in the database
  - "app/models" - Defining any additional model information
  - "test/api"   - Defining tests for your APIs (if needed)

### Key URLs

Few URLs to note (once rails server is running):

  - "/api/sessions" - Simple endpoint that returns text
  - "/rails/routes" - See a list of common rails routes
  - "/users/sign_in" - Login (or register) a user
  - "/admin" - Admin panel for viewing database content

### Request Methods

As a rule of thumb, the request method to pick is as follows:

|Method|Description|Example|
| ------ | ------ | ----- |
|get|For returning resources from read-only endpoint|Get user tweets|
|post|For creating new resources|Create new tweet|
|put|For updating an existing resource|Editing a user's password|
|delete|For deleting a resource|Trashing a tweet|


### Response Status Codes

Another thing to notice is API response `status` codes, as a rule of thumb:

|Status|Description|Example|
| ------ | ------ | ----- |
|200|Success|Retrieved list of user tweets|
|201|Created|Create new tweet|
|400|Bad request|Invalid email for registration|
|401|Unauthorized|No permission or not logged in|
|500|Error|Exception happened on server|
