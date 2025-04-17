using System;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace SkillMatrixManagement.Domain
{
    public class CustomUser : FullAuditedAggregateRoot<Guid> , ISoftDelete
    {
        public Guid IdentityUserId { get; set; } // Links to AbpUsers table
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; } // True for active users, False for pending

        protected CustomUser() { }

        public CustomUser(Guid id, Guid identityUserId, string userName, string email, bool isActive = false)
        {
            Id = id;
            IdentityUserId = identityUserId;
            UserName = userName;
            Email = email;
            IsActive = isActive;
        }
    }
}