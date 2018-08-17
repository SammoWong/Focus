using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Focus.Model.Company
{
    public class UpdateCompanyInputModel
    {
        [Display(Name = "公司主键"), Required(ErrorMessage = "{0}不能为空")]
        public string Id { get; set; }

        [Display(Name = "公司全称"), Required(ErrorMessage = "{0}不能为空")]
        public string FullName { get; set; }

        public string ShortName { get; set; }

        public string Nature { get; set; }

        public string Website { get; set; }

        public string Email { get; set; }

        public string Creator { get; set; }

        public string Contact { get; set; }

        public string Mobile { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public bool Enabled { get; set; }
    }
}
