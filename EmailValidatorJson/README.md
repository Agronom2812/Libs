# Email Parser Library

A C# library for parsing email addresses from JSON files, validating them, and providing formatted output.

## Features

- Parse email addresses from JSON files.
- Validate email addresses based on standard formats.
- Output results in a user-friendly format.

## Usage Instructions

After cloning the repository, follow these steps to use the Email Parser Library in your project:

### Prerequisites

Make sure you have the following installed:

- [.NET SDK](https://dotnet.microsoft.com/download) (version 8.0 or later)
- A code editor or IDE (such as Visual Studio, Visual Studio Code, or JetBrains Rider)

### Cloning the Repository

1. Open your terminal.
2. Clone the repository using the following command:
   ```bash
   git clone https://github.com/Agronom2812/Libs/tree/EmailValidatorJsonLibrary/EmailValidatorJson
   ```
3. Navigate to the project directory:
   ```bash
   cd EmailValidatorJson
   ```

### Building the Project

1. Restore the project dependencies:
   ```bash
   dotnet restore
   ```
2. Build the Project
   ```bash
   dotnet build
   ```

### Using the Library in Your Project

To use the Email Parser Library in your own project:

1. Create a new project or open an existing one.
2. Add a reference to the Email Parser Library:
   
   - If you cloned the library, you can add a project reference:
     ```bash
     dotnet add reference ../EmailParserLibrary/EmailParserLibrary.csproj
     ```
4. Write code to utilize the library. You can use the example from:
   ```bash
   https://github.com/Agronom2812/Libs/tree/EmailValidatorJsonLibrary/EmailValidatorJson/example
   ```

### JSON File Format

Ensure your JSON file (emails.json) is structured as follows:
  ```bash
  {
      "emails": [
          "example1@example.com",
          "example2@example.com",
          "invalid-email"
      ]
  }
```

## Contributing

You can submit a pull request or open an issue for any improvements or bug fixes.

1. Fork the repository.
2. Create your feature branch:
   ```bash
   git checkout -b feature/YourFeature
   ```
3. Commit your changes:
   ```bash
   git commit -m "Add some feature"
   ```
4. Push to the branch:
   ```bash
   git push origin feature/YourFeature
   ```
5. Open a pull request.

## Contact

For any inquiries or suggestions, please contact:

- Yury Zheludovich - iopawelyd@gmail.com
- GitHub: Agronom2812

