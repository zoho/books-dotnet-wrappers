# ZohoBooks .Net Client Library

The .Net library for intigrating with ZohoBooks

## Installation

Install the latest version of the library with the following commands:

Use NuGet : [NuGet] (https://nuget.org) is a package manager for Visual Studio.

To install the ZohoBooks .Net Client Library, run the following command in the package Manager Console:

	$ Install -package ZohoBooks

If you would prefer to build it from source: 
	
	$ git clone git@github.com:books-dotnet.git

## Documentation
Refer Api Documentation from [Here](https://www.zoho.com/books/api/v3/contacts/)

## Usage 

If you want to use all our Zoho Books services API, you should have a valid authtoken which requires the Zoho username and password.

How to generate authtoken ? [Refer from Here](https://www.zoho.com/books/api/v3/)
If you are having a valid `authtoken` , you are able to acess the ZohoBooks API Wrappers.

How to use our wrapper classes?

The following example of sample code describes the usage of the ZohoBooks .Net wrappers

You have to use the following classes in your project to access the ZohoBooks API services

	using zohobooks.api;
	using zohobooks.model;
	using zohobooks.service;

As a part of calling the wrapper class methods first you have to intialize the ZohoBooks services by passing your authtoken and organization id(on which organization you are working now)

	ZohoBooks service = new ZohoBooks();
	service.initialize("{authtoken}", "{organisation id}");

From the initialised service, your able to create the instances for the individual Api and its methods

The follwing sample code describes to how to create the instance of the OrganizationsApi which allows you to get the list of organisation and to get and update the specified organization.

	var organizationsApi=service.GetOrganizationsApi();

Now you are able to access the wrapper class methods by the instance organizationApi as shown below 

### To Create an organization:

To create an organization you have to call the `create()` method of the organizationApi instance.
For that you have to pass the Organisation object which contains the organization information as a parameter and returns the Organization object.

The following shows the how to create Organisation object

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

The following line of code shows how to pass the organization object as a parameter to the `create()`

	try
	{
		var newOrganization = organizationApi.Create(organizationInfo);
	
	}

The newOrganization is the organization object which having the details of the newly created organization by the OrganizationsApi instance.

### To Get the details of specified organization

If you want to get a particular Organization, you need to call `get()` method by passing the organization id as a parameter and it returns the Organization object which contains the details of specified organization id.
The following peice of code desribes the how to call `get()` method 

	try
	{
		Organization org = organizationsApi.Get(organization_id);
	}
		
### Catch the exception

When calling Zoho Books API wrappers if there is any error then the respective class throws the BooksException.
The BooksException is caught by the following way

	catch(Exception e)
	{
		Console.WriteLine(e.Message);
         }


See [Here](../../tree/master/test) for more examples.

