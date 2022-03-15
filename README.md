# Interest Rate API

This API has only one endpoint that returns a fixed interest rate defined in the source code. The value returned here is used by the FutureValueApi to calculate the future value of an amount of money.

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

The table below shows the main files in the project

|File|Namespace|Comment|
| ------ | ------ | ----- |
|InterestRateModel|Osm.InterestRate.Domain.Models|A model class that stores the interest rate value|
|InterestRateService|Osm.InterestRate.Domain.Services|A service which uses a repositry to retrieve an intereste rate model|
|InterestRateRepository|Osm.InterestRate.Data.Repositories|Currently this repository return a fixed interest rate, but it can be changed any time to get data from a database or from an enviroment variables|
|InterestRateController|Osm.InterestRate.Api.Controllers|A controller which exposes the service to the external world. It validate the return of InterestRateService and return a Internal Server Error. Otherwise, it will return 200 status code|

### Endpoints

The API has only one endpoint called "/TaxaJuros". It return the interest rate value whitin a JSON.

#### Request

`GET /TaxaJuros`

    curl -X 'GET' https://localhost:5001/TaxaJuros -H 'accept: application/json'

#### Response

    HTTP/1.1 200 OK
    Date: Thu, 15 Mar 2022 12:36:30 GMT
    Status: 200 OK
    Content-Type: application/json; charset=utf-8

    {
		"value":0.01
	}
