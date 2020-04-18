using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace T3_960261205
{
    public partial class CreateTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<String>(nullable: false),
                    Email = table.Column<String>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");
        }
    }

    public class DatabaseContext : DbContext
    {
        public DbSet<Student> Student { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=database.db");
        }
    }

    public class ReadAndWriteInfo
    {
        void Read()
        {
            using (var db = new DatabaseContext())
            {
                var Student = db.Student;
                foreach (var student in Student)
                {
                    Console.WriteLine("{0} {1} {2}", student.Id, student.Name, student.Email);
                }
            }
        }

        void Add()
        {
            using (var db = new DatabaseContext())
            {
                var student = new Student() { Name = "any name" , Email = "any email" };
                db.Student.Add(student);
                db.SaveChanges();
            }
        }

    }

    public class Student
    {
        public int Id { get; set; }

        public String Name { get; set; }

        public String Email { get; set; }
    }
}
