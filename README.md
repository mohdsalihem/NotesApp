## Notes App

- A simple note-taking web app where users can sign up, log in, and manage their notes

- Integrated JSON Web Token-based authentication and implemented token refresh mechanism, stored in an HttpOnly cookie to enhance security

- Implemented repository design pattern to create an abstraction between the data access and business logic layers. Additionally, the unit of work design pattern to aggregate multiple database operations into a single transaction

- Technologies: ASP.NET Core Web API v8, Dapper, SqlKata, Autofac, AutoMapper, Angular v17, Tailwind CSS, SQLite

#### Screenshots

Login page
<img title="" src="./Screenshots/Login.png" alt="Login page">

Home page
<img title="" src="./Screenshots/Notes.png" alt="Home page">
