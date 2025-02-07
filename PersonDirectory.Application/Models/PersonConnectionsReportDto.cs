namespace PersonDirectory.Application.Models
{
    public class PersonConnectionsReportDto
    {
       
        /// <summary>
        /// First name
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Last name
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Private number
        /// </summary>
        public string PrivateNumber { get; set; } = string.Empty;

        /// <summary>
        /// Connection dictionary by type
        /// </summary>
        public Dictionary<string, int> ConnectionCounts { get; set; } = [];
    }
}
