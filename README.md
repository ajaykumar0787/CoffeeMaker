# Coffee Maker Api

A simple Api in .Net core 3.1 for brewing coffee. 
The application has 2 endpoints
* api/brew-coffee - Brews your coffee with some surprises
* ping - check if your coffee brewer is alive

## How to run

* Clone or download the repo to your system
* Build to restore Nuget Package(s)
* Run with IIS express of self host
* The default page will be the index page and that exposes the Api documentation and the test of Api itself using Swagger
* https://localhost:5001/index.html is the default home page
* CoffeeMakerApi.Tests - Contains the unit tests and can be run via test explorer

## About the Api structure and though process

* The different entities of concern are separated using different folders
* All the services have contracts that can be injected
* Throwing of 503 error is handled in middleware itself without having the need to go to the end point but still leverages a service as that is where the business logic sits

## What more can we do

* Ideally, the services and contracts should be different projects in a large scale project
* We could use Memory cache if the 5th call is sort of a throttling/ request limiting and we could use the client ip to return 503 to that particular ip
* Logging should be done and we could use some log aggregator to inspect logs
* configurations for different environments can be hosted