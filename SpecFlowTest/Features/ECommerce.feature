Feature: ECommerce
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator](SpecFlowTest/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@scenario1
Scenario: Add an item to basket
	Given user has products to select
	When user selects one product and adds to the basket
	Then the basket should contains the product

@scenario2
Scenario: Add an existing product
	Given system already has 50 Kalem products
	When admin adds a new Kalem product with quantity 12
	Then Kalem quantity should be 62

@scenario3
Scenario: Getting total price of basket
	Given the system has Kalem, Silgi and Kalemtiras, the prices are 2 , 1 , 3
	When user adds 1 Kalem, 2 Silgi and 1 Kalemtiras to the basket
	Then total price of the basket should be 7
