//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee : User
    {
        public string BadgeNumber { get; set; }
        public string Post { get; set; }

        public Employee() { }

        public Employee(User user, string badgeNumber, string post) : base(user)
        {
            BadgeNumber = badgeNumber;
            Post = post;
        }

        public override void UpdateUser(User user)
        {
            base.UpdateUser(user);
        }
    }
}