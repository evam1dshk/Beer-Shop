# MyBeerShop

MyBeerShop is an online beer shop application designed to provide a seamless shopping experience for beer enthusiasts. It allows customers to browse, order, and track their favorite beers from a diverse selection.

## Table of Contents

- [Features](#features)
- [Technologies Used](#technologies-used)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
- [Usage](#usage)
- [Development](#development)
- [Contributing](#contributing)
- [License](#license)
- [Contact](#contact)

## Features

- User registration and authentication
- Browse beers by categories
- Shopping cart and checkout
- Order tracking
- Admin panel for managing orders and products
- Custom error pages
- Responsive design

## Technologies Used

- ASP.NET Core
- Entity Framework Core
- Microsoft SQL Server
- Bootstrap
- JavaScript (optional for additional features)

## Getting Started

### Prerequisites

Ensure you have the following installed on your local machine:

- [.NET 5.0 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Visual Studio 2019](https://visualstudio.microsoft.com/vs/) or [Visual Studio Code](https://code.visualstudio.com/)

### Installation

1. **Clone the repository:**

    ```bash
    git clone https://github.com/evam1dshk/Beer-Shop
    cd MyBeerShop
    ```

2. **Set up the database:**

    - Update the connection string in `appsettings.json` to point to your SQL Server instance.
    - Apply migrations to set up the database schema:

    ```bash
    dotnet ef database update
    ```

3. **Build the project:**

    ```bash
    dotnet build
    ```

## Usage

1. **Run the application:**

    ```bash
    dotnet run
    ```

2. **Open your browser and navigate to:**

    ```
    https://localhost:7141
    ```

3. **Explore the application:**

    - Register a new user or log in with an existing account.
    - Browse the beer selection, add items to the cart, and proceed to checkout.
    - Admin users can log in to access the admin panel for managing orders and products.

## Development

### Project Structure

- `MyBeerShop/`: The main project directory.
- `MyBeerShop.Data/`: Contains the data models and Entity Framework context.
- `MyBeerShop.Services/`: Contains the service layer for business logic.
- `MyBeerShop.Controllers/`: Contains the MVC controllers.
- `MyBeerShop.Views/`: Contains the Razor views.

### Adding a New Feature

1. **Create a new branch:**

    ```bash
    git checkout -b feature/your-feature-name
    ```

2. **Implement your feature:**

    - Add necessary models, services, controllers, and views.

3. **Commit your changes:**

    ```bash
    git commit -am "Add your feature description"
    ```

4. **Push to the branch:**

    ```bash
    git push origin feature/your-feature-name
    ```

5. **Create a pull request:**

    - Go to the repository on GitHub and create a pull request.

## Contributing

We welcome contributions! Please read our [Contributing Guide](CONTRIBUTING.md) for details on our code of conduct and the process for submitting pull requests.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contact

- **Email:** [info@yourbeershop.com](mailto:info@yourbeershop.com)
- **Phone:** +1 (234) 567-890
- **Address:** 123 Main Street, City, Country

Thank you for using MyBeerShop!
