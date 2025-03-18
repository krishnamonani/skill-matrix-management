using System.Threading.Tasks;

namespace SkillMatrixManagement.Data;

public interface ISkillMatrixManagementDbSchemaMigrator
{
    Task MigrateAsync();
}
