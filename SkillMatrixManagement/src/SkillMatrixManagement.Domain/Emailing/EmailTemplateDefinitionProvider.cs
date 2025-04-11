using Volo.Abp.TextTemplating;

namespace SkillMatrixManagement.Emailing
{
    public class EmailTemplateDefinitionProvider : TemplateDefinitionProvider
    {
        public override void Define(ITemplateDefinitionContext context)
        {
            context.Add(
                new TemplateDefinition(
                    name: "Welcome"
                ).WithVirtualFilePath(
                    "/Emailing/Templates/WelcomeTemplate.cshtml", 
                    isInlineLocalized: true
                )
            );
        }
    }
}
