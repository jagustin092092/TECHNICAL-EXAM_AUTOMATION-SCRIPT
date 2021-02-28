Feature: Signup on FIleInvite
	

@mytag
Scenario: Ability to SignUp on FIleInvite
	Given I am on FileInvite page
	When I enter qatestjsa4@yopmail.com as valid email address 
	And I click on Sign Up button
	Then I am able to sign up on FIleInvite
	| First Name | Last Name | Company      | Password  |
	| FIRSTJSA4  | LastJSA4  | Company JSA4 | Q@t45678123 | 

