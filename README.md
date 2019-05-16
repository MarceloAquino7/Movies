# 3rd Party Nuget Packages
Autofac
AutoMapper
FluentAssertiong
FluentMigrator
EFCore
NUnit
Selenium
Swagger (Swashbuckle)
Development Tools
Visual Studio (2017) or Visual Studio Code
MSSQL Server Management Studio 17
Swagger Editor
NodeJs + npm
Chrome
GIT


# 0 - Core
Hvp.Common.Cqrs.Core is a basic set of interfaces for building a command and event driven CQRS application.

Commands are created and dispatched by the application,
They are received by command handlers which apply behaviors on the domain model
Which generates events
Collected by the command handler
Then published
Received by event handlers which update the read/query model
Consumed by the front end of the application via query services.

# 1 - Domain
Domain commands and handlers specifically affect the domain model's aggregate roots.

Some of the basic premises of CQRS are modeled by these interfaces either explicitly or in their documentation.

Commands and events should be immutable
The query model should be immutable, except from the event handlers responsible for updating them when triggered by events published from domain model changes
Domain commands and handlers should only affect a single aggregate root instance in the domain model - more complex operations should be handled by sagas

# 2 - Application Service
This project will expose domain features to external world (e.g.: apis, apps, windows services, desktop apps) and it is responsible for business rules as well.

# 3 - Infrastructure
This project contains implementations of the interfaces defined in the inner layers of the solution. They may be dependent on external libraries or resources. Note that the implementations themselves are internal and should only be used for injection via their implemented interfaces.

# 4 - Entry Points
API project.
Front end project using Angular 6

# 5 - Tests
DomainTest: NUnit will test ApplicationService classes with no external dependencies. All Infrastructure dependencies must be mocked.

IntegrationTests:Longer running, more involved tests that test the integration of multiple components and external dependencies as Database/Email.

You shouldn't find:

Binaries committed to source control.
Unnecessary project or library references or third party frameworks.
Many "try" blocks - code defensively and throw exceptions if something is wrong.