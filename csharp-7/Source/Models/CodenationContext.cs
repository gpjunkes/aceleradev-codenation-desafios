using Microsoft.EntityFrameworkCore;

namespace Codenation.Challenge.Models
{
    public class CodenationContext : DbContext
    {
        public DbSet<Acceleration> Accelerations { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Challenge> Challenges { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Submission> Submissions { get; set; }
        public DbSet<User> Users { get; set; }
                
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Codenation;Trusted_Connection=True");            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigAcceleration(modelBuilder);
            ConfigCandidate(modelBuilder);
            ConfigChallenge(modelBuilder);
            ConfigCompany(modelBuilder);
            ConfigSubmission(modelBuilder);
            ConfigUser(modelBuilder);
        }

        private void ConfigAcceleration(ModelBuilder modelBuilder)
        {
            var config = modelBuilder.Entity<Acceleration>();

            config.ToTable("acceleration");

            config.HasKey(p => p.Id);

            config.Property(p => p.Id)
                .HasColumnType("int")
                .IsRequired()
                .ValueGeneratedOnAdd()
                .HasColumnName("id");

            config.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar")
                .HasColumnName("name");

            config.Property(p => p.Slug)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar")
                .HasColumnName("slug");

            config.Property(p => p.ChallengeId)
                .IsRequired()
                .HasColumnType("int")
                .HasColumnName("challenge_id");

            config.Property(p => p.CreatedAt)
                .IsRequired()
                .HasColumnType("timestamp")
                .HasColumnName("created_at");

            config.HasOne(p => p.Challenge)
                .WithMany()
                .HasForeignKey(p => p.ChallengeId)
                .IsRequired();            
        }

        private void ConfigCandidate(ModelBuilder modelBuilder)
        {
            var config = modelBuilder.Entity<Candidate>();

            config.ToTable("candidate");

            config.HasKey(p => new { p.UserId, p.CompanyId, p.AccelerationId });

            config.Property(p => p.UserId)
                .IsRequired()
                .HasColumnType("int")
                .HasColumnName("user_id");

            config.Property(p => p.CompanyId)
                .IsRequired()
                .HasColumnType("int")
                .HasColumnName("company_id");

            config.Property(p => p.AccelerationId)
                .IsRequired()
                .HasColumnType("int")
                .HasColumnName("acceleration_id");

            config.Property(p => p.Status)
                .IsRequired()
                .HasColumnType("int")
                .HasColumnName("status");

            config.Property(p => p.CreatedAt)
                .IsRequired()
                .HasColumnType("timestamp")
                .HasColumnName("created_at");

            config.HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .IsRequired();

            config.HasOne(p => p.Acceleration)
                .WithMany()
                .HasForeignKey(p => p.AccelerationId)
                .IsRequired();

            config.HasOne(p => p.Company)
                .WithMany()
                .HasForeignKey(p => p.CompanyId)
                .IsRequired();
        }

        private void ConfigChallenge(ModelBuilder modelBuilder)
        {
            var config = modelBuilder.Entity<Challenge>();

            config.ToTable("challenge");

            config.HasKey(p => p.Id);

            config.Property(p => p.Id)
                .HasColumnType("int")
                .IsRequired()
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            config.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar")
                .HasColumnName("name");

            config.Property(p => p.Slug)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar")
                .HasColumnName("slug");

            config.Property(p => p.CreatedAt)
                .IsRequired()
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
        }

        private void ConfigCompany(ModelBuilder modelBuilder)
        {
            var config = modelBuilder.Entity<Company>();

            config.ToTable("company");

            config.HasKey(p => p.Id);

            config.Property(p => p.Id)
                .HasColumnType("int")
                .IsRequired()
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            config.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar")
                .HasColumnName("name");

            config.Property(p => p.Slug)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar")
                .HasColumnName("slug");

            config.Property(p => p.CreatedAt)
                .IsRequired()
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
        }

        private void ConfigSubmission(ModelBuilder modelBuilder)
        {
            var config = modelBuilder.Entity<Submission>();

            config.ToTable("submission");

            config.HasKey(p => new { p.ChallengeId, p.UserId });

            config.Property(p => p.UserId)
                .IsRequired()
                .HasColumnType("int")
                .HasColumnName("user_id");

            config.Property(p => p.ChallengeId)
                .IsRequired()
                .HasColumnType("int")
                .HasColumnName("challenge_id");

            config.Property(p => p.Score)
                .IsRequired()
                .HasColumnType("float(9,2)")
                .HasColumnName("score");

            config.Property(p => p.CreatedAt)
                .IsRequired()
                .HasColumnType("timestamp")
                .HasColumnName("created_at");

            config.HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .IsRequired();

            config.HasOne(p => p.Challenge)
                .WithMany()
                .HasForeignKey(p => p.ChallengeId)
                .IsRequired();

        }

        private void ConfigUser(ModelBuilder modelBuilder)
        {
            var config = modelBuilder.Entity<User>();

            config.ToTable("user");

            config.HasKey(p => p.Id);

            config.Property(p => p.Id)
                .IsRequired()
                .HasColumnType("int")
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            config.Property(p => p.FullName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar")
                .HasColumnName("full_name");

            config.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar")
                .HasColumnName("email");

            config.Property(p => p.NickName)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar")
                .HasColumnName("nickname");

            config.Property(p => p.Password)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar")
                .HasColumnName("password");

            config.Property(p => p.CreatedAt)
                .IsRequired()
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
        }
    }
}