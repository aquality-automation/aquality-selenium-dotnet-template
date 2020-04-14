# Aquality Selenium Template Project
Template for [aquality-selenium-dotnet](https://github.com/aquality-automation/aquality-selenium-dotnet) library.

### Project structure
- **Aquality.Selenium.Template** - project related part with PageObjects, models and utilities
  - **Configuration/**: classes that used to fetch project config from [Resources/Environment](https://github.com/aquality-automation/aquality-selenium-dotnet-template/blob/master/Aquality.Selenium.Template/Aquality.Selenium.Template/Resources/Environment) folder
  - **Forms/**: Page Objects
  - **Models/**: classes that represent data models of the application under the test (POJO classes) 
  - **Utilities/**: util classes
  - **Resources/**: resource files such as configurations and test data
- **Aquality.Selenium.Template.SpecFlow** - SpecFlow implementation of the tests
  - **Features/**: Gherkin feature files with test scenarios
  - **Hooks/**: SpecFlow [hooks](https://specflow.org/documentation/Hooks/)
  - **StepDefinitions/**: step definition classes
  - **Transformations/**: SpecFlow [data transformations](https://specflow.org/documentation/Step-Argument-Transformations/)

### Configuration
[settings.json](https://github.com/aquality-automation/aquality-selenium-dotnet-template/blob/master/Aquality.Selenium.Template/Aquality.Selenium.Template/Resources/settings.json) file contains settings of Aquality Selenium library. Additional information you can find [here](https://github.com/aquality-automation/aquality-selenium-dotnet/wiki/Overview-(English)).

### Tests execution
Scenarios from feature files can be executed with IDE
or with .NET Core CLI [```dotnet test```](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-test) where you can specify all necessary arguments.

### License
Library's source code is made available under the [Apache 2.0 license](https://github.com/aquality-automation/aquality-selenium-dotnet-template/blob/master/LICENSE).