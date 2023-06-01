Feature: Product

As a user I would like to know if the Http methods work.

Background:
    * def token = 'eyJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJhZG1pbiIsImlhdCI6MTY4NTU5MzI1NiwiZXhwIjoxNjg1NTk2ODU2fQ.2f-Y7tsq-OF8FG4oPKfT-VKwX6f4jziF8XeGt0FUaaE'

@positive @smoke @regression
Scenario: A user is able to get a product with a valid ID
	Given I have a new "Get" request
	And I have an id with value 20
	When I send a Get request
	Then I expect a valid code response
	And I expect that is same id 20

@positive @smoke @regression
Scenario: A user is able to update a product with a valid ID
	Given I have a new Put request
	And I have an id with value 19
	And I send authorize token
	And I have the following data
	"""
    {
		name = "Purple Glasses",
  		description = "Purple Glasses",
  		image = "purple-glasses.jpg",
  		price = "13.99",
  		categoryId = 7
    }
	"""
	When I send the JSON data
	And I send a Put request
	Then I expect a valid code response
	And I expect that is same price "13.99"

@positive @smoke @regression
Scenario: A user is able to get a list of products with a valid category ID
	Given I have a new "Get" request
	And I have an id with value 7
	When I send a Get request
	Then I expect a valid code response
	#And I expect that is same id 7

@positive @smoke @regression
Scenario: A user is able to create a new product
	Given I have a new Post request
	And I send authorize token
	And I have the following data
	"""
    {
		name = "Purple Glasses",
  		description = "Purple Glasses",
  		image = "purple-glasses.jpg",
  		price = "13.99",
  		categoryId = 7
    }
	"""
	When I send the JSON data
	And I send a Post request
	Then I expect a valid code response
	And I expect that is same name "Purple Glasses"