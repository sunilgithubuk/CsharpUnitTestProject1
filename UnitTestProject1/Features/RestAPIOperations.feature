Feature: RestAPIOperations

Scenario: verify post and get operation
Given panda oath credentials are available
When  make a get call to Oauth token API
Then  access token is received
