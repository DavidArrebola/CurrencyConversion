# Running the project

## With Docker

If you have docker on your computer simply run `docker-compose up` in the root of the project and it will build both the client and server. Then navigate to http://localhost:3000 to see the user interface and begin testing.

## Without Docker

### Running the Client

To run the client, follow these steps:

1. Install dependencies: `npm install`

2. Build the project: `npm run build`

3. Start the application: `npm run start`

Then, either click on a link in the terminal to open or go to [http://localhost:3000](http://localhost:3000).

### Running the Server

To run the server, simply start the server in Visual Studio or Rider, and it should start both HTTP and HTTPS instances. For testing and running locally, the port is configured to the HTTP port from the front end.

# Validation

There is validation both on the front end and the back end. To make sure correct numbers get passed to the server. The bounds that I've set for this tests are +/- 999,999,999,999.99. You can only have 2 decimal places as well.

# Design Patterns and Decisions

The Project is implemented using a MVC design pattern. I have also used mediatr to give the option to scale the project using CQRS. Domains have been broken up and seperation of concerns has been honoured throughout the project. I split the project up in this way to give an idea of how I'd allow for scalability and reliability of a project moving forward. If this was to be a big project and this was starting block, I would instead opt to follow clean architecture princples and split the server into layers (Presentation, Persistence, Application and Domain) to make it easier for any devs that follow to "fall into a pit of success" where everything is already defined where it should be so it would simply be implementing any new business logic in the patterns provided.

The front end is architected for modularity, reusability and composability. Declarative naming used for component and hook names. Any business logic was encapsulated in a custom hook, sorted by domain.

# Tests

The service and validation in the backend is covered with XUnit tests. You will find these test cases in the server.test project.
