# Library App

## Description

Library App is a sample console-based library management system. It allows users to search for patrons, view patron details, manage book loans, and renew memberships. The application uses JSON files for data storage and demonstrates clean separation of concerns using repositories, services, dependency injection etc.

## Project Structure

- `AccelerateDevGitHubCopilot.sln`
- `README.md`
- src/
    - Library.ApplicationCore/
        - `Library.ApplicationCore.csproj`
        - Entities/
            - `Author.cs`
            - `Book.cs`
            - `BookItem.cs`
            - `Loan.cs`
            - `Patron.cs`
        - Enums/
            - `EnumHelper.cs`
            - `LoanExtensionStatus.cs`
            - `LoanReturnStatus.cs`
            - `MembershipRenewalStatus.cs`
        - Interfaces/
            - `ILoanRepository.cs`
            - `ILoanService.cs`
            - `IPatronRepository.cs`
            - `IPatronService.cs`
        - Services/
            - `LoanService.cs`
            - `PatronService.cs`
    - Library.Console/
        - `appSettings.json`
        - `CommonActions.cs`
        - `ConsoleApp.cs`
        - `ConsoleState.cs`
        - `Library.Console.csproj`
        - `Program.cs`
        - Json/
            - `Authors.json`
            - `BookItems.json`
            - `Books.json`
            - `Loans.json`
            - `Patrons.json`
    - Library.Infrastructure/
        - `Library.Infrastructure.csproj`
        - Data/
            - `JsonData.cs`
            - `JsonLoanRepository.cs`
            - `JsonPatronRepository.cs`
- tests/
    - UnitTests/
        - `UnitTests.csproj`
        - `LoanFactory.cs`
        - `PatronFactory.cs`
        - ApplicationCore/
            - LoanService/
                - `ExtendLoan.cs`
                - `ReturnLoan.cs`
            - PatronService/
                - `RenewMembership.cs`

## Key Classes and Interfaces

- **Entities**
    - `Author`, `Book`, `BookItem`, `Loan`, `Patron`: Core domain models.
- **Enums**
    - `LoanExtensionStatus`, `LoanReturnStatus`, `MembershipRenewalStatus`: Status enums for operations.
    - `EnumHelper`: Utility for enum descriptions.
- **Interfaces**
    - `IPatronRepository`: Patron data access contract.
    - `ILoanRepository`: Loan data access contract.
    - `IPatronService`: Patron business logic contract.
    - `ILoanService`: Loan business logic contract.
- **Services**
    - `PatronService`: Handles patron membership renewal.
    - `LoanService`: Handles loan extension and return.
- **Infrastructure**
    - `JsonData`: Loads and saves JSON data.
    - `JsonPatronRepository`: Implements patron repository.
    - `JsonLoanRepository`: Implements loan repository.
- **Console**
    - `ConsoleApp`: Main interactive application.
    - `Program`: Application entry point and DI setup.

## Usage

1. Build the solution using Visual Studio or `dotnet build`.
2. Run the console application:
    ```sh
    dotnet run --project src/Library.Console/Library.Console.csproj
    ```
3. Follow the prompts in the console to search for patrons, view details, manage loans, and renew memberships.

## License

This project is licensed under the MIT License. See LICENSE for details.