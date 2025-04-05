using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Comment
    {
        public int Id{ get; set; } // primary key for the comment class
        public String Title{ get; set; }= string.Empty;
        public String Content{ get; set; }= string.Empty;
        public DateTime CreatedOn{ get; set; }= DateTime.Now; // its like in a database we are asdding attritbutes for a response 
         
        public int? StockId { get; set; } //  foreign key reference refernfing to Primary key  //Navigation property  which will allow us to acces sbelwo allowing us to navigate and get elements/ compoienets in STcok class


        public Stock? Stock { get; set; } //Purpose: This is a navigation property that provides access to the related Stock entity.
    }
}