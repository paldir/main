//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SZI
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Text.RegularExpressions;

    public partial class Collector : IItem
    {
        public string CollectorId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public string[] GetElements
        {
            get
            {
                return new string[]
                {
                    CollectorId,
                    Name,
                    LastName,
                    PostalCode,
                    City,
                    Address,
                    PhoneNumber
                };
            }
        }

        public void InsertIntoDB()
        {
            try
            {
                using (var database = new CollectorsManagementSystemEntities())
                {
                    this.Address = this.Address.Substring(0, 17); // <- do poprawienia w przyszłości
                    this.PostalCode = Regex.Replace(this.PostalCode, "-", "");
                    database.Collectors.Add(this);
                    database.SaveChanges();
                }
            }
            catch(System.ComponentModel.DataAnnotations.ValidationException Ex)
            {
                ExceptionHandling.ShowException(Ex);
            }
            catch (DbUpdateException Ex)
            {
                ExceptionHandling.ShowException(Ex);
            }
        }

        public void ModifyRecord(string id)
        {
            using (var dataBase = new CollectorsManagementSystemEntities())
            {
                dataBase.Database.ExecuteSqlCommand
                (
                    "UPDATE Collector SET Name={0}, LastName={1}, PostalCode={2}, City={3}, Address={4}, PhoneNumber={5} WHERE CollectorId={6}",
                    this.Name,
                    this.LastName,
                    Regex.Replace(this.PostalCode, "-", ""),
                    this.City,
                    this.Address,
                    this.PhoneNumber,
                    id
                );
                dataBase.SaveChanges();
            }
        }
    }
}
