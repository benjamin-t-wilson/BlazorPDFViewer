Feature: Loading modal

@UseWebDriver
Scenario: Loading modal displays before document loads
	Given I open the index page
	Then A loading modal shows while I wait

@UseWebDriver
Scenario: Loading modal disappears when pdf is loaded
	Given I open the index page
	And I give the page time to load
	Then the loading modal will be gone
	And the pdf window will be present