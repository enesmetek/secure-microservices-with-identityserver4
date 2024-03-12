# Securing Microservices with IdentityServer4

A practice project on how to secure microservices with using standalone Identity Server 4 and backing with Ocelot API Gateway.

## Architectural Pattern

![Uygulama Ekran Görüntüsü](https://miro.medium.com/v2/resize:fit:4800/format:webp/1*5AVZnAGgZe4QFFTMX-6z5Q.png)

### Movies.API
First of all, i developed Movies.API and protect this API resources with IdentityServer4 OAuth 2.0 implementation. Generated JWT Token with client_credentials from IdentityServer4 and will use this token for securing Movies.API protected resources.

### Movies.Client
After that, i developed Movies.Client MVC project for Interactive Client of our application. This Interactive Movies.Client application will be secured with OpenID Connect in IdentityServer4. Our client application pass credentials with logging to an Identity Server and receive back a JSON Web Token (JWT).

### IdentityServer
Also, i developed centralized standalone Authentication Server and Identity Provider with implementing IdentityServer4.
Identity Server4 is an open source framework which implements OpenId Connect and OAuth2 protocols for .NET Core.
With Identity Server, we can provide authentication and access control for our web applications or Web APIs from a single point between applications or on a user basis.

### Ocelot API Gateway
Lastly, i developed an Ocelot API Gateway and make secure protected API resources over the Ocelot API Gateway with transferring JWTs.
Once the client has a bearer token it will call the API endpoint which is fronted by Ocelot. Ocelot is working as a reverse proxy in here.

After Ocelot reroutes the request to the internal API, it will present the token to Identity Server in the authorization pipeline. If the client is authorized the request will be processed and a list of movies will be sent back to the client.



## Run Locally

#### Prerequisites
- .NET 8.0

#### Clone the project

```bash
  git clone https://github.com/enesmetek/secure-microservices-with-identityserver4.git
```

#### Change direction

```bash
  cd .\secure-microservices-with-identityserver4
```

#### Build the solution

```bash
  dotnet build SecureMicroservices.sln
```

#### Run the projects

```bash
  dotnet run SecureMicroservices.sln
```

  
## API Endpoints

#### Get All Movies

```http
  GET /api/movies
```
#### Get Movie

```http
  GET /api/movies/{id}
```

#### Create Movie
```http
  POST /api/movies
```
#### Update Movie

```http
  PUT /api/movies/{id}
```
#### Delete Movie

```http
  DELETE /api/movies/{id}
```
