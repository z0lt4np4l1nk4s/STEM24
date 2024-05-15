# Frontend

Check `STEM24-App/` folder

# Backend

## Requirements

To run the service you need .NET 8

## How to run

Build the project using
`dotnet build`

And run it with
`dotnet run --project STEM24-Api/STEM24/`

The backend is finished with all the necesarry methods for Events and Comments
Its is well documented and structured
Backend was designed as a multilayer arhitecture app, so that the whole code is separated into smaller class libraries
For the database we were using PostgreSQL
We used EntityFramework to connect with the database and Microsofts built in Identity Framework for user authentication
The API has a swagger where all the endpoints are displayed so that the frontend can easily check out what they need to pass
work the backend method and what they will get in return

# Shift left security

For our shift left security we used 2 tools

- ESLint
- Snyk

We utilized those tools with GitHub workflows and CodeQL

The lint workflow does a couple of things

- it installs the Angular cli npm package
- installs the ESLint sarif formatter
- lints into a sarif file
- uploads sarif file to CodeQL

![Lint workflow](https://github.com/z0lt4np4l1nk4s/STEM24/blob/readme/screenshots/Slika%20zaslona%202024-05-15%20u%2021.21.55.png?raw=true)

The snyk workflow also does a couple of things

- it setups Snyk
- it authenticates Snyk
- runs snyk code test (which checks flaws in code suck as embedded secrets)
- runs snyk test (checks dependencies)
- uploads sarif files to CodeQL

![Snyk workflow](https://github.com/z0lt4np4l1nk4s/STEM24/blob/readme/screenshots/Slika%20zaslona%202024-05-15%20u%2021.23.49.png?raw=true)

It's worth noting that the snyk workflow runs every Sunday because new vulnerabilities could be found in existing packages.

All of the vulnerabilities end up in the security tab, under code scanning.

![Code scanning](https://github.com/z0lt4np4l1nk4s/STEM24/blob/readme/screenshots/Slika%20zaslona%202024-05-15%20u%2021.25.06.png?raw=true)
