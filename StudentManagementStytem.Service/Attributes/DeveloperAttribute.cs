namespace StudentManagementStytem.Service.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public class DeveloperAttribute : Attribute
{

    private readonly string _name;
    public DeveloperAttribute(string name)
    {
        _name = name;
    }

    public string GetName()
    {
        return "This Application is Developed by " + _name;
    }
}
