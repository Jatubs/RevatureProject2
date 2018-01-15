using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MinionChat.Data
{
    public partial class Project2Context : DbContext
    {
        public virtual DbSet<ChatGroups> ChatGroups { get; set; }
        public virtual DbSet<ChatLog> ChatLog { get; set; }
        public virtual DbSet<FriendList> FriendList { get; set; }
        public virtual DbSet<GroupMembers> GroupMembers { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"server=yoonsqlweek.database.windows.net;database=Project2;user=sqladmin;password=Password123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChatGroups>(entity =>
            {
                entity.HasKey(e => e.ChatGroupId);

                entity.Property(e => e.ChatGroupId).HasColumnName("ChatGroupID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ChatLog>(entity =>
            {
                entity.Property(e => e.ChatLogId).HasColumnName("ChatLogID");

                entity.Property(e => e.ChatGroupId).HasColumnName("ChatGroupID");

                entity.Property(e => e.Message).IsRequired();

                entity.Property(e => e.TimeofMessage).HasColumnType("datetime2(0)");

                entity.Property(e => e.UserIdofSender).HasColumnName("UserIDofSender");

                entity.HasOne(d => d.ChatGroup)
                    .WithMany(p => p.ChatLog)
                    .HasForeignKey(d => d.ChatGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChatLog__ChatGro__52593CB8");

                entity.HasOne(d => d.UserIdofSenderNavigation)
                    .WithMany(p => p.ChatLog)
                    .HasForeignKey(d => d.UserIdofSender)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChatLog__UserIDo__534D60F1");
            });

            modelBuilder.Entity<FriendList>(entity =>
            {
                entity.Property(e => e.FriendListId).HasColumnName("FriendListID");

                entity.Property(e => e.FriendId).HasColumnName("FriendID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Friend)
                    .WithMany(p => p.FriendListFriend)
                    .HasForeignKey(d => d.FriendId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FriendLis__Frien__571DF1D5");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FriendListUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FriendLis__UserI__5629CD9C");
            });

            modelBuilder.Entity<GroupMembers>(entity =>
            {
                entity.HasKey(e => e.GroupMemberId);

                entity.Property(e => e.GroupMemberId).HasColumnName("GroupMemberID");

                entity.Property(e => e.ChatGroupId).HasColumnName("ChatGroupID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.ChatGroup)
                    .WithMany(p => p.GroupMembers)
                    .HasForeignKey(d => d.ChatGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GroupMemb__ChatG__4F7CD00D");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.GroupMembers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GroupMemb__UserI__4E88ABD4");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.HasIndex(e => e.Username)
                    .HasName("UQ__Users__536C85E42B298920")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
