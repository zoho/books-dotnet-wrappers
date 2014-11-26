using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zohobooks.api;
using zohobooks.model;
using zohobooks.service;

namespace ContactsApiTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new ZohoBooks();
            service.initialize("{authtoken}", "{organizationId}");
            ContactsApi contactsApi = service.GetContactsApi();
            var parameters = new Dictionary<object, object>();
            var contactsList = contactsApi.GetContacts(parameters);
            var contacts=contactsList;
            var contactId = contacts[0].contact_id;
            if(contacts!=null)
            {

                foreach (var cont in contacts)
                    Console.WriteLine("{0},{1},{2}", cont.contact_id, cont.contact_name, cont.contact_type);
            }
            var contact = contactsApi.Get(contacts[0].contact_id);
            Console.WriteLine("{0},{1},{2}", contact.contact_id, contact.contact_name, contact.contact_type);
            var contactpers = contact.contact_persons;
            foreach (var per in contactpers)
                Console.WriteLine("{0},{1},{2}", per.contact_person_id, per.email, per.is_primary_contact);
            var newContact = new Contact()
            {
                contact_name = "name",
                payment_terms = 15,
                payment_terms_label = "Net 15",
                currency_id = "{currency id}",
                billing_address = new Address()
                {
                    address = "4900 Hopyard Rd, Suite 310",
                    city = "Pleasanton",
                    state = "CA",
                    zip = "94588",
                    country = "USA",
                    fax = "+1-925-924-9600"
                },
                shipping_address = new Address()
                {
                    address = "Suite 125, McMillan Avenue",
                    city = "San Francisco",
                    state = "CA",
                    zip = "94134",
                    country = "USA",
                    fax = "+1-925-924-9600"
                },
                contact_persons = new List<ContactPerson>(){
         new ContactPerson(){
            
             salutation="Mr.",
             first_name="Will",
             last_name="Smith",
             email="willsmith@bowmanfurniture.com",
           },
           new ContactPerson(){
            
             salutation="Mr.",
             first_name="Peter",
             last_name="Parker",
             email="peterparker@bowmanfurniture.com",
           }
         },

                notes = "Payment option : Through check"
        };
            var contact1 = contactsApi.Create(newContact);
            Console.WriteLine("{0},{1},{2}", contact1.contact_id, contact1.contact_name, contact1.contact_type);
            var contactpersons = contact.contact_persons;
            foreach (var per in contactpersons)
                Console.WriteLine("{0},{1},{2}", per.contact_person_id, per.email, per.is_primary_contact);
            var updateInfo = new Contact()
            {
                
                payment_terms = 15,
                payment_terms_label = "Net 15",
  
                billing_address = new Address()
                {
                    address = "4900 Hopyard Rd, Suite 310",
                    city = "Pleasanton",
                    state = "CA",
                    zip = "94588",
                    country = "USA",
                    fax = "+1-925-924-9600"
                },
                shipping_address = new Address()
                {
                    address = "Suite 125, McMillan Avenue",
                    city = "San Francisco",
                    state = "CA",
                    zip = "94134",
                    country = "USA",
                    fax = "+1-925-924-9600"
                },
                contact_persons = new List<ContactPerson>(){
         new ContactPerson(){
            
             salutation="Mr.",
             first_name="Will",
             last_name="Smith",
             email="willsmith@bowmanfurniture.com",
             phone="+1-925-921-9201",
             mobile="+1-4054439562"
           },
           new ContactPerson(){
            
             salutation="Mr.",
             first_name="Peter",
             last_name="Parker",
             email="peterparker@bowmanfurniture.com",
             phone="+1-925-929-7211",
             mobile="+1-4054439760"
           }
         },

                notes = "Payment option : Through check"
            };
            var updatedcontact = contactsApi.Update(contactId, updateInfo);
            Console.WriteLine("{0},{1},{2}", updatedcontact.contact_id, updatedcontact.contact_name, updatedcontact.contact_type);
            var contctpersons = updatedcontact.contact_persons;
            foreach (var per in contctpersons)
                Console.WriteLine("{0},{1},{2}", per.contact_person_id, per.email, per.is_primary_contact);
            var deleteContact = contactsApi.Delete(contacts[1].contact_id);
            Console.WriteLine(deleteContact);
            var inactive = contactsApi.MarkAsInactive(contactId);
            Console.WriteLine(inactive);
            var active = contactsApi.MarkAsActive(contactId);
            Console.WriteLine(active);
            var EnableReminder = contactsApi.EnablePaymentReminder(contactId);
            Console.WriteLine(EnableReminder);
            var disableReminder = contactsApi.DisablePaymentReminder(contactId);
            Console.WriteLine(disableReminder);
            var emailnote = new EmailNotification()
            {
                to_mail_ids =new List<string>(){
                    "email@host.com",},
                subject = "email notify",
                body = "body of mail"
            };
            var emailstmt = contactsApi.SendEmailStatement(contactId, emailnote, null, null);
            Console.WriteLine(emailstmt);
            parameters.Add("start_date", "2014-03-15");
            parameters.Add("end_date", "2014-04-29");
            var emaildata = contactsApi.GetEmailStatementContent(contactId, parameters);
            Console.WriteLine(emaildata.body);
            var emailnotify = new EmailNotification()
            {
                to_mail_ids =new List<string>(){
                    "email@host.com",},
                subject = "email notify",
                body = "body of mail"
            };
            var emailcntct = contactsApi.SendEmailStatement(contactId, emailnotify,null,null);
            Console.WriteLine(emailcntct);
            var comments = contactsApi.GetComments(contactId);
            foreach (var comment in comments)
                Console.WriteLine("{0},{1}", comment.comment_id, comment.description);
            var refunds = contactsApi.GetRefunds(contactId);
            foreach (var refund in refunds)
                Console.WriteLine("{0},{1}", refund.refund_mode, refund.amount);
            var track = contactsApi.Track1099(contactId);
            Console.WriteLine(track);
            var untrack = contactsApi.UnTrack1099(contactId);
            Console.WriteLine(untrack);
            var cntctpersnsList = contactsApi.GetContactPersons(contacts[0].contact_id);
            var cntctPersons = cntctpersnsList;
            var contactPersonId = cntctPersons[0].contact_person_id;
            foreach (var cntctper in cntctPersons)
                Console.WriteLine("{0},{1},{2}", cntctper.contact_person_id, cntctper.last_name, cntctper.first_name);

            var contactperson = contactsApi.GetContactPerson(contacts[0].contact_id, contactPersonId);
             Console.WriteLine("{0},{1},{2}", contactperson.contact_person_id, contactperson.last_name, contactperson.first_name);
             var contactPerInfo = new ContactPerson()
             {
                 contact_id = "{contactId}",
                 first_name = "hk"
             };
             var newContactPer = contactsApi.CreateContactPerson(contactPerInfo);
             Console.WriteLine("{0},{1},{2}", newContactPer.contact_person_id, newContactPer.last_name, newContactPer.first_name);
             var updateInfo1 = new ContactPerson()
             {
                
                 first_name = "fname"
             };
             var updated = contactsApi.UpdateContactperson(contactPersonId, updateInfo1);
             Console.WriteLine("{0},{1},{2}", updated.contact_person_id, updated.last_name, updated.first_name);
             var deletedmsg = contactsApi.DeleteContactPerson(contactPersonId);
             Console.WriteLine(deletedmsg);

             var makeAsPrimary = contactsApi.MarkAsPrimaryContactPerson(contactPersonId);
             Console.WriteLine(makeAsPrimary);
            Console.ReadKey();
        }
    }
}
