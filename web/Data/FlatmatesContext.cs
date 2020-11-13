using web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace web.Data
{
    public class FlatmatesContext : IdentityDbContext<ApplicationUser>
    {
        public FlatmatesContext(DbContextOptions<FlatmatesContext> options) : base(options)
        {
        }

//        public DbSet<Course> Courses { get; set; }
//        public DbSet<Enrollment> Enrollments { get; set; }
//       public DbSet<Student> Students { get; set; }

        public DbSet<Korisnik> Korisnici { get; set;}
        public DbSet<Household> Households { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Chore> Chores { get; set; }
        public DbSet<ForumPost> Forum_Posts { get; set; }
        public DbSet<ForumComment> Forum_Comments { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<Rent> Rent { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Stroski> Stroski { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Course>().ToTable("Course");
        //    modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
         //   modelBuilder.Entity<Student>().ToTable("Student");
              modelBuilder.Entity<Korisnik>().ToTable("korisnici");
              modelBuilder.Entity<Tenant>().ToTable("tenants");
              modelBuilder.Entity<Stroski>().ToTable("stroski");
              modelBuilder.Entity<Rent>().ToTable("rent");
              modelBuilder.Entity<Inventory>().ToTable("inventory");
              modelBuilder.Entity<Household>().ToTable("households");
              modelBuilder.Entity<ForumPost>().ToTable("forum_posts");
              modelBuilder.Entity<ForumComment>().ToTable("forum_comments");
              modelBuilder.Entity<Chore>().ToTable("chores");
              modelBuilder.Entity<Bill>().ToTable("bills");
        }
    }
}