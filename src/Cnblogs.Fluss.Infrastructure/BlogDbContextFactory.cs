using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Cnblogs.Fluss.Infrastructure
{
    /// <summary>
    /// Used for ef core migrations
    /// </summary>
    // ReSharper disable once UnusedType.Global
    public class BlogDbContextFactory : IDesignTimeDbContextFactory<BlogDbContext>
    {
        /// <inheritdoc />
        public BlogDbContext CreateDbContext(string[] args)
        {
            var mySqlConnectionStr = "Server=122.51.103.18;Database=fluss;Uid=root;Pwd=^TFC6tfc;";
            var options = new DbContextOptionsBuilder<BlogDbContext>();
            options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr));
            return new BlogDbContext(options.Options, new Mediator(_ => new object()));
        }
    }
}