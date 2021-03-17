Feature: ZoomFunctions

@UseWebDriver
Scenario: I increase the zoom of a document
	Given I open the index page
	And I give the page time to load
	And I click the zoom increase button
	Then the document will increase in size

@UseWebDriver
Scenario: I decrease the zoom of a document
	Given I open the index page
	And I give the page time to load
	And I click the zoom decrease button
	Then the document will decrease in size