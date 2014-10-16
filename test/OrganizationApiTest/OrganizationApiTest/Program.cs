using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zohobooks.api;
using zohobooks.model;
using zohobooks.service;

namespace OrganizationApiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var service = new ZohoBooks();
                service.initialize("{authtoken}", "{organisation id}");
                var organizationApi = service.GetOrganizationsApi();
               var organizationsList = organizationApi.GetOrganizations();
               var organizations = organizationsList;
               var organizationId = organizations[0].organization_id;
                foreach (var organization in organizations)
                    Console.WriteLine("Organization Id:{0},\n name:{1},\n contact name:{2},\n email:{3}", organization.organization_id, organization.name, organization.contact_name, organization.email);
                var organization1 = organizationApi.Get(organizationId);
                Console.WriteLine("Organization Id:{0},\n name:{1},\n contact name:{2},\n email:{3}\n addr:{4}\n", organization1.organization_id, organization1.name, organization1.contact_name, organization1.email,organization1.org_address);
                var addr = organization1.address;
                Console.WriteLine("Address:{0},{1},{2}",addr.city,addr.state,addr.country);
                var newOrganizationInfo = new Organization()
                {
                    name="org3",
                    currency_code="USD",
                    time_zone = "GMT+05:30"
                };
                var newOrganization = organizationApi.Create(newOrganizationInfo);
                Console.WriteLine("Organization Id:{0},\n name:{1},\n contact name:{2},\n email:{3}", newOrganization.organization_id, newOrganization.name, newOrganization.contact_name, newOrganization.email);
                var updateInfo = new Organization()
                {
                    name="Org2",
                    address = new Address()
                    {
                        city="Hyderabad",
                        state="Andhra",
                        country="India"
                    },
                };
                var updatedOrg = organizationApi.Upadte(organizationId, updateInfo);
                Console.WriteLine("Organization Id:{0},\n name:{1},\n contact name:{2},\n email:{3}\n addr:{4}\n", updatedOrg.organization_id, updatedOrg.name, updatedOrg.contact_name, updatedOrg.email, updatedOrg.org_address);
                var address = updatedOrg.address;
                Console.WriteLine("Address:{0},{1},{2}", address.city, address.state, address.country);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
