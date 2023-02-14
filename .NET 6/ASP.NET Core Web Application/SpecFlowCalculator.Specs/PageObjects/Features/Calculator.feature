Feature: Calculator
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator](SpecFlowCalculator.Specs/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@mytag
Scenario: standard user logs in
	Given the username is standard_user
	And the password is secret_sauce
	When User clicks login button
	Then User is sent to Home Page

Scenario: locked_user logs in
	Given the username is locked_out_user
	And the password is secrert_sauce
	When User clicks login button
	Then User is given a red prompt