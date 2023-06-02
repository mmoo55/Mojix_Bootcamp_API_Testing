Feature: Product

As a user I would like to know if the Http methods work.

Background:
	Given I navigate to the url

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
	And I send the following data: <name>, <description>, <image>, <price>, <categoryId>
	When I send a request
	Then I expect a valid code response
	And I expect that is same price <expected>

	Examples:
	| name 		   		| description		| image 				| price | categoryId 	| expected 	|
	| "Gray Glasses" 	| "Gray Glasses" 	| "gray-glasses.jpg" 	| 15.99 | 7 			| 15.99		|

@positive @smoke @regression
Scenario: A user is able to get a list of products with a valid category ID
	Given I have a new GET request to '/api/product'
	When I send a request
	Then I expect a valid code response
	And I expect a list of product

@positive @smoke @regression
Scenario: A user is able to create a new product
	Given I have a new POST request to '/api/product'
	And I send authorize token
	And I send the following data: <name>, <description>, <image>, <price>, <categoryId>
	When I send a request
	Then I expect a valid code response
	And I expect that is same name <expected>

	Examples:
	| name 		   		| description		| image 				| price | categoryId 	| expected 			|
	| "Purple Glasses" 	| "Purple Glasses" 	| "purple-glasses.jpg" 	| 13.99 | 7 			| "Purple Glasses"	|