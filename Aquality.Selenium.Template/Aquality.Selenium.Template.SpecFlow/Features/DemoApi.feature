@API @demo
Feature: Demo API

Scenario: GET user info
	When I send GET '/users/aqualityAutomation' request to github and save the 'response'
	Then the status code of the 'response' is '200'
