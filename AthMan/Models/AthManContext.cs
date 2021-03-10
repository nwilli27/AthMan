using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AthMan.Models
{
	/// <summary>
	/// Holds database structure for the AthMan application
    /// 
    /// Author: Nolan Williams
    /// Date:   3/9/2021
	/// </summary>
	/// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
	public class AthManContext : DbContext
    {

		/// <summary>
		/// Initializes a new instance of the <see cref="AthManContext"/> class.
		/// </summary>
		/// <param name="options">The options.</param>
		public AthManContext(DbContextOptions<AthManContext> options)
            : base(options)
        { }

		/// <summary>
		/// Gets or sets the items.
		/// </summary>
		/// <value>
		/// The items.
		/// </value>
		public DbSet<Item> Items { get; set; }

		/// <summary>
		/// Gets or sets the employees.
		/// </summary>
		/// <value>
		/// The employees.
		/// </value>
		public DbSet<Employee> Employees { get; set; }

		/// <summary>
		/// Gets or sets the countries.
		/// </summary>
		/// <value>
		/// The countries.
		/// </value>
		public DbSet<Country> Countries { get; set; }

		/// <summary>
		/// Gets or sets the clients.
		/// </summary>
		/// <value>
		/// The clients.
		/// </value>
		public DbSet<Client> Clients { get; set; }

		/// <summary>
		/// Gets or sets the incidents.
		/// </summary>
		/// <value>
		/// The incidents.
		/// </value>
		public DbSet<Incident> Incidents { get; set; }

		/// <summary>
		/// Gets the incidents populated.
		/// </summary>
		/// <value>
		/// The incidents populated.
		/// </value>
		public IList<Incident> IncidentsPopulated => this.Incidents.Include(i => i.Client).ThenInclude(c => c.Country)
                                                                   .Include(i => i.Item)
                                                                   .Include(i => i.Employee).ToList();

		/// <summary>
		/// Gets the clients populated.
		/// </summary>
		/// <value>
		/// The clients populated.
		/// </value>
		public IList<Client> ClientsPopulated => this.Clients.Include(c => c.Country).ToList();

        /// <summary>
		/// Returns the first Client that has the matching [id] from
        /// a list that has already been joined.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>A Client</returns>
        public Client ClientPopulated(int id)
		{
			return this.ClientsPopulated.FirstOrDefault(c => c.ClientID == id);
		}

		/// <summary>
		/// Returns the first incident that has the matching [id] from
        /// a list that has already been joined.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>A Incident</returns>
		public Incident IncidentPopulated(int id)
		{
            return this.IncidentsPopulated.FirstOrDefault(i => i.IncidentID == id);
		}

		/// <summary>
		/// Override this method to further configure the model that was discovered by convention from the entity types
		/// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
		/// and re-used for subsequent instances of your derived context.
		/// </summary>
		/// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
		/// define extension methods on this object that allow you to configure aspects of the model that are specific
		/// to a given database.</param>
		/// <remarks>
		/// If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
		/// then this method will not be run.
		/// </remarks>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    ItemID = 1,
                    ItemCode = "DRFT15",
                    Name = "Draft Manager 1.5",
                    YearlyPrice = 4.99M,
                    ReleaseDate = DateTime.Parse("2020-02-01")
                },
                new Item
                {
                    ItemID = 2,
                    ItemCode = "DRFT24",
                    Name = "Draft Manager 2.4",
                    YearlyPrice = 5.99M,
                    ReleaseDate = DateTime.Parse("2020-07-15 00:00:00.000")
                },
                new Item
                {
                    ItemID = 3,
                    ItemCode = "LEAG11",
                    Name = "League Scheduler 1.1",
                    YearlyPrice = 4.99M,
                    ReleaseDate = DateTime.Parse("2019-05-01 00:00:00.000")
                },
                new Item
                {
                    ItemID = 4,
                    ItemCode = "LEAGD20",
                    Name = "League Scheduler Deluxe 2.0",
                    YearlyPrice = 7.99M,
                    ReleaseDate = DateTime.Parse("2020-08-01 00:00:00.000")
                },
                new Item
                {
                    ItemID = 5,
                    ItemCode = "TEAM10",
                    Name = "Team Manager 1.0",
                    YearlyPrice = 4.99M,
                    ReleaseDate = DateTime.Parse("2020-05-01 00:00:00.000")
                },
                new Item
                {
                    ItemID = 6,
                    ItemCode = "TRNY10",
                    Name = "Tournament Master 1.0",
                    YearlyPrice = 4.99M,
                    ReleaseDate = DateTime.Parse("2019-11-01 00:00:00.000")
                },
                new Item
                {
                    ItemID = 7,
                    ItemCode = "TRNY20",
                    Name = "Tournament Master 2.0",
                    YearlyPrice = 5.99M,
                    ReleaseDate = DateTime.Parse("2020-02-15 00:00:00.000")
                }
            );

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeID = 11,
                    Name = "Alie Diaz",
                    Email = "alie@athman.com",
                    Phone = "800-555-1443"
                },
                new Employee
                {
                    EmployeeID = 12,
                    Name = "Jason Lea",
                    Email = "jason@athman.com",
                    Phone = "800-555-1444"
                },
                new Employee
                {
                    EmployeeID = 13,
                    Name = "Andy Wilson",
                    Email = "andy@athman.com",
                    Phone = "800-555-1449"
                },
                new Employee
                {
                    EmployeeID = 14,
                    Name = "George Wendt",
                    Email = "gwendt@athman.com",
                    Phone = "800-555-1400"
                },
                new Employee
                {
                    EmployeeID = 15,
                    Name = "Tina Fiori",
                    Email = "tfiori@athman.com",
                    Phone = "800-555-1459"
                }
            );

            modelBuilder.Entity<Country>().HasData(
                new Country { CountryID = "AU", Name = "Australia" },
                new Country { CountryID = "AT", Name = "Austria" },
                new Country { CountryID = "BE", Name = "Belgium" },
                new Country { CountryID = "BR", Name = "Brazil" },
                new Country { CountryID = "CA", Name = "Canada" },
                new Country { CountryID = "CN", Name = "China" },
                new Country { CountryID = "DK", Name = "Denmark" },
                new Country { CountryID = "FI", Name = "Finland" },
                new Country { CountryID = "FR", Name = "France" },
                new Country { CountryID = "GR", Name = "Greece" },
                new Country { CountryID = "GL", Name = "Greenland" },
                new Country { CountryID = "HK", Name = "Hong Kong" },
                new Country { CountryID = "IS", Name = "Iceland" },
                new Country { CountryID = "IN", Name = "India" },
                new Country { CountryID = "IE", Name = "Ireland" },
                new Country { CountryID = "IL", Name = "Israel" },
                new Country { CountryID = "IT", Name = "Italy" },
                new Country { CountryID = "JP", Name = "Japan" },
                new Country { CountryID = "LR", Name = "Liberia" },
                new Country { CountryID = "MY", Name = "Malaysia" },
                new Country { CountryID = "MX", Name = "Mexico" },
                new Country { CountryID = "NL", Name = "Netherlands" },
                new Country { CountryID = "NZ", Name = "New Zealand" },
                new Country { CountryID = "NG", Name = "Nigeria" },
                new Country { CountryID = "PH", Name = "Philippines" },
                new Country { CountryID = "PT", Name = "Portugal" },
                new Country { CountryID = "PR", Name = "Puerto Rico" },
                new Country { CountryID = "QA", Name = "Qatar" },
                new Country { CountryID = "SG", Name = "Singapore" },
                new Country { CountryID = "ES", Name = "Spain" },
                new Country { CountryID = "SE", Name = "Sweden" },
                new Country { CountryID = "CH", Name = "Switzerland" },
                new Country { CountryID = "TH", Name = "Thailand" },
                new Country { CountryID = "TR", Name = "Turkey" },
                new Country { CountryID = "UA", Name = "Ukraine" },
                new Country { CountryID = "AE", Name = "United Arab Emirates" },
                new Country { CountryID = "GB", Name = "United Kingdom" },
                new Country { CountryID = "US", Name = "United States" },
                new Country { CountryID = "VN", Name = "Vietnam" },
                new Country { CountryID = "ZW", Name = "Zimbabwe" }
            );

            modelBuilder.Entity<Client>().HasData(
                new Client
                {
                    ClientID = 1002,
                    FirstName = "Anita",
                    LastName = "Ervin",
                    Address = "PO Box 96621",
                    City = "Washington",
                    State = "DC",
                    PostalCode = "20090",
                    CountryID = "US",
                    Phone = "(301) 555-8950",
                    Email = "anita@mma.nidc.com"
                },
                new Client
                {
                    ClientID = 1004,
                    FirstName = "Kenzie",
                    LastName = "Quinne",
                    Address = "1990 Westwood Blvd Ste 260",
                    City = "Los Angeles",
                    State = "CA",
                    PostalCode = "90025",
                    CountryID = "US",
                    Phone = "(800) 555-8725",
                    Email = "kenzie@mma.jobtrak.com"
                },
                new Client
                {
                    ClientID = 1006,
                    FirstName = "Anton",
                    LastName = "Mauro",
                    Address = "3255 Ramos Cir",
                    City = "Sacramento",
                    State = "CA",
                    PostalCode = "95827",
                    CountryID = "US",
                    Phone = "(916) 555-6670",
                    Email = "amauro@yahoo.org"
                },
                new Client
                {
                    ClientID = 1008,
                    FirstName = "Kaitlin",
                    LastName = "Anthoni",
                    Address = "Box 52001",
                    City = "San Francisco",
                    State = "CA",
                    PostalCode = "94152",
                    CountryID = "US",
                    Phone = "(800) 555-6081",
                    Email = "kanthoni@pge.com"
                },
                new Client
                {
                    ClientID = 1010,
                    FirstName = "Kendall",
                    LastName = "May",
                    Address = "PO Box 2069",
                    City = "Fresno",
                    State = "CA",
                    PostalCode = "93718",
                    CountryID = "US",
                    Phone = "(559) 555-9999",
                    Email = "kmay@fresno.ca.gov"
                },
                new Client
                {
                    ClientID = 1012,
                    FirstName = "Marvin",
                    LastName = "Keeton",
                    Address = "4420 N. First Street, Suite 108",
                    City = "Fresno",
                    State = "CA",
                    PostalCode = "93726",
                    CountryID = "US",
                    Phone = "(559) 555-9586",
                    Email = "marvin@expedata.com"
                },
                new Client
                {
                    ClientID = 1015,
                    FirstName = "Gonzalo",
                    LastName = "Quintin",
                    Address = "27371 Valderas",
                    City = "Mission Viejo",
                    State = "CA",
                    PostalCode = "92691",
                    CountryID = "US",
                    Phone = "(214) 555-3647",
                    Email = ""
                }
            );


            modelBuilder.Entity<Incident>().HasData(
                new Incident
                {
                    IncidentID = 1,
                    ClientID = 1010,
                    ItemID = 1,
                    EmployeeID = 11,
                    Title = "Could not install",
                    Description = "Media appears to be bad.",
                    DateOpened = DateTime.Parse("2021-01-08"),
                    DateClosed = DateTime.Parse("2021-01-10")
                },
                new Incident
                {
                    IncidentID = 2,
                    ClientID = 1002,
                    ItemID = 4,
                    EmployeeID = 14,
                    Title = "Error importing data",
                    Description = "Received error message 415 while trying to import data from previous version.",
                    DateOpened = DateTime.Parse("2021-01-09"),
                    DateClosed = null
                },
                new Incident
                {
                    IncidentID = 3,
                    ClientID = 1015,
                    ItemID = 6,
                    EmployeeID = 15,
                    Title = "Could not install",                    
                    Description = "Setup failed with code 104.",
                    DateOpened = DateTime.Parse("2021-01-08"),
                    DateClosed = DateTime.Parse("2021-01-10")
                },
                new Incident
                {
                    IncidentID = 4,
                    ClientID = 1010,
                    ItemID = 3,
                    EmployeeID = null,
                    Title = "Error launching program",                    
                    Description = "Program fails with error code 510, unable to open database.",
                    DateOpened = DateTime.Parse("2021-01-10"),
                    DateClosed = null
                }
            );
        }
    }
}