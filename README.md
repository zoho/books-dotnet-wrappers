# ZohoBooks .Net Client Library

The .Net library for intigrating with the Zoho Books API.

## Installation

To install the ZohoBooks .Net Client Library, run the following command in [NuGet's](https://nuget.org/) console.

	$ Install -package ZohoBooks

To build the project from source, run the following command:
	
	$ git clone git@github.com:books-dotnet.git

Note: NuGet is the package manager for Microsoft Visual Studio.

## Documentation
 [API Reference](https://www.zoho.com/books/api/v3/index.html)

## Usage 

In order to access the Zoho Books APIs, users need to have a valid Zoho account and a valid Auth Token.

### Sign up for a Zoho Account:

For setting up a Zoho account, access the Zoho Books [Sign Up](https://www.zoho.com/books/signup/) page and enter the requisite details - email address and password.

### Generate Auth Token:

To generate the Auth Token, you need to send an authentication request to Zoho Accounts in a prescribed URL format. [Refer here](https://www.zoho.com/books/api/v3/index.html) 

### How to access Zoho Books APIs through .Net wrapper classes?

In order to access the the ZohoBooks API you need to use the following classes. Please import them to your project:

	using zohobooks.api;
	using zohobooks.model;
	using zohobooks.service;

Next step in calling the wrapper class methods involves initializing the ZohoBooks services. This can be achieved by passing the authtoken and id of the organization that you are currently working on. Sample code below:

	ZohoBooks service = new ZohoBooks();
	service.initialize("{authtoken}", "{organisation id}");

From the initialised service, your able to create the instances for the individual Api and its methods

For example, the following code illustrates how to create an instance of the OrganizationsApi which, in turn, allows you to get the list of organisations as well as update details of the particular organization (see sample below).

	var organizationsApi=service.GetOrganizationsApi();

## .Net Wrappers - Sample

### Create a new organization:

To create an organization you have to call the `create()` method of the organizationApi instance.

For getting the organizationApi instance you have to pass the Organisation object, which contains the organization information, as a parameter. It returns the Organization object as a response.

Use the below sample code shows to create the Organisation object:

	var organizationInfo = new Organization()
	{
		name="org name",
		currency_code="IR",
		time_zone = "GMT+05:30",
		address=new Addresss()
		{
			city="city name",
			state="state name",
			country="country name",
		},								         };

Once done, pass the Organisation object as a parameter while calling the `create()` method.

	try
	{
		var newOrganization = organizationApi.Create(organizationInfo);
	
	}

The newOrganization in the sample above is the organization object which carries details of the newly created organization by the OrganizationsApi instance.

### Get details of an organization:

In order to get the details of a organization, you need to call the `get()` method by passing  `organization_id` as a parameter.

	try
	{
		Organization org = organizationsApi.Get(organization_id);
	}
	
It returns Organization object as a response. 

Note: The Organization object contains details of the organization (identified by its `organization_id`)
	
### Catch Exceptions:
 
If there is any error encountered while calling the .Net Wrappers of Zoho Books API, the respective class will throw the BooksException. Use the below mentioned code to catch the BooksException:

	catch(Exception e)
	{
		Console.WriteLine(e.Message);
	}


For a full set of examples, click [here.](../../tree/master/test)

