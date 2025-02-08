# Securing Microservices with IdentityServer4

A practical project demonstrating how to secure microservices using a standalone **IdentityServer4** for authentication and authorization, backed by **Ocelot API Gateway**.

## 📌 Architectural Overview
This project follows a **microservices architecture** secured with **OAuth 2.0** and **OpenID Connect** using IdentityServer4. The key components of the system include:

- **Movies.API** – A protected microservice that serves movie data.
- **Movies.Client** – An interactive MVC client secured with OpenID Connect.
- **IdentityServer** – A standalone authentication and authorization provider.
- **Ocelot API Gateway** – A reverse proxy that securely routes requests.

---

## 🏗️ Project Components

### 🎬 Movies.API
The **Movies.API** is a microservice that serves movie-related resources. It is protected using **IdentityServer4 OAuth 2.0** implementation. A **JWT token** is generated using the **client credentials flow** from IdentityServer4, which is then required for accessing protected resources in Movies.API.

### 🎭 Movies.Client
The **Movies.Client** is an **MVC-based interactive client** application. It is secured using **OpenID Connect**, ensuring user authentication through IdentityServer4. The client logs in to the Identity Server and receives a **JWT (JSON Web Token)** for subsequent requests.

### 🔐 IdentityServer
The **IdentityServer** is a **standalone authentication server** implementing **OpenID Connect and OAuth2** for .NET applications. It serves as a centralized identity provider, managing authentication and access control for web applications and APIs.

### 🛡️ Ocelot API Gateway
The **Ocelot API Gateway** acts as a **reverse proxy** that routes requests to internal microservices securely. JWTs are transferred through the gateway, ensuring only authenticated requests are forwarded to **Movies.API**. If the token is valid, the request is processed, and the movie data is returned to the client.

---

## 🚀 Running the Project Locally

### 📌 Prerequisites
- **.NET 8.0** installed on your system.

### 🔧 Setup Instructions
1. Clone the repository:
   ```sh
   git clone https://github.com/enesmetek/secure-microservices-with-identityserver4.git
   ```
2. Navigate into the project directory:
   ```sh
   cd secure-microservices-with-identityserver4
   ```
3. Build the solution:
   ```sh
   dotnet build SecureMicroservices.sln
   ```
4. Run the application:
   ```sh
   dotnet run SecureMicroservices.sln
   ```

---

## 📡 API Endpoints
Below are the available endpoints in **Movies.API**:

| HTTP Method | Endpoint                 | Description           |
|------------|-------------------------|-----------------------|
| `GET`      | `/api/movies`            | Get all movies       |
| `GET`      | `/api/movies/{id}`       | Get a specific movie |
| `POST`     | `/api/movies`            | Create a new movie  |
| `PUT`      | `/api/movies/{id}`       | Update an existing movie |
| `DELETE`   | `/api/movies/{id}`       | Delete a movie       |

---

## 📜 License
This project is licensed under the **MIT License**.

---

## 🤝 Contributing
Contributions are welcome! Feel free to submit a pull request or open an issue.

---

## 📧 Contact
For any questions or issues, please reach out via GitHub Issues or email me at **[your email]**.

---

### 📢 Star the Repository ⭐
If you found this project useful, consider giving it a star on GitHub! 😊

