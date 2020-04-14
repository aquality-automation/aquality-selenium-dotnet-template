[![Build Status](https://dev.azure.com/aquality-automation/aquality-automation/_apis/build/status/aquality-automation.aquality-selenium-dotnet-template?branchName=master)](https://dev.azure.com/aquality-automation/aquality-automation/_build/latest?definitionId=10&branchName=master)
[![Quality Gate](https://sonarcloud.io/api/project_badges/measure?project=aquality-automation_aquality-selenium-dotnet-template&metric=alert_status)](https://sonarcloud.io/dashboard?id=aquality-automation_aquality-selenium-dotnet-template)

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

[allureConfig.json](https://github.com/aquality-automation/aquality-selenium-dotnet-template/blob/master/Aquality.Selenium.Template/Aquality.Selenium.Template.SpecFlow/allureConfig.json) is a part of Allure Report configuration. See details [here](https://github.com/allure-framework/allure-csharp#configuration).

### Tests execution
Scenarios from feature files can be executed with IDE
or with .NET Core CLI [```dotnet test```](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-test) where you can specify all necessary arguments.

### Reporting 
Allure Framework is used as a reporting tool. Report data will be places in ```{Environment.CurrentDirectory}/allure-results/``` folder (you can change it in ```allureConfig.json``` file).

Run [allure CLI](https://docs.qameta.io/allure/#_commandline) command ```allure serve "{path_to_allure_results_directory}"``` to build and open report in web browser. To generate report in CI use corresponding plugin for your system.


### License
Library's source code is made available under the [Apache 2.0 license](https://github.com/aquality-automation/aquality-selenium-dotnet-template/blob/master/LICENSE).