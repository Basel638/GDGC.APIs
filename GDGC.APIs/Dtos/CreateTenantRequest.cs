namespace GDGC.APIs.Dtos
{
	public class CreateTenantRequest
	{
		public string Name { get; set; }
		public string UniversityName { get; set; }
		public string SchemaName { get; set; }
		public string Slug { get; set; }
		public string ContactEmail { get; set; }
	}
}
