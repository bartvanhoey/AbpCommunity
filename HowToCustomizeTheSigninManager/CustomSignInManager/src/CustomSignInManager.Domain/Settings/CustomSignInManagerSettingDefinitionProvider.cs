using Volo.Abp.Settings;

namespace CustomSignInManager.Settings;

public class CustomSignInManagerSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(CustomSignInManagerSettings.MySetting1));
    }
}
