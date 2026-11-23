# WebClientUItests
Automated Frontend Testing Framework
Automated UI Testing with C#, .NET, Reqnroll & Playwright

Project Overview
- This project provides an automated testing framework for frontend components, leveraging C#, .NET, Reqnroll, and Playwright. It enables robust, maintainable, and scalable UI testing using Behavior-Driven Development (BDD) principles and the Page Object Model (POM) design pattern.

Features
- End-to-End UI Testing: Automates user interactions and validates frontend behavior.
- Behavior-Driven Development: Write tests in human-readable Gherkin syntax via Reqnroll.
- Page Object Model: Promotes maintainability and reusability of test code.
- Cross-Browser Support: Powered by Playwright for reliable testing across browsers.
- Integration Ready: Can be incorporated into CI/CD pipelines for continuous testing.

Requirements
- .NET 6.0 SDK or higher
- Node.js (for Playwright)
- Reqnroll
- Playwright

Project Structure
- Features/: Gherkin feature files describing test scenarios.
- Pages/: Page Object Model classes for UI elements and actions.
- Steps/: Step definitions mapping Gherkin steps to code.
- Drivers/: Playwright driver setup and configuration.
- Utils/: Utility classes and helpers.

How to Run Tests
Execute all tests:
- Configure test runs or target specific browsers via configuration files as needed.
Writing Tests
- Define scenarios in .feature files using Gherkin syntax:

Example </br>
<em> Feature: Login </br>

  Scenario: Successful login with valid credentials </br>
    Given I am on the login page </br>
    When I login with valid credentials </br>
    Then I should see the dashboard </em> </br>
Implement step definitions in C# under the Steps/ directory. </br>

Best Practices
- Use the Page Object Model for all UI interactions.
- Write clear, concise Gherkin scenarios for maintainability.
- Integrate with a version control system (e.g., Git) for collaborative development and test asset management.
- Consider continuous integration for automated test execution on code changes.

Author
- Sophie König
- nora.sophie.koenig@gmail.com
