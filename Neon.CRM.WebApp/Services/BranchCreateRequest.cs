namespace Neon.CRM.WebApp.Services.Request;

public class BranchCreateRequest
{
    public Branch branch { get; set; }
    public Endpoint[] endpoints { get; set; }
}

public class Branch
{
    public string parent_id { get; set; }
    public string name { get; set; }
    public string init_source { get; set; }
}

public class Endpoint
{
    public string type { get; set; }
}