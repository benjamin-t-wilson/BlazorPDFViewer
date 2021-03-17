Feature: Change Page

@UseWebDriver
Scenario: I want to see the next page
	Given I open the index page
	And I give the page time to load
	And I click the next page button
	Then the page number will increase to 2

@UseWebDriver
Scenario: I want to move to a specific page
	Given I open the index page
	And I give the page time to load
	And I click the thumbnail for page 3
	Then the page number will reflect 3