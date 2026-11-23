Feature: GoToWebPage

Go to the StackOverflow web page

Scenario: Open browser and go to the StackOverflow web page
	Given go to 'voebb.de'
	Then the page title contains "VÖBB"   