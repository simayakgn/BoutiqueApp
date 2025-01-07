﻿using Microsoft.AspNetCore.Authorization.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DAL
{
    public class User
    {
        public int Id { get; set; }

        [Required, StringLength(20)]
        public string UserName { get; set; }

        [Required, StringLength(10)]
        public string Password { get; set; }
        public bool IsActive {  get; set; }
        public int RoleId {  get; set; }
        public Role Role { get; set; }
    }
}
