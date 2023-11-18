using Microsoft.EntityFrameworkCore;
using System;
public class BlazorUnitedContext:DbContext
{
    public DbSet<Blog> Blogs {get;set;}
    public DbSet<Post> Posts {get;set;}
    public string DbPath {get;set;}

    public BlazorUnitedContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "blazorunited.db");
    }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite($"Data Source={DbPath}");

    public class Blog
    {
        public int BlogId {get;set;}
        public string Url {get;set;}
    }
    public class Post
    {
        public int PostId {get;set;}
        public string Title {get;set;}
        public string Content {get;set;}
        public int BlogId {get;set;}
        public Blog Blog {get;set;}
    }

}