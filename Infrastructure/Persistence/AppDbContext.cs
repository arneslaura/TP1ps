using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        //constructor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //declaracion de entidades
        public DbSet<CampaignType> CampaignType { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Interactions> Interactions { get; set; }
        public DbSet<InteractionTypes> InteractionTypes { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Domain.Entities.TaskStatus> TaskStatus { get; set; }
        public DbSet<User> User { get; set; }

        //modelado de la base de datos
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //creacion de tablas
            modelBuilder.Entity<CampaignType>(entity =>
            {
                entity.ToTable("CampaignType");
                entity.HasKey(ct => ct.Id);
                entity.Property(ct => ct.Id).ValueGeneratedOnAdd();
                entity.Property(ct => ct.Name).HasMaxLength(25).IsRequired();

                entity.HasMany(ct => ct.Projects)
                .WithOne(p => p.Campaigntype);
            });
            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");
                entity.HasKey(c => c.ClientID);
                entity.Property(c => c.ClientID).ValueGeneratedOnAdd();
                entity.Property(c => c.Name).HasMaxLength(255).IsRequired();
                entity.Property(c => c.Email).HasMaxLength(255).IsRequired();
                entity.Property(c => c.Phone).HasMaxLength(255).IsRequired();
                entity.Property(c => c.Company).HasMaxLength(100).IsRequired();
                entity.Property(c => c.Address).IsRequired();
                entity.Property(c => c.CreateDate).IsRequired();

                entity.HasMany(c => c.Projects)
                .WithOne(p => p.Client);
            });
            modelBuilder.Entity<InteractionTypes>(entity =>
            {
                entity.ToTable("InteractionTypes");
                entity.HasKey(it => it.Id);
                entity.Property(it => it.Id).ValueGeneratedOnAdd();
                entity.Property(it => it.Name).HasMaxLength(25).IsRequired();

                entity.HasMany(it => it.Interactions)
                .WithOne(i => i.Interactiontype);
            });
            modelBuilder.Entity<Domain.Entities.TaskStatus>(entity =>
            {
                entity.ToTable("TaskStatus");
                entity.HasKey(ts => ts.Id);
                entity.Property(ts => ts.Id).ValueGeneratedOnAdd();
                entity.Property(ts => ts.Name).HasMaxLength(25).IsRequired();

                entity.HasMany(ts => ts.Tasks)
                .WithOne(t => t.TaskStatus);
            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");
                entity.HasKey(u => u.UserID);
                entity.Property(u => u.UserID).ValueGeneratedOnAdd();
                entity.Property(u => u.Name).HasMaxLength(255).IsRequired();
                entity.Property(u => u.Email).HasMaxLength(255).IsRequired();

                entity.HasMany(u => u.Tasks)
                .WithOne(t => t.User);
            });
            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Project");
                entity.HasKey(p => p.ProjectID);
                entity.Property(p => p.ProjectID).ValueGeneratedOnAdd();
                entity.Property(p => p.ProjectName).HasMaxLength(255).IsRequired();
                entity.Property(p => p.StartDate).IsRequired();
                entity.Property(p => p.EndDate).IsRequired();
                entity.Property(p => p.CreateDate).IsRequired();
                entity.Property(p => p.UpdateDate).IsRequired();

                entity.HasMany(p => p.Interactions)
                .WithOne(i => i.Project);

                entity.HasMany(p => p.Tasks)
                .WithOne(t => t.Project);

                entity.HasOne(p => p.Campaigntype)
                .WithMany(ct => ct.Projects)
                .HasForeignKey(p => p.CampaignType);

                entity.HasOne(p => p.Client)
                .WithMany(c => c.Projects)
                .HasForeignKey(p => p.ClientID);
            });
            modelBuilder.Entity<Interactions>(entity =>
            {
                entity.ToTable("Interactions");
                entity.HasKey(i => i.InteractionID);
                entity.Property(i => i.InteractionID).ValueGeneratedOnAdd();
                entity.Property(i => i.Date).IsRequired();
                entity.Property(i => i.Notes).IsRequired();

                entity.HasOne(i => i.Interactiontype)
                .WithMany(it => it.Interactions)
                .HasForeignKey(i => i.InteractionType);

                entity.HasOne(i => i.Project)
                .WithMany(p => p.Interactions)
                .HasForeignKey(i => i.ProjectID);
            });
            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.ToTable("Tasks");
                entity.HasKey(t => t.TaskID);
                entity.Property(t => t.TaskID).ValueGeneratedOnAdd();
                entity.Property(t => t.Name).IsRequired();
                entity.Property(t => t.DueDate).IsRequired();
                entity.Property(t => t.CreateDate).IsRequired();
                entity.Property(t => t.UpdateDate).IsRequired();

                entity.HasOne(t => t.Project)
                .WithMany(p => p.Tasks)
                .HasForeignKey(t => t.ProjectID);

                entity.HasOne(t => t.User)
                .WithMany(u => u.Tasks)
                .HasForeignKey(t => t.AssignedTo);

                entity.HasOne(t => t.TaskStatus)
                .WithMany(ts => ts.Tasks)
                .HasForeignKey(t => t.Status);
            });
            //llenado de tablas
            modelBuilder.Entity<CampaignType>().HasData(
                new CampaignType { Id = 1, Name = "SEO" },
                new CampaignType { Id = 2, Name = "PPC" },
                new CampaignType { Id = 3, Name = "Social Media" },
                new CampaignType { Id = 4, Name = "Email Marketing" }
            );
            modelBuilder.Entity<InteractionTypes>().HasData(
                new InteractionTypes { Id = 1, Name = "Initial Meeting" },
                new InteractionTypes { Id = 2, Name = "Phone call" },
                new InteractionTypes { Id = 3, Name = "Email" },
                new InteractionTypes { Id = 4, Name = "Presentation of Results" }
            );
            modelBuilder.Entity<Domain.Entities.TaskStatus>().HasData(
                new Domain.Entities.TaskStatus { Id = 1, Name = "Pending" },
                new Domain.Entities.TaskStatus { Id = 2, Name = "In Progress" },
                new Domain.Entities.TaskStatus { Id = 3, Name = "Blocked" },
                new Domain.Entities.TaskStatus { Id = 4, Name = "Done" },
                new Domain.Entities.TaskStatus { Id = 5, Name = "Cancel" }
            );
            modelBuilder.Entity<User>().HasData(
                new User { UserID = 1, Name = "Joe Done", Email = "jdone@marketing.com" },
                new User { UserID = 2, Name = "Nill Amstrong", Email = "namstrong@marketing.com" },
                new User { UserID = 3, Name = "Marlyn Morales", Email = "mmoralez@marketing.com" },
                new User { UserID = 4, Name = "Antony Orue", Email = "aorue@marketing.com" },
                new User { UserID = 5, Name = "Jazmin Fernandez", Email = "jfernandez@marketing.com" }
            );
        }
    }
}
