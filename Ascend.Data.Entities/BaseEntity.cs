using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ascend.Data.Entities
{
    public class BaseEntity
    {
        public DateTime dateCreated { get; set; }

        public DateTime? dateModified { get; set; }


        [ForeignKey("userCreate")]
        public int? userCreated { get; set; }

        public int? userModified { get; set; }

        public bool isDelete { get; set;}
        public BaseEntity()
        {
            dateCreated = DateTime.Now;
        }

        public User userCreate { get; set; }

    }

}
