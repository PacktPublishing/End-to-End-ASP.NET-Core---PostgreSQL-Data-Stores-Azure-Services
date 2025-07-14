namespace Neon.CRM.WebApp.Services.Response;


public class BranchCreateResponse
{
    public Branch branch { get; set; }
    public Endpoint[] endpoints { get; set; }
    public Operation[] operations { get; set; }
    public Role[] roles { get; set; }
    public Databas[] databases { get; set; }
    public Connection_Uris[] connection_uris { get; set; }
}

public class Branch
{
    public string id { get; set; }
    public string project_id { get; set; }
    public string name { get; set; }
    public string current_state { get; set; }
    public string pending_state { get; set; }
    public DateTime state_changed_at { get; set; }
    public string creation_source { get; set; }
    public bool primary { get; set; }
    public bool _default { get; set; }
    public bool _protected { get; set; }
    public int cpu_used_sec { get; set; }
    public int compute_time_seconds { get; set; }
    public int active_time_seconds { get; set; }
    public int written_data_bytes { get; set; }
    public int data_transfer_bytes { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
    public Created_By created_by { get; set; }
    public string init_source { get; set; }
}

public class Created_By
{
    public string name { get; set; }
    public string image { get; set; }
}

public class Endpoint
{
    public string host { get; set; }
    public string id { get; set; }
    public string project_id { get; set; }
    public string branch_id { get; set; }
    public float autoscaling_limit_min_cu { get; set; }
    public int autoscaling_limit_max_cu { get; set; }
    public string region_id { get; set; }
    public string type { get; set; }
    public string current_state { get; set; }
    public string pending_state { get; set; }
    public Settings settings { get; set; }
    public bool pooler_enabled { get; set; }
    public string pooler_mode { get; set; }
    public bool disabled { get; set; }
    public bool passwordless_access { get; set; }
    public string creation_source { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
    public string proxy_host { get; set; }
    public int suspend_timeout_seconds { get; set; }
    public string provisioner { get; set; }
}

public class Settings
{
}

public class Operation
{
    public string id { get; set; }
    public string project_id { get; set; }
    public string branch_id { get; set; }
    public string action { get; set; }
    public string status { get; set; }
    public int failures_count { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
    public int total_duration_ms { get; set; }
    public string endpoint_id { get; set; }
}

public class Role
{
    public string branch_id { get; set; }
    public string name { get; set; }
    public bool _protected { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
}

public class Databas
{
    public int id { get; set; }
    public string branch_id { get; set; }
    public string name { get; set; }
    public string owner_name { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
}

public class Connection_Uris
{
    public string connection_uri { get; set; }
    public Connection_Parameters connection_parameters { get; set; }
}

public class Connection_Parameters
{
    public string database { get; set; }
    public string password { get; set; }
    public string role { get; set; }
    public string host { get; set; }
    public string pooler_host { get; set; }
}

