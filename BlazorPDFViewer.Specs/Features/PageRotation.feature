Feature: PageRotation

@UseWebDriver
Scenario: I rotate the page
	Given I open the index page
	And I give the page time to load
	And I click the rotate button
	Then the page will have rotated 90 degrees