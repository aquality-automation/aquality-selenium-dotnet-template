@API @demo
Feature: Demo API

Scenario: GET user info
	When I send GET '/users/aqualityAutomation' request to github and save the 'response'
	Then the status code of the 'response' is '200'
        And the 'response' matches json schema 'Users/UserResponse'

Scenario: GET users info
    When I send GET '/users' request to github and save the 'users response'
    Then the status code of the 'users response' is '200'
        And the 'users response' matches json schema 'Users/UsersResponse'
