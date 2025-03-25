using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillMatrixManagement.Constants
{
    public enum PermissionEnum
    {
        DEVELOPER_READ,
        DEVELOPER_WRITE,
        DEVELOPER_EDIT,
        DEVELOPER_DELETE,

        MANAGER_READ,
        MANAGER_WRITE,
        MANAGER_EDIT,
        MANAGER_DELETE,

        HR_READ,
        HR_WRITE,
        HR_EDIT,
        HR_DELETE,
    }
}
