using api.techunsolved.com.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace api.techunsolved.com.Configurations.ModelConfig
{
    public class TechArticleConfig : IEntityTypeConfiguration<TechArticles>
    {
        public void Configure(EntityTypeBuilder<TechArticles> builder)
        {
            builder.ToTable("TechArticle");
            builder.HasKey(x => x.TechArticleId);

            builder.Property(x => x.TechArticleId).UseIdentityColumn();

            builder.Property(x => x.main_Heading).IsRequired(true).HasMaxLength(500);
            builder.Property(x => x.main_subHeading).IsRequired(true).HasMaxLength(500);
            builder.Property(x => x.intro_Heading).IsRequired(false).HasColumnType("nvarchar(max)");
            builder.Property(x => x.intro_Data).IsRequired(false).HasColumnType("nvarchar(max)");
            builder.Property(x => x.content_Heading).IsRequired(false).HasColumnType("nvarchar(max)");
            builder.Property(x => x.content_Data).IsRequired(false).HasColumnType("nvarchar(max)");
            builder.Property(x => x.example_content).IsRequired(false).HasColumnType("nvarchar(max)");
            builder.Property(x => x.conclusion_data).IsRequired(false).HasColumnType("nvarchar(max)");
            builder.Property(x => x.other_Content).IsRequired(false).HasColumnType("nvarchar(max)");

            builder.HasData(new List<TechArticles>()
            {
                // C# INTERNAL STRUCTURE
                new TechArticles(){
                    TechArticleId = 20001,

                    main_Heading = "C# (Basic Architecture)",
                    main_subHeading = "This tutorial explains Basic Structure of C# Programming design by Microsoft.",
                    intro_Heading = "C# Overview",
                    intro_Data = "C# is a modern, general-purpose, object-oriented programming language developed by Microsoft and " +
                    "approved by European Computer Manufacturers Association (ECMA) and International Standards Organization " +
                    "(ISO).\r\n\r\nC# was developed by Anders Hejlsberg and his team during the development of .Net Framework." +
                    "\r\n\r\nC# is designed for Common Language Infrastructure (CLI), which consists of the executable code and " +
                    "runtime environment that allows use of various high-level languages on different computer platforms and " +
                    "architectures.",
                    content_Heading = "Why C# Used Widely Professional Language",
                    content_Data = "1. It is a modern, general-purpose programming language\r\n" +
                    "2. It is object oriented.\r\n" +
                    "3. It is component oriented.\r\n" +
                    "4. It is easy to learn.\r\n" +
                    "5. It is a structured language.\r\n" +
                    "6. It produces efficient programs.\r\n" +
                    "7. It can be compiled on a variety of computer platforms.\r\n" +
                    "8. It is a part of .Net Framework.",
                    example_content = "",
                    output_content = "1. The first line of the program using System; - the using keyword is used to include the " +
                    "System namespace in the program. A program generally has multiple using statements.\r\n\r\n" +
                    "2. The next line has the namespace declaration. A namespace is a collection of classes. The " +
                    "HelloWorldApplication namespace contains the class HelloWorld.\r\n\r\n" +
                    "3. The next line has a class declaration, " +
                    "the class HelloWorld contains the data and method definitions that your program uses. Classes generally " +
                    "contain multiple methods. Methods define the behavior of the class. However, the HelloWorld class has only " +
                    "one method Main.\r\n\r\n" +
                    "4. The next line defines the Main method, which is the entry point for all C# programs. The Main method states " +
                    "what the class does when executed.\r\n\r\n" +
                    "5. The next line /*...*/ is ignored by the compiler and it is put to add comments in the program.\r\n\r\n" +
                    "6. The Main method specifies its behavior with the statement Console.WriteLine(\"Hello World\");\r\n\r\n" +
                    "WriteLine is a method of the Console class defined in the System namespace. This statement causes the " +
                    "message \"Hello, World!\" to be displayed on the screen.\r\n\r\n" +
                    "7. The last line Console.ReadKey(); is for the VS.NET Users. This makes the program wait for a key press and " +
                    "it prevents the screen from running and closing quickly when the program is launched from Visual Studio .NET.",
                    conclusion_data = "",
                    other_Content = "It is worth to note the following points -\n\n" +
                    "1. C# Is case sensitive.\n2. All statements and expression must end with a semicolon (;).\n" +
                    "3. The program execution starts at the Main method.\n4. Unlik Java, program file name could be different from" +
                    " the class name.",

                    techTopicId = 10001, CreateDate = DateTime.Now
                },
                // C# METHODS
                new TechArticles(){
                    TechArticleId = 20002,

                    main_Heading = "C# | Methods",
                    main_subHeading = "A method is a group of statements that together perform a task. Every C# program has at least one " +
                    "class with a method named Main.\n To use a method, you need to - \n\n 1. Define the method\n2. Call the method",
                    intro_Heading = "Defining Methods in C#",
                    intro_Data = "Methods are generally the block of codes or statements in a program that gives the user the ability to reuse " +
                    "the same code which ultimately saves the excessive use of memory, acts as a time saver and more importantly, it provides " +
                    "a better readability of code. So basically, a method is a collection of statements that perform some specific task and " +
                    "return the result to the caller. A method can also perform some specific task without returning anything.",
                    content_Heading = "Method Calling",
                    content_Data = "Method Invocation or Method Calling is done when the user wants to execute the method. The method needs to be " +
                    "called for using its functionality. A method returns to the code that invoked it when:\r\n\r\n1. It completes all the statements " +
                    "in the method\r\n2. It reaches a return statement\r\n3. Throws an exception ",
                    example_content = "",
                    output_content = "",
                    conclusion_data = "Advantages of using the Methods :\n\n" +
                    "1. It makes the program well structured.\n" +
                    "2. Methods enhance the readability of the code.\n" +
                    "3. It provides an effective way for the user to reuse the existing code.\n" +
                    "4. It optimizes the execution time and memory space.",
                    other_Content = "",

                    techTopicId = 10002, CreateDate = DateTime.Now
                },
                // C# DATA TYPES
                new TechArticles(){
                    TechArticleId = 20003,

                    main_Heading = "C# Data Types",
                    main_subHeading = "In C#, There are Several Types of Data Types are available as per the application needs.",
                    intro_Heading = "",
                    intro_Data = "",
                    content_Heading = "",
                    content_Data = "",
                    example_content = "",
                    conclusion_data = "",
                    other_Content = "",

                    techTopicId = 10003, CreateDate = DateTime.Now
                },
                // C# PROPERTIES
                new TechArticles(){
                    TechArticleId = 20004,

                    main_Heading = "C# Properties",
                    main_subHeading = "C# Properties provides several benefits for an applications.",
                    intro_Heading = "",
                    intro_Data = "",
                    content_Heading = "",
                    content_Data = "",
                    example_content = "",
                    conclusion_data = "",
                    other_Content = "",

                    techTopicId = 10004, CreateDate = DateTime.Now
                },
                // C# TYPE CASTING
                new TechArticles(){
                    TechArticleId = 20005,

                    main_Heading = "C# Type Casting",
                    main_subHeading = "Type casting is an essential concept in C# Programming.",
                    intro_Heading = "",
                    intro_Data = "",
                    content_Heading = "",
                    content_Data = "",
                    example_content = "",
                    conclusion_data = "",
                    other_Content = "",

                    techTopicId = 10005, CreateDate = DateTime.Now
                },
                // C# VARIABLES
                new TechArticles(){
                    TechArticleId = 20006,

                    main_Heading = "C# Variables",
                    main_subHeading = "In C#, variables are used to store and manipulate data in computer memory.",
                    intro_Heading = "",
                    intro_Data = "",
                    content_Heading = "",
                    content_Data = "",
                    example_content = "",
                    conclusion_data = "",
                    other_Content = "",

                    techTopicId = 10005, CreateDate = DateTime.Now
                }
            });

            builder.HasOne(x => x.techTopic)
                .WithMany(x => x.techArticle)
                .HasForeignKey(x => x.techTopicId)
                .HasConstraintName("FK_TechArticle_TechTopic");

        }
    }
}
