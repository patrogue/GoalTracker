# Resources
https://medium.com/@edin.sahbaz/a-demo-on-clean-architecture-with-cqrs-and-repository-pattern-in-net-web-api-986838191e74
Looks into detail about repository pattern, MediatoR and CQRS pattern.

https://the-dotnet-weekly.ck.page/cqrs-v2
Implementation of CQRS

https://www.youtube.com/watch?v=RgqCavV2cqQ
Independent on EFCore

# Todo
NEED TO HAVE
Model database
Implement database
Create interfaces and repositories to get data from database
Add custom exceptions in repositories.
Setup test projects for unittest, integrationtest, uitests and end-to-end tests to test repositories.

NICE TO HAVE
Validate data using FluentValidator
Make sure dependency injections is utilized properly
Implement CQRS pattern
Implement proper Repository pattern
Added logging
Create entities to model database
Create project board in github and add tickets
Learn AWS
Deploy to AWS
Transactional Outbox Pattern
Domain Validation
Value Objects
Fluent Assertions
Unit of Work
Dapper
Materialized Views

# Useful Commands
dotnet new blazor -o (blazor project name)
dotnet new console -o (console project name)
dotnet new razorcomponent -n (component name) -o (component location -> Components/Pages)

dotnet run
dotnet build
dotnet test
dotnet watch

dotnet ef migrations add (migration name) --project .\GoalTracker.Infrastructure\ --startup-project .\GoalTracker.Presentation\
dotnet ef database update --project .\GoalTracker.Infrastructure\ --startup-project .\GoalTracker.Presentation\