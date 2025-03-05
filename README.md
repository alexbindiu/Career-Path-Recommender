# Career-Path-Recommender
Career Path Recommender is a full-stack application that uses AI models to helps people finding the skills needed for their desired job  and experience of choice.

Technologies used: C#,  .NET,  React,  JavaScript,  CSS,  Material UI,  Tailwind UI,  SQL Server

For any entered job and corresponding experience, it will display 3 lists:  must to have skills, nice to have ones, and some advanced skills.  
The application follows REST API principles to efficiently manage job skills requests. For each requested job, the system first checks if the relevant skills are already stored in the database. If they exist, the API retrieves and returns them. Otherwise, it makes a request to AI service, which will generate new skills using a provided access token. These new ones will be stored in the database, establishing relationships between jobs, experience, skills and usefulness.

The back-end follows Layered Architecture Pattern, adn the used technologies are C#, ASP.NET Core, EF Core.
For front-end I used React, Material UI, Tailwind UI, CSS and HTML.
