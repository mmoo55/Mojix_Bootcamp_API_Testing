Feature: Product

As a user I would like to know if the Http methods work.

Background:
	Given I navigate to the url
	And I have a new POST request to '/api/authenticate'
	When I submit username and password
	And I send a request
	Then I expect a valid code response
	And I expect to receive token 
    #* def token = 'eyJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJhZG1pbiIsImlhdCI6MTY4NTU5MzI1NiwiZXhwIjoxNjg1NTk2ODU2fQ.2f-Y7tsq-OF8FG4oPKfT-VKwX6f4jziF8XeGt0FUaaE'

@positive @smoke @regression
Scenario: A user is able to get a product with a valid ID
	Given I have a new GET request to '/api/product/{id}'
	And I have an id with value 20
	When I send a request
	Then I expect a valid code response
	And I expect that is same id 20

@positive @smoke @regression
Scenario Outline: A user is able to update a product with a valid ID
	Given I have a new PUT request to '/api/product/{id}'
	And I have an id with value 19
	And I send authorize token
	And I send the following data: <name>, <description>, <image>, <price>, <categotyId>
	When I send a request
	Then I expect a valid code response
	And I expect that is same price <expected>

	Examples:
	| name 		   		| description		| image 				| price | categoryId 	| expected 	|
	| "Gray Glasses" 	| "Gray Glasses" 	| "gray-glasses.jpg" 	| 15.99 | 7 			| 15.99		|

@positive @smoke @regression
Scenario: A user is able to get a list of products with a valid category ID
	Given I have a new GET request to '/api/product'
	#And I have an id with value 7
	When I send a request
	Then I expect a valid code response
	#And I expect that is same id 7

@positive @smoke @regression
Scenario: A user is able to create a new product
	Given I have a new POST request to '/api/product'
	And I send authorize token
	And I have the following data: <name>, <description>, <image>, <price>, <categotyId>
	When I send a request
	Then I expect a valid code response
	And I expect that is same name <expected>

	Examples:
	| name 		   		| description		| image 				| price | categoryId 	| expected 			|
	| "Purple Glasses" 	| "Purple Glasses" 	| "purple-glasses.jpg" 	| 13.99 | 7 			| "Purple Glasses"	|