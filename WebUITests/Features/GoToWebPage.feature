Feature: GoToWebPage

Go to the VÖBB web page

Scenario: Open browser and go to the VÖBB web page and click button
	Given go to 'voebb.de'
	Then the page title contains "Startseite - Verbund der Öffentlichen Bibliotheken Berlins"
	Then click the button "Digitale Angebote"
	And the page title contains "Die Digitalen Angebote des VÖBB - Verbund der Öffentlichen Bibliotheken Berlins"