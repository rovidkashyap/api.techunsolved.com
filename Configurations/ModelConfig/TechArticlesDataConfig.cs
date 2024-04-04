using api.techunsolved.com.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text;

namespace api.techunsolved.com.Configurations.ModelConfig
{
    public class TechArticlesDataConfig : IEntityTypeConfiguration<TechArticlesData>
    {
        public void Configure(EntityTypeBuilder<TechArticlesData> builder)
        {
            builder.ToTable("TechArticlesData");
            builder.HasKey(x => x.TechArticlesDataId);

            builder.Property(x => x.TechArticlesDataId).UseIdentityColumn();

            builder.Property(x => x.program_heading).IsRequired(false).HasColumnType("varchar(max)");
            builder.Property(x => x.program_code).IsRequired(false).HasColumnType("nvarchar(max)");
            builder.Property(x => x.output_heading).IsRequired(false).HasColumnType("nvarchar(max)");
            builder.Property(x => x.output_code).IsRequired(false).HasColumnType("nvarchar(max)");
            builder.Property(X => X.other_heading).IsRequired(false).HasColumnType("nvarchar(max)");
            builder.Property(x => x.other_code).IsRequired(false).HasColumnType("nvarchar(max)");

            #region TechArticlesDataId = 190005 CODE/OUTPUT
            string codeData = @"
                using System;

                namespace HelloWorldApplication {
                    class HelloWorld {
                        static void Main(string[] args) {
                            /* my first program in c# */
                            Console.WriteLine(""Hello World"");
                            Console.ReadKey();
                        }
                    }
                }
               ";
            string output = @"Hello World";
            #endregion
            #region TechArticlesDataId = 190006 CODE/OUTPUT
            string callingmethod = @"
                // Method Name --> GetCircleArea()
                // Return Type --> double

                static double GetCircleArea(double radius) {
                    const float pi = 3.14F;
                    double area = pi * radius * radius;

                    return area;
                }
            ";
            string outputmethod = @"
            // C# Program to illustrate method calling
            using System;
            namespace ConsoleApplication {
                
                class Techunsolved {
                    // Here Sum() method asks for two parameters from the user and
                    // calculates the sum of these and finally returns the result.
                    static int Sum(int x, int y) {
                        // 'a' and 'b' are two local variables assigned value of 
                        // parameter 'x' and 'y'
                        int a = x;
                        int b = y;
                        // calculates the sum and return the result of 'int' type
                        int result = a + b;
                        return result;
                        }
                
                    // Main Method
                    static void Main(string[] args) {
                        int a = 12;
                        int b = 23;

                        // Method Sum() is invoked and the returned value is stored in
                        // the local variable say 'c'
                        int c = Sum(a, b);

                        // Display Result
                        Console.WriteLine(""The Value of the sum is "" + c);
                    }
                }
            }   
            ";
            string otheroutput = @"The Valus of the sum is 35";
            #endregion


            builder.HasData(new List<TechArticlesData>()
            {
                new TechArticlesData() {
                    TechArticlesDataId = 190005,
                    program_heading = "Let us look at a simple code that prints the words (Hello World) -",
                    program_code = codeData,
                    output_heading = "When this code is compiled and executed, it produces the following result -",
                    output_code = output,
                    other_heading = "",
                    other_code = "",
                    TechArticlesId = 20001
                },
                new TechArticlesData() {
                    TechArticlesDataId = 190006,
                    program_heading = "Example :",
                    program_code = callingmethod,
                    output_heading = "In the code below, a method names Sum() is called.",
                    output_code = outputmethod,
                    other_heading = "Output :",
                    other_code = otheroutput,
                    TechArticlesId = 20002
                }
            });

            builder.HasOne(x => x.TechArticles)
                .WithMany(x => x.techArticlesData)
                .HasForeignKey(x => x.TechArticlesId)
                .HasConstraintName("FK_TechArticlesData_TechArticles");
        }
    }
}
