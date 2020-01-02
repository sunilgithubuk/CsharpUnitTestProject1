Feature: ProductSearch

Scenario: user is able to search a product
Given user is logged in 
When search for a product
Then result page displayed the searched product