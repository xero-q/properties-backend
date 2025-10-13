using Domain.Properties;
using SharedKernel;

namespace Domain.Hosts;

public class Host: Entity
{
   
    public string FullName { get; set; }
    
    public string Email { get; set; }

    public string Phone { get; set; }

    public List<Property> Properties { get; set; } = [];

}