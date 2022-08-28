﻿// See https://aka.ms/new-console-template for more information

using Domain;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

var dbContext = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>());

var randomBlogs = await dbContext.Blogs
    .OrderBy(_ => Guid.NewGuid())
    .Take(10)
    .ToListAsync();


//var groupByNothing = await dbContext.Blogs
//    .GroupBy(_ => 1)
//    .Select(x => new { SumLikes = x.Sum(s => s.Likes) })
//    .FirstOrDefaultAsync();
