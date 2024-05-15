# Frontend
Check `STEM24-App/` folder

# Backend

## Requirements
To run the service you need .NET 6

## How to run
Build the project using
`dotnet build`

And run it with
`dotnet run --project STEM24-Api/STEM24/`

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

