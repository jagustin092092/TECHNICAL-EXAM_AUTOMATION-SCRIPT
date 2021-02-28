Feature: FileInviteEndToEndFunctionalities
	This is to test the different functionalities and features on FileInvite

@mytag1
Scenario: Validate the ability to create new Contact
	Given I navigate on fileinvite signin page
	And I sign in using correct email address and password
	| Email Address          | Password    |
	| qatestjsa3@yopmail.com | Q@t45678123 |
	When I click Create Person button from Contacts form
	And I enter Contact Details
	| Field         | Value                   |
	| FirstName     | FirstJSA4E              |
	| LastName      | LastJSA4E               |
	| Company       | COMPANY JSA4E           |
	| EmailType     | Home                    |
	| Email			| qatestjsa4e@yopmail.com |
	| PhoneType     | Home                    |
	| Mobile        | 9985962461233322        |
	| AddressType   | Office                  |
	| Address1      | Address Test 1          |
	| Address2      | Address Test 2          |
	| City          | Malolos                 |
	| State         | Bulacan                 |
	| Country       | Philippines             |
	| Zip Code      | 3000                    |
	And I click Save Contact button
	Then I am able to successfully create a new Contact with correct details
	| Field         | Value                   |
	| FirstName     | FirstJSA4E              |
	| LastName      | LastJSA4E               |
	| Company       | COMPANY JSA4E           |
	| Email		    | qatestjsa4e@yopmail.com |
	| Mobile        | 9985962461233322        |
	| Address1      | Address Test 1          |
	| Address2      | Address Test 2          |
	| City          | Malolos                 |
	| State         | Bulacan                 |
	| Zip Code      | 3000                    |

@mytag2
Scenario: Validate the ability to create new Company
	Given I navigate on fileinvite signin page
	And I sign in using correct email address and password
	| Email Address          | Password    |
	| qatestjsa3@yopmail.com | Q@t45678123 | 
	When I click Companies button from Contacts form
	And I enter Company Details
	| Field         | Value                   |
	| Name			| Company JSA4E           |
	| Website       | www.google.com          |
	| EmailType     | Work                    |
	| Email			| qatestjsa4e@yopmail.com |
	| PhoneType     | Work                    |
	| Number        | 9985962461233321        |
	| AddressType   | Office                  |
	| Address1      | Address Test 1          |
	| Address2      | Address Test 2          |
	| City          | Malolos                 |
	| State         | Bulacan                 |
	| Country       | Philippines             |
	| ZipCode       | 3000                    |
	And I click Save Company button
	Then I am able to successfully create a new Company with correct details
	| Field         | Value                   |
	| Name			| Company JSA4E           |
	| Website       | www.google.com          |
	| Email			| qatestjsa4e@yopmail.com |
	| Number        | 9985962461233321        |
	| Address1      | Address Test 1          |
	| Address2      | Address Test 2          |
	| City          | Malolos                 |
	| State         | Bulacan                 |
	| ZipCode       | 3000                    |

@mytag3
Scenario: Validate the ability to Create Invite
	Given I navigate on fileinvite signin page
	And I sign in using correct email address and password
	| Email Address          | Password    |
	| qatestjsa3@yopmail.com | Q@t45678123 | 
	When I click Create New Invite button
	And I use existing template
	And I select Due Date
	And I search for Amy Smith as an existing Contact
	When I select new Request
	And I click on Review Invite button
	Then I can see Invite Information
	When I click Send Invite button
	Then I can view the Invite Progress

