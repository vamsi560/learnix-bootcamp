using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AzureBootCamp.Context
{
    public partial class AZBootcamp2021DBContext : DbContext
    {
        public AZBootcamp2021DBContext()
        {
        }

        public AZBootcamp2021DBContext(DbContextOptions<AZBootcamp2021DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SessionLink> SessionLinks { get; set; }
        public virtual DbSet<Speaker> Speakers { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<TopicSpeaker> TopicSpeakers { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:globalazuredbserver2023.database.windows.net,1433;Initial Catalog=GlobalAzureDB;Persist Security Info=False;User ID=globaldbadmin;Password=Valuemomentum123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<SessionLink>(entity =>
            {
                entity.ToTable("SessionLink");

                entity.Property(e => e.SessionLinkValue)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.SessionTime).HasColumnType("datetime");

                entity.HasOne(d => d.Track)
                    .WithMany(p => p.SessionLinks)
                    .HasForeignKey(d => d.TrackId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SessionLink_Track");
            });

            modelBuilder.Entity<Speaker>(entity =>
            {
                entity.ToTable("Speaker");

                entity.Property(e => e.SpeakerBio)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.SpeakerDesignation)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SpeakerImage)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.SpeakerName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.ToTable("Topic");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.TopicDescription)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.TopicImage)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.TopicName)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.TopicTime)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Track)
                    .WithMany(p => p.Topics)
                    .HasForeignKey(d => d.TrackId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Topic_Track");
            });

            modelBuilder.Entity<TopicSpeaker>(entity =>
            {
                entity.ToTable("TopicSpeaker");

                entity.HasOne(d => d.Speaker)
                    .WithMany(p => p.TopicSpeakers)
                    .HasForeignKey(d => d.SpeakerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TopicSpeaker_Speaker");

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.TopicSpeakers)
                    .HasForeignKey(d => d.TopicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TopicSpeaker_Topic");
            });

            modelBuilder.Entity<Track>(entity =>
            {
                entity.ToTable("Track");

                entity.Property(e => e.TrackName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasIndex(e => e.Email, "IX_User")
                    .IsUnique();

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Company Name");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Designation)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Experience)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Tracks)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
