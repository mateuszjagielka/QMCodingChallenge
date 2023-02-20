Feature: QualityMinds Code Challenge Tests


Scenario: Test case 1
	Given QualityMinds main page is opened
	When I hover over Language menu
	And I select German language
	Then QualityMinds main page is opened in German
	And current URL is https://qualityminds.com/de/
	When I hover over Portfolio menu
	#And I click [string] button


Scenario: Test case 3
	Given QualityMinds job offers page is opened
	#Then at least one job offer is available
	#When I click [string] button